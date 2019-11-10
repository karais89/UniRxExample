using System;
using System.Collections;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class ConvertToCoroutine : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(WaitCoroutine());
    }

    private IEnumerator WaitCoroutine()
    {
        // Subscribe 대신 ToYieldInstruction()을 이용하여
        // 코루틴으로 스트림을 처리 할 수 있게 된다

        // 1초 기다린다
        Debug.Log("Wait for 1 second.");
        yield return Observable.Timer(TimeSpan.FromSeconds(1)).ToYieldInstruction();

        // ToYieldInstruction()은 OnCompleted가 발행되어 코루틴 종료
        // 따라서 OnCompleted가 반드시 발행되는 스트림에서만 사용할 수 있다.
        // 무한으로 이어지는 스트림의 경우 First나 FirstOrDefault를 사용하면 좋겠다.
        Debug.Log("Press any key");

        // 아무 키나 누를 때까지 기다린다
        yield return this.UpdateAsObservable()
            .FirstOrDefault(_ => Input.anyKeyDown)
            .ToYieldInstruction();

        // FirstOrDefault 조건을 충족하면 OnNext와 OnCompleted를 모두 발행한다.
        Debug.Log("Pressed");
    }
}