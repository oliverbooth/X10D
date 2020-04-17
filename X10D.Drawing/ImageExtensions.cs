namespace X10D.Drawing
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for <see cref="Image"/>.
    /// </summary>
    public static class ImageExtensions
    {
        /// <summary>
        /// Asynchronously converts the image so that its aspect ratio is 1:1, surrounding any new area with
        /// transparency.
        /// </summary>
        /// <param name="image">The image to convert.</param>
        /// <returns>Returns an <see cref="Image"/>.</returns>
        public static async Task<Image> ToSquareAsync(this Image image)
        {
            return await Task.Run(image.ToSquare);
        }

        /// <summary>
        /// Asynchronously converts the image so that its aspect ratio is 1:1, surrounding any new area with
        /// transparency.
        /// </summary>
        /// <param name="image">The image to convert.</param>
        /// <param name="size">The new size of the image, i.e. the value of both the width and height.</param>
        /// <returns>Returns an <see cref="Image"/>.</returns>
        public static async Task<Image> ToSquareAsync(this Image image, int size)
        {
            return await Task.Run(() => image.ToSquare(size));
        }

        /// <summary>
        /// Asynchronously converts the image so that its aspect ratio is 1:1, surrounding any new area with a
        /// specified background color.
        /// </summary>
        /// <param name="image">The image to convert.</param>
        /// <param name="size">The new size of the image, i.e. the value of both the width and height.</param>
        /// <param name="background">The background color to fill.</param>
        /// <returns>Returns an <see cref="Image"/>.</returns>
        public static async Task<Image> ToSquareAsync(this Image image, int size, Color background)
        {
            return await Task.Run(() => image.ToSquare(size, background));
        }

        /// <summary>
        /// Asynchronously converts the image so that its aspect ratio is 1:1, surrounding any new area with a
        /// specified background color.
        /// </summary>
        /// <param name="image">The image to convert.</param>
        /// <param name="background">The background color to fill.</param>
        /// <returns>Returns an <see cref="Image"/>.</returns>
        public static async Task<Image> ToSquareAsync(this Image image, Color background)
        {
            return await Task.Run(() => image.ToSquare(background));
        }

        /// <summary>
        /// Converts the image so that its aspect ratio is 1:1, surrounding any new area with transparency.
        /// </summary>
        /// <param name="image">The image to convert.</param>
        /// <returns>Returns an <see cref="Image"/>.</returns>
        public static Image ToSquare(this Image image)
        {
            return image.ToSquare(Color.Transparent);
        }

        /// <summary>
        /// Converts the image so that its aspect ratio is 1:1, surrounding any new area with transparency.
        /// </summary>
        /// <param name="image">The image to convert.</param>
        /// <param name="size">The new size of the image, i.e. the value of both the width and height.</param>
        /// <returns>Returns an <see cref="Image"/>.</returns>
        public static Image ToSquare(this Image image, int size)
        {
            return image.ToSquare(size, Color.Transparent);
        }

        /// <summary>
        /// Converts the image so that its aspect ratio is 1:1, surrounding any new area with a specified background
        /// color.
        /// </summary>
        /// <param name="image">The image to convert.</param>
        /// <param name="background">The background color to fill.</param>
        /// <returns>Returns an <see cref="Image"/>.</returns>
        public static Image ToSquare(this Image image, Color background)
        {
            int resolution = Math.Max(image.Width, image.Height);
            return image.ToSquare(resolution, background);
        }

        /// <summary>
        /// Converts the image so that its aspect ratio is 1:1, surrounding any new area with a specified background
        /// color.
        /// </summary>
        /// <param name="image">The image to convert.</param>
        /// <param name="size">The new size of the image, i.e. the value of both the width and height.</param>
        /// <param name="background">The background color to fill.</param>
        /// <returns>Returns an <see cref="Image"/>.</returns>
        public static Image ToSquare(this Image image, int size, Color background)
        {
            int    resolution = Math.Max(image.Width, image.Height);
            Bitmap newImage   = new Bitmap(resolution, resolution);

            using (Graphics graphics = Graphics.FromImage(newImage))
            {
                graphics.FillRectangle(new SolidBrush(background), new Rectangle(0, 0,
                                                                                 resolution, resolution));

                graphics.DrawImageUnscaled(image, resolution / 2 - image.Width  / 2,
                                           resolution        / 2 - image.Height / 2);
            }

            return newImage.Scale(size, size);
        }

        /// <summary>
        /// Asynchronously scales the image.
        /// </summary>
        /// <param name="image">The image to scale.</param>
        /// <param name="width">The new width.</param>
        /// <param name="height">The new height.</param>
        /// <returns>Returns a new <see cref="Image"/>.</returns>
        public static async Task<Bitmap> ScaleAsync(this Image image, int width, int height)
        {
            return await Task.Run(() => image.Scale(width, height));
        }

        /// <summary>
        /// Asynchronously scales the image.
        /// </summary>
        /// <param name="image">The image to scale.</param>
        /// <param name="factor">The scale factor.</param>
        /// <returns>Returns a new <see cref="Image"/>.</returns>
        public static async Task<Bitmap> ScaleAsync(this Image image, float factor)
        {
            return await Task.Run(() => image.Scale(factor));
        }

        /// <summary>
        /// Scales the image.
        /// </summary>
        /// <param name="image">The image to scale.</param>
        /// <param name="factor">The scale factor.</param>
        /// <returns>Returns a new <see cref="Image"/>.</returns>
        public static Bitmap Scale(this Image image, float factor)
        {
            return image.Scale((int) (image.Width * factor), (int) (image.Height * factor));
        }

        /// <summary>
        /// Scales the image.
        /// </summary>
        /// <param name="image">The image to scale.</param>
        /// <param name="width">The new width.</param>
        /// <param name="height">The new height.</param>
        /// <returns>Returns a new <see cref="Image"/>.</returns>
        public static Bitmap Scale(this Image image, int width, int height)
        {
            Rectangle destRect  = new Rectangle(0, 0, width, height);
            Bitmap    destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (Graphics graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode    = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode  = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode      = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode    = PixelOffsetMode.HighQuality;

                using (ImageAttributes wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel,
                                       wrapMode);
                }
            }

            return destImage;
        }
    }
}
