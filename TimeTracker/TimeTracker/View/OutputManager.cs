using Pastel;
using Spectre.Console;
using TimeTracker.Model;
using ConsoleTables;

namespace TimeTracker.View
{
    internal class OutputManager
    {
        public void PrintWelcomeMessage()
        {
            Console.WriteLine("\nWelcome to time tracker application !!!".Pastel(ConsoleColor.Magenta));
        }
        public void PrintSuccessfulLogin()
        {
            ImplementProgressBar("Logging in");
            Console.WriteLine("User Login Successful !! ".Pastel(ConsoleColor.Cyan));
        }

        public void PrintSuccessfulRegistration()
        {
            ImplementProgressBar("Registering User");
            Console.WriteLine("User Registration Successful !! ".Pastel(ConsoleColor.Cyan));
        }

        public void PrintFailedLogin()
        {
            Console.Beep();
            Console.WriteLine("\nUser Login Failure !!!".Pastel(ConsoleColor.Red));
        }

        public void PrintFailedRegistration()
        {
            Console.Beep();
            Console.WriteLine("\nThe passwords don't match...\nUser Registration Failure !!!".Pastel(ConsoleColor.Red));
        }

        public void PrintUserAlreadyPresent()
        {
            Console.Beep();
            Console.WriteLine("\nUser Id is already present !!".Pastel(ConsoleColor.Red));
        }

        public void PrintAnyKeyToPerformAction()
        {
            Console.WriteLine("\nPress any key to perform next action !!".Pastel(ConsoleColor.Magenta));
        }

        public void PrintEnterKeyToExit()
        {
            Console.WriteLine("\nPress enter key to exit the application !!".Pastel(ConsoleColor.Magenta));
        }

        private void ImplementProgressBar(string displayMessage)
        {
            AnsiConsole.Progress()
            .Start(progressBar =>
            {
                var task = progressBar.AddTask($"[green]{displayMessage}[/]");
                while (!task.IsFinished) { task.Increment(new Random().Next(5, 25)); Thread.Sleep(300); }
            });
        }

        public void PrintWelcomeUser(string userName)
        {
            Console.WriteLine($"\nWelcome {userName}".Pastel(ConsoleColor.Cyan));
        }

        public void PrintUserInformation(User user)
        {
            string userName = user.UserName;
            var consoleWidth = Console.WindowWidth;
            Console.SetCursorPosition(consoleWidth - userName.Length - 1, 0);
            Console.WriteLine($"{userName}".Pastel(ConsoleColor.Magenta));
            Console.SetCursorPosition(consoleWidth - DateTime.Now.ToString("MMM d,yyyy - h:mm tt").Length - 1, 1);
            Console.WriteLine($"{DateTime.Now.ToString("MMM d,yyyy - h:mm tt")}".Pastel(ConsoleColor.Magenta));
            var runningTask = user.UserTasks.Where(t => t.Status == UserTaskStatus.Running).FirstOrDefault();
            string? runningTaskDetails;
            if (runningTask == null)
            {
                runningTaskDetails = "No tasks are currently running.";
            }
            else
            {
                runningTaskDetails = "Current Running Task : " + runningTask.Heading + " - Start Time : " + runningTask.StartTime.Value.ToString("MMM d,yyyy - h:mm tt");
            }
            Console.SetCursorPosition(consoleWidth - runningTaskDetails.Length - 1, 2);
            Console.WriteLine($"{runningTaskDetails}".Pastel(ConsoleColor.Magenta));
        }

        public void PrintSpecificTaskInformation(UserTask task)
        {
            ConsoleTable taskTable = new ConsoleTable("Heading", "Description", "TaskStatus", "StartTime", "EndTime", "TimeExecuted");
            taskTable.AddRow(task.Heading, task.Description, task.Status, task.StartTime.HasValue ? task.StartTime.Value.ToString("MMM d,yy - h:mm tt") : task.StartTime, task.EndTime.HasValue ? task.EndTime.Value.ToString("MMM d,yyyy - h:mm tt") : task.EndTime, task.TimeExecuted);
            taskTable.Write();
        }

        public void PrintSuccessfulTaskCreation()
        {
            Console.WriteLine("\nThe Task has been successfully created.\n".Pastel(ConsoleColor.Cyan));
        }

        public void PrintSuccessfulTaskDeletion()
        {
            Console.WriteLine("\nThe Task has been successfully deleted.\n".Pastel(ConsoleColor.Cyan));
        }

        public void PrintNoMatches()
        {
            Console.WriteLine("\nThere are no matches found !!".Pastel(ConsoleColor.Red));
        }

        public void PrintTasks(List<UserTask> tasks, string displayMessage)
        {
            Console.WriteLine($"{displayMessage}".Pastel(ConsoleColor.Cyan));
            ConsoleTable taskTable = new ConsoleTable("Heading", "Description", "TaskStatus", "StartTime", "EndTime", "TimeExecuted");
            foreach (UserTask task in tasks)
            {
                taskTable.AddRow(task.Heading, task.Description, task.Status, task.StartTime.HasValue ? task.StartTime.Value.ToString("MMM d,yyyy - h:mm tt") : task.StartTime, task.EndTime.HasValue ? task.EndTime.Value.ToString("MMM d,yyyy - h:mm tt") : task.EndTime, task.TimeExecuted);
            }

            taskTable.Write();
        }

        public void PrintRecentTask(List<UserTask> userTasks)
        {
            if (userTasks.Count >= 3)
            {
                Console.WriteLine("\nRecently updated three tasks : ".Pastel(ConsoleColor.Cyan));
                ConsoleTable taskTable = new ConsoleTable("Heading", "Description", "TaskStatus", "StartTime", "EndTime", "TimeExecuted");
                UserTask task;

                for (int index = 0; index < 3; index++)
                {
                    task = userTasks[userTasks.Count() - index - 1];
                    taskTable.AddRow(task.Heading, task.Description, task.Status, task.StartTime.HasValue ? task.StartTime.Value.ToString("MMM d,yyyy - h:mm tt") : task.StartTime, task.EndTime.HasValue ? task.EndTime.Value.ToString("MMM d,yyyy - h:mm tt") : task.EndTime, task.TimeExecuted);

                }

                taskTable.Write();
            }
        }

        public void PrintNoTasksPresent()
        {
            Console.WriteLine("\nThere are no tasks present !!!".Pastel(ConsoleColor.Red));
        }

        public void PrintInvalidTaskOperation()
        {
            Console.WriteLine("\nInvalid Operation performed on the task !!!".Pastel(ConsoleColor.Red));
            Console.WriteLine("Exiting.....".Pastel(ConsoleColor.Red));
        }

        public void PrintTaskStarted()
        {
            Console.WriteLine("\nTask has been successfully started.".Pastel(ConsoleColor.Cyan));
        }

        public void PrintTaskStopped()
        {
            Console.WriteLine("\nTask has been successfully stopped.".Pastel(ConsoleColor.Cyan));
        }

        public void PrintTaskPaused()
        {
            Console.WriteLine("\nTask has been successfully paused.".Pastel(ConsoleColor.Cyan));
        }

        public void PrintTaskResumed()
        {
            Console.WriteLine("\nTask has been successfully resumed.".Pastel(ConsoleColor.Cyan));
        }

        public void PrintTaskUpdated()
        {
            Console.WriteLine("\nTask details has been successfully edited.".Pastel(ConsoleColor.Cyan));
        }

        public void PrintTaskAlreadyRunning()
        {
            Console.WriteLine("\nA task is already running !!!".Pastel(ConsoleColor.Red));
        }

        public void PrintExportedToCsv()
        {
            Console.WriteLine("\nThe tasks data are successfully exported to CSV File.".Pastel(ConsoleColor.Cyan));
            Console.Write("\nOpening the file".Pastel(ConsoleColor.Cyan));
            int count = 0;
            while (count < 10)
            {
                Console.Write(".".Pastel(ConsoleColor.Cyan));
                Thread.Sleep(100);
                count++;
            }
            Console.WriteLine();
        }

        public void PrintExitMessage()
        {
            Console.Clear();
            var consoleWidth = Console.WindowWidth;
            var consoleHeight = Console.WindowHeight;
            Console.SetCursorPosition(consoleWidth / 2 - 10, consoleHeight / 2);
            Console.Write("Exiting Application".Pastel(ConsoleColor.Magenta));
            int count = 0;
            while (count < 10)
            {
                Console.Write(".".Pastel(ConsoleColor.Magenta));
                Thread.Sleep(100);
                count++;
            }
        }
    }
}
