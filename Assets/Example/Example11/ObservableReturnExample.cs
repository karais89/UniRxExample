using System;
using UniRx;
using UnityEngine;

public class ObservableReturnExample : MonoBehaviour
{ 
    private void Start()
    {
        // 단지 호출하는 경우
        // 100 밀리 초 후에 Log를 출력한다.
        Observable.Return(Unit.Default)
            .Delay(TimeSpan.FromMilliseconds(100))
            .Subscribe(_ => Debug.Log("Delay call"));
        
        // 매개 변수를 전달하는 경우
        // 현재 플레이어의 좌표를 500 밀리 초 후에 표시
        Observable.Return(transform.position)
            .Delay(TimeSpan.FromMilliseconds(500))
            .Subscribe(p => Debug.Log("Player Position : " + p));
        
        // 다음 프레임에서 실행
        Observable.Return(Unit.Default)
            .DelayFrame(1)
            .Subscribe(_ => Debug.Log("Next Frame"));
        
        // 다음 FixedUpdate에서 실행
        Observable.Return(Unit.Default)
            .DelayFrame(1, FrameCountType.FixedUpdate)
            .Subscribe(_ => Debug.Log("Next FixedUpdate"));

        // 다음 프레임에서 실행
        Observable.NextFrame()
            .Subscribe(_ => Debug.Log("Next Frame"));
    }
}
