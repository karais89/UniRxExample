using UniRx;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;

    private bool IsStunned
    {
        set => _animator.SetBool("IsStunned", value);
    }
    
    private void Start()
    {
        _animator = GetComponent<Animator>();

        var playerHealth = GetComponent<PlayerHealth>();
        
        // 기절 플래그를 써 고쳐하면 Animator의 기절 플래그에 반영
        playerHealth.IsStunned.Subscribe(x => IsStunned = x);
    }
}
