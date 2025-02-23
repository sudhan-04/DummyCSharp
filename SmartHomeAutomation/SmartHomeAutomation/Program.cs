using System.Timers;

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
                var outputData = File.ReadAllLines("MotionLog.txt").Reverse().Take(5).Reverse();
                Console.WriteLine(string.Join(Environment.NewLine, outputData));
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
        MotionReaderEventArgs motionReaderEventArgs = new MotionReaderEventArgs(currentMotion);

        NotifyMotion(this, motionReaderEventArgs);

        LogMotion(elapsedEventArgs.SignalTime, motionReaderEventArgs);
        
    }

    private void LogMotion(DateTime eventElapsedTime, MotionReaderEventArgs motionReaderEventArgs)
    {
        using (StreamWriter streamWriter = new StreamWriter("MotionLog.txt", true) )
        {
            streamWriter.Write($"\n{motionReaderEventArgs.Motion} - At Time : {eventElapsedTime.ToString("HH : mm : ss")}");
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

    public MotionReaderEventArgs(double Motion)
    {
        this.Motion = Motion;
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
