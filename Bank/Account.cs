using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    internal class Account
    {
        public bool haveAccount = false;
        public string AccountHolder;
        private string Password;

        public void TakePassword (string password) { 
            if (string.IsNullOrEmpty(password))
            {
                Console.Clear();
                Console.WriteLine("Please enter a valid password.");
            } else
            {
                Password = password;
            }
        }
    }
}
