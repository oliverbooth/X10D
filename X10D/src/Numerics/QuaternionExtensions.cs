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
}
