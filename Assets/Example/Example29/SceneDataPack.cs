using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BirdStrike.MIKOMA.Scripts.Utilities.SceneDataPacks
{
    /// <summary>
    /// 씬 전반에 데이터를 전달할 때 사용 한다.
    /// </summary>
    public abstract class SceneDataPack
    {
        /// <summary>
        /// 이전 씬
        /// </summary>
        public abstract GameScenes PreviousGameScene { get; }

        /// <summary>
        /// 씬에서 추가 로드하는 장면 목록
        /// </summary>
        public abstract GameScenes[] PreviousAdditiveScene { get; }
    }

    /// <summary>
    /// 디폴트 구현
    /// </summary>
    public class DefaultSceneDataPack : SceneDataPack
    {
        private readonly GameScenes _prevGameScenes;
        private readonly GameScenes[] _additiveScenes;

        public GameScenes[] AdditiveScenes => _additiveScenes;

        public override GameScenes PreviousGameScene => _prevGameScenes;

        public override GameScenes[] PreviousAdditiveScene => null;

        public DefaultSceneDataPack(GameScenes prev, GameScenes[] additive)
        {
            _prevGameScenes = prev;
            _additiveScenes = additive;
        }
    }
}