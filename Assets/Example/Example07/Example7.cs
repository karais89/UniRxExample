using System;
using UnityEngine;
using UniRx;

public class Example7 : MonoBehaviour
{
    private Animator _animator;

    private StateMachineObservables _stateMachineObservables;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _stateMachineObservables = _animator.GetBehaviour<StateMachineObservables>();
        
        // 시작한 애니메이션의 short Name Hash 를 보여준다.
        _stateMachineObservables
            .OnStateEnterObservable
            .Subscribe(stateInfo => Debug.Log(stateInfo.shortNameHash));

        _stateMachineObservables
            .OnStateEnterObservable                                               // 상태 변화를 감지
            .Throttle(TimeSpan.FromSeconds(5))                                    // 마지막 상태 변화 후 5초 경과했을 때
            .Where(x => x.IsName("Base Layer.Idle"))                              // 현재 재싱중인 애니메이션이 Base Layer의 Idle이라면
            .Subscribe(_ => _animator.SetBool("Rest", true)); // Animator의 Rest 파라미터를 True로 한다.
    }
}
