using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class Example14 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 클릭 되고 나서 5초 동안 클릭을 무시하는 예제
        this.UpdateAsObservable()
            .Where(_=>Input.GetMouseButtonDown(0))
            .ThrottleFirst(TimeSpan.FromSeconds(5))
            .Subscribe(x => Debug.Log("Clicked!"));
        
        // 업데이트를 1/10로 솎아 내는 예제 (9회 Update가 올 때까지 무시)
        this.UpdateAsObservable()
            .ThrottleFirstFrame(9)
            .Subscribe(x => Debug.Log("tenth part Update"));
    }
}
