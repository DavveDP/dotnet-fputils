using System;

namespace FPUtils
{
    public sealed class Failure<T> : Try<T>
    {
        internal Failure() : base(default)
        {
        }

        public override Try<T> Filter(Func<T, bool> predicate)
        {
            return this;
        }

        public override Try<V> FlatMap<V>(Func<T, Try<V>> transformation)
        {
            return new Failure<V>();
        }

        public override T GetOrElse(T other)
        {
            return other;
        }

        public override void IfSuccess(Action<T> action)
        {
            return;
        }

        public override bool IsFailure()
        {
            return true;
        }

        public override bool IsSuccess()
        {
            return false;
        }

        public override Try<V> Map<V>(Func<T, V> transformation)
        {
            return new Failure<V>();
        }

        public override Option<T> ToOption()
        {
            return new None<T>();
        }
    }    
}