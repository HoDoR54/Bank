using System;
using System.Threading;
using Bank;

internal class Program
{
    private static void Main(string[] args)
    {
        Util.setTypingEffect("Welcome to bank HTN. How can I help you?");
        string[] options;
        options = new string[] { "Deposit funds", "Transfer funds", "Withdraw funds", "Apply for a loan", "Apply for a credit card" };
        Service.PromptAndTakeOption(options);

        Console.ReadKey();
    }
}