using UnityEngine;
using Effekseer;
using UniRx;
using System;

namespace Samples
{
    /// <summary>
    /// 효과를 재생하여 일정 시간 후에 통지한다.
    /// </summary>
    public class ExplosionEffect : MonoBehaviour
    {
        private EffekseerEmitter _effectEmitter;
        private EffekseerEmitter Emitter
        {
            get
            {
                // 초기화 지연으로 변경
                return _effectEmitter ?? (_effectEmitter = GetComponent<EffekseerEmitter>());
            }
        }

        /// <summary>
        /// 효과를 재생 한다.
        /// </summary>
        /// <param name="positon"> 재생 위치 </param>
        /// <returns> 재생 종료 통지 </returns>
        public IObservable<Unit> PlayEffect(Vector3 positon)
        {
            transform.position = positon;

            // 효과음 재생
            Emitter.Play();

            // 1초 후 효과를 멈추고 종료 통지
            return Observable.Timer(TimeSpan.FromSeconds(1.0f))
                .ForEachAsync(_ => Emitter.Stop());
        }
    }
}