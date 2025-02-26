namespace TimeTableScheduler.Model
{
    public class User
    {
        private int _id;
        private string? _password;
        private string? _name;
        private List<Task> _userTask;

        public int UserId { get { return _id; } set { _id = value; } }
        public string Password { get { return _password; } set { _password = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public List<Task> UserTask { get { return _userTask; } set { _userTask = value; } }
    }
}