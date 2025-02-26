using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using ConsoleTables;
using Pastel;
using TimeTableScheduler.Model;
using Task = TimeTableScheduler.Model.Task;

namespace TimeTableScheduler.ConsoleUI
{
    public class OutputManager
    {
        public void PrintSuccessfulLogin()
        {
            Console.WriteLine("\nUser Login Successful !! ".Pastel(ConsoleColor.Cyan));
        }

        public void PrintFailedLogin()
        {
            Console.WriteLine("\nUser Login Failure !!!\nReturning to Main Menu".Pastel(ConsoleColor.Red));
            Console.ResetColor();
        }

        public void PrintSpecificTaskInformation(Task task)
        {
            ConsoleTable taskTable = new ConsoleTable("Heading", "Description", "TargetDate", "Recurrence");
            taskTable.AddRow(task.Heading, task.Description, task.TargetDate.ToString("MM/dd/yyyy"), task.Recurrence);
            taskTable.Write();
        }

        public void PrintSuccessfulDeletion()
        {
            Console.WriteLine("The Task has been successfully deleted.\n".Pastel(ConsoleColor.Cyan));
        }

        public void PrintNoMatches()
        {
            Console.WriteLine("\nThere are no matches found !!".Pastel(ConsoleColor.Red));
        }

        public void PrintTasks(List<Task> tasks)
        {
            ConsoleTable consoleTable = new ConsoleTable("Heading", "Description", "TargetDate", "Recurrence");
            foreach (Task task in tasks)
            {
                consoleTable.AddRow(task.Heading, task.Description, task.TargetDate.ToString("MM/dd/yyyy"), task.Recurrence);
            }
            consoleTable.Write();
        }

        public void PrintUserAlreadyPresent()
        {
            Console.Beep();
            Console.WriteLine("User Id is already present !!".Pastel(ConsoleColor.Red));
        }

        public void PrintPressAnyKeyToPerformNextAction()
        {
            Console.WriteLine("\nPress any key to perform next action !!".Pastel(ConsoleColor.Cyan));
        }

        public void PrintPressAnyKeyToExit()
        {
            Console.WriteLine("\nPress any key to Exit !!".Pastel(ConsoleColor.Cyan));
        }
    }
}