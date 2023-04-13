namespace X10D.ReExposed.ArrayExtensions;

/// <summary>
///     Extension methods for <see cref="Array"/>
/// </summary>
[SuppressMessage("ReSharper", "UnusedType.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public static class ArrayExtensions
{
    /// <inheritdoc cref="Array.AsReadOnly{T}(T[])"/>
    public static ReadOnlyCollection<T> AsReadOnly<T>(this T[] values)
    {
        return Array.AsReadOnly(values);
    }

    /// <inheritdoc cref="Array.BinarySearch(Array,int,int,object,IComparer)"/>
    public static int BinarySearch(this Array array, object? value, int index = 0, int? length = null, IComparer? comparer = null)
    {
        return Array.BinarySearch(array, index, length ?? array.Length - index, value, comparer);
    }

    /// <inheritdoc cref="Array.BinarySearch{T}(T[],int,int,T,IComparer{T})"/>
    public static int BinarySearch<T>(this T[] values, T? value, int index = 0, int? length = null, IComparer<T?>? comparer = null)
    {
        return Array.BinarySearch(values, index, length ?? values.Length - index, value, comparer);
    }

    /// <inheritdoc cref="Array.Clear(Array,int,int)"/>
    public static void Clear(this Array array, int index, int length)
    {
        Array.Clear(array, index, length);
    }

    /// <inheritdoc cref="Array.Clear(Array)"/>
    public static void Clear<T>(this T?[] array)
    {
        Array.Clear(array);
    }

    /// <inheritdoc cref="Array.ConstrainedCopy(Array,int,Array,int,int)"/>
    public static void ConstrainedCopy(this Array sourceArray, int sourceIndex, Array destinationArray, int destinationIndex, int length)
    {
        Array.ConstrainedCopy(sourceArray, sourceIndex, destinationArray, destinationIndex, length);
    }

    /// <inheritdoc cref="Array.ConvertAll{TFrom,TTo}(TFrom[],Converter{TFrom,TTo})"/>
    public static TTo[] ConvertAll<TFrom, TTo>(this TFrom[] values, Converter<TFrom, TTo> converter)
    {
        return Array.ConvertAll(values, converter);
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
    public static bool Exists<T>(this T[] values, Predicate<T> match)
    {
        return Array.Exists(values, match);
    }

    /// <inheritdoc cref="Array.Fill{T}(T[],T,int,int)"/>
    public static void Fill<T>(this T[] values, T fillValue, int startIndex = 0, int? count = null)
    {
        Array.Fill(values, fillValue, startIndex, count ?? values.Length - startIndex);
    }

    /// <inheritdoc cref="Array.Find{T}(T[],Predicate{T})"/>
    public static T? Find<T>(this T[] values, Predicate<T> predicate)
    {
        return Array.Find(values, predicate);
    }

    /// <inheritdoc cref="Array.FindAll{T}(T[],Predicate{T})"/>
    public static T[] FindAll<T>(this T[] values, Predicate<T> match)
    {
        return Array.FindAll(values, match);
    }

    /// <inheritdoc cref="Array.FindIndex{T}(T[],int,int,Predicate{T})"/>
    public static int FindIndex<T>(this T[] values, Predicate<T> match, int index = 0, int? count = null)
    {
        return Array.FindIndex(values, index, count ?? values.Length - index, match);
    }

    /// <inheritdoc cref="Array.FindLast{T}(T[],Predicate{T})"/>
    public static T? FindLast<T>(this T[] values, Predicate<T> match)
    {
        return Array.FindLast(values, match);
    }

    /// <inheritdoc cref="Array.FindLastIndex{T}(T[],int,int,Predicate{T})"/>
    public static int FindLastIndex<T>(this T[] values, Predicate<T> match, int index = 0, int? count = null)
    {
        return Array.FindLastIndex(values, index, count ?? values.Length - index, match);
    }

    /// <inheritdoc cref="Array.IndexOf(Array,object,int,int)"/>
    public static int IndexOf(this Array array, object? value, int index = 0, int? count = null)
    {
        return Array.IndexOf(array, value, index, count ?? array.Length - index);
    }

    /// <inheritdoc cref="Array.IndexOf{T}(T[],T,int,int)"/>
    public static int IndexOf<T>(this T[] values, T value, int index = 0, int? count = null)
    {
        return Array.IndexOf(values, value, index, count ?? values.Length - index);
    }

    /// <inheritdoc cref="Array.Reverse(Array,int,int)"/>
    public static void Reverse(this Array value, int startIndex = 0, int? length = null)
    {
        Array.Reverse(value, startIndex, length ?? value.Length - startIndex);
    }

    /// <inheritdoc cref="Array.Reverse{T}(T[],int,int)"/>
    public static void Reverse<T>(this T[] values, int startIndex = 0, int? length = null)
    {
        Array.Reverse(values, startIndex, length ?? values.Length - startIndex);
    }

    /// <inheritdoc cref="Array.Sort(Array,Array,int,int,IComparer)"/>
    public static void Sort(this Array keys, Array? items = null, int index = 0, int? length = null, IComparer? comparer = null)
    {
        Array.Sort(keys, items, index, length ?? keys.Length - index, comparer);
    }

    /// <inheritdoc cref="Array.Sort{TKey,TValue}(TKey[],TValue[],int,int,IComparer{TKey})"/>
    public static void Sort<TKey, TValue>(this TKey[] keys,
                                          TValue[]? items = null,
                                          int index = 0,
                                          int? length = null,
                                          IComparer<TKey>? comparer = null)
    {
        Array.Sort(keys, items, index, length ?? keys.Length - index, comparer);
    }

    /// <inheritdoc cref="Array.Sort{T}(T[],int,int,IComparer{T})"/>
    public static void Sort<T>(this T[] values, int index = 0, int? length = null, IComparer<T>? comparer = null)
    {
        Array.Sort(values, index, length ?? values.Length - index, comparer);
    }

    /// <inheritdoc cref="Array.Sort{T}(T[],Comparison{T})"/>
    public static void Sort<T>(this T[] values, Comparison<T> comparison)
    {
        Array.Sort(values, comparison);
    }

    /// <inheritdoc cref="Array.TrueForAll{T}(T[],Predicate{T})"/>
    public static bool TrueForAll<T>(this T[] values, Predicate<T> match)
    {
        return Array.TrueForAll(values, match);
    }
}