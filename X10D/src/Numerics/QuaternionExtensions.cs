using System.Numerics;

namespace X10D.Numerics;

/// <summary>
///     Numeric-related extension methods for <see cref="Quaternion" />.
/// </summary>
public static class QuaternionExtensions
{
    /// <summary>
    ///     Rotates the specified point with the specified rotation.
    /// </summary>
    /// <param name="rotation">The rotation.</param>
    /// <param name="point">The point.</param>
    /// <returns>The rotated point.</returns>
    public static Vector3 Multiply(this in Quaternion rotation, in Vector3 point)
    {
        // the internet wrote it, I just handed it in.
        // https://github.com/Unity-Technologies/UnityCsReference/blob/master/Runtime/Export/Math/Quaternion.cs
        float x = rotation.X * 2.0f;
        float y = rotation.Y * 2.0f;
        float z = rotation.Z * 2.0f;
        float xx = rotation.X * x;
        float yy = rotation.Y * y;
        float zz = rotation.Z * z;
        float xy = rotation.X * y;
        float xz = rotation.X * z;
        float yz = rotation.Y * z;
        float wx = rotation.W * x;
        float wy = rotation.W * y;
        float wz = rotation.W * z;

        (float px, float py, float pz) = point;

        return new Vector3(
            (1.0f - (yy + zz)) * px + (xy - wz) * py + (xz + wy) * pz,
            (xy + wz) * px + (1.0f - (xx + zz)) * py + (yz - wx) * pz,
            (xz - wy) * px + (yz + wx) * py + (1.0f - (xx + yy)) * pz
        );
    }

    /// <summary>
    ///     Converts this quaternion to an axis/angle pair.
    /// </summary>
    /// <param name="value">The quaternion to convert.</param>
    /// <returns>A tuple containing the converted axis, and the angle in radians.</returns>
    public static (Vector3 Axis, float Angle) ToAxisAngle(this in Quaternion value)
    {
        float angle = 2.0f * MathF.Acos(value.W);
        Vector3 axis = Vector3.Normalize(new Vector3(value.X, value.Y, value.Z));
        return (axis, angle);
    }

    /// <summary>
    ///     Converts this quaternion to a <see cref="Vector3" /> containing an Euler representation of the rotation.
    /// </summary>
    /// <param name="value">The quaternion to convert.</param>
    /// <returns>The Euler representation of <paramref name="value" />, in radians.</returns>
    public static Vector3 ToVector3(this in Quaternion value)
    {
        Quaternion normalized = Quaternion.Normalize(value);
        float qx = normalized.X;
        float qy = normalized.Y;
        float qz = normalized.Z;
        float qw = normalized.W;

        float x = MathF.Asin(-2 * (qx * qy - qz * qw));
        float y = MathF.Atan2(2 * (qy * qw + qx * qz), 1 - 2 * (qy * qy + qx * qx));
        float z = MathF.Atan2(2 * (qx * qw + qy * qz), 1 - 2 * (qz * qz + qw * qw));
        return new Vector3(-x, -y, -z);
    }
}
