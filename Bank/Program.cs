using System;
using System.Threading;

internal class Program
{
    private static void Main(string[] args)
    {
        setTypingEffect("Welcome to bank HTN. How can I help you?");
        string response;
        string[] options;
        options = new string[] { "Depose money", "Withdraw money", "Make an account" };
        response = PromptAndTakeOption(options);

        for (int i = 1; i <= options.Length; i++)
        {
            if (response == $"{i}")
            {
                setTypingEffect($"Can you please confirm that you are here to {options[i - 1].ToLower()}?");
                options = new string[] { "yes", "no" };
                response = PromptAndTakeOption(options);
            }
        }

        Console.ReadKey();
    }

    static void setTypingEffect(string text)
    {
        foreach (char letter in text)
        {
            Console.Write(letter);
            Thread.Sleep(25);
        }
        Console.WriteLine();
    }

    static string PromptAndTakeOption(string[] options)
    {
        for (int i = 0; i < options.Length; i++)
        {
            setTypingEffect($"{i + 1}) {options[i]}");
        }

        string chosenOption = null;
        while (true)
        {
            Console.Write("\nResponse: ");
            string chosenOne = Console.ReadLine();

            if (string.IsNullOrEmpty(chosenOne))
            {
                setTypingEffect("You must choose an option!");
            }
            else if (!int.TryParse(chosenOne, out int chosen))
            {
                setTypingEffect("Please put a valid value.");
            }
            else if (chosen < 1 || chosen > options.Length)
            {
                setTypingEffect("Please put a valid number.");
            }
            else
            {
                chosenOption = chosenOne;
                break;
            }
        }

        return chosenOption;
    }
}
