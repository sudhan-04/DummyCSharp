namespace TimeTableScheduler.Model
{
    public class Task
    {
        private string? _heading;
        private string? _description;
        private DateTime _targetDate;
        private string? _recurrence;

        public string Heading { get { return _heading; } set { _heading = value; } }

        public string Description { get { return _description; } set { _description = value; } }

        public string Recurrence { get { return _recurrence; } set { _recurrence = value; } }

        public DateTime TargetDate { get { return _targetDate; } set { _targetDate = value; } }

    }
}