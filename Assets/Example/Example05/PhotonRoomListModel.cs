using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UniRx;

public class PhotonRoomListModel : MonoBehaviourPunCallbacks
{
    public ReactiveProperty<List<RoomInfo>> RoomInfoReactiveProperty
        = new ReactiveProperty<List<RoomInfo>>();

    public override void OnRoomListUpdate(List<RoomInfo> roomList) =>
        RoomInfoReactiveProperty.Value = roomList;
}
