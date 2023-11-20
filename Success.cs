using System;
using System.Diagnostics.Contracts;

namespace FPUtils
{
    public sealed class Success<T> : Try<T>
    {
        internal Success(T value) : base(value)
        {
        }

        public override Try<V> Map<V>(Func<T, V> transformation)
        {
            try
            {
                return new Success<V>(transformation.Invoke(value));
            }
            catch (Exception)
            {
                return new Failure<V>();
            }
        }

        public override Try<V> FlatMap<V>(Func<T, Try<V>> transformation)
        {
            return Map(transformation).Get();
        }

        public override Try<T> Filter(Func<T, bool> predicate)
        {
            try
            {
                return predicate.Invoke(value)
                    ? this
                    : new Failure<T>();
            }
            catch (Exception)
            {
                return new Failure<T>();
            }
        }

        public override void IfSuccess(Action<T> action)
        {
            action.Invoke(value);
        }

        public override T GetOrElse(T other)
        {
            return value;
        }

        public override bool IsFailure()
        {
            return false;
        }

        public override bool IsSuccess()
        {
            return true;
        }

        public override Option<T> ToOption()
        {
            return Option.Of(value);
        }
    }
}