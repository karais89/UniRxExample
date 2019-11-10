using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class ConvertFromCoroutine2 : MonoBehaviour
{
    // 이동 좌표 목록
    [SerializeField] private List<Vector2> moveList;
    
    private void Start() =>
        Observable.FromCoroutineValue<Vector2>(MovePositionCoroutine)
            .Subscribe(x => Debug.Log(x));

    /// <summary>
    /// 목록에서 값을 1 프레임씩 꺼내는 코루틴
    /// </summary>
    /// <returns></returns>
    private IEnumerator MovePositionCoroutine()
    {
        foreach (var v in moveList)
        {
            yield return v;
        }
        
        // ↑의 foreach 문은 통째로 
        // "return moveList.GetEnumerator ();"
        // 로 고쳐 써도 된다.
    }
}
