using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTableScheduler.ConsoleUI;
using TimeTableScheduler.FileManager;
using TimeTableScheduler.Model;
using Task = TimeTableScheduler.Model.Task;

namespace TimeTableScheduler.Utility
{
    public class TaskManager
    {
        private InputManager _inputManager;
        private OutputManager _outputManager;
        private DataHandler _dataHandler;
        public TaskManager(InputManager mainInputManager, OutputManager mainOutputManager, DataHandler mainDataHandler)
        {
            _inputManager = mainInputManager;
            _outputManager = mainOutputManager;
            _dataHandler = mainDataHandler;
        }
        public int GetUserOption(int inputUserId, int userChoice)
        {
            User user = _dataHandler.ReadFile($"{inputUserId}.json");
            UserOptions userOptions = (UserOptions)userChoice;
            switch (userOptions)
            {
                case UserOptions.AddTasks:
                    AddTask(user);
                    break;
                case UserOptions.DeleteTasks:
                    DeleteTask(user);
                    break;
                case UserOptions.ViewTasks:
                    ViewTasks(user);
                    break;
                case UserOptions.EditTasks:
                    EditTask(user);
                    break;
                case UserOptions.CalendarView:
                    ViewCalender(user);
                    break;
            }
            return userChoice;
        }

        public void AddTask(User user)
        {
            Task task = new Task();
            task.Heading = _inputManager.GetTaskHeading();
            task.TargetDate = _inputManager.GetTargetDate();
            task.Description = _inputManager.GetTaskDescription();
            RecurrenceField recurrenceField = (RecurrenceField)_inputManager.GetTaskRecurrence();
            task.Recurrence = recurrenceField.ToString();
            user.UserTask = RecurByParameter(user.UserTask, task, recurrenceField);
            user.UserTask = user.UserTask.OrderBy(o => o.TargetDate).ToList();
            _dataHandler.WriteFile($"{user.UserId}.json", user);
        }

        public void DeleteTask(User user)
        {
            int deleteChoiceIndex = SelectTaskIndex(user.UserTask);
            if (deleteChoiceIndex > -1)
            {
                user.UserTask.RemoveAt(deleteChoiceIndex);
                _outputManager.PrintSuccessfulDeletion();
                _dataHandler.WriteFile($"{user.UserId}.json", user);
            }
            else
            {
                _outputManager.PrintNoMatches();
            }
        }

        public void ViewTasks(User user)
        {

            _outputManager.PrintTasks(user.UserTask);
        }

        public void EditTask(User user)
        {
            int editChoiceIndex = SelectTaskIndex(user.UserTask);
            if (editChoiceIndex > -1)
            {
                EditField editField = (EditField)_inputManager.GetEditField();
                switch (editField)
                {
                    case EditField.EditHeading:
                        user.UserTask[editChoiceIndex].Heading = _inputManager.GetTaskHeading();
                        break;
                    case EditField.EditDescription:
                        user.UserTask[editChoiceIndex].Description = _inputManager.GetTaskDescription();
                        break;
                    case EditField.EditTargetDate:
                        user.UserTask[editChoiceIndex].TargetDate = _inputManager.GetTargetDate();
                        break;
                    case EditField.EditRecurrence:
                        user.UserTask[editChoiceIndex].Recurrence = ((RecurrenceField)_inputManager.GetTaskRecurrence()).ToString();
                        break;
                }
                user.UserTask = user.UserTask.OrderBy(o => o.TargetDate).ToList();
                _dataHandler.WriteFile($"{user.UserId}.json", user);
            }
            else
            {
                _outputManager.PrintNoMatches();
            }
        }

        public void ViewCalender(User user)
        {
            int userCalenderChoice = _inputManager.GetCalendarOption();
            CalendarChoice calenderChoice = (CalendarChoice)userCalenderChoice;
            PrintSameParameterTasks(user.UserTask, calenderChoice);
        }
        private int SelectTaskIndex(List<Task> userTask)
        {
            DateTime deleteChoiceDate = _inputManager.GetTargetDate();
            string deleteChoiceHeading = _inputManager.GetTaskHeading();
            int numberOfMatchingChoices = 0;
            int matchedIndex = 0;
            foreach (Task task in userTask)
            {
                if (task.TargetDate == deleteChoiceDate && task.Heading == deleteChoiceHeading)
                {
                    numberOfMatchingChoices++;
                    Console.WriteLine($"[{numberOfMatchingChoices}]");
                    _outputManager.PrintSpecificTaskInformation(task);
                }
            }

            if (numberOfMatchingChoices > 0)
            {
                int deleteChoiceIndex = _inputManager.GetTaskIndex(numberOfMatchingChoices);
                numberOfMatchingChoices = 0;
                foreach (Task task in userTask)
                {
                    if (task.TargetDate == deleteChoiceDate && task.Heading == deleteChoiceHeading)
                    {
                        numberOfMatchingChoices++;
                        if (deleteChoiceIndex == numberOfMatchingChoices)
                        {
                            matchedIndex = userTask.IndexOf(task);
                        }
                    }
                }
                return matchedIndex;
            }
            return -1;
        }

        private void PrintSameParameterTasks(List<Task> userTask, CalendarChoice calenderChoice)
        {
            switch (calenderChoice)
            {
                case CalendarChoice.Day:
                    foreach (Task task in userTask)
                    {
                        if (task.TargetDate == DateTime.Today)
                        {
                            _outputManager.PrintSpecificTaskInformation(task);
                        }
                    }
                    break;
                case CalendarChoice.Month:
                    foreach (Task task in userTask)
                    {
                        if (task.TargetDate.Month == DateTime.Today.Month)
                        {
                            _outputManager.PrintSpecificTaskInformation(task);
                        }
                    }
                    break;
                case CalendarChoice.Year:
                    foreach (Task task in userTask)
                    {
                        if (task.TargetDate.Year == DateTime.Today.Year)
                        {
                            _outputManager.PrintSpecificTaskInformation(task);
                        }
                    }
                    break;
            }
        }

        public void PrintRecentTask(List<Task> userTask)
        {
            if (userTask.Count > 1)
            {
                _outputManager.PrintSpecificTaskInformation(userTask[0]);
                _outputManager.PrintSpecificTaskInformation(userTask[1]);
            }
        }

        private List<Task> RecurByParameter(List<Task> userTask, Task task, RecurrenceField recurrenceField)
        {
            DateTime initialDate = task.TargetDate;
            int count = 0;
            switch (recurrenceField)
            {
                case RecurrenceField.Daily:
                    while (count < 30)
                    {
                        Task recurrentTask = new Task();
                        recurrentTask.TargetDate = initialDate.AddDays(count);
                        recurrentTask.Heading = task.Heading;
                        recurrentTask.Recurrence = task.Recurrence;
                        recurrentTask.Description = task.Description;
                        userTask.Add(recurrentTask);
                        count++;
                    }
                    break;
                case RecurrenceField.Weekly:
                    while (count <= 70)
                    {
                        Task recurrentTask = new Task();
                        recurrentTask.TargetDate = initialDate.AddDays(count);
                        recurrentTask.Heading = task.Heading;
                        recurrentTask.Recurrence = task.Recurrence;
                        recurrentTask.Description = task.Description;
                        userTask.Add(recurrentTask);
                        count = count + 7;
                    }
                    break;
                case RecurrenceField.Monthly:
                    while (count < 12)
                    {
                        Task recurrentTask = new Task();
                        recurrentTask.TargetDate = initialDate.AddMonths(count);
                        recurrentTask.Heading = task.Heading;
                        recurrentTask.Recurrence = task.Recurrence;
                        recurrentTask.Description = task.Description;
                        userTask.Add(recurrentTask);
                        count++;
                    }
                    break;
            }

            return userTask;
        }
    }
}