using UniRx;
using UnityEngine;

public class Example21_1 : MonoBehaviour
{
    private void Start()
    {
        // 문자열을 발행하는 Subject
        Subject<string> subject = new Subject<string>();

        // 문자열을 콘솔에 출력
        subject.Subscribe(x => Debug.Log($"플레이어가 {x}에 충돌했습니다."));

        // Enemy만 필터링
        subject
            .Where(x => x == "Enemy") // 필터링 오퍼레이터
            .Subscribe(x => Debug.Log($"플레이어가 {x}에 충돌했습니다."));

        // 이벤트 메시지 발급
        // 플레이어가 언급한 개체의 Tag가 발행되었다는 가정
        subject.OnNext("Enemy");
        subject.OnNext("Wall");
        subject.OnNext("Wall");
        subject.OnNext("Enemy");
        subject.OnNext("Enemy");
    }
}
