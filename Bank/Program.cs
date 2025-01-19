using System;
using System.Threading;
using Bank;

public class Program
{
    private static void Main(string[] args)
    {
        Util.setTypingEffect("Welcome to bank HTN. How can I help you?");
        string[] options;
        options = new string[] { "Deposit funds", "Transfer funds", "Withdraw funds", "Apply for a loan", "Apply for a credit card" };
        string chosenNum = Service.PromptAndTakeOption(options);
        bool isValid = Util.ValidateOption(chosenNum, options.Length);
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
                        Util.YesOrNo(text => Util.setTypingEffect(text), "LOL");
                    }
                }
            }
            else
            {
                Account.promptSignUp();
            }
        }

        Console.ReadKey();
    }
}