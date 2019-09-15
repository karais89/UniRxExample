using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class ColdExample : MonoBehaviour
{
    private void Start()
    {
        var subject = new Subject<string>();
        
        // subject에서 생성된 Observable은 [Hot]
        var sourceObservable = subject.AsObservable();
        
        // 스트림에 흘러 들어온 문자열을 연결하여 새로운 문자열로 만드는 스트림
        // Scan()은 [Cold]
        var stringObservable = sourceObservable.Scan((p, c) => p + c);
        
        // 스트림에 값을 흘린다
        subject.OnNext("A");
        subject.OnNext("B");
        
        // 스트림에 값을 흘린 후 Subscribe 한다.
        stringObservable.Subscribe(Debug.Log);
        
        // Subscribe 후 스트림에 값을 흘린다.
        subject.OnNext("C");
        
        // 완료
        subject.OnCompleted();
    }
}
