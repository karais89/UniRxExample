using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class Example19_Operator : MonoBehaviour
{
    private void Start()
    {
        var mouseDownStream = this.UpdateAsObservable()
            .Where(_ => Input.GetMouseButtonDown(0));
        var mouseUpStream = this.UpdateAsObservable()
            .Where(_ => Input.GetMouseButtonUp(0));

        // 길게 누르기 판정
        mouseDownStream
            // 마우스 클릭되면 3초 후 OnNext를 흐르게 한다.
            .SelectMany(_ => Observable.Timer(TimeSpan.FromSeconds(3)))
            // 도중에 MouseUp되면 스트림을 재설정 한다.
            .TakeUntil(mouseUpStream)
            .RepeatUntilDestroy(gameObject)
            .Subscribe(_ => Debug.Log("길게"));

        // 길게 누르기 취소 판정
        mouseDownStream.Timestamp()
            .Zip(mouseUpStream.Timestamp(), (d, u) => (u.Timestamp - d.Timestamp).TotalMilliseconds / 1000.0f)
            .Where(time => time < 3.0f)
            .Subscribe(t => Debug.Log(t + "초에서 취소"));
    }
}