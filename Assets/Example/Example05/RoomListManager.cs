using System;
using System.Collections.Generic;
using Photon.Realtime;
using UniRx;
using UnityEngine;

public class RoomListManager : MonoBehaviour
{
    private IObservable<List<RoomInfo>> _onRoomInfoChangedObservable;

    /// <summary>
    /// 방 정보가 업데이트 되었을 때 새로운 방 목록을 제공하는 Observable
    /// </summary>
    public IObservable<List<RoomInfo>> OnRoomInfoChangedObservable
    {
        get
        {
            return _onRoomInfoChangedObservable;
        }   
    }
    private void Awake() => _onRoomInfoChangedObservable = PhotonCallbacks.Instance
        .OnRoomListUpdateAsObservable()
        .Publish()
        .RefCount();
}
