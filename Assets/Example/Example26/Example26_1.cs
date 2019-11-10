using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class Example26_1 : MonoBehaviour
{
    private void Start() =>
        Observable.WhenAll(
            Observable.FromCoroutine<string>(o => CoroutineA(o))
            , Observable.FromCoroutine<string>(o => CoroutineB(o))

        ).Subscribe(xs =>
        {
            foreach (var x in xs)
            {
                Debug.Log("result: " + x);
            }
        });

    private IEnumerator CoroutineA(IObserver<string> observer)
    {
        Debug.Log("CoroutineA start");
        yield return new WaitForSeconds(3);
        observer.OnNext("CoroutineA done!");
        observer.OnCompleted();
    }
    
    private IEnumerator CoroutineB(IObserver<string> observer)
    {
        Debug.Log("CoroutineB start");
        yield return new WaitForSeconds(1);
        observer.OnNext("CoroutineB done!");
        observer.OnCompleted();
    }
}
