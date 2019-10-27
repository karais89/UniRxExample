using UniRx;
using UnityEngine;

public class Example23_ReactiveProperty : MonoBehaviour
{
    private void Start()
    {
        // int형의 ReactiveProperty
        var rp = new ReactiveProperty<int>(10); // 초기값 지정 가능

        // 일반적으로 대입하거나 값을 읽을 수 있다.
        rp.Value = 20;
        var currentValue = rp.Value;

        // Subscribe 할 수 있다. (Subscribe시 현재 값도 발행된다)
        rp.Subscribe(x => Debug.Log(x));

        // 값을 다시 설정할때 OnNext 발행 된다.
        rp.Value = 30;
    }
}