using System;
using System.Linq;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class Example20 : MonoBehaviour
{
    [SerializeField] private int bufferSize = 5; // 버퍼 사이즈
    public ReadOnlyReactiveProperty<float> FpsReactiveProperty;
    
    private void Awake()
    {
        FpsReactiveProperty = this.UpdateAsObservable()
            .Select(_ => Time.deltaTime) // Time.deltaTime로 변환
            .Buffer(bufferSize, 1)
            .Select(x => 1.0f / x.Average()) // 평균에서 fps 산출
            .ToReadOnlyReactiveProperty();

        FpsReactiveProperty.Subscribe(x => Debug.Log(x));
    }

    private void Start()
    {
        FPSCounter.Current.Subscribe(fps => Debug.Log(fps));
    }
}
