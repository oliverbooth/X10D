namespace X10D.ReExposed.VectorExtensions;

/// <summary>
///     Extensions for <see cref="Vector2"/>.
/// </summary>
[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public static class VectorExtensions
{
    /// <inheritdoc cref="Vector2.Abs"/>
    public static Vector2 Abs(this Vector2 value)
    {
        return Vector2.Abs(value);
    }

    /// <inheritdoc cref="Vector2.Clamp"/>
    public static Vector2 Clamp(this Vector2 value1, Vector2 min, Vector2 max)
    {
        return Vector2.Clamp(value1, min, max);
    }

    /// <inheritdoc cref="Vector2.Distance"/>
    public static float Distance(this Vector2 value1, Vector2 value2)
    {
        return Vector2.Distance(value1, value2);
    }

    /// <inheritdoc cref="Vector2.DistanceSquared"/>
    public static float DistanceSquared(this Vector2 value1, Vector2 value2)
    {
        return Vector2.DistanceSquared(value1, value2);
    }

    /// <inheritdoc cref="Vector2.Dot"/>
    public static float Dot(this Vector2 value1, Vector2 value2)
    {
        return Vector2.Dot(value1, value2);
    }

    /// <inheritdoc cref="Vector2.Lerp"/>
    public static Vector2 Lerp(this float amount, Vector2 value1, Vector2 value2)
    {
        return Vector2.Lerp(value1, value2, amount);
    }

    /// <inheritdoc cref="Vector2.Lerp"/>
    public static Vector2 LerpTo(this Vector2 value1, Vector2 value2, float amount)
    {
        return Vector2.Lerp(value1, value2, amount);
    }

    /// <inheritdoc cref="Vector2.Max"/>
    public static Vector2 Max(this Vector2 value1, Vector2 value2)
    {
        return Vector2.Max(value1, value2);
    }

    /// <inheritdoc cref="Vector2.Min"/>
    public static Vector2 Min(this Vector2 value1, Vector2 value2)
    {
        return Vector2.Min(value1, value2);
    }

    /// <inheritdoc cref="Vector2.Normalize"/>
    public static Vector2 Normalize(this Vector2 value)
    {
        return Vector2.Normalize(value);
    }

    /// <inheritdoc cref="Vector2.Reflect"/>
    public static Vector2 Reflect(this Vector2 vector, Vector2 normal)
    {
        return Vector2.Reflect(vector, normal);
    }

    /// <inheritdoc cref="Vector2.SquareRoot"/>
    public static Vector2 SquareRoot(this Vector2 value)
    {
        return Vector2.SquareRoot(value);
    }

    /// <inheritdoc cref="Vector2.Transform(Vector2,Matrix3x2)"/>
    public static Vector2 Transform(this Vector2 position, Matrix3x2 matrix)
    {
        return Vector2.Transform(position, matrix);
    }

    /// <inheritdoc cref="Vector2.Transform(Vector2,Matrix4x4)"/>
    public static Vector2 Transform(this Vector2 position, Matrix4x4 matrix)
    {
        return Vector2.Transform(position, matrix);
    }

    /// <inheritdoc cref="Vector2.Transform(Vector2,Quaternion)"/>
    public static Vector2 Transform(this Vector2 position, Quaternion rotation)
    {
        return Vector2.Transform(position, rotation);
    }

    /// <inheritdoc cref="Vector2.TransformNormal(Vector2,Matrix3x2)"/>
    public static Vector2 TransformNormal(this Vector2 normal, Matrix3x2 matrix)
    {
        return Vector2.TransformNormal(normal, matrix);
    }

    /// <inheritdoc cref="Vector2.TransformNormal(Vector2,Matrix4x4)"/>
    public static Vector2 TransformNormal(this Vector2 normal, Matrix4x4 matrix)
    {
        return Vector2.TransformNormal(normal, matrix);
    }
}