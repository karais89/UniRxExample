using UniRx;
using UnityEngine;

public class TestReactiveProperty : MonoBehaviour
{
    // int형의 ReactiveProperty (인스펙터 뷰에 나오는 버전) 
    [SerializeField]
    private IntReactiveProperty playerHealth = new IntReactiveProperty(100);
    
    private void Start() => playerHealth.Subscribe(x => Debug.Log(x));
}
