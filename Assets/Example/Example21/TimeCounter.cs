using System.Collections;
using UnityEngine;

/// <summary>
/// 100에서 카운트 다운 값을 보고하는 샘플
/// </summary>
public class TimeCounter : MonoBehaviour
{
    /// <summary>
    /// 이벤ㅌ 핸들러 (이벤트 메시지의 형식 정의)
    /// </summary>
    public delegate void TimerEventHandler(int time);

    /// <summary>
    /// 이벤트
    /// </summary>
    public event TimerEventHandler OnTimeChanged;

    private void Start()
    {
        // 타이머 시작
        StartCoroutine(TimerCoroutine());        
    }

    private IEnumerator TimerCoroutine()
    {
        // 100에서 카운트 다운
        var time = 100;
        while (time > 0)
        {
            time--;

            // 이벤트 알림
            OnTimeChanged(time);

            // 1초 기다리는
            yield return new WaitForSeconds(1);
        }
    }
}
