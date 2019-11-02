using System.Collections;
using UniRx;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    /// <summary>
    /// 기절 플래그
    /// </summary>
    public BoolReactiveProperty IsStunned = new BoolReactiveProperty();

    /// <summary>
    /// 데미지 처리
    /// </summary>
    public void ApplyDamage()
    {
        // 기절하지 않았다면 기절 시킨다.
        if (!IsStunned.Value) StartCoroutine(StunCoroutine());
    }

    /// <summary>
    /// 기절하는 동안 수행되는 코루틴
    /// </summary>
    private IEnumerator StunCoroutine()
    {
        // 기절 플래그 ON
        IsStunned.Value = true;
        // 적당히 대기 한다.
        yield return new WaitForSeconds(5);
        // 기절 플래그 OFF
        IsStunned.Value = false;
    }
}
