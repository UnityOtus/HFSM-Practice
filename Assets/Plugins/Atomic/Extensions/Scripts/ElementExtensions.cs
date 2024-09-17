using System;
using System.Runtime.CompilerServices;
using Atomic.Elements;

namespace Atomic.Extensions
{
    public static class ElementExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Let<T>(this T it, Action<T> let)
        {
            let.Invoke(it);
            return it;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AtomicValue<T> AsValue<T>(this T it)
        {
            return new AtomicValue<T>(it);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AtomicVariable<T> AsVariable<T>(this T it)
        {
            return new AtomicVariable<T>(it);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AtomicFunction<R> AsFunction<T, R>(this T it, Func<T, R> func)
        {
            return new AtomicFunction<R>(() => func.Invoke(it));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AtomicFunction<bool> AsNot(this IAtomicValue<bool> it)
        {
            return new AtomicFunction<bool>(() => !it.Value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AtomicProperty<R> AsProperty<T, R>(this T it, Func<T, R> getter, Action<T, R> setter)
        {
            return new AtomicProperty<R>(() => getter.Invoke(it), value => setter.Invoke(it, value));
        }
    }
}