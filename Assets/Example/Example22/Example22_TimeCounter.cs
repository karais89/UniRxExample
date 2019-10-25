using System;
using System.Collections;
using UniRx;
using UnityEngine;

/// <summary>
/// 카운트 다운하고 그때 값을 통지한다.
/// 3,2,1,0,(OnCompleted) 이런식으로 이벤트가 날라간다.
/// </summary>
public class Example22_TimeCounter : MonoBehaviour
{
    [SerializeField] private int TimeLeft = 3;
    
    // 타이머 스트림의 실체는 이 Subject
    private Subject<int> timerSubject = new Subject<int>();

    public IObservable<int> OnTimeChanged => timerSubject;

    private void Start()
    {
        StartCoroutine(TimerCoroutine());
        
        // 현재의 카운트를 표시
        timerSubject.Subscribe(x => Debug.Log(x));
    }

    private IEnumerator TimerCoroutine()
    {
        yield return null;

        var time = TimeLeft;
        while (time >= 0)
        {
            timerSubject.OnNext(time--);
            yield return new WaitForSeconds(1);
        }
        timerSubject.OnCompleted();
    }
}
