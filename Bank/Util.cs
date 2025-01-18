using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank;

namespace Bank
{
    internal class Util
    {
        public static void setTypingEffect(string text)
        {
            foreach (char letter in text)
            {
                Console.Write(letter);
                Thread.Sleep(25);
            }
        }

        public static bool ValidateOption(string option, int length)
        {
            bool isValid = false;
            if (string.IsNullOrEmpty(option))
            {
                Util.setTypingEffect("You must choose an option!\nTry again: ");
                ValidateOption(Console.ReadLine().Trim(), length);
            }
            else if (!int.TryParse(option, out int chosen))
            {
                Util.setTypingEffect("Please put a valid value.\nTry again: ");
                ValidateOption(Console.ReadLine().Trim(), length);
            }
            else if (chosen < 1 || chosen > length)
            {
                Util.setTypingEffect("Please put a valid number.\nTry again: ");
                ValidateOption(Console.ReadLine().Trim(), length);
            }
            else
            {
                isValid = true;
            }
            return isValid;
        }


        public static void YesOrNo(Action<string> yesFunction)
        {
            Util.setTypingEffect("\n1) Yes\n2) No");

            Console.Write("\n\nResponse: ");
            string chosenNum = Console.ReadLine();

            bool isValid = ValidateOption(chosenNum, 2);

            if (isValid)
            {
                if (chosenNum == "2")
                {
                    Util.setTypingEffect("Okay, let us know if you need anything else.");
                    Service.PromptAndTakeOption(["Deposit funds", "Transfer funds", "Withdraw funds", "Apply for a loan", "Apply for a credit card"]);
                }
                else
                {
                    yesFunction("Sorry, I haven't dealt with the 'yes' part yet.");
                }
            }
        }

    }
}
