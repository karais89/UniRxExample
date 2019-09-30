using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class RepeatSubjectExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var subject = new Subject<int>();
        subject
            .Materialize()
//            .Repeat()
            .Subscribe(x => Debug.Log(x));

        subject.OnNext(1);
        subject.OnNext(2);
        subject.OnNext(3);
        subject.OnCompleted();
    }
}
