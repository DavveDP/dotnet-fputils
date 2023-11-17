namespace Monads;

public sealed class Some<T> : Option<T>
{
    internal Some(T value) : base(value)
    {
    }

    public override Option<V> Map<V>(Func<T, V> transformation)
    {
        if (transformation == null)
        {
            return new None<V>();
        }
        return transformation.Invoke(value) is V result
            ? new Some<V>(result)
            : new None<V>();
    }

    public override Option<V> FlatMap<V>(Func<T, Option<V>> transformation)
    {
        return Map(transformation).Get();
    }

    public override Option<T> Filter(Func<T, bool> predicate)
    {
        return predicate.Invoke(value)
            ? this
            : new None<T>();
    }

    public override void IfPresent(Action<T> action)
    {
        action.Invoke(value);
    }

    public override T GetOrElse(T other)
    {
        return value;
    }

    public override bool IsEmpty()
    {
        return false;
    }

    public override bool IsPresent()
    {
        return true;
    }
}