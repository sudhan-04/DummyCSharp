using System.Security.Cryptography.X509Certificates;

public class Program
{
    static void Main()
    {
        BoilerTemperatureReader tempReader = new BoilerTemperatureReader();
        tempReader.GetBoilerTemperature();
        tempReader.GetBoilerTemperature();
        tempReader.GetBoilerTemperature();
        tempReader.GetBoilerTemperature();
    }

    
}

public class BoilerTemperatureReader
{
    public delegate TempNotifier(double temperature);
    public event TempNotifier();

    public double ReadTemperature()
    {
        double minTemp = 80.0;
        double maxTemp = 120.0;
        double temperature = minTemp + new Random().NextDouble() * (maxTemp - minTemp);


        return temperature;
    }

    public void TempNotifier()
    {
    }
}

public class PhoneReader
{
    public void DisplayAlert(double currentTemp)
    {
        if(currentTemp > 110)
        Console.WriteLine($"{currentTemp}---Alert in phone");
    }
}

public class LaptopReader
{
    public void DisplayAlert(double currentTemp)
    {
        if(currentTemp > 100)
        Console.WriteLine($"{currentTemp}---Alert in laptop");
    }
}
