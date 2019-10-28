using UniRx;
using UnityEngine;
using UniRx.Triggers;

public class Example23_TriggersSample : MonoBehaviour
{
    void Start()
    {
        bool isForceEnabled = true;
        var rb = GetComponent<Rigidbody>();

        this.FixedUpdateAsObservable()
            .Where(_ => isForceEnabled)
            .Subscribe(_ => rb.AddForce(Vector3.up * 20));

        this.OnTriggerEnterAsObservable()
            .Where(x => x.gameObject.CompareTag("WarpZone"))
            .Subscribe(_ => isForceEnabled = true);
        
        this.OnTriggerExitAsObservable()
            .Where(x => x.gameObject.CompareTag("WarpZone"))
            .Subscribe(_ => isForceEnabled = false);
    }
}
