using TimeTracker.Model;
using TimeTracker.Services;
using TimeTracker.View;

namespace TimeTracker.Controller
{
    internal class UserController
    {
        private InputManager _inputManager;
        private OutputManager _outputManager;
        private FileHandler _fileHandler;
        private Encryptor _encryptor;

        public UserController(InputManager inputManager, OutputManager outputManager, FileHandler fileHandler, Encryptor encryptor)
        {
            _inputManager = inputManager;
            _outputManager = outputManager;
            _fileHandler = fileHandler;
            _encryptor = encryptor;
        }

        public int StartApplication()
        {
            InitialMenu userAction = (InitialMenu)Enum.Parse(typeof(InitialMenu), _inputManager.GetUserType());
            Console.Clear();
            switch (userAction)
            {
                case InitialMenu.SignUp:
                    return AddUser();
                case InitialMenu.Login:
                    return ValidateUser();
                case InitialMenu.ExitApplication:
                    return 5;
            }

            return -1;
        }

        public int AddUser()
        {
            User user = new User();
            int userId = _inputManager.GetUserId();
            var fileFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "TimeTracker\\UserData");
            if (File.Exists($"{fileFolderPath}\\{userId}.json"))
            {
                _outputManager.PrintUserAlreadyPresent();
            }
            else
            {
                user.UserId = userId;
                string inputPassword = _inputManager.RegisterPassword();
                if (inputPassword.Equals(""))
                {
                    _outputManager.PrintFailedRegistration();
                }

                user.Password = _encryptor.EncryptInput(inputPassword);
                user.UserName = _inputManager.GetUserName();
                user.UserTasks = new List<UserTask>();
                Directory.CreateDirectory(fileFolderPath);
                _fileHandler.WriteToJsonFile(fileFolderPath + $"\\{user.UserId}.json", user);

                _outputManager.PrintSuccessfulRegistration();
                _outputManager.PrintWelcomeUser(user.UserName);
                return user.UserId;
            }

            return -1;
        }

        public int ValidateUser()
        {

            int UserId = _inputManager.GetUserId();
            var fileFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "TimeTracker\\UserData");
            if (File.Exists($"{fileFolderPath}\\{UserId}.json"))
            {
                User user = _fileHandler.ReadJsonFile($"{fileFolderPath}\\{UserId}.json");
                if (_inputManager.ValidatePassword(_encryptor.DecryptInput(user.Password)))
                {
                    _outputManager.PrintSuccessfulLogin();
                    _outputManager.PrintWelcomeUser(user.UserName);
                    return user.UserId;
                }
                else
                {
                    _outputManager.PrintFailedLogin();
                }
            }
            else
            {
                _outputManager.PrintFailedLogin();
            }

            return -1;
        }
    }
}
