using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.WriteLine();
        }
    }
}
