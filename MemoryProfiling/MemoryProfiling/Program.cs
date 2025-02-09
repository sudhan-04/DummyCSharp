using ConsoleTables;
using Pastel;

/// <summary>
/// Class to define methods to analyze memory usage
/// </summary>
public class MemoryEater
{
    List<int[]> memAlloc = new List<int[]>();

    /// <summary>
    /// Method to allocate heap memory
    /// </summary>
    public void Allocate()
    {
        ConsoleTable memoryTable = new ConsoleTable("Loop Count", "Occupied Heap Memory (Bytes)");
        int loopCount = 0;

        Console.Write("Provide the number of memory allocations : ");
        int maxAllocations = int.Parse(Console.ReadLine());

        //Loop which continuously allocates memory by adding new objects until the maximum number of allocations
        while (loopCount < maxAllocations)
        {
            memAlloc.Add(new int[1000]);

            // Assume memAlloc variable is used only within this loop.
            Thread.Sleep(1000);
            memoryTable.AddRow(++loopCount, GC.GetTotalMemory(false));
            memoryTable.Write();
        }

        // Measuring heap memory after completion of memory allocation
        Console.WriteLine($"The heap memory after allocating required memory for the objects : {$"{(double) GC.GetTotalMemory(false) / 1000}".Pastel(ConsoleColor.Red)} Kilobytes");

        Thread.Sleep(1000);

        // Clearing the heap memory by force calling the Garbage collector
        GC.Collect();
        Console.WriteLine($"\nThe heap memory after the garbage collection of unreferenced objects : {$"{(double) GC.GetTotalMemory(false) / 1000}".Pastel(ConsoleColor.Red)} Kilobytes");
    }
}

class Program
{
    static void Main(string[] args)
    {
        MemoryEater me = new MemoryEater();
        me.Allocate();

        Console.ReadKey();
    }  
}
