using ConsoleTables;
using Pastel;

namespace Dictionary
{
    public class StudentGrades
    {
        Dictionary<string, int> studentGrades;

        /// <summary>
        /// Constructor block to assign the dictionary
        /// </summary>
        /// <param name="studentGrades">The dictionary which is injected through the constructor</param>
        public StudentGrades(Dictionary<string, int> studentGrades)
        { this.studentGrades = studentGrades; }

        /// <summary>
        /// Performs the required dictionary operations
        /// </summary>
        public void DoDictionaryOperations()
        {

            Console.WriteLine($"--------WELCOME--------".Pastel(ConsoleColor.Magenta));
            Console.WriteLine($"\nThe Dictionary of student grades is successfully created !!".Pastel(ConsoleColor.Cyan));

            AddStudent();

            RemoveStudent();

            ReturnDictionaryAsTable().Write();

        }


        /// <summary>
        /// Method which returns the Dictionary as a Console Table
        /// </summary>
        /// <returns>The Console Table which is built from the dictionary</returns>
        private ConsoleTable ReturnDictionaryAsTable()
        {
            Console.WriteLine($"\nAll the student grades in the dictionary are : ".Pastel(ConsoleColor.Yellow));

            ConsoleTable stduentGradeTable = new ConsoleTable("S_No", "Student Name","Student Grade");

            for (int count = 1; count <= studentGrades.Count(); count++)
                stduentGradeTable.AddRow(count, studentGrades.ElementAt(count-1).Key, studentGrades.ElementAt(count-1).Value );

            return stduentGradeTable;
        }

        /// <summary>
        /// Method to remove a key-value pair from the dictionary
        /// </summary>
        private void RemoveStudent()
        {
            Console.WriteLine($"\n--------REMOVING STUDENTS--------".Pastel(ConsoleColor.Magenta));

            Console.Write($"\nProvide the name of the student to be deleted : ".Pastel(ConsoleColor.Yellow));
            string deletingStudentName = GetValidString(Console.ReadLine());

            if (studentGrades.Remove(deletingStudentName))
            {
                Console.WriteLine($"\nThe Student '{deletingStudentName}' is successfully deleted from the dictionary !!".Pastel(ConsoleColor.Cyan));
            }
            else
            {
                Console.WriteLine($"\nThe Student '{deletingStudentName}' is not present in the dictionary !!".Pastel(ConsoleColor.Red));
            }
        }

        /// <summary>
        /// Method to add a key-value pair to the dictionary
        /// </summary>
        private void AddStudent()
        {
            Console.WriteLine($"\n--------ADDING GRADES--------\n".Pastel(ConsoleColor.Magenta));

            for (int count = 1; count <= 5; count++)
            {
                Console.Write($"\nProvide the name of the student whose grade is to be added : ".Pastel(ConsoleColor.Yellow));
                string studentName = GetValidString(Console.ReadLine());

                Console.Write($"Provide the grade of the student : ".Pastel(ConsoleColor.Yellow));
                int studentGrade = GetValidInteger(Console.ReadLine());

                studentGrades.Add(studentName, studentGrade);
            }

            ReturnDictionaryAsTable().Write();
        }

        /// <summary>
        /// Method to get a valid string
        /// </summary>
        /// <param name="inputString">String which is checked if it is valid</param>
        /// <returns>A valid string</returns>
        private string GetValidString(string inputString)
        {
            while(inputString == "" ||  inputString == null)
            {
                Console.WriteLine($"The given string is either null or empty !!!".Pastel(ConsoleColor.Red));
                Console.Write($"Provide a valid string :".Pastel(ConsoleColor.Yellow));
                inputString = Console.ReadLine();
            }

            return inputString;
        }

        /// <summary>
        /// Method to get a valid string which can be parsed to an integer
        /// </summary>
        /// <param name="inputString">String which is checked if it can be parsed to an integer</param>
        /// <returns>A valid integer</returns>
        private int GetValidInteger(string inputString)
        {
            while(!int.TryParse(inputString, out int result))
            {
                Console.WriteLine($"The given input is in invalid format and cannot be parsed to an integer !!!".Pastel(ConsoleColor.Red));
                Console.Write($"Provide a valid integer :".Pastel(ConsoleColor.Yellow));
                inputString = Console.ReadLine();
            }

            return int.Parse(inputString);
        }
    }
}
