public class Program
{
    static void Main()
    {
        Stack<char> characters = new Stack<char>();
        CharacterStack characterStack = new CharacterStack(characters);
        characterStack.DoStackOperations();

        Console.ReadKey();
    }
}