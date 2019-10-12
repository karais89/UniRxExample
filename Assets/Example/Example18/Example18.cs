using System.Linq;
using UniRx;
using UnityEngine;

public class Example18 : MonoBehaviour
{
    private void Start()
    {
        Observable.Range(1, 10)
            .Select(x => x.ToString())
            .Buffer(2) // 2개 묶음 (방류한 뒤에 2개 건너뛰고 다음을 방류한다. Buffer(2,2)와 동일)
            .Subscribe(x =>
            {
                // buffer의 내용을 표시
                Debug.Log(x.Aggregate<string>((p, c) => p.ToString() + ", " + c.ToString()));
            });
        
        Debug.Log("=============================================");

        Observable.Range(1, 10)
            .Select(x => x.ToString())
            .Buffer(2, 1) // 2개 묶음. 방류 후 1개 건너뛰고 방류하다.
            .Subscribe(x =>
            {
                // buffer의 내용을 표시
                Debug.Log(x.Aggregate<string>((p, c) => p.ToString() + ", " + c.ToString()));
            });
        
        Debug.Log("=============================================");
        
        Observable.Range(1, 10)
            .Select(x => x.ToString())
            .Buffer(2, 1) // 2개 묶음. 방류 후 1개 건너뛰고 방류하다.
            .Subscribe(x =>
            {
                // buffer의 내용을 표시
                Debug.Log(x.Aggregate<string>((p, c) => p.ToString() + ", " + c.ToString()));
            });

        Debug.Log("=============================================");

        Observable.Range(1, 10)
            .Select(x => x.ToString())
            .Buffer(3, 2) // 3개 묶음. 방류 후 2개 건너뛰고 방류하다.
            .Subscribe(x =>
            {
                // buffer의 내용을 표시
                Debug.Log(x.Aggregate<string>((p, c) => p.ToString() + ", " + c.ToString()));
            });
    }
}