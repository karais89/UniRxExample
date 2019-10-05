using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UniRx;
using UnityEngine;

public class Example16 : MonoBehaviour
{
    private class Player
    {
        public bool IsAlive { get; set; }
    }

    private Player player = new Player();

    private void Start()
    {
        // player 초기화 같은 로직 실행

        // 플레이어의 생존 시간을 30초 카운트 다운
        // 타이머의 현재 카운트 [초]가 통지 된다.
        Observable
            .FromCoroutine<int>(observer => CountDownCoroutine(observer, 30, player))
            .Subscribe(count => Debug.Log(count));

        StartCoroutine(CoroutineA());
    }

    /// <summary>
    /// 플레이어가 살아있는 동안에만 카운트 다운 타이머
    /// 플레이어가 죽은 경우 카운트 중지
    /// </summary>
    IEnumerator CountDownCoroutine(IObserver<int> observer, int startTime, Player player)
    {
        var currentTime = startTime;
        while (currentTime > 0)
        {
            if (player.IsAlive)
            {
                observer.OnNext(currentTime--);
            }

            yield return new WaitForSeconds(1.0f);
        }

        observer.OnCompleted();
    }

    IEnumerator CoroutineA()
    {
        // 코루틴의 실행 결과를 저장하는 변수
        var result = 0;
        // Observable.Range을 코루틴으로 변환한다.
        yield return Observable
            .Range(0, 10)
            .StartAsCoroutine(c => result = c);

        Debug.Log("result : " + result);
    }

    private IEnumerator HeavyTaskCoroutine()
    {
        // 실행 결과
        bool result = false;

        // 비동기 처리 대기
        // Observable.Start 다른 스레드에서 작업을 수행 한다.
        yield return Observable
            .Start(() => HeavyTask())
            .StartAsCoroutine(x => result = x);

        // 실행 결과를 확인한다.
        if (result)
        {
            Debug.Log("Success");
        }
        else
        {
            Debug.Log("Failure");
        }
    }

    /// <summary> 
    /// 실행에 시간이 걸릴 무거운 처리 
    /// </ summary> 
    /// <returns> 성공 여부 </ returns> 
    bool HeavyTask()
    {
        // 무거운 처리하는 
        Thread.Sleep(3000);

        // 실행의 성공 여부를 반환 (의사 적으로 랜덤에 true / false를 반환) 
        var random = new System.Random();
        return random.Next() % 2 == 0;
    }
}