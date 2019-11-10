using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UniRx;
using UnityEngine;

public class Example26 : MonoBehaviour
{
    private void Start() =>
        Observable.FromCoroutine(CoroutineA)
            .SelectMany(CoroutineB) // SelectMany에서 합성
            .Subscribe(_ => Debug.Log("All Coroutine Finished"));

    private IEnumerator CoroutineA()
    {
        Debug.Log("CoroutineA start");
        yield return new WaitForSeconds(3);
        Debug.Log("CoroutineA finished");
    }
    
    private IEnumerator CoroutineB()
    {
        Debug.Log("CoroutineB start");
        yield return new WaitForSeconds(3);
        Debug.Log("CoroutineB finished");
    }
}
