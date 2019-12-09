using UniRx.Toolkit;
using UnityEngine;

namespace Samples
{
    /// <summary>
    /// ExplosionEffect의 Pool
    /// </summary>
    public class EffectPool : ObjectPool<ExplosionEffect>
    {
        private readonly ExplosionEffect _prefab;
        private readonly Transform _parenTransform;

        // 생성자
        public EffectPool(Transform parenTransform, ExplosionEffect prefab)
        {
            _parenTransform = parenTransform;
            _prefab = prefab;
        }

        /// <summary>
        /// 오브젝트의 추가 생성 할 때 실행된다.
        /// </summary>
        /// <returns></returns>
        protected override ExplosionEffect CreateInstance()
        {
            // 새로 생성
            var e = GameObject.Instantiate(_prefab);

            // 계층 구조 정리
            e.transform.SetParent(_parenTransform);

            return e;
        }

        /// <summary>
        /// 개체의 대출시에 실행 된다.
        /// </summary>
        /// <param name="instance"></param>
        protected override void OnBeforeRent(ExplosionEffect instance)
        {
            // 대출 개체의 인스턴스 ID를 출력
            Debug.Log(instance.GetInstanceID());

            // base에서 instance.gameObject.SetActive(true)를 실행한다.
            base.OnBeforeRent(instance);
        }

        protected override void OnBeforeReturn(ExplosionEffect instance)
        {
            // base 에서 instacne.gameObject.SetActive(false)를 실행한다.
            base.OnBeforeReturn(instance);

            // 반환 된 개체의 인스턴스 ID를 출력
            Debug.Log(instance.GetInstanceID());
        }

        protected override void OnClear(ExplosionEffect instance)
        {
            // 삭제 개체의 인스턴스 ID를 출력 한다.
            Debug.Log(instance.GetInstanceID());

            // base에서 Destroy 된다.
            base.OnClear(instance);
        }
    }
}