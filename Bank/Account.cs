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
        public string accountHolder = null;
        private string password = null;

        public void TakePassword (string pw) { 
            if (string.IsNullOrEmpty(pw))
            {
                Console.Clear();
                Console.WriteLine("Please enter a valid password.");
            } else
            {
                password = pw;
            }
        }

        public string MakeAccount() 
        {
            return "You have made an account.";
        }
    }
}
