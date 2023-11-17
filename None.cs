using System;

namespace FPUtils
{
    public sealed class None<T> : Option<T>
    {
        internal None() : base(default)
        {
        }

        public override Option<V> Map<V>(Func<T, V> transformation)
        {
            return new None<V>();
        }

        public override Option<V> FlatMap<V>(Func<T, Option<V>> transformation)
        {
            return new None<V>();
        }

        public override Option<T> Filter(Func<T, bool> predicate)
        {
            return this;
        }

        public override void IfPresent(Action<T> action)
        {
            return;
        }

        public override T GetOrElse(T other)
        {
            return other;
        }

        public override bool IsEmpty()
        {
            return true;
        }

        public override bool IsPresent()
        {
            return false;
        }
    }
}