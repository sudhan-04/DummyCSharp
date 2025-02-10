public class Program
{
    static void Main()
    {
        List<string> books = new List<string>();
        BookList bookList = new BookList(books);
        bookList.DoListOperations();

        Console.ReadKey();
    }
}
