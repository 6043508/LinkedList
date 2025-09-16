using CsOpdrachten;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CsOpdrachten
{
    public static class Extensions
    {
        public static IEnumerable<TResult> MySelect<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            ArgumentNullException.ThrowIfNull(source);
            ArgumentNullException.ThrowIfNull(selector);

            foreach (var i in source)
                yield return selector(i);
        }

        public static IEnumerable<TResult> MySelect<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, Int32, TResult> selector)
        {
            ArgumentNullException.ThrowIfNull(source);
            ArgumentNullException.ThrowIfNull(selector);

            int index = 0;
            foreach (var i in source)
            {
                yield return selector(i, index);
                index++;
            }
        }

        public static IEnumerable<TSource> MyWhere<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            ArgumentNullException.ThrowIfNull(source);
            ArgumentNullException.ThrowIfNull(predicate);

            foreach (var i in source)
            {
                if (predicate(i))
                    yield return i;
            }
        }

        public static IEnumerable<TSource> MyWhere<TSource>(this IEnumerable<TSource> source, Func<TSource, Int32, bool> predicate)
        {
            ArgumentNullException.ThrowIfNull(source);
            ArgumentNullException.ThrowIfNull(predicate);

            int index = 0;
            foreach (var i in source)
            {
                if (predicate(i, index))
                {
                    yield return i;
                }
                index++;
            }
        }

        public static int MyCount<TSauce>(this IEnumerable<TSauce> source, Func<TSauce, bool> predicate)
        {

            ArgumentNullException.ThrowIfNull(source);
            ArgumentNullException.ThrowIfNull(predicate);

            int count = 0;

            foreach (var i in source)
            {
                if (predicate(i))
                    count++;
            }
            return count;
        }

        public static int MyCount<TSource> (this IEnumerable<TSource> source)
        {
            ArgumentNullException.ThrowIfNull(source);

            int count = 0;
            foreach (var i in source)
                count++;

            return count;
        }

        public static bool MyAny<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {

            ArgumentNullException.ThrowIfNull(source);
            ArgumentNullException.ThrowIfNull(predicate);

            foreach (var i in source)
                if (predicate(i))
                    return true;
            
            return false;
        }

        public static bool MyAny<TSource>(this IEnumerable<TSource> source)
        {
            ArgumentNullException.ThrowIfNull(source);

            using var enumerator = source.GetEnumerator();
            return enumerator.MoveNext();
        }
        

        public static TSource? MyFirstOrDefault<TSource>(this IEnumerable<TSource> source)
        {
            ArgumentNullException.ThrowIfNull(source);

            foreach (var i in source)
                return i;
            return default;
        }

        public static TSource? MyFirstOrDefault<TSource>(this IEnumerable<TSource> source, TSource value)
        {
            ArgumentNullException.ThrowIfNull(source);

            foreach (var i in source)
                return i;
            return value;
        }

        public static TSource? MyFirstOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            ArgumentNullException.ThrowIfNull(source);
            ArgumentNullException.ThrowIfNull(predicate);

            foreach (var i in source)
                if (predicate(i))
                    return i;

            return default;
        }

        public static TSource? MyFirstOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate, TSource value)
        {
            ArgumentNullException.ThrowIfNull(source);
            ArgumentNullException.ThrowIfNull(predicate);

            foreach (var i in source)
                if (predicate(i))
                    return i;

            return value;
        }
    }
}

