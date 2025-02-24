using System.Globalization;
using System.Timers;
using CsvHelper;

public class Program
{
    static void Main()
    {
        double thresholdMotion = 70.0;

        MotionReader motionReader = new MotionReader();
        MobileReader mobileReader = new MobileReader(thresholdMotion);
        LaptopReader laptopReader = new LaptopReader(thresholdMotion);

        var timer = new System.Timers.Timer(2000);

        Console.WriteLine("[0] Start Monitoring");
        Console.WriteLine("[1] View Previous logs");
        Console.WriteLine("[2] Exit");
        Console.Write("Enter the choice :");
        var userChoice = int.Parse(Console.ReadLine());
        while (userChoice != 2)
        {
            if (userChoice == 0)
            {
                motionReader.MotionNotifier += mobileReader.DisplayAlert;
                motionReader.MotionNotifier += laptopReader.DisplayAlert;

                StartMotionMonitoring(timer, motionReader);

                motionReader.MotionNotifier -= mobileReader.DisplayAlert;
                motionReader.MotionNotifier -= laptopReader.DisplayAlert;
            }
            else if (userChoice == 1)
            {
                using (StreamReader stream = new StreamReader(@"C:\ProgramData\SmartHomeAutomationSystem\MotionLog.csv"))
                {
                    using (CsvReader csvReader = new CsvReader(stream, CultureInfo.InvariantCulture))
                    {
                        var list =csvReader.GetRecords<MotionReaderEventArgs>().Reverse().Take(5).Reverse(); 
                        foreach (var item in list)
                        {
                            Console.WriteLine(item.Motion+","+item.EventElapsedTime);
                        }
                    }
                }
            }
            Console.WriteLine("\nPress any key to perform next action");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("[0] Start Monitoring");
            Console.WriteLine("[1] View Previous logs");
            Console.WriteLine("[2] Exit");
            Console.Write("Enter the choice :");
            userChoice = int.Parse(Console.ReadLine());
        }
        Console.WriteLine("Press any key to exit....");
        Console.ReadKey();
    }

    private static void StartMotionMonitoring(System.Timers.Timer timer, MotionReader motionReader)
    {
        timer.Elapsed += motionReader.ReadMotion;
        timer.AutoReset = true;
        timer.Enabled = true;

        timer.Start();
        Console.WriteLine("Press any key to stop the monitoring process");
        Console.ReadKey();
        Console.Clear();
        timer.Stop();
        timer.Dispose();
    }
}

public class MotionReader
{
    public event EventHandler<MotionReaderEventArgs>? MotionNotifier;
    private Random random = new Random();

    public void ReadMotion(object? sender, ElapsedEventArgs elapsedEventArgs)
    {
        double minMotion = 20.0;
        double maxMotion = 100.0;

        double currentMotion = minMotion + random.NextDouble()*(maxMotion - minMotion);

        MotionReaderEventArgs motionReaderEventArgs = new MotionReaderEventArgs(currentMotion, elapsedEventArgs.SignalTime.ToString("HH.mm.ss"));

        NotifyMotion(this, motionReaderEventArgs);

        LogMotion(motionReaderEventArgs);
        
    }

    private void LogMotion(MotionReaderEventArgs motionReaderEventArgs)
    {
        using (StreamWriter streamWriter = new StreamWriter(@"C:\ProgramData\SmartHomeAutomationSystem\MotionLog.csv", true) )
        {
            using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
            {
                if (!File.Exists(@"C:\ProgramData\SmartHomeAutomationSystem\MotionLog.csv") || new FileInfo(@"C:\ProgramData\SmartHomeAutomationSystem\MotionLog.csv").Length == 0)
                {
                    csvWriter.WriteHeader<MotionReaderEventArgs>();
                    csvWriter.NextRecord();
                }
                csvWriter.WriteRecord(motionReaderEventArgs);
                csvWriter.NextRecord();
            }
        }
    }

    private void NotifyMotion(object? sender, MotionReaderEventArgs motionReaderEventArgs)
    {
        MotionNotifier?.Invoke(sender, motionReaderEventArgs );
    }
}

public class MotionReaderEventArgs : EventArgs
{
    public double Motion { get; }

    public string EventElapsedTime { get; }
    public MotionReaderEventArgs(double Motion, string EventElapsedTime)
    {
        this.Motion = Motion;
        this.EventElapsedTime = EventElapsedTime;
    }
}

public class MobileReader
{
    private double _thresholdMotion;
    public MobileReader(double ThresholdMotion)
    {
        _thresholdMotion = ThresholdMotion;
    }
    public void DisplayAlert(object? sender, MotionReaderEventArgs motionReaderEventArgs)
    {
        if(motionReaderEventArgs.Motion > _thresholdMotion)
        {
            Console.WriteLine($"{motionReaderEventArgs.Motion} --- Alert by mobile---- Sender : {sender.ToString()}");
        }
    }
}

public class LaptopReader
{
    private double _thresholdMotion;
    public LaptopReader(double ThresholdMotion)
    {
        _thresholdMotion = ThresholdMotion;
    }
    public void DisplayAlert(object? sender, MotionReaderEventArgs motionReaderEventArgs)
    {
        
        if (motionReaderEventArgs.Motion > _thresholdMotion)
        {
            Console.WriteLine($"{motionReaderEventArgs.Motion} --- Alert by laptop---- Sender : {sender.ToString()}");
        }
    }
}
