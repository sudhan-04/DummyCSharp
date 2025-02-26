using TimeTableScheduler.DataValidation;
using TimeTableScheduler.ConsoleUI;
using TimeTableScheduler.Utility;
using TimeTableScheduler.FileManager;
using TimeTableScheduler.Model;
using CsvHelper;
using System.Globalization;
public class Program
{
    static void Main()
    {
        InputValidation inputValidation = new InputValidation();
        PasswordValidation passwordValidation = new PasswordValidation();
        InputManager inputManager = new InputManager(inputValidation, passwordValidation);
        OutputManager outputManager = new OutputManager();
        DataHandler dataHandler = new DataHandler();
        UserManager userManager = new UserManager(inputManager, outputManager, dataHandler);
        TaskManager taskManager = new TaskManager(inputManager, outputManager, dataHandler);

        int userChoice;
        int userAction;

        do
        {
            userAction = userManager.UserValidation();
            if (userAction != 5 && userAction != -1)
            {
                User user = dataHandler.ReadFile($"{userAction}.json");
                do
                {
                    user = dataHandler.ReadFile($"{userAction}.json");
                    taskManager.PrintRecentTask(user.UserTask);
                    userChoice = taskManager.GetUserOption(userAction, inputManager.GetUserOption());
                    outputManager.PrintPressAnyKeyToPerformNextAction();
                    Console.ReadKey();
                    Console.Clear();
                } while (userChoice != 5);
                Console.Clear();
            }
        } while (userAction != 5);

        outputManager.PrintPressAnyKeyToExit();
        StreamReader streamReader;
        streamReader = new StreamReader("Schedule.csv");
        CsvReader csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture);

        Console.ReadKey();
    }
}