using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class Example23_ObservableWWW : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ObservableWWW.Get("https://google.com")
            .Subscribe(x => Debug.Log(x));
        
        Observable.NextFrame()
            .Subscribe(x => Debug.Log(x));
    }
}
