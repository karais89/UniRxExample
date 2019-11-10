using System.Collections;
using UniRx;
using UnityEngine;

public class ConvertFromCoroutine : MonoBehaviour
{
    private void Start() =>
        Observable.FromCoroutine(NantokaCoroutine, publishEveryYield: false)
            .Subscribe(
                _ => Debug.Log("OnNext"),
                () => Debug.Log("OnCompleted")
            ).AddTo(gameObject);

    private IEnumerator NantokaCoroutine()
    {
        Debug.Log("Coroutine started");
        
        // 어떤 처리를 하고 기다리고 있는 예
        yield return new WaitForSeconds(3);
        
        Debug.Log("Coroutine finished.");
    }
}