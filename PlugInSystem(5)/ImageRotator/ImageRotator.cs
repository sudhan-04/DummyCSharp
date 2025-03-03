using PlugInSystem;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace ImageRotator
{
    internal class ImageRotator : IImageProcessor
    {
        public string ImagePath => "../../../../JJK.jpg";

        public Image ProcessImage(Image image)
        {
            image.Mutate(image => image.Rotate(SelectRotateMode()));
            return image;
        }

        private float SelectRotateMode()
        {
            Console.Write("Select an angle to rotate the image : ");
            float rotateAngle = float.Parse( Console.ReadLine() );
            return rotateAngle;
        }
    }
}
