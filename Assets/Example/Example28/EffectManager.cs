using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

namespace Samples
{
    /// <summary>
    /// 효과를 생성하는 놈
    /// </summary>
    public class EffectManager : MonoBehaviour
    {
        [SerializeField]
        private Button _button;

        [SerializeField]
        private ExplosionEffect _effectPrefab; // 효과 프리팹
        
        [SerializeField]
        private Transform _hierarchyTransform;

        private EffectPool _effectPool;
        private EffectPoolAsync _effectPoolAsync;

        private void Start()
        {
            // 객체 풀을 생성
            _effectPool = new EffectPool(_hierarchyTransform, _effectPrefab);
            _effectPoolAsync = new EffectPoolAsync(_hierarchyTransform, _effectPrefab);

            // 풀에 사용하지 않는 개체가 있는 경우 RentAsync은 즉시 값을 반환 한다.
            // 객체가 부족한 경우 CreateInstance를 실행하고 그 결과를 갖고 RentAysnc 값을 반환한다.
            _effectPoolAsync.RentAsync().Subscribe(effect =>
            {
                effect.PlayEffect(Vector3.zero).Subscribe(__ => _effectPoolAsync.Return(effect));
            });

            // 파기 될때 Pool 제거
            this.OnDestroyAsObservable().Subscribe(_ => _effectPool.Dispose());

            // 버튼이 눌려 졌을 때 효과 생성
            _button.OnClickAsObservable()
                .Subscribe(_ =>
                {
                    // 임의의 위치
                    var position = new Vector3(Random.Range(-5f, 5f), 0, Random.Range(-5f, 5f));

                    // pool에서 하나 가져온다.
                    var effect = _effectPool.Rent();

                    // 효과를 재생하고 재생이 끝나면 pool에 반환 한다.
                    effect.PlayEffect(position)
                        .Subscribe(__ =>
                        {
                            _effectPool.Return(effect);
                        });
                });
        }
    }
}