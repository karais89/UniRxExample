using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class Example26_2 : MonoBehaviour
{
    private void Start() => StartCoroutine(GetEnemyDataFromServerCoroutine());

    /// <summary>
    /// 서버에서 적의 정보를 당겨오는 코루틴
    /// </summary>
    /// <returns></returns>
    private IEnumerator GetEnemyDataFromServerCoroutine()
    {
        // 서버에서 xml 다운로드
        var www = new WWW ("http://api.hogehoge.com/resouces/enemey.xml");
        
        yield return www;

        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.Log(www.error);
        }

        var xmlText = www.text;
        
        // ParseXml 함수를 다른 스레드에서 실행
        // Observable.Start는 인수의 함수를 ThreadPool에서 실행하는 기능
        var o = Observable.Start(() => ParseXml(xmlText)).ToYieldInstruction();
        
        // 파스 종료 대기
        yield return o;

        if (o.HasError)
        {
            // 파스 실패
            Debug.LogError(o.Error);
            yield break;
        }
        
        // 파스 결과
        var result = o.Result;
        Debug.Log(result);
        
        // 이 후 처리 계속
    }

    private Dictionary<string, EnemyParameter> ParseXml(string xml)
    {
        // 여기에 xml 파싱을 Dictinonary에 넣는다는 가정
        return new Dictionary<string, EnemyParameter>();
    }

    /// <summary>
    /// 적 매개 변수
    /// </summary>
    private struct EnemyParameter
    {
        public string Name { get; set; }
        public string Health { get; set; }
        public string Power { get; set; }
    }
}
