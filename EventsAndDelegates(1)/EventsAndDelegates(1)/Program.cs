using EventsAndDelegates;

public class Program
{
    static void Main()
    {
        Notifier notifier = new Notifier();

        notifier.OnAction += MessagePrinter;
        notifier.TriggerEvent("\nEVENT SUCCESSFULLY TRIGGERED !!!!");
        notifier.OnAction -= MessagePrinter;

        notifier.OnAction += MessagePrinter;
        notifier.TriggerEvent("\nPress any key to exit....");
        notifier.OnAction -= MessagePrinter;

        Console.ReadKey();
    }

    static void MessagePrinter(string message)
    {
        Console.WriteLine(message);
    }
}