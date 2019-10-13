using System.Linq;
using UniRx;
using UnityEngine;

public static class FPSCounter
{
    private const int BufferSize = 5; // 샘플 수를 바꾸려면 여기를 바꾼다.
    public static IReadOnlyReactiveProperty<float> Current { get; private set; }
 
    static FPSCounter() =>
        Current = Observable.EveryUpdate()
            .Select(_ => Time.deltaTime)
            .Buffer(BufferSize, 1)
            .Select(x => 1.0f / x.Average())
            .ToReadOnlyReactiveProperty();
}
