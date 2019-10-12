using System.Linq;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class BufferFrame : MonoBehaviour
{
    private void Start()
    {
        this.UpdateAsObservable()
            .Select(_ => Time.deltaTime)
            .Buffer(10, 1)
            .Select(x => x.Average())
            .Subscribe(x => Debug.Log("Average : " + x));
    }
}
