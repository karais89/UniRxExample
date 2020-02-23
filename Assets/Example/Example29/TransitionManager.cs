using BirdStrike.MIKOMA.Scripts.Utilities.SceneDataPacks;
using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace BirdStrike.MIKOMA.Scripts.Utilities.Transition
{
    /// <summary>
    /// 장면 전환을 관리한다.
    /// </summary>
    public class TransitionManager : SingletonMonoBehaviourFast<TransitionManager>
    {
        /// <summary>
        /// 뚜껑 그림 (전환 애니메이션의 관리 컴포넌트)
        /// 무료 제공되는 Fade 사용
        /// </summary>
        private Fade _transitionComponent;

        /// <summary>
        /// 뚜껑 그림의 Image
        /// </summary>
        private RawImage _image;

        /// <summary>
        /// 장면 전환 작업을 수행 중인지 여부
        /// </summary>
        private bool _isRunning = false;

        public bool IsRunning => _isRunning;

        /// <summary>
        /// 전환 애니메이션을 종료해야 할지 여부
        /// (뚜껑 그림을 여는 애니메이션을 재생해야 할지 여부)
        /// </summary>
        private ReactiveProperty<bool> CanEndTransition = new ReactiveProperty<bool>(false);

        private GameScenes _currentGameScene;

        /// <summary>
        /// 현재 장면 정보
        /// </summary>
        public GameScenes CurrentGameScene => _currentGameScene;

        /// <summary>
        /// 전환 애니메이션의 종료 통지
        /// (뚜껑 그림이 열리거나 닫히는 것을 통지한다)
        /// </summary>
        private Subject<Unit> _onTransactionFinishedInternal = new Subject<Unit>();

        /// <summary>
        /// 전환이 완료되는 장면이 시작되었음을 알린다.
        /// </summary>
        private Subject<Unit> _onTransitionAnimationFinishedSubject = new Subject<Unit>();

        private Subject<Unit> onAllSceneLoaded = new Subject<Unit>();

        /// <summary>
        /// 전체 장면의 로드가 완료되었음을 알린다.
        /// </summary>
        public IObservable<Unit> OnScenesLoaded => onAllSceneLoaded;

        /// <summary>
        /// 전환이 완료가 시작되었음을 알린다
        /// OnCompleted도 세트로 발행 된다.
        /// </summary>
        public IObservable<Unit> OnTransitionAnimationFinished
        {
            get
            {
                if (_isRunning)
                {
                    return _onTransitionAnimationFinishedSubject.FirstOrDefault();
                }
                else
                {
                    // 장면 전환을 실행하지 않는 경우 즉시 값을 반환 한다.
                    return Observable.Return(Unit.Default);
                }
            }
        }

        /// <summary>
        /// 전환 애니메이션을 종료시킨다
        /// (AutoMove = false를 지정했을 때 호출 할 필요가 있다)
        /// </summary>
        public void Open()
        {
            CanEndTransition.Value = true;
        }

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);

            try
            {
                // 현재의 장면을 얻는다.
                _currentGameScene = (GameScenes)Enum.Parse(typeof(GameScenes), SceneManager.GetActiveScene().name, false);
            }
            catch
            {
                Debug.Log("현재 장면의 취득 실패");
                _currentGameScene = GameScenes.Title; // 
            }
        }

        private void Start()
        {
            Initialize();

            // 전환의 종료를 대기하고 게임을 시작하는 같은 설정의 경우를 상정한다.
            // 초기화 직후에 장면 전환 완료 통지를 발생시킨다 (디버깅에서 어떤 장면에서 게임을 시작 할 수 있도록)
            onAllSceneLoaded.OnNext(Unit.Default);
        }

        /// <summary>
        /// 초기화
        /// </summary>
        private void Initialize()
        {
            if (_transitionComponent == null)
            {
                _transitionComponent = GetComponent<Fade>();
                _image = GetComponent<RawImage>();
                _image.raycastTarget = false; // 터치 이벤트를 뚜껑 그림에서는 적용하지 않도록

                // 이 부분은 EMT 설정
                // Fade 사용으로 따로 설정할 내용 없음
            }
        }

        /// <summary>
        /// 장면 전환을 실행한다.
        /// </summary>
        /// <param name="nextScene">다음 장면</param>
        /// <param name="data">다음 장면에 전달하는 데이터</param>
        /// <param name="additiveLoadScenes">추가 로드하는 장면</param>
        /// <param name="autoMove">전환을 자동 전환 할지 여부</param>
        public void StartTransaction(GameScenes nextScene,
            SceneDataPack data, 
            GameScenes[] additiveLoadScenes, 
            bool autoMove)
        {

        }
    }
}