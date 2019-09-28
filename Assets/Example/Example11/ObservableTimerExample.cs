using System;
using UniRx;
using UnityEngine;

public class ObservableTimerExample : MonoBehaviour
{
    private void Start()
    {
        // 단지 호출만 하는 경우
        // 100 밀리 초 후에 Log를 출력한다.
        Observable.Timer(TimeSpan.FromMilliseconds(100))
            .Subscribe(_ => Debug.Log("Delay call"));

        // 매개 변수를 전달하는 경우
        // 현재 플레이어의 좌표를 500 밀리 초 후에 표시
        var playerPosition = transform.position;
        Observable.Timer(TimeSpan.FromMilliseconds(500))
            .Subscribe(_ => Debug.Log("Player Position : " + playerPosition));

        // 다음 프레임에서 실행
        Observable.TimerFrame(1)
            .Subscribe(_ => Debug.Log("Next Update"));
        
        // 다음 FixedUpdate에서 실행
        Observable.TimerFrame(1, FrameCountType.FixedUpdate)
            .Subscribe(_ => Debug.Log("Next FixedUpdate"));
    }
}