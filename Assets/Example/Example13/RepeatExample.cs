using UniRx;
using UnityEngine;

public class RepeatExample : MonoBehaviour
{
    private void Start()
    {
        var random = new System.Random();
        
        // 난수를 1개 반환하는 스트림
        Observable.Create<int>(observer =>
            {
                observer.OnNext(random.Next());
                observer.OnCompleted();
                return Disposable.Empty;
            })
            .RepeatUntilDestroy(gameObject)
            .Take(3)
            .Subscribe(x => Debug.Log(x), () => Debug.Log("OnCompleted!"));
    }
}
