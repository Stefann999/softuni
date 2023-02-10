using System.Reflection.Emit;
using System.Threading.Tasks.Dataflow;

namespace _4._Password_Validator
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string password = Console.ReadLine();

            charValidator(password);
            alphaNumericValidator(password);
            digitValidator(password);

            string problemcharr = charValidator(password);
            string problemAlphaNumr = alphaNumericValidator(password);
            string problemDigitr = digitValidator(password);

            bool isValid = true;

            if (problemcharr != " ")
            {
                Console.WriteLine(problemcharr);
                isValid = false;
            }
            if (problemAlphaNumr != " ")
            {
                Console.WriteLine(problemAlphaNumr);
                isValid = false;
            }
            if (problemDigitr != " ")
            {
                Console.WriteLine(problemDigitr);
                isValid = false;
            }

            if (isValid)
            {
                Console.WriteLine("Password is valid");
            }




            static string charValidator(string password)
            {
                string problemChar = " ";

                if (password.Length < 6 || password.Length > 10)
                {
                    problemChar = "Password must be between 6 and 10 characters";
                }
                return problemChar;
            }

            static string alphaNumericValidator(string password)
            {
                string problemAlphaNum = " ";

                foreach (char ch in password)
                {
                    if (!char.IsLetterOrDigit(ch))
                    {
                        problemAlphaNum = "Password must consist only of letters and digits";
                    }
                }
                return problemAlphaNum;
            }

            static string digitValidator(string password)
            {
                string problemDigit = " ";
                int digitCnt = 0;

                foreach (char ch in password)
                {
                    if (char.IsDigit(ch))
                    {
                        digitCnt++;
                    }
                }

                if (digitCnt < 2)
                {
                    problemDigit = "Password must have at least 2 digits";
                }
                return problemDigit;
            }
        }
    }
}