using UniRx;
using UnityEngine;

public class Model : MonoBehaviour
{
    // 외부에 공개하는 데이터
    public ReactiveProperty<string> Name = new ReactiveProperty<string>();
}
