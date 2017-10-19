using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ConsoleApp26
{
    /// <summary>
    /// チャート → WPF向けオブジェクトの作成
    /// </summary>
    public static class ImageFactory
    {
        public static ImageBrush CreateImageBrush(Rgb24ImageBuffer buffer)
        {
            return new ImageBrush()
            {
                ImageSource = CreateImageSource(buffer)
            };
        }

        public static ImageSource CreateImageSource(Rgb24ImageBuffer buffer)
        {
            return BitmapSource.Create(buffer.X, buffer.Y, 96, 96, PixelFormats.Rgb24, null, buffer.GetBuffer(), buffer.RawStride);
        }
    }
}
