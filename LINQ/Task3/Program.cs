public class Program
{
    static void Main()
    {
        int[] testArray = [2,7,3,9,9,6,3,1,1,7,5,3,2,4,8,3,0,11,19,43,22,12,-3,-2,1,20,61,33,76,14,12,29];
        var sortedArray = testArray.Distinct().OrderByDescending(x => x).ToArray();
        Console.WriteLine("The second highest number in the array : "+sortedArray[1]);

        Console.Write("\nProvide the specified target sum : ");
        int targetSum = int.Parse(Console.ReadLine());

        var pairIntegers = testArray.Where(x => testArray.Contains(targetSum - x)).ToArray();

        var pairedArray = pairIntegers.Select(x => (x,targetSum -x)).Distinct().ToArray();

        var distinctPairs = pairedArray.OrderBy(x => x.Item1)
            .Select((x,index) => (index >= pairedArray.Count() /2 ) ? (x.Item2, x.Item1) : x)
            .Distinct();
        
        Console.WriteLine("\nThe pairs in the array adding up to the target sum : ");
        foreach (var item in distinctPairs) Console.WriteLine(item); 

        Console.ReadKey();
    }
}