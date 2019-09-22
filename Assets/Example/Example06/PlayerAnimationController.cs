using System;
using UniRx;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimationController : MonoBehaviour
{
    private enum AnimatorParameters
    {
        IsAttackA,
        IsAttackB
    }

    private Animator _animator;

    /// <summary>
    /// Action 대리자를 내보내는 Subject
    /// </summary>
    private Subject<Action> _actionSubject = new Subject<Action>();

    private void Start()
    {
        _animator = GetComponent<Animator>();

        // 1 프레임 지연시켜 Action 대리자를 실행한다.
        _actionSubject
            .DelayFrame(1)
            .Subscribe(x => x());

        Debug.Log($"Start 실행 : {Time.frameCount}");

        // _ actionSubject 흘린 Action 대리자가 다음 프레임에서 실행되는 
        _actionSubject
            .OnNext(() => Debug.Log($"1 프레임 후에 실행 : {Time.frameCount}"));
    }

    /// <summary>
    /// 공격 애니메이션 A 시작
    /// </summary>
    public void SetTriggerAttackA()
    {
        // IsAttackATrigger을 true로 설정
        _animator.SetBool(AnimatorParameters.IsAttackA.ToString(), true);

        // IsAttackATrigger을 다음 프레임에서 false로하는 
        _actionSubject.OnNext(() => _animator.SetBool(AnimatorParameters.IsAttackA.ToString(), false));
    }

    /// <summary>
    /// 공격 애니메이션 B 시작
    /// </summary>
    public void SetTriggerAttackB()
    {
//        // IsAttackBTrigger을 true로 설정
//        _animator.SetBool(AnimatorParameters.IsAttackB.ToString(), true);
//
//        // IsAttackBTrigger을 다음 프레임에서 false로하는 
//        _actionSubject.OnNext(() => _animator.SetBool(AnimatorParameters.IsAttackB.ToString(), false));

        _animator.SetBool(AnimatorParameters.IsAttackB.ToString(), true);
        Observable.NextFrame()
            .Subscribe(_ => _animator.SetBool(AnimatorParameters.IsAttackB.ToString(), false));
    }
}