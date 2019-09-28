using System;
using System.Collections;
using UnityEngine;

public class CoroutineExample : MonoBehaviour
{
    private void Start()
    {
        // 3.5 초 후에 실행
        StartCoroutine(DelayMethod(3.5f, () =>
        {
            Debug.Log("Delay Call");
        }));
    }

    /// <summary>
    /// 전달 된 처리를 지정 시간 이후에 실행 한다.
    /// </summary>
    /// <param name="waitTime">지연시간[밀리초]</param>
    /// <param name="action">수행할 작업</param>
    /// <returns></returns>
    private IEnumerator DelayMethod(float waitTime, Action action)
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }
}
