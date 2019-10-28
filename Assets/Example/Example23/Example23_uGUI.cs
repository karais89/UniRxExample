using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class Example23_uGUI : MonoBehaviour
{
    // 인스펙터에서 설정
    [SerializeField] private Button button; 
    [SerializeField] private InputField inputField;
    [SerializeField] private Slider slider;
    
    private void Start()
    {
        // uGUI의 기본 Unity 이벤트의 이름을 한 Observable이 준비되어 있다.
        button.OnClickAsObservable().Subscribe(_ =>
        {
            Debug.Log("button OnClick!");
        });

        inputField.OnValueChangedAsObservable().Subscribe(str =>
        {
            Debug.Log("inputField OnValueChanged : " + str);
        });
        inputField.OnEndEditAsObservable().Subscribe(str =>
        {
            Debug.Log("inputField OnEndEdit : " + str);
        });

        slider.OnValueChangedAsObservable().Subscribe(val =>
        {
            Debug.Log("slider value changed : " + val);
        });
        
        // ----------
        
        // 또한 이러한 방법도 있다.
        inputField.onValueChanged.AsObservable().Subscribe();
        
        // 이 두 기법의 차이는 Subscribe시 현재 값의 초기 값의 발행 여부이다
        // Subscribe시 초기 값이 필요한 경우는 전자를 사용하면 된다.
        inputField.OnValueChangedAsObservable(); // 초기값이 있다.
        inputField.onValueChanged.AsObservable(); // 초기값이 없다.
    }
}
