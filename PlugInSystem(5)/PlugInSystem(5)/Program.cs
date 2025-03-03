using System.Reflection;
using PlugInSystem;
using SixLabors.ImageSharp;

public class Program
{
    static void Main()
    {
        string pluginPath = "../../../../Plugins/";
        string[] dllPaths = Directory.GetFiles(pluginPath, "*.dll");

        List<Assembly> assemblies = new List<Assembly>();

        // Load all DLLs
        foreach (string path in dllPaths)
        {
            assemblies.Add(Assembly.LoadFrom(path));
        }

        var processorTypes = assemblies
            .SelectMany(a => a.GetTypes())
            .Where(t => typeof(IImageProcessor).IsAssignableFrom(t) && !t.IsInterface);

        foreach (var type in processorTypes)
        {
            if (Activator.CreateInstance(type) is IImageProcessor imageProcessor)
            {
                Image inputImage = Image.Load(imageProcessor.ImagePath);
                Image outputImage = imageProcessor.ProcessImage(inputImage);

                string outputPath = $"../../../../{imageProcessor.GetType().Name}_Processed.jpg";
                outputImage.Save(outputPath);

                Console.WriteLine($"Processed image saved: {outputPath}");
            }
        }
    }
}
