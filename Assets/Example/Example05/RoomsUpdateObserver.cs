using UniRx;
using UnityEngine;

public class RoomsUpdateObserver : MonoBehaviour
{
    [SerializeField] private PhotonRoomListModel roomModel;
    
    private void Start() => roomModel
        .RoomInfoReactiveProperty
        .AsObservable()
        .Subscribe(rooms =>
        {
            Debug.Log(rooms.Count);
        });
}
