using System;
using System.Collections;
using UniRx;
using UnityEngine;

public class Example23_Timer : MonoBehaviour
{
    public bool IsPaused { get; private set; }
    
    private void Start()
    {
        Observable.FromCoroutine<int>(observer => TimerCoroutine(observer, 60))
            .Subscribe(x => Debug.Log(x));
    }

    IEnumerator TimerCoroutine(IObserver<int> observer, int initializeTime)
    {
        var current = initializeTime;
        while (current > 0)
        {
            if (!IsPaused)
            {
                observer.OnNext(current--);
            }
            yield return new WaitForSeconds(1.0f);
        }
        observer.OnNext(0);
        observer.OnCompleted();
    }
}
