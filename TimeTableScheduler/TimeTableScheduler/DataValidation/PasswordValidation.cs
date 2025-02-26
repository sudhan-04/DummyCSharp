namespace TimeTableScheduler.DataValidation
{
    public class PasswordValidation
    {
        public bool IsPasswordValid(string inputString)
        {
            bool isConditionSatisfied = false;
            if (inputString.Length >= 6)
                isConditionSatisfied = true;
            if (isConditionSatisfied)
            {
                isConditionSatisfied = false;
                if (inputString.Contains("!") || inputString.Contains("@") || inputString.Contains("#") || inputString.Contains("$") || inputString.Contains("%") || inputString.Contains("^") || inputString.Contains("(") || inputString.Contains(")") || inputString.Contains("&") || inputString.Contains("_"))
                {
                    isConditionSatisfied = true;
                }
            }
            if (isConditionSatisfied)
            {
                isConditionSatisfied = false;
                foreach (char Character in inputString)
                {
                    if (Character >= 'a' && Character <= 'z')
                    {
                        isConditionSatisfied = true;
                        break;
                    }
                }
            }
            if (isConditionSatisfied)
            {
                isConditionSatisfied = false;
                foreach (char Character in inputString)
                {
                    if (Character >= '0' && Character <= '9')
                    {
                        isConditionSatisfied = true;
                        break;
                    }
                }
            }
            if (isConditionSatisfied)
            {
                isConditionSatisfied = false;
                foreach (char Character in inputString)
                {
                    if (Character >= 'A' && Character <= 'Z')
                    {
                        isConditionSatisfied = true;
                        break;
                    }
                }
            }
            return isConditionSatisfied;
        }
    }
}