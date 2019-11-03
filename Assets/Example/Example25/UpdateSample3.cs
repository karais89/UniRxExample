using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class UpdateSample3 : MonoBehaviour
{
    // 실행 간격
    [SerializeField]
    private float intervalSeconds = 0.25f;

    private void Start() =>
        // ThrottleFirst는 마지막으로 실행하고
        // 일정 시간 OnNext를 차단하는 오퍼레이터
        this.UpdateAsObservable()
            .Where(_ => Input.GetKey(KeyCode.Z))
            .ThrottleFirst(TimeSpan.FromSeconds(intervalSeconds))
            .Subscribe(_ => Attack());

    private void Attack() => Debug.Log("Attack");
}
