using System;
using System.Collections;
using UniRx;
using UnityEngine;

public class Example19_FromCoroutine : MonoBehaviour
{
    private void Start()
    {
        Observable.FromCoroutine<Unit>(observer => LongClickCoroutine(observer, 3.0f));
        Observable.FromCoroutine<float>(observer => LongClickCancelCoroutine(observer, 3.0f));
    }

    private IEnumerator LongClickCoroutine(IObserver<Unit> longClickObserver, float threshold)
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
                count = 0;
                isLongClicked = false;
            }
            yield return null;
        }
    }
    
    private IEnumerator LongClickCancelCoroutine(IObserver<float> longClickCancelObserver, float threshold)
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

}
