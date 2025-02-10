using Dictionary;

public class Program
{
    static void Main()
    {
        Dictionary<string, int> studentGradePairs = new Dictionary<string, int>();
        StudentGrades studentGrades = new StudentGrades(studentGradePairs);

        studentGrades.DoDictionaryOperations();

        Console.ReadKey();
    }
}