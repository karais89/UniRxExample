using System;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTimerManager : MonoBehaviour
{
    /// <summary>
    /// 경기 시작 전 카운트 다운
    /// </summary>
    public IObservable<int> GameStartCountDownObservable { get; private set; }
    
    /// <summary>
    /// 경기 중 카운트 다운
    /// </summary>
    public IObservable<int> BattleCountDownObservable { get; private set; }

    private void Start()
    {
        // 경기 전 3초 타이머
        // 3초 타이머의 스트림을 Publish로 Hot으로 변환 (아직 Connect는 하지 않는다)
        var startConnectableObservable = CreateCountDownObservable(3).Publish();
        // 외부에 공개하기 위해 Observable로 저장
        GameStartCountDownObservable = startConnectableObservable;
        
        // 경기 중 60초 타이머
        // 60초 타이머의 스트림을 Publish로 Hot으로 변환 (아직 Connect는 하지 않는다)
        var battleConnectableObservable = CreateCountDownObservable(60).Publish();
        // 외부에 공개하기 위해 Observable로 저장
        BattleCountDownObservable = battleConnectableObservable;
        
        // 3초 타이머의 OnComplete에서 60초 타이머를 Connect한다 (60초 타이머 시작)
        GameStartCountDownObservable
            .Subscribe(_ => { ; }, () => battleConnectableObservable.Connect());
        
        // 60초 타이머 뒤에 Concat으로 5초 타이머를 연결하고 OnComplete에서 Scene를 전환한다.
        BattleCountDownObservable
            .Concat(CreateCountDownObservable(5))
            .Subscribe(_ => { ; }, () =>
            {
                SceneManager.LoadScene("NextScene");
            }).AddTo(gameObject);
        
        // 3초 타이머 시작
        startConnectableObservable.Connect();
    }
    
    /// <summary>
    /// countTime 만큼 카운트 다운하는 스트림
    /// </summary>
    /// <param name="countTime"></param>
    /// <returns></returns>
    private IObservable<int> CreateCountDownObservable(int countTime) =>
        Observable
            .Timer(TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(1))
            .Select(x => (int) (countTime - x))
            .TakeWhile(x => x > 0);
}
