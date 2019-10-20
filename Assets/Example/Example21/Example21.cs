using UniRx;
using UnityEngine;

public class Example21 : MonoBehaviour
{    
    private void Start()
    {
        // Subject 작성
        Subject<string> subject = new Subject<string>();

        // 3회 Subscrbie
        subject.Subscribe(msg => Debug.Log("Subscribe1 : " + msg));
        subject.Subscribe(msg => Debug.Log("Subscribe2 : " + msg));
        subject.Subscribe(msg => Debug.Log("Subscribe3 : " + msg));

        // 이벤트 메시지 발행
        subject.OnNext("안녕하세요");
        subject.OnNext("안녕");
    }
}
