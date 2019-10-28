using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class Example23_ObservableEveryValueChanged : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var characterController = GetComponent<CharacterController>();
        
        // CharacterController의 isGrounded를 감시
        // false -> true가 되면 로그 출력
        characterController
            .ObserveEveryValueChanged(c => c.isGrounded)
            .Where(x => x)
            .Subscribe(_ => Debug.Log("착지!"))
            .AddTo(gameObject);
        
        // ↑ 코드는 ↓와 거의 동의어
        Observable.EveryUpdate()
            .Select(_ => characterController.isGrounded)
            .DistinctUntilChanged()
            .Where(x => x)
            .Subscribe(_ => Debug.Log("착지!"))
            .AddTo(gameObject);
        
        // ObserveEveryValueChanged는
        // EveryUpdate + Select + DistinctUntilChanged
        // 의 축약 버전에 속한다.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
