using System;
using UniRx;
using UnityEngine;

public class StateMachineObservables : StateMachineBehaviour
{
    #region OnStateEnter
    private Subject<AnimatorStateInfo> onStateEnterSubject = new Subject<AnimatorStateInfo>();

    public IObservable<AnimatorStateInfo> OnStateEnterObservable => onStateEnterSubject;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        onStateEnterSubject.OnNext(stateInfo);
    }
    #endregion
    
    #region OnStateExit
    private Subject<AnimatorStateInfo> onStateExitSubject = new Subject<AnimatorStateInfo>();

    public IObservable<AnimatorStateInfo> OnStateExitObservable => onStateExitSubject;

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        onStateExitSubject.OnNext(stateInfo);
    }
    #endregion

    #region OnStateMachineEnter
    private Subject<int> onStateMachineEnterSubject = new Subject<int>();

    public IObservable<int> OnStateMachineEnterObservable => onStateMachineEnterSubject;

    public override void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    {
        onStateMachineEnterSubject.OnNext(stateMachinePathHash);
    }
    #endregion
    
    #region OnStateMachineExit
    private Subject<int> onStateMachineExitSubject = new Subject<int>();

    public IObservable<int> OnStateMachineExitObservable => onStateMachineExitSubject;

    public override void OnStateMachineExit(Animator animator, int stateMachinePathHash)
    {
        onStateMachineExitSubject.OnNext(stateMachinePathHash);
    }
    #endregion
    
    #region OnStateMove
    private Subject<AnimatorStateInfo> onStateMoveSubject = new Subject<AnimatorStateInfo>();

    public IObservable<AnimatorStateInfo> OnStateMoveObservable => onStateMoveSubject;

    public override void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        onStateMoveSubject.OnNext(stateInfo);
    }
    #endregion
    
    #region OnStateIK
    private Subject<AnimatorStateInfo> onStateIKSubject = new Subject<AnimatorStateInfo>();

    public IObservable<AnimatorStateInfo> OnStateIKObservable => onStateIKSubject;

    public override void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        onStateIKSubject.OnNext(stateInfo);
    }
    #endregion
}
