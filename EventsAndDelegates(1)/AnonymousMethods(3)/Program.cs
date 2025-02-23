public class Program
{
    public delegate IEnumerable<int> TestDelegate(int[] intArray);

    static void Main()
    {
        int[] testArray = [3,1,7,2,3,5,4];

        TestDelegate anonymousMethod = delegate (int[] testArray)
        {
           return testArray.Order();
        };

        var sortedArray = anonymousMethod(testArray);

        foreach (int integer in sortedArray)
        {
            Console.WriteLine(integer); 
        }

        Array.Sort(testArray, delegate (int number1, int number2)
        {
            return number1.CompareTo(number2);
        });
    }
}
