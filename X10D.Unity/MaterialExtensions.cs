namespace X10D.Unity
{
    #region Using Directives

    using System.Diagnostics.CodeAnalysis;
    using UnityEngine;

    #endregion

    /// <summary>
    /// A set of extension methods for <see cref="Material"/>.
    /// </summary>
    public static class MaterialExtensions
    {
        private static readonly int srcBlend = Shader.PropertyToID("_SrcBlend");
        private static readonly int dstBlend = Shader.PropertyToID("_DstBlend");
        private static readonly int zWrite   = Shader.PropertyToID("_ZWrite");

        /// <summary>
        /// An enumeration of blend modes.
        /// </summary>
        public enum BlendMode
        {
            Opaque,
            Cutout,
            Fade,
            Transparent
        }

        /// <summary>
        /// Changes the material's blend mode.
        /// </summary>
        /// <param name="material">The material.</param>
        /// <param name="blendMode">The blend mode.</param>
        [SuppressMessage("ReSharper", "StringLiteralTypo")]
        public static void ChangeRenderMode(this Material material, BlendMode blendMode)
        {
            switch (blendMode)
            {
                case BlendMode.Opaque:
                    material.SetInt(srcBlend, (int)UnityEngine.Rendering.BlendMode.One);
                    material.SetInt(dstBlend, (int)UnityEngine.Rendering.BlendMode.Zero);
                    material.SetInt(zWrite,   1);
                    material.DisableKeyword("_ALPHATEST_ON");
                    material.DisableKeyword("_ALPHABLEND_ON");
                    material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                    material.renderQueue = -1;
                    break;

                case BlendMode.Cutout:
                    material.SetInt(srcBlend, (int)UnityEngine.Rendering.BlendMode.One);
                    material.SetInt(dstBlend, (int)UnityEngine.Rendering.BlendMode.Zero);
                    material.SetInt(zWrite,   1);
                    material.EnableKeyword("_ALPHATEST_ON");
                    material.DisableKeyword("_ALPHABLEND_ON");
                    material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                    material.renderQueue = 2450;
                    break;

                case BlendMode.Fade:
                    material.SetInt(srcBlend, (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                    material.SetInt(dstBlend, (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                    material.SetInt(zWrite,   0);
                    material.DisableKeyword("_ALPHATEST_ON");
                    material.EnableKeyword("_ALPHABLEND_ON");
                    material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                    material.renderQueue = 3000;
                    break;

                case BlendMode.Transparent:
                    material.SetInt(srcBlend, (int)UnityEngine.Rendering.BlendMode.One);
                    material.SetInt(dstBlend, (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                    material.SetInt(zWrite,   0);
                    material.DisableKeyword("_ALPHATEST_ON");
                    material.DisableKeyword("_ALPHABLEND_ON");
                    material.EnableKeyword("_ALPHAPREMULTIPLY_ON");
                    material.renderQueue = 3000;
                    break;
            }
        }
    }
}
