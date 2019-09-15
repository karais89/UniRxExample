using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class CountTimeExample : MonoBehaviour
{
    /// <summary>
    /// countTime 만큼 카운트 다운하는 스트림
    /// </summary>
    /// <param name="countTime"></param>
    /// <returns></returns>
    private IObservable<int> CreateCountDownObservable(int countTime)
    {
        return Observable
            .Timer(TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(1)) // 0초 이후 1초 간격으로 실행
            .Select(x => (int) (countTime - x)) // x는 시작하고 나서의 시간(초)
            .TakeWhile(x => x > 0); // 0초 초과 동안 OnNext 0이 되면 OnComplete
    }
}
