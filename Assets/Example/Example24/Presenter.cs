using UniRx;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Model과 View를 연결하는 Presenter
/// </summary>
public class Presenter : MonoBehaviour
{
    // view
    [SerializeField]
    private InputField _nameInputField;

    // model
    [SerializeField]
    private Model _model;
    
    private void Start()
    {
        // view가 업데이트되면 Model의 데이터를 업데이트 한다
        _nameInputField
            .OnValueChangedAsObservable()
            .Subscribe(x => _model.Name.Value = x);

        // model이 업데이트 되면 view를 다시 업데이트 한다.
        _model.Name
            .Subscribe(x => _nameInputField.text = x);
    }
}
