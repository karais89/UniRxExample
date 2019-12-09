using System;
using UniRx;
using UniRx.Toolkit;
using UnityEngine;

namespace Samples
{
    /// <summary>
    /// EffectPool의 Async 버전
    /// </summary>
    public class EffectPoolAsync : AsyncObjectPool<ExplosionEffect>
    {
        private readonly ExplosionEffect _prefab;
        private readonly Transform _parenTransform;

        public EffectPoolAsync(Transform parenTransform, ExplosionEffect prefab)
        {
            _parenTransform = parenTransform;
            _prefab = prefab;
        }

        /// <summary>
        /// 비동기적으로 인스턴스를 생성한다.
        /// </summary>
        /// <returns></returns>
        protected override IObservable<ExplosionEffect> CreateInstanceAsync()
        {
            var e = GameObject.Instantiate(_prefab);
            e.transform.SetParent(_parenTransform);

            // 이번 예에서는 비동기 요소가 없기 때문에 Observable.Return에서 값을 그대로 반환하고 종료한다.
            return Observable.Return(e);
        }
    }
}