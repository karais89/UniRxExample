using System;
using System.Collections;
using UniRx;
using UnityEngine;

public class ConvertFromCoroutine3 : MonoBehaviour
{
    // 일시 정지 플래그, true인 경우 타이머 중지
    public bool IsPaused;
    
    private void Start() =>
        Observable.FromCoroutine<long>(observer => CountCoroutine(observer))
            .Subscribe(x => Debug.Log(x))
            .AddTo(gameObject);

    /// <summary>
    /// 일시 정지 플래그가 지나지 않은 상태의 시간(초)를 계산하여 알려준다.
    /// </summary>
    /// <param name="observer">알림 IObserver</param>
    /// <returns></returns>
    IEnumerator CountCoroutine(IObserver<long> observer)
    {
        long current = 0;
        float deltaTime = 0;
     
        // Dispose하면 코루틴이 멈추니까 while(true) 해도 문제없이 움직인다.
        // 기분 나쁘다면 CancellationToken을 받아 이용하면 된다.
        while (true)
        {
            if (!IsPaused)
            {
                // 일시 플래그가 지나지 않은 사이 시간을 측정한다.
                deltaTime += Time.deltaTime;
                if (deltaTime >= 1.0f)
                {
                    // 차이가 1초를 초과한 경우 정수 부분을 꺼내 집계 통지한다.
                    var integerPart = (int) Mathf.Floor(deltaTime);
                    current += integerPart;
                    deltaTime -= integerPart;
                    
                    // 시간(초) 통지
                    observer.OnNext(current);
                }
            }
            yield return null;
        }
    }
}
