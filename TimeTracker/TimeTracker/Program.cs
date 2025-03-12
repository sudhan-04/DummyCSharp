﻿using TimeTracker.Controller;
using TimeTracker.Model;
using TimeTracker.Services;
using TimeTracker.View;

public class Program
{
    static void Main()
    {
        InputValidation inputValidation = new InputValidation();
        InputManager inputManager = new InputManager(inputValidation);
        OutputManager outputManager = new OutputManager();
        FileHandler fileHandler = new FileHandler();
        Encryptor encryptor = new Encryptor();
        UserController userController = new UserController(inputManager, outputManager, fileHandler, encryptor);
        TaskController taskController = new TaskController(inputManager, outputManager, fileHandler);

        outputManager.PrintWelcomeMessage();
        Dashboard dashboardChoice;
        int userAction;

        do
        {
            userAction = userController.StartApplication();

            if (userAction != 5 && userAction != -1)
            {
                var fileFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "TimeTracker\\UserData");
                User user = fileHandler.ReadJsonFile($"{fileFolderPath}\\{userAction}.json");
                outputManager.PrintAnyKeyToPerformAction();
                Console.ReadKey();
                Console.Clear();

                do
                {
                    user = fileHandler.ReadJsonFile($"{fileFolderPath}\\{userAction}.json");
                    outputManager.PrintUserInformation(user.UserName);
                    outputManager.PrintRecentTask(user.UserTasks);
                    dashboardChoice = taskController.GetDashboardChoice(userAction, inputManager.GetUserOption());
                    outputManager.PrintAnyKeyToPerformAction();
                    Console.ReadKey();
                    Console.Clear();
                } while (dashboardChoice != Dashboard.LogOut);

                Console.Clear();
            }
        } while (userAction != 5);

        outputManager.PrintEnterKeyToExit();
        Console.ReadLine();
    }
}
