using UniRx;
using UnityEngine;

public class Example23_ReactiveCollection : MonoBehaviour
{
    private void Start()
    {
        var collection = new ReactiveCollection<string>();
        collection.ObserveAdd()
            .Subscribe(x =>
            {
                Debug.Log($"Add [{x.Index}] = {x.Value}");
            });

        collection.ObserveRemove()
            .Subscribe(x =>
            {
                Debug.Log($"Remove [{x.Index}] = {x.Value}");
            });
        
        collection.Add("Apple");
        collection.Add("Baseball");
        collection.Add("Cherry");
        collection.Remove("Apple");
    }
}
