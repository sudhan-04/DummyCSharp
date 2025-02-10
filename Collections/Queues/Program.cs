public class Program
{
    static void Main()
    {
        Queue<string> persons = new Queue<string>();
        PersonQueue personQueue = new PersonQueue(persons);
        personQueue.DoQueueOperations();

        Console.ReadKey();
    }
}
