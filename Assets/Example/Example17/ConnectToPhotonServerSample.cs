using System.Collections;
using Photon.Pun;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Example.Example17
{
    public class ConnectToPhotonServerSample : MonoBehaviour
    {
        private PhotonCallbacks _callbacks;

        private void Start()
        {
            _callbacks = PhotonCallbacks.Instance;
            
            // 버튼이 눌려 졌을 때 로그인 프로세스 시작
            GetComponent<Button>()
                .OnClickAsObservable()
                .Subscribe(_ => StartCoroutine(LoginTask()));
        }

        /// <summary>
        /// Photon 로그인 처리를 한다.
        /// </summary>
        private IEnumerator LoginTask()
        {
            Debug.Log("서버에 연결 시작");
             
            // 연결 시작
            PhotonNetwork.GameVersion = "0.1";
            PhotonNetwork.ConnectUsingSettings();
            
            // 성공 여부 판정 저장 용
            ConnectServerResult serverResult = null;
            
            // 로그인 처리의 종료를 대기
            yield return _callbacks
                .ConnectToSeverObservable
                .StartAsCoroutine(x => serverResult = x);
            
            // if 문에서 성공 여부를 판정 할 수 있다
            if (serverResult is ConnectServerFail)
            {
                Debug.LogError("로그인 실패");
                Debug.LogError((ConnectServerFail) serverResult);
                // 결과가 실패하면 종료
                yield break;
            }
            
            // 로그인 성공 후 계속 진행
            Debug.Log("로그인 성공");
            
            // 로비 입실을 대기 한다
            yield return _callbacks
                .OnJoinedLobbyAsObservable
                .StartAsCoroutine();
            
            Debug.Log("로비 입실 완료");
            
            // 다음 로그인 후 처리를 진행 한다.
        }
    }
}