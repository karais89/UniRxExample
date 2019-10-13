using System;
using System.Collections;
using UniRx;
using UnityEngine;

public class Example19_Coroutine : MonoBehaviour
{
    #region 길게 누르기 스트림
    private Subject<Unit> _longClickSubject;

    private IObservable<Unit> LongClickAsObservable =>
        _longClickSubject ?? (_longClickSubject = new Subject<Unit>());
    #endregion

    #region 길게 누르기 취소 스트림
    private Subject<float> _longClickCancelSubject;

    private IObservable<float> LongClickCancelAsObservable =>
        _longClickCancelSubject ?? (_longClickCancelSubject = new Subject<float>());
    #endregion

    private Coroutine _longClickCoroutine;

    private void Start()
    {
        _longClickCoroutine = StartCoroutine(LongClickCoroutine(3.0f, _longClickSubject, _longClickCancelSubject));

        LongClickAsObservable.Subscribe(_ => Debug.Log("길게"));
        LongClickCancelAsObservable.Subscribe(t => Debug.Log(t + "초 취소"));
    }

    /// <summary>
    /// 길게 누르기 판정 코루틴
    /// </summary>
    private IEnumerator LongClickCoroutine(float threshold,
        IObserver<Unit> longClickObserver,
        IObserver<float> longClickCancelObserver)
    {
        var isLongClicked = false;
        var count = 0.0f;

        while (true)
        {
            if (Input.GetMouseButton(0))
            {
                count += Time.deltaTime;
                if (!isLongClicked && count > threshold)
                {
                    isLongClicked = true;
                    longClickObserver.OnNext(Unit.Default);
                }
            }
            else if (Input.GetMouseButtonUp(0))
            {
                isLongClicked = false;
                if (count > 0)
                {
                    longClickCancelObserver.OnNext(count);
                    count = 0;
                }
            }
            yield return null;
        }
    }

    private void OnDestroy()
    {
        if (_longClickCoroutine != null)
            StopCoroutine(_longClickCoroutine);
    }
}