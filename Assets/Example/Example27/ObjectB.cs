using UniRx;
using UnityEngine;

/// <summary>
/// ObjectA 후 초기화 되었으면 하는 쪽
/// </summary>
public class ObjectB : MonoBehaviour
{
    [SerializeField]
    private ObjectA objectA;

    private void Start()
    {
        Debug.Log("ObjectB의 Start가 실행되었습니다.");

        // A의 초기화 완료 통지가 오면 B를 초기화
        // OnInitializedAsync 이미 Completed 된 경우 즉시 실행된다.
        objectA.OnInitializedAsync.Subscribe(_ => Initialize());
    }

    private void Initialize()
    {
        // 여기에서 B의 초기화 처리
        Debug.Log("ObjectB의 초기화가 끝났습니다.");
    }
}
