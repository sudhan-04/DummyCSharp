using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using TimeTableScheduler.Model;

namespace TimeTableScheduler.FileManager
{
    public class DataHandler
    {
        public User ReadFile(string path)
        {
            string userDetails = File.ReadAllText(path);
            return JsonSerializer.Deserialize<User>(userDetails);
        }

        public void WriteFile(string path, User user)
        {
            File.WriteAllText(path, JsonSerializer.Serialize(user));
        }
    }
}