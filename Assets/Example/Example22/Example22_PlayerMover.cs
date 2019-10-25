using UniRx;
using UnityEngine;

// 플레이어 이동 처리
// 타이머가 0이되면 초기 좌표로 돌린다.
public class Example22_PlayerMover : MonoBehaviour
{
    [SerializeField] private Example22_TimeCounter _timeCounter;
    private float _moveSpeed = 10.0f;

    private void Start()
    {
        // 타이머 구독
        _timeCounter.OnTimeChanged
            .Where(x => x == 0) // 타이머가 0이 되었을 때만 실행
            .Subscribe(_ =>
            {
                // 타이머가 0이되면 초기 좌표로 돌린다
                transform.position = Vector3.zero;
            }).AddTo(gameObject);
    }

    private void Update()
    {
        // 오른쪽 화살표를 누르고 있는 동안 이동
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0) * _moveSpeed * Time.deltaTime;
        }
        
        // 화면 밖으로 나오면 제거
        if (transform.position.x > 10)
        {
            Debug.Log("화면 밖에 나왔다!");
            Destroy(gameObject);
        }
    }
}
