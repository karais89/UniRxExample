using UniRx;
using UnityEngine;

/// <summary>
/// 이동 관리 컴포넌트
/// </summary>
public class PlayerMove : MonoBehaviour
{
    /// <summary>
    /// 이동 허가 플래그
    /// </summary>
    public bool _canMove;
    
    private void Start()
    {
        // 참조의 취득은 원하는 방식으로 구현
        var playerHealth = GetComponent<PlayerHealth>();
        
        // 기절 플래그가 변경되면 이동 허가 플래그에 반영한다.
        playerHealth.IsStunned.Subscribe(x => _canMove = x);
        
        // 다음 부분은 _canMove 플래그를 사용하여 이동 처리를 작성하는 로직
        // 이하 생략
    }
}
