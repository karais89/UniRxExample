using System.IO;
using System.Net;
using UniRx;
using UnityEngine;

public class Example23_ObservableStart : MonoBehaviour
{
    private void Start()
    {
        // 주어진 블록 내부를 다른 스레드에서 실행
        Observable.Start(() =>
            {
                // google의 메인 페이지를 http를 통해 get 한다.
                var req = (HttpWebRequest) WebRequest.Create("https://google.com");
                var res = (HttpWebResponse) req.GetResponse();
                using (var reader = new StreamReader(res.GetResponseStream()))
                {
                    return reader.ReadToEnd();
                }
            })
            .ObserveOnMainThread()
            .Subscribe(x => Debug.Log(x));
    }
}
