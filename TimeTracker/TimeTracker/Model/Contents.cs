namespace TimeTracker.Model
{
    public enum InitialMenu
    {
        Login,
        SignUp,
        ExitApplication
    }

    public enum Dashboard
    {
        CreateTask,
        SelectTask,
        ExportToCsv,
        ViewTasks,
        LogOut
    }

    public enum FilterChoice
    {
        Heading,
        TaskStatus,
        Both,
        None
    }
    public enum TaskOperations
    {
        StartTask,
        StopTask,
        PauseTask,
        ResumeTask,
        EditTask,
        DeleteTask
    }

    public enum EditField
    {
        EditHeading,
        EditDescription,
        EditStartTime,
        EditEndTime,
        EditTimeExecuted
    }

    public enum UserTaskStatus
    {
        Created,
        Running,
        Paused,
        Stopped
    }
}
