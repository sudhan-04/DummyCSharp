using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using PlugInSystem;

namespace GrayScaleConverter
{
    internal class GrayScaleConverter : IImageProcessor
    {
        public string ImagePath => "../../../../JJK.jpg";

        public Image ProcessImage(Image image)
        {
            image.Mutate(i => i.BlackWhite());
            return image;
        }
    }
}
