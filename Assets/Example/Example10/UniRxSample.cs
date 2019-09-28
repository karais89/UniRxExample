using UniRx.Triggers;
using UniRx;
using UnityEngine;

public class UniRxSample : MonoBehaviour
{
    private void Start()
    {
        this.UpdateAsObservable()
            .Subscribe(_ => Debug.Log("Update!"));
    }
}
