using UniRx;
using UnityEngine;

public class DisposeExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
//        var subject = new Subject<int>();
//
//        // IDispose 저장
//        var disposable = subject.Subscribe(x => Debug.Log(x), () => Debug.Log("OnCompleted"));
//
//        subject.OnNext(1);
//        subject.OnNext(2);
//
//        // 구독종
//        disposable.Dispose();
//
//        subject.OnNext(3);
//        subject.OnCompleted();
        
        var subject = new Subject<int>();

// IDispose 저장
        var disposable1 = subject.Subscribe(x => Debug.Log("스트림1:" + x), () => Debug.Log("OnCompleted"));
        var disposable2 = subject.Subscribe(x => Debug.Log("스트림2:" + x), () => Debug.Log("OnCompleted"));
        subject.OnNext(1);
        subject.OnNext(2);

// 스트림1만 구독종료
        disposable1.Dispose();

        subject.OnNext(3);
        subject.OnCompleted();
    }
}
