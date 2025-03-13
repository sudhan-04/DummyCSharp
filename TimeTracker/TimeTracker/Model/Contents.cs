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
        StartTime,
        TimeExecuted,
        EndTime
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
        StartTime,
        TimeExecuted,
        EndTime,
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
