using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class PlayerExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 단지 테스트 용도
        this.UpdateAsObservable()
            .Where(_ => Input.GetKeyDown(KeyCode.A))
            .Subscribe(_ => { gameObject.SendMessage("SetTriggerAttackA"); });
        
        // 단지 테스트 용도
        this.UpdateAsObservable()
            .Where(_ => Input.GetKeyDown(KeyCode.S))
            .Subscribe(_ => { gameObject.SendMessage("SetTriggerAttackB"); });

    }
}
