using System;
using UniRx;
using UnityEngine;

public class OnErrorExample : MonoBehaviour
{
    void Start()
    {
//        var stringSubject = new Subject<string>();
//        
//        // 문자열을 스트림 중간에서 정수로 변환 
//        stringSubject
//            .Select(str => int.Parse(str)) // 숫자를 표현하는 문자열이 아닌 경우는공 예외가 나온다 
//            .Subscribe(
//                x => Debug.Log("성공:" + x), // OnNext생
//                ex => Debug.Log("예외가 발:" + ex) //생 OnError
//            );
//        
//        stringSubject.OnNext("1");
//        stringSubject.OnNext("2");
//        stringSubject.OnNext("Hello"); // 이 메시지에서 예외가 발
//        stringSubject.OnNext("4");
//        stringSubject.OnCompleted();

        var stringSubject = new Subject<string>();

        // 문자열을 스트림 중간에서 정수로 변환 
        stringSubject
            .Select(str => int.Parse(str))
            .OnErrorRetry((FormatException ex) => // 예외의 형식으로 필터링 가능
            {
                Debug.Log("예외가 발생하여 다시 구독 합니다");
            })
            .Subscribe(
                x => Debug.Log("성공:" + x), // OnNext
                ex => Debug.Log("예외가 발생:" + ex) // OnError
            );

        stringSubject.OnNext("1");
        stringSubject.OnNext("2");
        stringSubject.OnNext("Hello");
        stringSubject.OnNext("4");
        stringSubject.OnNext("5");
        stringSubject.OnCompleted();
    }
}