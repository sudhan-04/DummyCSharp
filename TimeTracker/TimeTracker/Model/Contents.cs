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
        ManageTasks,
        LogOut
    }

    public enum TaskListOperations
    {
        FilterTasks,
        SortTasks,
        ViewTaskSummary,
        ExportToCsv,
        ReturnToDashboard
    }

    public enum SortingField
    {
        TaskStatus,
        Heading,
        TimeExecuted
    }

    public enum SummaryOptions
    {
        Daily,
        Weekly,
        Monthly
    }

    public enum FilteringField
    {
        Heading,
        TaskStatus,
        TimeExecuted,
        Description
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
        Heading,
        Description,
        TimeInterval
    }

    public enum TimeIntervalOptions
    {
        DeleteTimeInterval,
        EditTimeInterval
    }

    public enum UserTaskStatus
    {
        Created,
        Running,
        Paused,
        Stopped
    }
}
