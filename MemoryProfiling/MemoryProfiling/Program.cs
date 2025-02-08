using ConsoleTables;

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

        Console.WriteLine($"The heap memory after allocating required memory for the objects : {GC.GetTotalMemory(false)} bytes");

        Thread.Sleep(1000);

        GC.Collect();
        Console.WriteLine($"The heap memory after the garbage collection of unreferenced objects : {GC.GetTotalMemory(false)} bytes");
    }
}

class Program
{
    static void Main(string[] args)
    {
        MemoryEater me = new MemoryEater();
        me.Allocate();
    }
}
