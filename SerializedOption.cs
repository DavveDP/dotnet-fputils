using System;

namespace FPUtils.Unity
{
    [Serializable]
    public class SerializedOption<T> : Option<T>
    {
        new public T value;

        public SerializedOption(T value) : base(value)
        {
        }

        public override Option<T> Filter(Func<T, bool> predicate)
        {
            return Option.Of(value).Filter(predicate);
        }

        public override Option<V> FlatMap<V>(Func<T, Option<V>> transformation)
        {
            return Option.Of(value).FlatMap(transformation);
        }

        public override T GetOrElse(T other)
        {
            return Option.Of(value).GetOrElse(other);
        }

        public override void IfPresent(Action<T> action)
        {
            Option.Of(value).IfPresent(action);
        }

        public override bool IsEmpty()
        {
            return Option.Of(value).IsEmpty();
        }

        public override bool IsPresent()
        {
            return Option.Of(value).IsPresent();
        }

        public override Option<V> Map<V>(Func<T, V> transformation)
        {
            return Option.Of(value).Map(transformation);
        }
    }
}