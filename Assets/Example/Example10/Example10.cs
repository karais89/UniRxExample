using UniRx;
using UnityEngine;

public class Example10 : MonoBehaviour
{
    private void Start()
    {
        Observable
            .EveryUpdate()
            .Subscribe(x => Debug.Log(x));
    }
}
