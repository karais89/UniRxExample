using System;
using System.Collections;
using UniRx;
using UnityEngine;

/// <summary>
/// 100에서 카운트 다운하고 Debug.Log에 그 값을 표시하는 샘플
/// </summary>
public class TimeCounterRx : MonoBehaviour
{
    // 이벤트를 발행하는 핵심 인스턴스
    private Subject<int> timerSubject = new Subject<int>();

    // 이벤트의 구독자만 공개
    public IObservable<int> OnTimeChanged => timerSubject;

    private void Start() => StartCoroutine(TimerCoroutine());

    private IEnumerator TimerCoroutine()
    {
        // 100에서 카운트 다운
        var time = 100;
        while (time > 0)
        {
            time--;

            // 이벤트를 발행
            timerSubject.OnNext(time);

            // 1초 기다리는
            yield return new WaitForSeconds(1);
        }
    }
}
