using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTableScheduler.DataValidation
{
    public class InputValidation
    {
        public bool IsValidInput(string inputString)
        {
            return (inputString == null || inputString == "");
        }

        public bool IsValidDate(string inputString)
        {
            bool isValidDate = DateTime.TryParse(inputString, out DateTime parsedDate);
            if (isValidDate)
            {
                return parsedDate >= DateTime.Today;
            }
            return false;
        }

        public bool IsValidInteger(string inputString)
        {
            return (int.TryParse(inputString, out int parsedInteger));
        }
    }
}