using System;

namespace FPUtils
{
    public abstract class Try<T>
    {
        protected T value;
        protected Try(T value)
        {
            this.value = value;
        }
        public abstract Try<V> Map<V>(Func<T, V> transformation);
        public abstract Try<V> FlatMap<V>(Func<T, Try<V>> transformation);
        public abstract Try<T> Filter(Func<T, bool> predicate);
        public abstract void IfSuccess(Action<T> action);
        public abstract T GetOrElse(T other);
        public abstract bool IsFailure();
        public abstract bool IsSuccess();
        public T Get() 
        {
            return value;
        }
        public abstract Option<T> ToOption();
    }

    public static class Try
    {
        public static Try<T> Do<T>(Func<T> expression)
        {
            try
            {
                return new Success<T>(expression.Invoke());
            }
            catch (Exception e)
            {
                return new Failure<T>();
            }
        }
    }
}