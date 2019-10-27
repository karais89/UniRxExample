using UniRx;
using UnityEngine;

public class Example23_ObservableCreate : MonoBehaviour
{
    private void Start()
    {
        Observable.Create<int>(observer =>
        {
            Debug.Log("Start");
            for (int i = 0; i <= 100; i += 10)
            {
                observer.OnNext(i);
            }
            
            Debug.Log("Finished");
            observer.OnCompleted();
            
            return Disposable.Create(() =>
            {
                Debug.Log("Dispose");
            });
        }).Subscribe(x => Debug.Log(x));
    }
}
