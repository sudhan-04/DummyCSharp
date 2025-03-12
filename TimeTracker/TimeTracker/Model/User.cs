namespace TimeTracker.Model
{
    public class User
    {
        public int UserId { get; set; }
        public string Password { get; set; }
        public string? UserName { get; set; }
        public List<UserTask>? UserTasks { get; set; }
    }
}
