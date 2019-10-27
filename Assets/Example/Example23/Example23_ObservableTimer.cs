using System;
using UniRx;
using UnityEngine;

public class Example23_ObservableTimer : MonoBehaviour
{
    private void Start()
    {
        // 5초 후에 메시지 발행
        Observable.Timer(TimeSpan.FromSeconds(5.0f))
            .Subscribe(_ => Debug.Log("5초 경과했습니다."));

        // 5초 후 메시지 발행 후 1초 간격으로 계속 발행
        // 스스로 멈추지 않는 한 계속 움직인다.
        Observable.Timer(TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(1))
            .Subscribe(x => Debug.Log(x))
            .AddTo(gameObject);
    }
}
