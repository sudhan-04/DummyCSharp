# MEMORY OPTIMIZATION
## TASK-1
### CODE SNIPPET
```
public class MemoryEater
{
    List<int[]> memAlloc = new List<int[]>();

    public void Allocate()
    {
        while (true)
        {
            memAlloc.Add(new int[1000]);
            // Assume memAlloc variable is used only within this loop. 
            Thread.Sleep(10); 
        }
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
```
- The above code snippet is analyzed for memory issues.  
- `Visual Studio's built-in Diagnostic Tools` is used to diagnose the problem in the code.
### OBSERVATION
- A memory issue is found out in the provided code. The `Allocate` method continuously allocates memory by adding new integer arrays `(int[1000])` to the `memAlloc` list without any termination or cleanup.
- The memory allocation constantly rises for each loop count since there is no memory freed.
- This leads to an infinite memory allocation, eventually causing an `OutOfMemoryException`.

  ![task1](https://github.com/user-attachments/assets/355f0615-87ec-4c3a-b9c4-788cf087c6f3)

  ![task1-2](https://github.com/user-attachments/assets/e3a39865-923e-4e41-a018-96756022a951)
### INSIGHTS
- The scope of the program remains inside the loop forever since `While(true)` remains as the condition.
- This results in the `memAlloc` list being constantly referenced and therefore `Garbage Collector` is unable to clean up the resources.
- Since GC is unable to free the memory and the loop is also not broken, at a certain iteration `OutOfMemoryException` is bound to happen.
## TASK-2 
- The code snippet is diagnosed for the memory issue and suitable approaches for memory management are found out.
- The memory issue in the provided code snippet is fixed and the best approach for the memory management is implemented.
- The code is optimized by using the best approach for memory management and the heap memory is managed.
### OBSERVATION
- The main reason for the infinte memory allocation lies in infinite loop iteration and not performing garbage collection.
### INSIGHTS
- The Memory optimization can be performed by `limiting` the number of loop iterations.
- Clean up of the allocated memory can be performed by forcing the GC to clear unreferenced objects through `GC.Collect()` method.

  ![task 2 p1](https://github.com/user-attachments/assets/041e6d88-94b9-48e7-a5a2-1ff5bafe7243)

  ![task-2 p2](https://github.com/user-attachments/assets/091af311-f46c-4454-93c1-0fac856a7d40)

## TASK-3 
- Visual Studio's built-in Diagnostic Tools is used  to profile the memory usage of the optimized code.
- The changes after optimization of the code are analyzed and documented in a markdown file.
### OBSERVATION 
- Limiting the number of loop iterations terminates the memory allocation after the loop ends.
- Calling the `Garbage Collector` through GC.Collect() shows a steep decrease in the `Process memory graph` of the Visual studio diagnostic tools.
- Through the analysis of the `GC Heap size`, it can also be noted that memory is freed when `GC.Collect()` is called.

  ![task2 -p1](https://github.com/user-attachments/assets/5411bb59-9851-436e-92b5-1804d6ad5731)

  ![task2 p2](https://github.com/user-attachments/assets/6f6f5e23-60b0-4718-973f-e212b9d1ecc1)

  ![task-2 p2](https://github.com/user-attachments/assets/091af311-f46c-4454-93c1-0fac856a7d40)
### INSIGHTS
- Limiting the loop iterations ends the scope at a finite time and therefore the objects becomes unreferenced.
- Forcing the `Garbage Collector` through GC.Collect() method ensures the removal of unreferenced objects from the heap memory, thus conserving the memory.

## TASK-4 
- The key takeaways and understanding about memory management in C# are documented in the `Memory Optimization` Markdown file.
- The challenges faced and the approaches taken to resolve them are also included.
- Justification for the approach performed is expained in the markdown file.
