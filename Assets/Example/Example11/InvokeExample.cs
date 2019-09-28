using UnityEngine;

public class InvokeExample : MonoBehaviour
{
    private void Start()
    {
        // DelayMethod을 3.5 초 후에 호출 
        Invoke("DelayMethod", 3.5f);
    }

    private void DelayMethod()
    {
        Debug.Log("Delay call");
    }
}