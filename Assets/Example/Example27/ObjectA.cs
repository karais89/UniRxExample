using System;
using UniRx;
using UnityEngine;

/// <summary>
/// 먼저 초기화되면 좋은 쪽
/// </summary>
public class ObjectA : MonoBehaviour
{
    private AsyncSubject<Unit> _initializedAsyncSubject = new AsyncSubject<Unit>();

    public IObservable<Unit> OnInitializedAsync => _initializedAsyncSubject;

    private void Start()
    {
        Debug.Log("ObjectA의 Start가 실행되었습니다.");

        // 여기에서 a의 초기화 처리

        Debug.Log("ObjectA의 초기화가 끝났습니다.");

        // 초기화 완료 통지
        _initializedAsyncSubject.OnNext(Unit.Default);
        _initializedAsyncSubject.OnCompleted();
    }
}
