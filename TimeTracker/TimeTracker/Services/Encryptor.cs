using System.Text;

namespace TimeTracker.Services
{
    internal class Encryptor
    {
        public string EncryptInput(string originalInput)
        {
            StringBuilder encryptedInput = new StringBuilder();

            for (int index = 0; index < originalInput.Length; index++)
            {
                encryptedInput.Append((char)(originalInput[index] + index));
            }

            return encryptedInput.ToString();
        }

        public string DecryptInput(string encryptedInput)
        {
            StringBuilder decryptedInput = new StringBuilder();

            for (int index = 0; index < encryptedInput.Length; index++)
            {
                decryptedInput.Append((char)(encryptedInput[index] - index));
            }

            return decryptedInput.ToString();
        }
    }
}
