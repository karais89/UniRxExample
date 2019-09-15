using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 타이머의 시간을 기초로 Text를 업데이트 할 컴포넌트
/// </summary>
public class CountDownTextComponent : MonoBehaviour
{
    /// <summary>
    /// UnityEditor에서 할당 한다.
    /// </summary>
    [SerializeField] private RxCountDownTimer _rxCountDownTimer;

    /// <summary>
    /// uGUI의 Text
    /// </summary>
    private Text _text;

    private void Start()
    {
        _text = GetComponent<Text>();
        
        // 타이머의 남은 시간을 표시한다.
        _rxCountDownTimer
            .CountDownObservable
            .Subscribe(time =>
            {
                // onNext에서 시간을 표시한다.
                _text.text = $"남은 시간 : {time}";
            }, () =>
            {
                // onComplete에서 문자를 지운다.
                _text.text = string.Empty;
            }).AddTo(gameObject);
        
        // 타이머가 10초 이하로 되는 타이밍에 색을 붉은 색으로 한다.
        _rxCountDownTimer
            .CountDownObservable
            .First(timer => timer <= 10)
            .Subscribe(_ => _text.color = Color.red);
    }
}
