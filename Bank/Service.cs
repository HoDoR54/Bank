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
    public class Service
    {
        public static string PromptAndTakeOption(string[] options)
        {
            for (int i = 0; i < options.Length; i++)
            {
                Util.setTypingEffect($"\n{i + 1}) {options[i]}");
            }

            Util.setTypingEffect("\n\nResponse: ");
            string chosenNum = Console.ReadLine();

            return chosenNum;
        }

    }

}
