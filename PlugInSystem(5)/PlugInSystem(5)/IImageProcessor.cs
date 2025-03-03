using SixLabors.ImageSharp;

namespace PlugInSystem
{
    public interface IImageProcessor
    {
        string ImagePath { get; }
        Image ProcessImage(Image image);
    }
}
