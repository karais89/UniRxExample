using System;
using UniRx;
using UnityEngine;

/// <summary>
/// 게임오브젝트가 카메라에 찍힌 것을 통지하는 스크립트
/// </summary>
public class OnVisibleScript : MonoBehaviour
{
    /// <summary>
    /// 카메라에 비친 게임오브젝트를 흐르는 스트림
    /// </summary>
    private Subject<GameObject> onVisibleStream = new Subject<GameObject>();

    /// <summary>
    /// 외부에 공개하는 Observable
    /// </summary>
    public IObservable<GameObject> OnVisibleObservable => onVisibleStream.AsObservable();
    
    /// <summary>
    /// 카메라에 찍힐 때 실행되는 Unity 전용 콜백
    /// </summary>
    private void OnBecameVisible()
    {
        // OnNext에서 자신의 게임오브젝트를 스트림에 흐르게 한다.
        onVisibleStream.OnNext(gameObject);
    }
}