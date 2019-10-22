using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 필터링 오퍼레이터
/// </summary>
public class MyFilter<T> : IObservable<T>
{
    /// <summary>
    /// 상류가 되는 Observable
    /// </summary>
    private IObservable<T> _source;

    /// <summary>
    /// 판정식
    /// </summary>
    private Func<T, bool> _conditionalFunc;

    public MyFilter(IObservable<T> source, Func<T, bool> conditionalFunc)
    {
        _source = source;
        _conditionalFunc = conditionalFunc;
    }
    
    public IDisposable Subscribe(IObserver<T> observer)
    {
        // Subscribe되면 MyFilterOperator 본체를 만들어 반환한다.
        return new MyFilterInternal(this, observer).Run();
    }
    
    // Observer로 MyFilterInternal이 실제로 작동하는 곳
    private class MyFilterInternal : IObserver<T>
    {
        private MyFilter<T> _parent;
        private IObserver<T> _observer;
        private object _lockObject = new object();

        public MyFilterInternal(MyFilter<T> parent, IObserver<T> observer)
        {
            _parent = parent;
            _observer = observer;
        }

        public IDisposable Run()
        {
            return _parent._source.Subscribe(this);
        }

        public void OnNext(T value)
        {
            lock (_lockObject)
            {
                if (_observer == null)
                {
                    return;
                }

                try
                {
                    // 같은 경우에만 OnNext를 통과
                    if (_parent._conditionalFunc(value))
                    {
                        _observer.OnNext(value);
                    }
                }
                catch (Exception e)
                {
                    // 도중에 에러가 발생하면 에러를 전송
                    _observer.OnError(e);
                    _observer = null;
                }
            }
        }

        public void OnError(Exception error)
        {
            lock (_lockObject)
            {
                // 오류를 전파하고 정지
                _observer.OnError(error);
                _observer = null;
            }
        }
        
        public void OnCompleted()
        {
            lock (_lockObject)
            {
                // 정지
                _observer.OnCompleted();
                _observer = null;
            }
        }
    }
}
