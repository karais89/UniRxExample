using UnityEngine;
using UniRx;
using UniRx.Triggers; // 이 using문이 필요

public class UpdateSample : MonoBehaviour
{
    private void Start()
    {
        // UpdateAsObservable는 Component에 대한
        // 확장 메서드로 정의되어 있기 때문에 호출시
        // "this"가 필요
        this.UpdateAsObservable()
            .Subscribe(
            _ => Debug.Log("Update!"), // OnNext
            () => Debug.Log("OnCompleted") // OnCompleted            
            );

        // OnDestroy를 받아 로그 출력
        this.OnDestroyAsObservable()
            .Subscribe(_ => Debug.Log("Destroy!"));

        // 1초 후에 파기
        Destroy(gameObject, 1.0f);
    }
}
