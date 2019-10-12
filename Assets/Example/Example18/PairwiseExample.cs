using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;

public class PairwiseExample : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        // Pairwise()
        Observable.Range(1, 10)
            .Pairwise()
            .Subscribe(x => Debug.Log($"{x.Previous}, {x.Current}"));

        // Buffer (2,1)
        Observable.Range(1, 10)
            .Select(x => x.ToString())
            .Buffer(2, 1)
            .Subscribe(x => Debug.Log(x.Aggregate<string>((p, c) => p.ToString() + ", " + c.ToString())));
    }
}