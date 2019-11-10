using System;
using System.Collections;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class ConvertToCoroutine2 : MonoBehaviour
{
    private void Start() => StartCoroutine(DetectCoroutine());

    private IEnumerator DetectCoroutine()
    {
        Debug.Log("Coroutine start!");
        
        // 코루틴이 시작되고 나서
        // 3초 이내에 먼저 자신을 건드린 객체를 얻는다.
        var o = this.OnCollisionEnterAsObservable()
            .FirstOrDefault()
            .Select(x => x.gameObject)
            .Timeout(TimeSpan.FromSeconds(3))
            .ToYieldInstruction(throwOnError: false);
        
        // Timeout은 지정 시간 이내에 스트림이 완료되지 않는 경우
        // OnError를 발행하는 오퍼레이터
        
        // 결과를 기다린다.
        yield return o;

        if (o.HasError || !o.HasResult)
        {
            // 아무것도 치지 않았다.
            Debug.Log("hit object is nothing.");
        }
        else
        {
            // 뭔가에 맞았다.
            var hitObject = o.Result;
            Debug.Log(hitObject.name);
        }
    }
}
