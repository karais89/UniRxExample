using System;

public static class ObservableOperators
{
    public static IObservable<T> FilterOperator<T>(this IObservable<T> source, Func<T, bool> conditionalFunc) 
        => new MyFilter<T>(source, conditionalFunc);
}
