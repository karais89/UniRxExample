using System;
using Photon.Realtime;
using UniRx;

namespace Example.Example17
{
    // Photon 콜백을 Observable로 제공하는 싱글 톤
    public class PhotonCallbacks : PhotonSingletonMonoBehaviourFast<PhotonCallbacks>
    {
        #region Server
        /// <summary>
        /// 서버 연결 결과를 통지 할 Subject
        /// </summary>
        private Subject<ConnectServerResult> _connectToSeverResultSubject;

        /// <summary>
        /// 서버 연결의 결과를 통지 한다.
        /// </summary>
        public IObservable<ConnectServerResult> ConnectToSeverObservable
        {
            get
            {
                if (_connectToSeverResultSubject == null)
                    _connectToSeverResultSubject = new Subject<ConnectServerResult>();

                return _connectToSeverResultSubject.AsObservable().First(); // OnCompleted를 발행하기 위한 First 선언
            }
        }

        /// <summary>
        /// 서버에 접속 성공했다.
        /// </summary>
        public override void OnConnected()
        {
            base.OnConnected();

            _connectToSeverResultSubject?.OnNext(new ConnectServerSuccess());
        }

        /// <summary> 
        /// Photon 서버와 연결이 끊겼다.
        /// </summary> 
        /// <param name = 'cause'> 원인 </param> 
        public override void OnDisconnected(DisconnectCause cause)
        {
            base.OnDisconnected(cause);
            
            _connectToSeverResultSubject?.OnNext(new ConnectServerFail(cause));
        }
        #endregion
        
        #region Lobby
        /// <summary>
        /// 로비에 연결 한 것을 통지하는 Subject
        /// </summary>
        private Subject<Unit> _onJoinedLobby;

        /// <summary>
        /// 로비 입장 성공을 알린다.
        /// </summary>
        public IObservable<Unit> OnJoinedLobbyAsObservable
        {
            get
            {
                if (_onJoinedLobby == null)
                    _onJoinedLobby = new Subject<Unit>();

                return _onJoinedLobby.First();
            }
        }

        /// <summary>
        /// 로비에 입장 한다.
        /// </summary>
        public override void OnJoinedLobby()
        {
            base.OnJoinedLobby();
            
            _onJoinedLobby?.OnNext(Unit.Default);
        }
        #endregion
    }
}