using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class TimerViewRx : MonoBehaviour
{
    // 각 인스턴스는 인스펙터에서 설정
    [SerializeField] private TimeCounterRx timeCounter;
    [SerializeField] private Text counterText; // UGUI의 Text

    private void Start() =>
        // 타이머 카운터가 변화한 이벤트를 받고 UGUI Text를 업데이트
        timeCounter.OnTimeChanged.Subscribe(time =>
        {
            // 현재 타이머 값을 ui에 반영
            counterText.text = time.ToString();
        });
}
