using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class Example08 : MonoBehaviour
{
    private CharacterController _characterController;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _characterController
            .ObserveEveryValueChanged(x => x.isGrounded)
            .Where(x => x)
            .Subscribe(_ => Debug.Log("OnGrounded!"));
        
        this.UpdateAsObservable()
            .Select(_ => _characterController.isGrounded)
            .DistinctUntilChanged()
            .Where(x => x)
            .Subscribe(_ => Debug.Log("OnGrounded!"));
    }
}