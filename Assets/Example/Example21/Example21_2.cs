using UniRx;
using UnityEngine;

public class Example21_2 : MonoBehaviour
{
    private void Start()
    {
        // 문자열을 발행하는 Subject 
        Subject<string> subject = new Subject<string>();

        // filter를 끼고 Subscribe 보면 
        subject
            .FilterOperator(x => x == "Enemy")
            .Subscribe(x => Debug.Log(string.Format("플레이어가 {0}에 충돌했습니다", x)));

        // 이벤트 메시지 발급 
        // 플레이어가 언급 한 개체의 Tag가 발행되어, 같은 가정 
        subject.OnNext("Wall");
        subject.OnNext("Wall");
        subject.OnNext("Enemy");
        subject.OnNext("Enemy");
    }
}