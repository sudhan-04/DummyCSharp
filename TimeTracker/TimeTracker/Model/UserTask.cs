using System.Diagnostics;
using CsvHelper.Configuration.Attributes;

namespace TimeTracker.Model
{
    public class UserTask
    {
        public string Heading { get; set; }
        public string? Description { get; set; }
        public DateTime? StartTime { get; set; }       
        public DateTime? EndTime { get; set; }      
        public UserTaskStatus Status { get; set; }
        public TimeSpan TimeExecuted { get; set; }
    }
}
