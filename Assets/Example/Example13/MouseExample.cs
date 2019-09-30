using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class MouseExample : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        var mouseMove = this.UpdateAsObservable()
            .Select(_ => Input.mousePosition);
        var mouseDown = this.OnMouseDownAsObservable();
        var mouseUp = this.OnMouseUpAsObservable();

        mouseMove
            .SkipUntil(mouseDown)
            .TakeUntil(mouseUp)
            .RepeatUntilDestroy(gameObject)
            .Subscribe(pos => Debug.Log(pos.x));
    }
}
