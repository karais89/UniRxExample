using UniRx;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    private void Start()
    {
        var playerHealth = GetComponent<PlayerHealth>();
        
        // 기절 상태에 맞추어 효과음을 재생, 중지
        playerHealth.IsStunned.Subscribe(x =>
        {
            if (x)
            {
                Play();
            }
            else
            {
                Stop();
            }
        });

    }

    private void Play()
    {
        // 생략
    }
    
    private void Stop()
    {
        // 생략
    }
}
