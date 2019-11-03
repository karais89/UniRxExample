using UniRx;
using UnityEngine;

public class UpdateSample2 : MonoBehaviour
{
    private void Start() =>
        Observable.EveryUpdate()
            .Subscribe(_ => Debug.Log("Update!"));
}
