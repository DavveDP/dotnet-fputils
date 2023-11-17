using System;

namespace FPUtils
{
    public abstract class Option<T>
    {
        protected T value;
        protected Option(T value)
        {
            this.value = value;
        }
        public abstract Option<V> Map<V>(Func<T, V> transformation);
        public abstract Option<V> FlatMap<V>(Func<T, Option<V>> transformation);
        public abstract Option<T> Filter(Func<T, bool> predicate);
        public abstract void IfPresent(Action<T> action);
        public abstract T GetOrElse(T other);
        public abstract bool IsEmpty();
        public abstract bool IsPresent();
        public T Get()
        {
            return value;
        }
    }

    public static class Option
    {
        public static Option<T> Of<T>(T value)
        {
            return value != null
                ? new Some<T>(value)
                : new None<T>();
        }
    }
}