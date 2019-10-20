using UnityEngine;
using UnityEngine.UI;

public class TimerView : MonoBehaviour
{
    // 각 인스턴스는 인스펙터에서 설정
    [SerializeField] private TimeCounter timeCounter;
    [SerializeField] private Text counterText; // UGUI의 Text

    private void Start()
    {
        // 타이머 카운터가 변화한 이벤트를 받고 UGUI Text를 업데이트
        timeCounter.OnTimeChanged += time => // "=>" 는 람다식이라는 익명 함수 표기법 
        {
            // 현재 타이머 값을 UI에 반영
            counterText.text = time.ToString();
        };
    }
}
