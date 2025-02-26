using TimeTableScheduler.ConsoleUI;
using TimeTableScheduler.Model;
using TimeTableScheduler.FileManager;
using Task = TimeTableScheduler.Model.Task;

namespace TimeTableScheduler.Utility
{
    public class UserManager
    {
        private InputManager _inputManager;
        private OutputManager _outputManager;
        private DataHandler _dataHandler;
        public UserManager(InputManager mainInputManager, OutputManager mainOutputManager, DataHandler mainDataHandler)
        {
            _inputManager = mainInputManager;
            _outputManager = mainOutputManager;
            _dataHandler = mainDataHandler;
        }
        public int UserValidation()
        {
            UserType userType = (UserType)_inputManager.GetUserType();
            switch (userType)
            {
                case UserType.NewUser:
                    return AddUser();
                case UserType.OldUser:
                    return ValidateUser();
                case UserType.ExitApplication:
                    Console.ReadKey();
                    return 5;
                default:
                    return -1;
            }
        }

        public int AddUser()
        {
            User user = new User();
            int userId = _inputManager.GetUserId();
            if (File.Exists($"{userId}.json"))
            {
                _outputManager.PrintUserAlreadyPresent();
                return -1;
            }
            else
            {
                user.UserId = userId;
                user.Password = _inputManager.GetPassword();
                user.Name = _inputManager.GetUserName();
                user.UserTask = new List<Task>();
                _dataHandler.WriteFile($"{user.UserId}.json", user);
                _outputManager.PrintSuccessfulLogin();
                _outputManager.PrintPressAnyKeyToPerformNextAction();
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine($"Welcome {user.Name} !!!");
                return user.UserId;
            }
        }

        public int ValidateUser()
        {

            int UserId = _inputManager.GetUserId();
            if (File.Exists($"{UserId}.json"))
            {
                User user = _dataHandler.ReadFile($"{UserId}.json");
                if (_inputManager.ValidatePassword(user.Password))
                {
                    _outputManager.PrintSuccessfulLogin();
                    _outputManager.PrintPressAnyKeyToPerformNextAction();
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine($"Welcome {user.Name} !!!");
                    return user.UserId;
                }
                else
                {
                    _outputManager.PrintFailedLogin();
                    return -1;
                }
            }
            else
            {
                _outputManager.PrintFailedLogin();
                return -1;
            }
        }
    }
}