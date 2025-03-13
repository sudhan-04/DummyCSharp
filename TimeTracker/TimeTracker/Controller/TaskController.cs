﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Model;
using TimeTracker.View;
using TimeTracker.Services;
using System.Diagnostics;
using ConsoleTables;
using Pastel;

namespace TimeTracker.Controller
{
    internal class TaskController
    {
        private InputManager _inputManager;
        private OutputManager _outputManager;
        private FileHandler _fileHandler;

        public TaskController(InputManager inputManager, OutputManager outputManager, FileHandler fileHandler)
        {
            _inputManager = inputManager;
            _outputManager = outputManager;
            _fileHandler = fileHandler;
        }

        public Dashboard GetDashboardChoice(int inputUserId, Dashboard dashboardChoice)
        {
            var fileFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "TimeTracker\\UserData");
            User user = _fileHandler.ReadJsonFile($"{fileFolderPath}\\{inputUserId}.json");

            AppDomain.CurrentDomain.ProcessExit += (sender, e) => LogOutUser(user);
            Console.CancelKeyPress += (sender, e) => LogOutUser(user);

            switch (dashboardChoice)
            {
                case Dashboard.CreateTask:
                    CreateTask(user);
                    break;
                case Dashboard.SelectTask:
                    SelectTask(user);
                    break;
                case Dashboard.ExportToCsv:
                    ExportToCsvFile(user);
                    break;
                case Dashboard.ViewTasks:
                    _outputManager.PrintTasks(user.UserTasks, "\nAll the tasks are displayed below : ");
                    break;
                case Dashboard.ManageTasks:
                    ManageTasks(user);
                    break;
                case Dashboard.LogOut:
                    LogOutUser(user);
                    break;

            }
            return dashboardChoice;
        }

        private void ExportToCsvFile(User user)
        {
            var fileFolderPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                "TimeTracker",
                "CsvData"
            );

            string filePath = Path.Combine(fileFolderPath, $"{user.UserId}.csv");

            Directory.CreateDirectory(fileFolderPath);

            _fileHandler.CreateCsvFile(filePath);
            _fileHandler.WriteToCsvFile(filePath, user.UserTasks);
            _outputManager.PrintExportedToCsv();

            try
            {
                Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
            }
            catch { }
        }

        private void ExportFilteredListToCsvFile(User user, List<UserTask> taskList)
        {
            var fileFolderPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                "TimeTracker",
                "FilteredCsvData",
                $"{user.UserName}"
            );

            string currentTime = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            string filePath = Path.Combine(fileFolderPath, $"{user.UserName}_{currentTime}.csv");

            Directory.CreateDirectory(fileFolderPath);

            _fileHandler.CreateCsvFile(filePath);
            _fileHandler.WriteToCsvFile(filePath, taskList);
            _outputManager.PrintExportedToCsv();

            try
            {
                Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
            }
            catch { }
        }

        private void CreateTask(User user)
        {
            UserTask newTask = new UserTask();
            newTask.Heading = _inputManager.GetTaskHeading();
            newTask.Description = _inputManager.GetTaskDescription();
            newTask.Status = UserTaskStatus.Created;
            newTask.StartTime = null;
            newTask.EndTime = null;
            user.UserTasks?.Add(newTask);
            var fileFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "TimeTracker\\UserData");
            _fileHandler.WriteToJsonFile($"{fileFolderPath}\\{user.UserId}.json", user);
            _outputManager.PrintSuccessfulTaskCreation();
            _outputManager.PrintSpecificTaskInformation(newTask);
        }

        private void StartTask(User user, int taskIndex)
        {
            if (user.UserTasks?.Where(i => i.Status == UserTaskStatus.Running).Count() == 0)
            {
                if (user.UserTasks?[taskIndex].Status == UserTaskStatus.Created)
                {
                    user.UserTasks[taskIndex].Status = UserTaskStatus.Running;
                    user.UserTasks[taskIndex].StartTime = DateTime.Now;
                }
                else if (user.UserTasks?[taskIndex].Status == UserTaskStatus.Stopped)
                {
                    UserTask userTask = new UserTask();
                    userTask.Heading = user.UserTasks[taskIndex].Heading;
                    userTask.Description = user.UserTasks[taskIndex].Description;
                    userTask.Status = UserTaskStatus.Running;
                    userTask.StartTime = DateTime.Now;
                    userTask.EndTime = null;
                    user.UserTasks.Add(userTask);
                }
                else
                {
                    _outputManager.PrintInvalidTaskOperation();
                    return;
                }

                var fileFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "TimeTracker\\UserData");
                _fileHandler.WriteToJsonFile($"{fileFolderPath}\\{user.UserId}.json", user);
                _outputManager.PrintTaskStarted();
            }
            else
            {
                _outputManager.PrintTaskAlreadyRunning();
            }
        }

        private void PauseTask(User user, int taskIndex)
        {
            if (user.UserTasks?[taskIndex].Status == UserTaskStatus.Running)
            {
                user.UserTasks[taskIndex].Status = UserTaskStatus.Paused;
                user.UserTasks[taskIndex].PausedTimesList.Add(DateTime.Now);
                user = CalculateTimeExecuted(user, taskIndex);
                var fileFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "TimeTracker\\UserData");
                _fileHandler.WriteToJsonFile($"{fileFolderPath}\\{user.UserId}.json", user);
                _outputManager.PrintTaskPaused();
            }
            else
            {
                _outputManager.PrintInvalidTaskOperation();
            }
        }

        private User CalculateTimeExecuted(User user, int taskIndex)
        {
            var pausedTimesCount = user.UserTasks[taskIndex].PausedTimesList.Count();
            var resumedTimesCount = user.UserTasks[taskIndex].ResumedTimesList.Count();

            if (pausedTimesCount != 0 && resumedTimesCount != 0)
            {
                if (pausedTimesCount == user.UserTasks[taskIndex].ResumedTimesList.Count || pausedTimesCount - 1 == user.UserTasks[taskIndex].ResumedTimesList.Count)
                {
                    if (pausedTimesCount != 1)
                    {
                        for (int count = 0; count < pausedTimesCount; count++)
                        {
                            if (count == 0)
                            {
                                user.UserTasks[taskIndex].TimeExecuted += user.UserTasks[taskIndex].PausedTimesList[0] - user.UserTasks[taskIndex].StartTime;
                            }
                            else if (count == pausedTimesCount - 1)
                            {
                                user.UserTasks[taskIndex].TimeExecuted += user.UserTasks[taskIndex].EndTime - user.UserTasks[taskIndex].ResumedTimesList[pausedTimesCount - 1];

                            }
                            else
                            {
                                user.UserTasks[taskIndex].TimeExecuted += user.UserTasks[taskIndex].PausedTimesList[count + 1] - user.UserTasks[taskIndex].ResumedTimesList[count];
                            }
                        }
                    }
                }

                return user;
            }

            else if (pausedTimesCount == 1 && resumedTimesCount == 1)
            {
                user.UserTasks[taskIndex].TimeExecuted += user.UserTasks[taskIndex].PausedTimesList[0] - user.UserTasks[taskIndex].StartTime;
                user.UserTasks[taskIndex].TimeExecuted += user.UserTasks[taskIndex].EndTime - user.UserTasks[taskIndex].ResumedTimesList[0];
                return user;
            }

            else if (pausedTimesCount == 1 && resumedTimesCount == 0)
            {
                user.UserTasks[taskIndex].TimeExecuted += user.UserTasks[taskIndex].PausedTimesList[0] - user.UserTasks[taskIndex].StartTime;
                return user;
            }

            else if(pausedTimesCount == 0)
            {
                user.UserTasks[taskIndex].TimeExecuted += user.UserTasks[taskIndex].EndTime - user.UserTasks[taskIndex].StartTime;
                return user;
            }

            else
            {
                return user;
            }
        }

        private void StopTask(User user, int taskIndex)
        {
            if (user.UserTasks?[taskIndex].Status == UserTaskStatus.Running)
            {
                user.UserTasks[taskIndex].Status = UserTaskStatus.Stopped;
                user.UserTasks[taskIndex].EndTime = DateTime.Now;
                user = CalculateTimeExecuted(user, taskIndex);
                var fileFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "TimeTracker\\UserData");
                _fileHandler.WriteToJsonFile($"{fileFolderPath}\\{user.UserId}.json", user);
                _outputManager.PrintTaskStopped();
            }
            else
            {
                _outputManager.PrintInvalidTaskOperation();
            }
        }

        private void ResumeTask(User user, int taskIndex)
        {
            if (user.UserTasks?[taskIndex].Status == UserTaskStatus.Paused)
            {
                user.UserTasks[taskIndex].Status = UserTaskStatus.Running;
                user.UserTasks[taskIndex].ResumedTimesList?.Add(DateTime.Now);
                var fileFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "TimeTracker\\UserData");
                _fileHandler.WriteToJsonFile($"{fileFolderPath}\\{user.UserId}.json", user);
                _outputManager.PrintTaskResumed();
            }
            else
            {
                _outputManager.PrintInvalidTaskOperation();
            }
        }


        private void DeleteTask(User user, int deleteChoiceIndex)
        {
            if (deleteChoiceIndex > -1)
            {
                user.UserTasks?.RemoveAt(deleteChoiceIndex);
                _outputManager.PrintSuccessfulTaskDeletion();
                var fileFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "TimeTracker\\UserData");
                _fileHandler.WriteToJsonFile($"{fileFolderPath}\\{user.UserId}.json", user);
            }
            else
            {
                _outputManager.PrintNoMatches();
            }
        }

        private void EditTask(User user, int editChoiceIndex)
        {
            if (editChoiceIndex > -1)
            {
                EditField editField = (EditField)Enum.Parse(typeof(EditField), _inputManager.GetEditField());
                switch (editField)
                {
                    case EditField.EditHeading:
                        user.UserTasks[editChoiceIndex].Heading = _inputManager.GetTaskHeading();
                        break;

                    case EditField.EditDescription:
                        user.UserTasks[editChoiceIndex].Description = _inputManager.GetTaskDescription();
                        break;

                    case EditField.EditStartTime:
                        var editedStartTime = _inputManager.GetStartDateTime();
                        var editedEndTime = user.UserTasks?[editChoiceIndex].EndTime;
                        while (editedEndTime < editedStartTime)
                        {
                            editedEndTime = _inputManager.GetValidTimeShifts(user, editChoiceIndex, false);
                        }

                        user.UserTasks[editChoiceIndex].StartTime = editedStartTime;
                        user.UserTasks[editChoiceIndex].EndTime = editedEndTime;
                        break;

                    case EditField.EditEndTime:
                        var modifiedEndTime = _inputManager.GetEndDateTime();
                        var modifiedStartTime = user.UserTasks?[editChoiceIndex].StartTime;
                        while (modifiedEndTime < modifiedStartTime)
                        {
                            modifiedStartTime = _inputManager.GetValidTimeShifts(user, editChoiceIndex, true);
                        }

                        user.UserTasks[editChoiceIndex].StartTime = modifiedStartTime;
                        user.UserTasks[editChoiceIndex].EndTime = modifiedEndTime;
                        break;

                    case EditField.EditTimeExecuted:
                        user.UserTasks[editChoiceIndex].TimeExecuted = _inputManager.GetTimeExecuted();
                        break;
                }

                _outputManager.PrintTaskUpdated();
                _outputManager.PrintSpecificTaskInformation(user.UserTasks[editChoiceIndex]);
                var fileFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "TimeTracker\\UserData");
                _fileHandler.WriteToJsonFile($"{fileFolderPath}\\{user.UserId}.json", user);
            }
            else
            {
                _outputManager.PrintNoMatches();
            }
        }

        private int SelectTaskIndex(User user)
        {
            var filteredList = ReturnFilteredList(user);
            Console.WriteLine();
            for (int index = 1; index <= filteredList.Count; index++)
            {
                Console.WriteLine($"[{index}]");
                _outputManager.PrintSpecificTaskInformation(filteredList[index - 1]);
                Console.WriteLine();
            }

            int matchedIndex = 0;
            if (filteredList.Count > 0)
            {
                int numberOfMatchingChoices = 0;
                int ChoiceIndex = _inputManager.GetTaskIndex(filteredList.Count);
                foreach (UserTask userTask in filteredList)
                {
                    numberOfMatchingChoices++;
                    if (ChoiceIndex == numberOfMatchingChoices)
                    {
                        matchedIndex = user.UserTasks.IndexOf(userTask);
                    }
                }

                return matchedIndex;
            }

            return -1;
        }

        private List<UserTask> ReturnFilteredList(User user)
        {
            var filterChoice = (FilterChoice)Enum.Parse(typeof(FilterChoice), _inputManager.GetFilterChoice());
            string taskHeading;
            UserTaskStatus taskStatus;
            switch (filterChoice)
            {
                case FilterChoice.None:
                    return user.UserTasks;
                case FilterChoice.Both:
                    taskHeading = _inputManager.GetTaskHeading();
                    taskStatus = (UserTaskStatus)Enum.Parse(typeof(UserTaskStatus), _inputManager.GetTaskStatus());
                    return user.UserTasks.Where(i => i.Heading.Contains(taskHeading) && i.Status.Equals(taskStatus)).ToList();
                case FilterChoice.Heading:
                    taskHeading = _inputManager.GetTaskHeading();
                    return user.UserTasks.Where(i => i.Heading.Contains(taskHeading)).ToList();
                case FilterChoice.TaskStatus:
                    taskStatus = (UserTaskStatus)Enum.Parse(typeof(UserTaskStatus), _inputManager.GetTaskStatus());
                    return user.UserTasks.Where(i => i.Status.Equals(taskStatus)).ToList();

            }

            return new List<UserTask>();
        }

        private void SelectTask(User user)
        {
            if (user.UserTasks?.Count > 0)
            {
                int taskIndex = SelectTaskIndex(user);
                if (taskIndex < 0)
                    _outputManager.PrintNoMatches();
                else
                {
                    var currentTask = Enum.Parse(typeof(TaskOperations), _inputManager.GetTaskOperation());

                    if (user.UserTasks[taskIndex].PausedTimesList == null)
                        user.UserTasks[taskIndex].PausedTimesList = new List<DateTime>();
                    if (user.UserTasks[taskIndex].ResumedTimesList == null)
                        user.UserTasks[taskIndex].ResumedTimesList = new List<DateTime>();
                    if (user.UserTasks[taskIndex].TimeExecuted == null)
                        user.UserTasks[taskIndex].TimeExecuted = TimeSpan.Zero;


                    switch (currentTask)
                    {
                        case TaskOperations.StartTask:
                            StartTask(user, taskIndex);
                            break;
                        case TaskOperations.StopTask:
                            StopTask(user, taskIndex);
                            break;
                        case TaskOperations.PauseTask:
                            PauseTask(user, taskIndex);
                            break;
                        case TaskOperations.ResumeTask:
                            ResumeTask(user, taskIndex);
                            break;
                        case TaskOperations.DeleteTask:
                            DeleteTask(user, taskIndex);
                            break;
                        case TaskOperations.EditTask:
                            EditTask(user, taskIndex);
                            break;
                    }
                }
            }
            else
            {
                _outputManager.PrintNoTasksPresent();
            }
        }

        public void LogOutUser(User user)
        {
            var runningTaskIndex = user.UserTasks.IndexOf(user.UserTasks.Where(i => i.Status == UserTaskStatus.Running).FirstOrDefault());
            if (runningTaskIndex >= 0)
            {
                user.UserTasks[runningTaskIndex].Status = UserTaskStatus.Paused;
                var fileFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "TimeTracker\\UserData");
                _fileHandler.WriteToJsonFile($"{fileFolderPath}\\{user.UserId}.json", user);
            }
        }

        public void ManageTasks(User user)
        {
            var taskListOperation = (TaskListOperations)Enum.Parse(typeof(TaskListOperations), _inputManager.GetTaskListOperation());
            List<UserTask> taskList = user.UserTasks;
            while (taskListOperation != TaskListOperations.ReturnToDashboard)
            {
                switch (taskListOperation)
                {
                    case TaskListOperations.SortTasks:
                        taskList = SortTasks(taskList);
                        break;
                    case TaskListOperations.FilterTasks:
                        taskList = FilterTasks(taskList);
                        break;
                    case TaskListOperations.ExportToCsv:
                        ExportFilteredListToCsvFile(user, taskList);
                        Console.Clear();
                        _outputManager.PrintAnyKeyToPerformAction();
                        Console.ReadKey();
                        break;
                    case TaskListOperations.ViewTaskSummary:
                        ViewTaskSummary(user.UserTasks);
                        break;
                }

                _outputManager.PrintAnyKeyToPerformAction();
                Console.ReadKey();
                Console.Clear();
                taskListOperation = (TaskListOperations)Enum.Parse(typeof(TaskListOperations), _inputManager.GetTaskListOperation());
            }
        }

        public List<UserTask> SortTasks(List<UserTask> tasks)
        {
            var sortingField = (SortingField)Enum.Parse(typeof(SortingField), _inputManager.GetSortingField());
            switch (sortingField)
            {
                case SortingField.Heading:
                    tasks = tasks.OrderBy(x => x.Heading).ToList();
                    break;
                case SortingField.TaskStatus:
                    tasks = tasks.OrderBy(x => x.Status).ToList();
                    break;
                case SortingField.StartTime:
                    tasks = tasks.OrderBy(x => x.StartTime).ToList();
                    break;
                case SortingField.EndTime:
                    tasks = tasks.OrderBy(x => x.EndTime).ToList();
                    break;
                case SortingField.TimeExecuted:
                    tasks = tasks.OrderBy(x => x.TimeExecuted).ToList();
                    break;
                default:
                    return tasks;
            }

            _outputManager.PrintTasks(tasks, "\nThe sorted list is displayed below : ");
            return tasks;
        }

        public List<UserTask> FilterTasks(List<UserTask> tasks)
        {
            var filteringFields = _inputManager.GetFilteringField();
            foreach (var filterField in filteringFields)
            {
                var filterCategory = (FilteringField)Enum.Parse(typeof(FilteringField), filterField);
                switch (filterCategory)
                {
                    case FilteringField.Heading:
                        var taskHeading = _inputManager.GetTaskHeading();
                        tasks = tasks.Where(x => x.Heading.Contains(taskHeading)).ToList();
                        break;
                    case FilteringField.TaskStatus:
                        var status = _inputManager.GetTaskStatus();
                        var taskStatus = (UserTaskStatus)Enum.Parse(typeof(UserTaskStatus), status);
                        tasks = tasks.Where(x => x.Status == taskStatus).ToList();
                        break;
                    case FilteringField.StartTime:
                        var taskStartTime = _inputManager.GetTargetStartDate();
                        tasks = tasks.Where(x => x.StartTime?.Date == taskStartTime).ToList();
                        break;
                    case FilteringField.EndTime:
                        var taskEndTime = _inputManager.GetTargetEndDate();
                        tasks = tasks.Where(x => x.EndTime?.Date == taskEndTime).ToList();
                        break;
                    case FilteringField.TimeExecuted:
                        var taskExecutedTime = _inputManager.GetTimeExecuted();
                        tasks = tasks.Where(x => x.TimeExecuted <= taskExecutedTime).ToList();
                        break;
                    case FilteringField.Description:
                        var taskDescription = _inputManager.GetTaskDescription();
                        tasks = tasks.Where(x => x.Description.Contains(taskDescription)).ToList();
                        break;
                }
            }

            _outputManager.PrintTasks(tasks, "\nThe filtered list is displayed below : ");
            return tasks;
        }

        public void ViewTaskSummary(List<UserTask> tasks)
        {
            var summaryOption = (SummaryOptions)Enum.Parse(typeof(SummaryOptions), _inputManager.GetSummaryOptions());
            switch (summaryOption)
            {
                case SummaryOptions.Daily:
                    GenerateDailySummary(tasks);
                    break;
                case SummaryOptions.Weekly:
                    GenerateWeeklySummary(tasks);
                    break;
                case SummaryOptions.Monthly:
                    GenerateMonthlySummary(tasks);
                    break;
            }
        }

        private void GenerateDailySummary(List<UserTask> tasks)
        {
            var targetDate = _inputManager.GetTargetDate();
            ConsoleTable consoleTable = new ConsoleTable("Total Time Spent", "Longest Task - Time Spent", "Shortest Task - Time Spent", "Total number of tasks");
            var targetDateTasks = tasks.Where(x => x.StartTime?.Date == (targetDate));
            var timeSpentOnTasks = targetDateTasks.Select(x => x.TimeExecuted);

            TimeSpan? totalTime = TimeSpan.Zero;
            foreach (var timeSpent in timeSpentOnTasks)
            {
                totalTime += timeSpent;
            }

            var longestTask = targetDateTasks.MaxBy(x => x.TimeExecuted);
            var longestTaskDetails = longestTask?.Heading + " - " + longestTask?.TimeExecuted.ToString();

            var shortestTask = targetDateTasks.MinBy(x => x.TimeExecuted);
            var shortestTaskDetails = shortestTask?.Heading + " - " + shortestTask?.TimeExecuted.ToString();

            var tasksCount = targetDateTasks.Count();

            consoleTable.AddRow(totalTime, longestTaskDetails, shortestTaskDetails, tasksCount);
            consoleTable.Write();
        }

        private void GenerateWeeklySummary(List<UserTask> tasks)
        {
            var startOfWeek = DateTime.Now.AddDays(-(int)DateTime.Now.DayOfWeek);
            var endOfWeek = DateTime.Now.Date;

            ConsoleTable consoleTable = new ConsoleTable("Total Time Spent", "Average Time Spent Each day", "Most Productive Day - Time Spent", "Longest Task - Time Spent", "Shortest Task - Time Spent", "Total number of tasks");

            var weeklyTasks = tasks.Where(x => x.StartTime?.Date >= startOfWeek && x.StartTime?.Date <= endOfWeek);
            var timeSpentOnTasks = weeklyTasks.Select(x => x.TimeExecuted);

            TimeSpan? totalTime = TimeSpan.Zero;
            foreach (var timeSpent in timeSpentOnTasks)
            {
                totalTime += timeSpent;
            }

            var longestTask = weeklyTasks.MaxBy(x => x.TimeExecuted);
            var longestTaskDetails = longestTask?.Heading + " - " + longestTask?.TimeExecuted.ToString();

            var shortestTask = weeklyTasks.MinBy(x => x.TimeExecuted);
            var shortestTaskDetails = shortestTask?.Heading + " - " + shortestTask?.TimeExecuted.ToString();

            var tasksCount = weeklyTasks.Count();

            var daywiseTasks = weeklyTasks.GroupBy(x => x.StartTime?.Date);
            TimeSpan? dailyTimeSpent = TimeSpan.Zero;
            TimeSpan? highestTimeSpent = TimeSpan.Zero;
            string mostProductiveDay = null;

            foreach (var dailyTasks in daywiseTasks)
            {
                foreach (var task in dailyTasks)
                {
                    dailyTimeSpent += task.TimeExecuted;
                }

                if (dailyTimeSpent > highestTimeSpent)
                {
                    mostProductiveDay = dailyTasks.FirstOrDefault().StartTime.Value.ToString("dd/MM/yyyy");
                    highestTimeSpent = dailyTimeSpent;
                }
            }

            consoleTable.AddRow(totalTime, totalTime / (endOfWeek - startOfWeek), mostProductiveDay + " - " + highestTimeSpent, longestTaskDetails, shortestTaskDetails, tasksCount);
            consoleTable.Write();
        }

        private void GenerateMonthlySummary(List<UserTask> tasks)
        {
            var startOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 01);
            var endOfMonth = DateTime.Now.Date;

            ConsoleTable consoleTable = new ConsoleTable("Total Time Spent", "Average Time Spent Each day", "Most Productive Day - Time Spent", "Longest Task - Time Spent", "Shortest Task - Time Spent", "Total number of tasks");

            var weeklyTasks = tasks.Where(x => x.StartTime?.Date >= startOfMonth && x.StartTime?.Date <= endOfMonth);
            var timeSpentOnTasks = weeklyTasks.Select(x => x.TimeExecuted);

            TimeSpan? totalTime = TimeSpan.Zero;
            foreach (var timeSpent in timeSpentOnTasks)
            {
                totalTime += timeSpent;
            }

            var longestTask = weeklyTasks.MaxBy(x => x.TimeExecuted);
            var longestTaskDetails = longestTask?.Heading + " - " + longestTask?.TimeExecuted.ToString();

            var shortestTask = weeklyTasks.MinBy(x => x.TimeExecuted);
            var shortestTaskDetails = shortestTask?.Heading + " - " + shortestTask?.TimeExecuted.ToString();

            var tasksCount = weeklyTasks.Count();

            var daywiseTasks = weeklyTasks.GroupBy(x => x.StartTime?.Date);
            TimeSpan? dailyTimeSpent = TimeSpan.Zero;
            TimeSpan? highestTimeSpent = TimeSpan.Zero;
            string mostProductiveDay = null;

            foreach (var dailyTasks in daywiseTasks)
            {
                foreach (var task in dailyTasks)
                {
                    dailyTimeSpent += task.TimeExecuted;
                }

                if (dailyTimeSpent > highestTimeSpent)
                {
                    mostProductiveDay = dailyTasks.FirstOrDefault().StartTime.Value.ToString("dd/MM/yyyy");
                    highestTimeSpent = dailyTimeSpent;
                }
            }

            consoleTable.AddRow(totalTime.Value.ToString("hh:mm:ss"), (totalTime / (endOfMonth - startOfMonth)).Value.ToString("hh:mm:ss"), mostProductiveDay + " - " + highestTimeSpent.Value.ToString("hh/mm/ss"), longestTaskDetails, shortestTaskDetails, tasksCount);
            consoleTable.Write();
        }
    }
}
