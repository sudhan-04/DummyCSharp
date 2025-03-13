using TimeTracker.Services;
using TimeTracker.Model;
using Spectre.Console;
using Pastel;

namespace TimeTracker.View
{
    internal class InputManager
    {
        private InputValidation _inputValidation;

        public InputManager(InputValidation inputValidation)
        {
            _inputValidation = inputValidation;
        }

        public string GetUserType()
        {
            var userAction = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("\n[yellow2] Provide the user input : [/]")
            .AddChoices(new[] {
                        $"{InitialMenu.Login}", $"{InitialMenu.SignUp}", $"{InitialMenu.ExitApplication}"
                    }));

            return userAction;
        }

        private string GetValidString(string inputString)
        {
            while (_inputValidation.IsInvalidInput(inputString))
            {
                inputString = ReplaceEmptyInput();
            }
            return inputString;
        }

        private string ReplaceEmptyInput()
        {
            Console.WriteLine("The given input is empty.".Pastel(ConsoleColor.Red));
            Console.Write("Provide a valid Input : ".Pastel(ConsoleColor.Yellow));
            return Console.ReadLine();
        }

        public int GetUserId()
        {
            Console.Write("Enter User ID : ".Pastel(ConsoleColor.Yellow));
            int inputId = GetValidInteger(Console.ReadLine());
            return inputId;
        }

        private string MaskConsoleInput(string inputString)
        {
            string maskedInput = AnsiConsole.Prompt(new TextPrompt<string>($"{inputString} ").Secret());
            return maskedInput;
        }

        private string GetPassword()
        {
            string inputPassword = MaskConsoleInput("[yellow2]Enter User Password :[/]");
            return inputPassword;
        }

        public string RegisterPassword()
        {
            string inputPassword = MaskConsoleInput("[yellow2]Enter password :[/]");
            while (!_inputValidation.IsPasswordValid(inputPassword))
            {
                inputPassword = ReplaceInvalidPassword();
            }

            string confirmationPassword = MaskConsoleInput("[yellow2]Confirm the password :[/]");
            int noOfAttempts = 0;
            while (!confirmationPassword.Equals(inputPassword) && noOfAttempts < 2)
            {
                confirmationPassword = MaskConsoleInput("[yellow2]Enter the same input password :[/]");
                noOfAttempts++;
            }

            return inputPassword.Equals(confirmationPassword) ? inputPassword : "";
        }

        private string ReplaceInvalidPassword()
        {
            Console.Beep();
            Console.WriteLine("The input password is invalid".Pastel(ConsoleColor.Red));
            Console.WriteLine("The password must be of minimum length 6,\nMust contain atleast one number,\nMust contain atleast one uppercase alphabet,\nMust contain atleast one lowercase Alphabet,\nMust contain atleast one special Character".Pastel(ConsoleColor.Red));

            return MaskConsoleInput("[yellow2]Enter a valid password :[/]");
        }

        public string ReplaceInvalidInputInteger()
        {
            Console.WriteLine("The input must be an integer.".Pastel(ConsoleColor.Red));
            Console.Write("Provide the Input again : ".Pastel(ConsoleColor.Yellow));
            string inputParameter = Console.ReadLine();

            return inputParameter;
        }

        public string GetUserName()
        {
            Console.Write("Provide the User Name : ".Pastel(ConsoleColor.Yellow));
            return GetValidString(Console.ReadLine());
        }

        public int GetValidInteger(string inputParameter)
        {
            while (!_inputValidation.IsValidInteger(inputParameter))
            {
                inputParameter = ReplaceInvalidInputInteger();
            }
            int.TryParse(inputParameter, out int validData);
            return validData;
        }

        public bool ValidatePassword(string correctPassword)
        {
            string inputPassword = GetPassword();
            int noOfTries = 0;
            while (noOfTries < 2)
            {
                if (correctPassword != inputPassword)
                {
                    Console.Beep();
                    inputPassword = MaskConsoleInput("[yellow2]Provide the Correct Password :[/]");
                }

                else
                    return true;

                noOfTries++;
            }

            return correctPassword.Equals(inputPassword);
        }

        public Dashboard GetUserOption()
        {
            var dashboardChoice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("\n[yellow2] Select the action to be performed : [/]")
            .AddChoices(new[] {
                    $"{Dashboard.CreateTask}", $"{Dashboard.SelectTask}", $"{Dashboard.ExportToCsv}",$"{Dashboard.ViewTasks}", $"{Dashboard.ManageTasks}", $"{Dashboard.LogOut}"
                    }));

            return (Dashboard)Enum.Parse(typeof(Dashboard), dashboardChoice);
        }

        public string GetEditField()
        {
            var editField = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("\n[yellow2] Select the field to be edited : [/]")
            .AddChoices(new[] {
                    $"{EditField.EditHeading}", $"{EditField.EditDescription}", $"{EditField.EditStartTime}",$"{EditField.EditEndTime}",$"{EditField.EditTimeExecuted}"
                    }));

            return editField;
        }

        public string GetTaskStatus()
        {
            var currentStatus = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("\n[yellow2] Select the current status of the task : [/]")
            .AddChoices(new[] {
                    $"{UserTaskStatus.Created}", $"{UserTaskStatus.Running}", $"{UserTaskStatus.Paused}",$"{UserTaskStatus.Stopped}", "Skip"
                    }));

            return currentStatus;
        }

        public string GetTaskOperation()
        {
            var taskOperation = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("\n[yellow2] Select the operation to be performed on the task : [/]")
            .AddChoices(new[] {
                    $"{TaskOperations.StartTask}", $"{TaskOperations.PauseTask}", $"{TaskOperations.ResumeTask}", $"{TaskOperations.StopTask}",$"{TaskOperations.EditTask}", $"{TaskOperations.DeleteTask}"
                    }));

            return taskOperation;
        }

        public string GetFilterChoice()
        {
            var filterChoice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("\n[yellow2] Select the categories to be filtered : [/]")
            .AddChoices(new[] {
                    $"{FilterChoice.Heading}", $"{FilterChoice.TaskStatus}", $"{FilterChoice.Both}", $"{FilterChoice.None}"
                    }));

            return filterChoice;
        }

        public string GetTaskListOperation()
        {
            var tasksOperation = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("\n[yellow2] Select the operation to be performed on the list of tasks : [/]")
            .AddChoices(new[] {
                    $"{TaskListOperations.FilterTasks}", $"{TaskListOperations.SortTasks}", $"{TaskListOperations.ViewTaskSummary}", $"{TaskListOperations.ExportToCsv}", $"{TaskListOperations.ReturnToDashboard}"
                    }));

            return tasksOperation;
        }

        public string GetSortingField()
        {
            var sortingField = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("\n[yellow2] Select the field based on which the list is to be sorted : [/]")
            .AddChoices(new[] {
                    $"{SortingField.Heading}", $"{SortingField.TaskStatus}", $"{SortingField.TimeExecuted}", $"{SortingField.StartTime}", $"{SortingField.EndTime}"
                    }));

            return sortingField;
        }

        public string GetSummaryOptions()
        {
            var summaryOptions = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("\n[yellow2] Select the field on which the summary is required : [/]")
            .AddChoices(new[] {
                    $"{SummaryOptions.Daily}", $"{SummaryOptions.Weekly}", $"{SummaryOptions.Monthly}"
                    }));

            return summaryOptions;
        }

        public List<string> GetFilteringField()
        {
            var filteringFields = AnsiConsole.Prompt(
            new MultiSelectionPrompt<string>()
                .Title("\n[yellow2] Select the field based on which the list is to be filtered : [/]")
                .InstructionsText("[grey](Use [blue]Space[/] to select, [green]Enter[/] to confirm)[/]")
                .AddChoices(new[] { $"{FilteringField.Heading}", $"{FilteringField.StartTime}", $"{FilteringField.TaskStatus}", $"{FilteringField.EndTime }", $"{FilteringField.TimeExecuted}", $"{FilteringField.Description}"})
                );

            AnsiConsole.MarkupLine($"\n[green]Selected Fields : {string.Join(", ", filteringFields)}[/]");
            return filteringFields;
        }

        public string GetTaskHeading()
        {
            Console.Write("\nProvide the heading of the Task : ".Pastel(ConsoleColor.Yellow));
            return GetValidString(Console.ReadLine());
        }

        public string GetTaskDescription()
        {
            Console.Write("\nProvide the description: ".Pastel(ConsoleColor.Yellow));
            return GetValidString(Console.ReadLine());
        }

        public int GetTaskIndex(int maxValue)
        {
            Console.Write("\nSelect the task index : ".Pastel(ConsoleColor.Yellow));
            int userSelectedIndex = GetValidInteger(Console.ReadLine());
            while (userSelectedIndex <= 0 || userSelectedIndex > maxValue)
            {
                userSelectedIndex = GetValidInteger(ReplaceInvalidInputInteger());
            }
            return userSelectedIndex;
        }

        public DateTime GetStartDateTime()
        {
            Console.Write("\nPlease enter the modified start date and time (format: yyyy-MM-dd HH:mm:ss) : ".Pastel(ConsoleColor.Yellow));
            var inputDateTime = Console.ReadLine();

            while (!_inputValidation.IsValidDateTime(inputDateTime))
            {
                Console.WriteLine("The input must be in date time format (format: yyyy-MM-dd HH:mm:ss) !!".Pastel(ConsoleColor.Red));
                Console.Write("Please enter the modified start date and time (format: yyyy-MM-dd HH:mm:ss) : ".Pastel(ConsoleColor.Yellow));
                inputDateTime = Console.ReadLine();
            }

            DateTime.TryParse(inputDateTime, out DateTime validDateTime);
            return validDateTime;
        }

        public DateTime GetTargetStartDate()
        {
            Console.Write("\nPlease enter the target start date (format: yyyy-MM-dd) : ".Pastel(ConsoleColor.Yellow));
            var inputDateTime = Console.ReadLine();

            while (!_inputValidation.IsValidDateTime(inputDateTime))
            {
                Console.WriteLine("The input must be in date format (format: yyyy-MM-dd) !!".Pastel(ConsoleColor.Red));
                Console.Write("Please enter the target start date (format: yyyy-MM-dd) : ".Pastel(ConsoleColor.Yellow));
                inputDateTime = Console.ReadLine();
            }

            DateTime.TryParse(inputDateTime, out DateTime validDateTime);
            return validDateTime;
        }

        public DateTime GetTargetDate()
        {
            Console.Write("\nPlease enter the target date (format: yyyy-MM-dd) : ".Pastel(ConsoleColor.Yellow));
            var inputDateTime = Console.ReadLine();

            while (!_inputValidation.IsValidDateTime(inputDateTime))
            {
                Console.WriteLine("The input must be in date format (format: yyyy-MM-dd) !!".Pastel(ConsoleColor.Red));
                Console.Write("Please enter the target date (format: yyyy-MM-dd) : ".Pastel(ConsoleColor.Yellow));
                inputDateTime = Console.ReadLine();
            }

            DateTime.TryParse(inputDateTime, out DateTime validDateTime);
            return validDateTime;
        }

        public DateTime GetTargetEndDate()
        {
            Console.Write("\nPlease enter the target end date (format: yyyy-MM-dd) : ".Pastel(ConsoleColor.Yellow));
            var inputDateTime = Console.ReadLine();

            while (!_inputValidation.IsValidDateTime(inputDateTime))
            {
                Console.WriteLine("The input must be in date format (format: yyyy-MM-dd) !!".Pastel(ConsoleColor.Red));
                Console.Write("Please enter the target end date (format: yyyy-MM-dd) : ".Pastel(ConsoleColor.Yellow));
                inputDateTime = Console.ReadLine();
            }

            DateTime.TryParse(inputDateTime, out DateTime validDateTime);
            return validDateTime;
        }

        public DateTime GetEndDateTime()
        {
            Console.Write("\nPlease enter the modified end date and time (format: yyyy-MM-dd HH:mm:ss) : ".Pastel(ConsoleColor.Yellow));
            var inputDateTime = Console.ReadLine();

            while (!_inputValidation.IsValidDateTime(inputDateTime))
            {
                Console.WriteLine("The input must be in date time format (format: yyyy-MM-dd HH:mm:ss) !!".Pastel(ConsoleColor.Red));
                Console.Write("Please enter the modified end date and time (format: yyyy-MM-dd HH:mm:ss) : ".Pastel(ConsoleColor.Yellow));
                inputDateTime = Console.ReadLine();
            }

            DateTime.TryParse(inputDateTime, out DateTime validDateTime);
            return validDateTime;
        }

        public DateTime GetValidTimeShifts(User user, int editChoiceIndex, bool isStartTime)
        {
            var timeType = isStartTime ? "start time" : "end time";
            Console.WriteLine($"The {timeType} of the task is saved as {user.UserTasks[editChoiceIndex].EndTime}".Pastel(ConsoleColor.Red));
            Console.WriteLine($"The {timeType} of the task must also be changed.".Pastel(ConsoleColor.Red));
            DateTime modifiedDateTime = isStartTime ? GetStartDateTime() : GetEndDateTime();
            return modifiedDateTime;
        }

        private string GetTaskTimeExecuted()
        {
            Console.Write("Please enter the modified execution time (format: HH:mm:ss) : ".Pastel(ConsoleColor.Yellow));
            return Console.ReadLine();
        }

        public TimeSpan GetTimeExecuted()
        {
            var inputDateTime = GetTaskTimeExecuted();
            while (!_inputValidation.IsValidTimeSpan(inputDateTime))
            {
                Console.WriteLine("The input is in invalid format !!".Pastel(ConsoleColor.Red));
                inputDateTime = GetTaskTimeExecuted();
            }

            TimeSpan.TryParse(inputDateTime, out TimeSpan validTimeSpan);
            return validTimeSpan;
        }
    }
}
