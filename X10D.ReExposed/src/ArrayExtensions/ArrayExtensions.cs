namespace X10D.ReExposed.ArrayExtensions;

/// <summary>
///     Extension methods for <see cref="Array"/>
/// </summary>
[SuppressMessage("ReSharper", "UnusedType.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public static class ArrayExtensions
{
    /// <inheritdoc cref="Array.AsReadOnly{T}(T[])"/>
    public static ReadOnlyCollection<T> AsReadOnly<T>(this T[] array)
    {
        return Array.AsReadOnly(array);
    }

    /// <inheritdoc cref="Array.BinarySearch(Array,object)"/>
    public static int BinarySearch(this Array array, object? value)
    {
        return Array.BinarySearch(array, value);
    }

    /// <inheritdoc cref="Array.BinarySearch(Array,int,int,object)"/>
    public static int BinarySearch(this Array array, int index, int length, object? value)
    {
        return Array.BinarySearch(array, index, length, value);
    }

    /// <inheritdoc cref="Array.BinarySearch(Array,object,IComparer)"/>
    public static int BinarySearch(this Array array, object? value, IComparer? comparer)
    {
        return Array.BinarySearch(array, value, comparer);
    }

    /// <inheritdoc cref="Array.BinarySearch(Array,int,int,object,IComparer)"/>
    public static int BinarySearch(this Array array, int index, int length, object? value, IComparer? comparer)
    {
        return Array.BinarySearch(array, index, length, value, comparer);
    }

    /// <inheritdoc cref="Array.BinarySearch{T}(T[],T)"/>
    public static int BinarySearch<T>(this T[] array, T value)
    {
        return Array.BinarySearch(array, value);
    }

    /// <inheritdoc cref="Array.BinarySearch{T}(T[],T,IComparer{T})"/>
    public static int BinarySearch<T>(this T[] array, T value, IComparer<T>? comparer)
    {
        return Array.BinarySearch(array, value, comparer);
    }

    /// <inheritdoc cref="Array.BinarySearch{T}(T[],int,int,T)"/>
    public static int BinarySearch<T>(this T[] array, int index, int length, T value)
    {
        return Array.BinarySearch(array, index, length, value);
    }

    /// <inheritdoc cref="Array.BinarySearch{T}(T[],int,int,T,IComparer{T})"/>
    public static int BinarySearch<T>(this T[] array, int index, int length, T value, IComparer<T>? comparer)
    {
        return Array.BinarySearch(array, index, length, value, comparer);
    }

    /// <inheritdoc cref="Array.Clear(Array,int,int)"/>
    public static void Clear(this Array array, int index, int length)
    {
        Array.Clear(array, index, length);
    }

    /// <inheritdoc cref="Array.Clear(Array)"/>
    public static void Clear(this Array array)
    {
        Array.Clear(array);
    }

    /// <inheritdoc cref="Array.ConstrainedCopy(Array,int,Array,int,int)"/>
    public static void ConstrainedCopy(this Array sourceArray, int sourceIndex, Array destinationArray, int destinationIndex, int length)
    {
        Array.ConstrainedCopy(sourceArray, sourceIndex, destinationArray, destinationIndex, length);
    }

    /// <inheritdoc cref="Array.ConvertAll{TInput,TOutput}(TInput[],Converter{TInput,TOutput})"/>
    public static TOutput[] ConvertAll<TInput, TOutput>(this TInput[] array, Converter<TInput, TOutput> converter)
    {
        return Array.ConvertAll(array, converter);
    }

    /// <inheritdoc cref="Array.Copy(Array,int,Array,int,int)"/>
    public static void Copy(this Array sourceArray, int sourceIndex, Array destinationArray, int destinationIndex, int length)
    {
        Array.Copy(sourceArray, sourceIndex, destinationArray, destinationIndex, length);
    }

    /// <inheritdoc cref="Array.Copy(Array,long,Array,long,long)"/>
    public static void Copy(this Array sourceArray, long sourceIndex, Array destinationArray, long destinationIndex, long length)
    {
        Array.Copy(sourceArray, sourceIndex, destinationArray, destinationIndex, length);
    }

    /// <inheritdoc cref="Array.Exists{T}(T[],Predicate{T})"/>
    public static bool Exists<T>(this T[] array, Predicate<T> match)
    {
        return Array.Exists(array, match);
    }

    /// <inheritdoc cref="Array.Fill{T}(T[],T)"/>
    public static void Fill<T>(this T[] array, T value)
    {
        Array.Fill(array, value);
    }

    /// <inheritdoc cref="Array.Fill{T}(T[],T,int,int)"/>
    public static void Fill<T>(this T[] array, T value, int startIndex, int count)
    {
        Array.Fill(array, value, startIndex, count);
    }

    /// <inheritdoc cref="Array.Find{T}(T[],Predicate{T})"/>
    public static T? Find<T>(this T[] array, Predicate<T> predicate)
    {
        return Array.Find(array, predicate);
    }

    /// <inheritdoc cref="Array.FindAll{T}(T[],Predicate{T})"/>
    public static T[] FindAll<T>(this T[] array, Predicate<T> match)
    {
        return Array.FindAll(array, match);
    }

    /// <inheritdoc cref="Array.FindIndex{T}(T[],Predicate{T})"/>
    public static int FindIndex<T>(this T[] array, Predicate<T> match)
    {
        return Array.FindIndex(array, match);
    }

    /// <inheritdoc cref="Array.FindIndex{T}(T[],int,int,Predicate{T})"/>
    public static int FindIndex<T>(this T[] array, int startIndex, int count, Predicate<T> match)
    {
        return Array.FindIndex(array, startIndex, count, match);
    }

    /// <inheritdoc cref="Array.FindLast{T}(T[],Predicate{T})"/>
    public static T? FindLast<T>(this T[] array, Predicate<T> match)
    {
        return Array.FindLast(array, match);
    }

    /// <inheritdoc cref="Array.FindLastIndex{T}(T[],Predicate{T})"/>
    public static int FindLastIndex<T>(this T[] array, Predicate<T> match)
    {
        return Array.FindLastIndex(array, match);
    }

    /// <inheritdoc cref="Array.FindLastIndex{T}(T[],int,int,Predicate{T})"/>
    public static int FindLastIndex<T>(this T[] array, int startIndex, int count, Predicate<T> match)
    {
        return Array.FindLastIndex(array, startIndex, count, match);
    }

    /// <inheritdoc cref="Array.IndexOf(Array,object)"/>
    public static int IndexOf(this Array array, object? value)
    {
        return Array.IndexOf(array, value);
    }

    /// <inheritdoc cref="Array.IndexOf(Array,object,int)"/>
    public static int IndexOf(this Array array, object? value, int startIndex)
    {
        return Array.IndexOf(array, value, startIndex);
    }

    /// <inheritdoc cref="Array.IndexOf(Array,object,int,int)"/>
    public static int IndexOf(this Array array, object? value, int startIndex, int count)
    {
        return Array.IndexOf(array, value, startIndex, count);
    }

    /// <inheritdoc cref="Array.IndexOf{T}(T[],T)"/>
    public static int IndexOf<T>(this T[] array, T value)
    {
        return Array.IndexOf(array, value);
    }

    /// <inheritdoc cref="Array.IndexOf{T}(T[],T,int)"/>
    public static int IndexOf<T>(this T[] array, T value, int startIndex)
    {
        return Array.IndexOf(array, value, startIndex);
    }

    /// <inheritdoc cref="Array.IndexOf{T}(T[],T,int,int)"/>
    public static int IndexOf<T>(this T[] array, T value, int startIndex, int count)
    {
        return Array.IndexOf(array, value, startIndex, count);
    }

    /// <inheritdoc cref="Array.Reverse(Array)"/>
    public static void Reverse(this Array array)
    {
        Array.Reverse(array);
    }

    /// <inheritdoc cref="Array.Reverse(Array,int,int)"/>
    public static void Reverse(this Array array, int index, int length)
    {
        Array.Reverse(array, index, length);
    }

    /// <inheritdoc cref="Array.Reverse{T}(T[])"/>
    public static void Reverse<T>(this T[] array)
    {
        Array.Reverse(array);
    }

    /// <inheritdoc cref="Array.Reverse{T}(T[],int,int)"/>
    public static void Reverse<T>(this T[] array, int index, int length)
    {
        Array.Reverse(array, index, length);
    }

    /// <inheritdoc cref="Array.Sort(Array,IComparer)"/>
    public static void Sort(this Array array, IComparer? comparer)
    {
        Array.Sort(array, comparer);
    }

    /// <inheritdoc cref="Array.Sort(Array,Array,IComparer)"/>
    public static void Sort(this Array keys, Array? items, IComparer? comparer)
    {
        Array.Sort(keys, items, comparer);
    }

    /// <inheritdoc cref="Array.Sort(Array,int,int,IComparer)"/>
    public static void Sort(this Array array, int index, int length, IComparer? comparer)
    {
        Array.Sort(array, index, length, comparer);
    }

    /// <inheritdoc cref="Array.Sort(Array,Array,int,int,IComparer)"/>
    public static void Sort(this Array keys, Array? items, int index, int length, IComparer? comparer)
    {
        Array.Sort(keys, items, index, length, comparer);
    }

    /// <inheritdoc cref="Array.Sort{T}(T[])"/>
    public static void Sort<T>(this T[] array)
    {
        Array.Sort(array);
    }

    /// <inheritdoc cref="Array.Sort{TKey,TValue}(TKey[],TValue[])"/>
    public static void Sort<TKey, TValue>(this TKey[] keys, TValue[]? items)
    {
        Array.Sort(keys, items);
    }

    /// <inheritdoc cref="Array.Sort{T}(T[],int,int)"/>
    public static void Sort<T>(this T[] array, int index, int length)
    {
        Array.Sort(array, index, length);
    }

    /// <inheritdoc cref="Array.Sort{TKey,TValue}(TKey[],TValue[],int,int)"/>
    public static void Sort<TKey, TValue>(this TKey[] keys, TValue[]? items, int index, int length)
    {
        Array.Sort(keys, items, index, length);
    }

    /// <inheritdoc cref="Array.Sort{T}(T[],IComparer{T})"/>
    public static void Sort<T>(this T[] array, IComparer<T>? comparer)
    {
        Array.Sort(array, comparer);
    }

    /// <inheritdoc cref="Array.Sort{TKey,TValue}(TKey[],TValue[],IComparer{TKey})"/>
    public static void Sort<TKey, TValue>(this TKey[] keys, TValue[]? items, IComparer<TKey>? comparer)
    {
        Array.Sort(keys, items, comparer);
    }

    /// <inheritdoc cref="Array.Sort{T}(T[],int,int,IComparer{T})"/>
    public static void Sort<T>(this T[] array, int index, int length, IComparer<T>? comparer)
    {
        Array.Sort(array, index, length, comparer);
    }

    /// <inheritdoc cref="Array.Sort{TKey,TValue}(TKey[],TValue[],int,int,IComparer{TKey})"/>
    public static void Sort<TKey, TValue>(this TKey[] keys, TValue[]? items, int index, int length, IComparer<TKey>? comparer)
    {
        Array.Sort(keys, items, index, length, comparer);
    }

    /// <inheritdoc cref="Array.Sort{T}(T[],Comparison{T})"/>
    public static void Sort<T>(this T[] array, Comparison<T> comparison)
    {
        Array.Sort(array, comparison);
    }

    /// <inheritdoc cref="Array.TrueForAll{T}(T[],Predicate{T})"/>
    public static bool TrueForAll<T>(this T[] array, Predicate<T> match)
    {
        return Array.TrueForAll(array, match);
    }
}