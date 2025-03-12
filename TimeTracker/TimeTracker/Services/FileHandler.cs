using System.Formats.Asn1;
using System.Globalization;
using System.Text.Json;
using ConsoleTables;
using TimeTracker.Model;
using CsvHelper;

namespace TimeTracker.Services
{
    internal class FileHandler
    {
        public User ReadJsonFile(string path)
        {
            string userDetails = File.ReadAllText(path);
            return JsonSerializer.Deserialize<User>(userDetails);
        }

        public void WriteToJsonFile(string path, User user)
        {
            File.WriteAllText(path, JsonSerializer.Serialize(user));
        }

        public void CreateCsvFile(string path)
        {
            if (File.Exists(path)) File.Delete(path);
            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                CsvWriter csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);
                csvWriter.WriteHeader<UserTask>();
                csvWriter.NextRecord();
            }

        }

        public void WriteToCsvFile(string path, List<UserTask> userTasks)
        {
            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                CsvWriter csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);
                csvWriter.WriteRecords(userTasks);
                csvWriter.NextRecord();
            }
        }
    }
}
