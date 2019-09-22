using UniRx;
using UnityEngine;

public class RoomListView : MonoBehaviour
{
    [SerializeField] private RoomListManager _roomListManager;

    private void Start() =>
        _roomListManager
            .OnRoomInfoChangedObservable
            .Subscribe(roomList =>
            {
               Debug.Log($"현재 방 수 : {roomList.Count}"); 
            });
}