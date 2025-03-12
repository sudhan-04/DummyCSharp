namespace TimeTracker.Services
{
    internal class InputValidation
    {
        public bool IsValidInput(string inputString)
        {
            return (inputString == null || inputString == "");
        }

        public bool IsValidInteger(string inputString)
        {
            return (int.TryParse(inputString, out int parsedInteger));
        }

        public bool IsValidDateTime(string inputString)
        {
            return (DateTime.TryParse(inputString, out DateTime parsedDateTime));
        }

        public bool IsValidTimeSpan(string inputString)
        {
            return (TimeSpan.TryParse(inputString, out TimeSpan parsedDateTime));
        }

        public bool IsPasswordValid(string inputString)
        {
            bool isConditionSatisfied = false;

            if (inputString.Length >= 6)
                isConditionSatisfied = true;

            if (isConditionSatisfied)
            {
                isConditionSatisfied = false;

                char[] specialCharacters = { '!', '@', '#', '$', '%', '^', '&', '+', '=', '*', '(', ')', '_', '-', '?', '/', '>', '<', ':', ';', '{', '}', '[', ']', '\\', '|' };
                if (inputString.IndexOfAny(specialCharacters) != -1)
                    isConditionSatisfied = true;
            }

            if (isConditionSatisfied)
            {
                isConditionSatisfied = false;

                if (inputString.Any(c => c >= 'a' && c <= 'z'))
                    isConditionSatisfied = true;
            }

            if (isConditionSatisfied)
            {
                isConditionSatisfied = false;

                if (inputString.Any(c => c >= '0' && c <= '9'))
                    isConditionSatisfied = true;
            }

            if (isConditionSatisfied)
            {
                isConditionSatisfied = false;

                if (inputString.Any(c => c >= 'A' && c <= 'Z'))
                    isConditionSatisfied = true;
            }

            return isConditionSatisfied;
        }
    }
}
