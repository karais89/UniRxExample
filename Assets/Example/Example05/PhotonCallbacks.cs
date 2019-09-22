using System;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UniRx;

public class PhotonCallbacks : MonoBehaviourPunCallbacks
{
    public static PhotonCallbacks Instance;
    
    private Subject<List<RoomInfo>> _roomUpdateSubject = new Subject<List<RoomInfo>>();
    
    private void Awake() => Instance = this;
    
    public override void OnRoomListUpdate(List<RoomInfo> roomList) => 
        _roomUpdateSubject.OnNext(roomList);
    
    public IObservable<List<RoomInfo>> OnRoomListUpdateAsObservable() => _roomUpdateSubject;
}
