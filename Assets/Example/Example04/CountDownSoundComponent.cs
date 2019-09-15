using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CountDownSoundComponent : MonoBehaviour
{
    // 효과음
    [SerializeField] private AudioClip _seCountDownTick;
    [SerializeField] private AudioClip _seCountDownEnd;
    
    private AudioSource _audioSource;

    /// <summary>
    /// UnityEditor에서 할당 한다.
    /// </summary>
    [SerializeField] private RxCountDownTimer _rxCountDownTimer;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        
        // 카운트가 10초 이하가 되면 효과음을 1초마다 울리게 한다.
        _rxCountDownTimer
            .CountDownObservable
            .Where(time => time <= 10)
            .Subscribe(_ => _audioSource.PlayOneShot(_seCountDownTick));
        
        // 계산이 완료된 시점에서 효과음을 울린다.
        _rxCountDownTimer
            .CountDownObservable
            .Subscribe(_ => { ; }, () => _audioSource.PlayOneShot((_seCountDownEnd)));
    }
}
