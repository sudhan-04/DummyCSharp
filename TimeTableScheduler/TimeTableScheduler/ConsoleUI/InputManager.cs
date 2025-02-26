using Pastel;
using TimeTableScheduler.DataValidation;
using TimeTableScheduler.Model;

namespace TimeTableScheduler.ConsoleUI
{
    public class InputManager
    {
        private InputValidation _inputValidation;
        private PasswordValidation _passwordValidation;
        public InputManager(InputValidation mainInputValidation, PasswordValidation mainPasswordValidation)
        {
            _inputValidation = mainInputValidation;
            _passwordValidation = mainPasswordValidation;
        }

        public int GetUserType()
        {
            Console.WriteLine("\n---------WELCOME----------".Pastel(ConsoleColor.Magenta));
            Console.WriteLine($"\n[0] {UserType.OldUser}\n[1] {UserType.NewUser}\n[2] {UserType.ExitApplication}");
            Console.Write("\nProvide the UserType : ".Pastel(ConsoleColor.Yellow));
            return GetChoiceWithinBounds(2);
        }

        public int GetUserOption()
        {
            Console.WriteLine($"\n[0] {UserOptions.AddTasks}\n[1] {UserOptions.DeleteTasks}\n[2] {UserOptions.ViewTasks}\n[3] {UserOptions.EditTasks}\n[4] {UserOptions.CalendarView}\n[5] {UserOptions.LogOut}");
            Console.Write("\nProvide the UserOption: ".Pastel(ConsoleColor.Yellow));
            return GetChoiceWithinBounds(5);
        }

        public int GetEditField()
        {
            Console.WriteLine($"\n[0] {EditField.EditHeading}\n[1] {EditField.EditDescription}\n[2] {EditField.EditTargetDate}\n[3] {EditField.EditRecurrence}");
            Console.Write("\nProvide the UserOption: ".Pastel(ConsoleColor.Yellow));
            return GetChoiceWithinBounds(3);
        }
        public string GetValidString(string inputString)
        {
            while (_inputValidation.IsValidInput(inputString))
            {
                inputString = ReplaceEmptyInput();
            }
            return inputString;
        }

        private string ReplaceEmptyInput()
        {
            Console.WriteLine("\nThe given input is empty");
            Console.Write("Provide a valid Input :".Pastel(ConsoleColor.Yellow));
            return Console.ReadLine();
        }

        public int GetUserId()
        {
            Console.Write("\nEnter the User ID : ".Pastel(ConsoleColor.Yellow));
            string inputId = Console.ReadLine();
            while (!_inputValidation.IsValidInteger(inputId))
            {
                inputId = ReplaceInvalidId();
            }
            return int.Parse(inputId);
        }

        private string ReplaceInvalidId()
        {
            Console.Beep();
            Console.WriteLine("\nThe input ID is invalid ".Pastel(ConsoleColor.Red));
            Console.Write("Give a valid ID :".Pastel(ConsoleColor.Yellow));
            return Console.ReadLine();
        }

        public string GetPassword()
        {
            Console.Write("Enter the User Password : ".Pastel(ConsoleColor.Yellow));
            string inputPassword = Console.ReadLine();
            while (!_passwordValidation.IsPasswordValid(inputPassword))
            {
                inputPassword = ReplaceInvalidPassword();
            }
            return inputPassword;
        }

        private string ReplaceInvalidPassword()
        {
            Console.Beep();
            Console.WriteLine("\nThe input password is invalid".Pastel(ConsoleColor.Red));
            Console.WriteLine("The password must be of minimum length 6,\nMust contain atleast one number,\nMust contain atleast one uppercase alphabet,\nMust contain atleast one lowercase Alphabet,\nMust contain atleast one special Character".Pastel(ConsoleColor.Red));
            Console.Write("Enter a valid Password :".Pastel(ConsoleColor.Yellow));
            return Console.ReadLine();
        }

        public DateTime GetTargetDate()
        {
            Console.Write("Give the Target Date of the Task (DD/MM/YYYY) : ".Pastel(ConsoleColor.Yellow));
            string targetDate = Console.ReadLine();
            while (!_inputValidation.IsValidDate(targetDate))
            {
                targetDate = ReplaceInvalidDate();
            }
            return DateTime.Parse(targetDate);
        }

        private string ReplaceInvalidDate()
        {
            Console.Beep();
            Console.WriteLine("The input Date is invalid or is of the past !!".Pastel(ConsoleColor.Red));
            Console.Write("Give a valid date : ".Pastel(ConsoleColor.Yellow));
            Console.ResetColor();
            return Console.ReadLine();
        }

        private int GetChoiceWithinBounds(int maxEnumLength)
        {
            int enumChoice = GetValidInteger(Console.ReadLine());
            while (enumChoice < 0 || enumChoice > maxEnumLength)
            {
                enumChoice = GetValidInteger(ReplaceInvalidInput());
            }
            return enumChoice;
        }

        public int GetValidInteger(string inputParameter)
        {
            while (!_inputValidation.IsValidInteger(inputParameter))
            {
                inputParameter = ReplaceInvalidInput();
            }
            int.TryParse(inputParameter, out int validData);
            return validData;
        }
        public string ReplaceInvalidInput()
        {
            Console.Write("\nThe Provided input is invalid !!\nProvide the Input again :".Pastel(ConsoleColor.Red));
            string inputParameter = Console.ReadLine();
            Console.ResetColor();
            return inputParameter;
        }

        public string GetUserName()
        {
            Console.Write("Provide the User Name :".Pastel(ConsoleColor.Yellow));
            return Console.ReadLine();
        }

        public bool ValidatePassword(string correctPassword)
        {
            string inputPassword = GetPassword();
            int noOfTries = 0;
            while (noOfTries < 2)
            {
                if (correctPassword == inputPassword)
                    return true;
                else
                {
                    Console.Beep();
                    Console.WriteLine("\nThe input password is wrong !!".Pastel(ConsoleColor.Red));
                    Console.Write("Give the Correct Password :".Pastel(ConsoleColor.Yellow));
                    inputPassword = Console.ReadLine();
                }
                noOfTries++;
            }
            return false;
        }

        public string GetTaskHeading()
        {
            Console.Write("Provide the heading of the Task: ".Pastel(ConsoleColor.Yellow));
            return GetValidString(Console.ReadLine());
        }

        public string GetTaskDescription()
        {
            Console.Write("Provide the description: ".Pastel(ConsoleColor.Yellow));
            return GetValidString(Console.ReadLine());
        }

        public int GetTaskRecurrence()
        {
            Console.WriteLine($"[0] {RecurrenceField.Daily}\n[1] {RecurrenceField.Weekly}\n[2] {RecurrenceField.Monthly}");
            Console.Write("Provide the Recurrence of the Task: ".Pastel(ConsoleColor.Yellow));
            return GetChoiceWithinBounds(3);
        }

        public int GetCalendarOption()
        {
            Console.WriteLine($"[0] {CalendarChoice.Day}\n[1] {CalendarChoice.Month}\n[2] {CalendarChoice.Year}");
            Console.Write("Provide the field of the calendar : ".Pastel(ConsoleColor.Yellow));
            return GetChoiceWithinBounds(2);
        }

        public int GetTaskIndex(int maxValue)
        {
            Console.Write("Select the task index : ".Pastel(ConsoleColor.Yellow));
            int userSelectedIndex = GetValidInteger(Console.ReadLine());
            while (userSelectedIndex <= 0 || userSelectedIndex > maxValue)
            {
                userSelectedIndex = GetValidInteger(ReplaceInvalidInput());
            }
            return userSelectedIndex;
        }
    }
}