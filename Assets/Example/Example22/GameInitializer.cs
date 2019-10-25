using System;
using System.Collections;
using UniRx;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    // Unit형 사용
    private Subject<Unit> initializedSubject = new Subject<Unit>();

    public IObservable<Unit> OnInitializedAsync => initializedSubject;

    private void Start()
    {
        // 초기화 시작
        StartCoroutine(GameInitializeCoroutine());

        OnInitializedAsync.Subscribe(_ => { Debug.Log("초기화 완료"); });
    }

    private IEnumerator GameInitializeCoroutine()
    {
        /*
         * 초기화 처리
         *
         * WWW 통신이나 개체 인스턴스화 등
         * 시간이 걸리고 무거운 처리를 여기에서 한다고 가정
         */
        yield return null;
        
        // 초기화 완료 통지
        initializedSubject.OnNext(Unit.Default); // 타이밍이 중요한 통지이므로 Unit로도 충분하다.
        initializedSubject.OnCompleted();
    }
}
