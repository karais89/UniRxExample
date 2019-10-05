using System;
using System.Linq;
using System.Runtime.CompilerServices;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class Example15 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var keyBufferStream = this.UpdateAsObservable()
            .Where(_ => Input.anyKeyDown) // 아무 버튼 눌렀을 때
            .Where(_ => !(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) ||
                          Input.GetMouseButtonDown(2))) // 마우스는 무시
            .Select(_ => Input.inputString) // 버튼 스트링
            .Buffer(4, 1) // 4 개씩 정리
            .Do(_ => Debug.Log("Buffered")) // Buffer가 OnNext를 방출한 타이밍에 출력된다.
            .Select(x => x.Aggregate((p, c) => p + c)) // 문자에서 문자열로 변환
            .Publish() // Publish에서 Hot 변환(Publish가 대표하여 Subscribe 해 준다)
            .RefCount(); // RefCount 은 Observer가 추가되었을 때 자동 Connect 해 주는 오퍼레이터.

        // 결과 표시
//        keyBufferStream.Subscribe(Debug.Log);

        keyBufferStream.Where(x => x == "HOGE")
            .Subscribe(_ => Debug.Log("Input HOGE"));
        
        keyBufferStream.Where(x => x == "FUGA")
            .Subscribe(_ => Debug.Log("Input FUGA"));
    }
}