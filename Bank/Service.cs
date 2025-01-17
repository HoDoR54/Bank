using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Bank;

namespace Bank
{
    internal class Service
    {
        public static void PromptAndTakeOption(string[] options)
        {
            for (int i = 0; i < options.Length; i++)
            {
                Util.setTypingEffect($"{i + 1}) {options[i]}");
            }

            Console.Write("\nResponse: ");
            string chosenNum = Console.ReadLine();
            bool isValid = ValidateOption(chosenNum, options.Length);

            if (isValid)
            {
                Account account = new Account();
                if (account.haveAccount)
                {
                    for (int i = 1; i <= options.Length; i++)
                    {
                        if (chosenNum == $"{i}")
                        {
                            Util.setTypingEffect($"Can you please confirm that you are here to {options[i - 1].ToLower()}?");
                            YesOrNo(text => Util.setTypingEffect(text));
                        }
                    }
                }
                else
                {
                    Util.setTypingEffect("You are required to make an account first. Would you like to?");
                    YesOrNo(text => Util.setTypingEffect(text));
                }
            }            
        }


        public static void YesOrNo(Action<string> yesFunction)
        {
            Util.setTypingEffect("1) Yes\n2) No");

            Console.Write("\nResponse: ");
            string chosenNum = Console.ReadLine();

            bool isValid = ValidateOption(chosenNum, 2);

            if (isValid)
            {
                if (chosenNum == "2")
                {
                    Util.setTypingEffect("Okay, let us know if you need anything else.");
                    PromptAndTakeOption(["Deposit funds", "Transfer funds", "Withdraw funds", "Apply for a loan", "Apply for a credit card"]);
                }
                else
                {
                    yesFunction("Sorry, I haven't dealt with the 'yes' part yet.");
                }
            }
        }


        static bool ValidateOption (string option, int length)
        {
            bool isValid = false;
            string chosenOption = "";
                if (string.IsNullOrEmpty(option))
                {
                    Util.setTypingEffect("You must choose an option!");
                }
                else if (!int.TryParse(option, out int chosen))
                {
                    Util.setTypingEffect("Please put a valid value.");
                }
                else if (chosen < 1 || chosen > length)
                {
                    Util.setTypingEffect("Please put a valid number.");
                }
                else
                {
                    chosenOption = option;
                    isValid = true;
                }
            return isValid;
        }
    }

}
