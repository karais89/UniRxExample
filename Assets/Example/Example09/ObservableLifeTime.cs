using System;
using UniRx;
using UnityEngine;

public class ObservableLifeTime : MonoBehaviour
{
    private void Start()
    {
        // 1 초마다 메시지를 발행하는 Observable
        Observable.Timer(TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(1))
            .Subscribe(x => Debug.Log(x))
            .AddTo(gameObject); // GameObject의 수명과 연결.

        // 3 초 후에 GameObject를 제거한다
        Invoke("DestroyGameObject", 3);
    }

    /// <summary>
    /// 로그를 출력하고 오브젝트를 제거한다.
    /// </summary>
    private void DestroyGameObject()
    {
        Debug.Log("Destroy");
        Destroy(gameObject);
    }
}
