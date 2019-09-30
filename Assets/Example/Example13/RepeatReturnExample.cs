using UniRx;
using UnityEngine;

public class RepeatReturnExample : MonoBehaviour
{
    private void Start()
    {
        var random = new System.Random();

        // 난수를 반환
        Observable.Defer(() => Observable.Return(random.Next()))
                .RepeatUntilDestroy(gameObject)
                .Take(3)
                .Subscribe(x => Debug.Log(x), () => Debug.Log("OnCompleted"));
    }
}