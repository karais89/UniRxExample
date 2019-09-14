using System;
using System.Linq;
using UniRx;
using UnityEngine;

public class ObserveScript : MonoBehaviour
{
    /// <summary>
    /// TargetCube를 묶는 GameObject
    /// UnityEditor에서 설정해두자.
    /// </summary>
    public GameObject cubes;

    private void Start()
    {
        // OnVisibleScript를 획득
        var onVisibleScripts = cubes.GetComponentsInChildren<OnVisibleScript>();
        
        // Merge : 여러개의 OnVisibleObservable을 하나로 통합
        var allOnVisibleObservable = Observable.Merge(onVisibleScripts.Select((x => x.OnVisibleObservable)));
        
        // 250ms 이내에 화면에 함께 찍힌 GameObject를 계산
        allOnVisibleObservable
            .Buffer(allOnVisibleObservable.Throttle(TimeSpan.FromMilliseconds(250)))
            .Subscribe(x => Debug.Log(x.Count));
    }
}