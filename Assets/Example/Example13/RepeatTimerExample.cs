using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class RepeatTimerExample : MonoBehaviour
{
    private void Start()
    {
        var mouseClick = this.UpdateAsObservable()
            .Where(_ => Input.GetMouseButtonDown(0));
        
        // 5초 지나면 카운터를 0 으로 초기화
        Observable.Timer(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1))
            .Take(5)
            .RepeatUntilDestroy(gameObject)
            .Subscribe(time => Debug.Log(time));
        
        // 클릭되면 타이머를 다시 0 으로 초기화
        Observable.Timer(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1))
            .TakeUntil(mouseClick)
            .RepeatUntilDestroy(gameObject)
            .Subscribe(time => Debug.Log(time));
    }
}
