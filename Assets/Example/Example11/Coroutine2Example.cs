using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coroutine2Example : MonoBehaviour
{
    private void Start()
    {
        // 5 프레임 후에 실행
        StartCoroutine(DelayMethod(5, () =>
        {
            Debug.Log("Delay Call");
        }));
    }

    /// <summary>
    /// 전달된 처리를 지정 프레임 이후에 실행
    /// </summary>
    /// <param name="delayFrameCount">지연할 프레임</param>
    /// <param name="action">수행 할 작업</param>
    /// <returns></returns>
    private IEnumerator DelayMethod(int delayFrameCount, Action action)
    {
        for (int i = 0; i < delayFrameCount; i++)
        {
            yield return null;
        }

        action();
    }
}
