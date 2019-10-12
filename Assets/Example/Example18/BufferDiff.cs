using System.Linq;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class BufferDiff : MonoBehaviour
{
    private void Start()
    {
        this.UpdateAsObservable()
            .Select(_ => transform.position)
            .Buffer(2, 1)
            .Where(x => x.Count == 2)
            .Select(x => x.Last() - x.First())
            .Subscribe(x => Debug.Log("Delta: " + x));
    }
}
