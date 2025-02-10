using Generics.CollectionRepository;
using Pastel;

public class Program
{
    static void Main()
    {
        List<double> list = new List<double>();
        Queue<int> queue = new Queue<int>();
        Stack<string> stack = new Stack<string>();
        Dictionary<long, char> dictionary = new Dictionary<long, char>();

        GenericList<double> genericList = new GenericList<double>(list);

        genericList.CreateList();

        genericList.AddItem((double)12.20);
        genericList.AddItem((double)54.54);
        genericList.AddItem((double)135466.67);
        genericList.AddItem((double)100.00);
        genericList.AddItem((double)1);

        genericList.RemoveItem((double)56);
        genericList.RemoveItem((double)100.00);

        genericList.CheckItem((double)789.21);
        genericList.CheckItem((double)54.54);

        genericList.ReturnListAsTable().Write();

        Console.WriteLine($"Press any key to continue to generic queues.....".Pastel(ConsoleColor.Magenta));
        Console.ReadKey();
        Console.Clear();

        GenericQueue<int> genericQueue = new GenericQueue<int>(queue);

        genericQueue.CreateQueue();

        genericQueue.EnqueueItem(int.Parse("54"));
        genericQueue.EnqueueItem((int)54.54);
        genericQueue.EnqueueItem(int.Parse("23"));
        genericQueue.EnqueueItem(12);
        genericQueue.EnqueueItem((int)1.76);
               
        genericQueue.DequeueItem();
        genericQueue.DequeueItem();
               
        genericQueue.ReturnQueueAsTable().Write();

        Console.WriteLine($"Press any key to continue to generic stacks.....".Pastel(ConsoleColor.Magenta));
        Console.ReadKey();
        Console.Clear();

        GenericStack<string> genericStack = new GenericStack<string>(stack);

        genericStack.CreateStack();
               
        genericStack.PushItem("456");
        genericStack.PushItem((54.54).ToString());
        genericStack.PushItem("12.56.YU.IO");
        genericStack.PushItem((DateTime.Now).ToString());
        genericStack.PushItem("Apple");
               
        genericStack.PopItem();

        genericStack.ReturnStackAsTable(stack).Write();

        genericStack.ReverseContent();

        Console.WriteLine($"Press any key to continue to Generic Dictionary.....".Pastel(ConsoleColor.Magenta));
        Console.ReadKey();
        Console.Clear();

        GenericDictionary<long, char> genericDictionary = new GenericDictionary<long, char>(dictionary);

        genericDictionary.CreateDictionary();
               
        genericDictionary.AddItemToDictionary((long)12.20, 'a');
        genericDictionary.AddItemToDictionary(long.Parse("54444"), 'A');
        genericDictionary.AddItemToDictionary((long)135466.67, '@');
        genericDictionary.AddItemToDictionary(1000000000, '2');
        genericDictionary.AddItemToDictionary(1, 'x');
               
        genericDictionary.RemoveItemFromDictionary(45678);
        genericDictionary.RemoveItemFromDictionary((long)12.20);
               
        genericDictionary.ReturnDictionaryAsTable().Write();

        Console.WriteLine($"Press any key to continue to exit.....".Pastel(ConsoleColor.Magenta));
        Console.ReadKey();
    }
}