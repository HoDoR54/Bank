using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Transactions;
using Bank;

namespace Bank
{
    internal class Account
    {
        public bool haveAccount = false;
        public string accountHolder;
        private string nrcId;
        private string password;
        private char gender;

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

        public string validatePassword (string pw)
        {
            string validatedPw = null;
            if (string.IsNullOrEmpty(pw))
            {
                Util.setTypingEffect("Please enter a password: ");
                validatePassword(Console.ReadLine().Trim());
            } 
            else if (pw.ToCharArray().Length < 8)
            {
                Util.setTypingEffect("\nYour password is too short. try again: ");
                validatePassword(Console.ReadLine().Trim());
            }
            else if (!Regex.IsMatch(pw, @"[^a-zA-Z0-9]"))
            {
                Util.setTypingEffect("\nThe password must include at least one special character. e.g.(@, #, !...)");
                Util.setTypingEffect("\nTry again: ");
                validatePassword(Console.ReadLine().Trim());
            }
            else
            {
                validatedPw = pw;
            }
            return validatedPw;
        }
        public void setPassword ()
        {
            Util.setTypingEffect("\nEnter a password here: ");
            string validatedPwFirst = validatePassword(Console.ReadLine().Trim());

            Util.setTypingEffect("\nConfirm your password: ");
            string validatedPwSecond = validatePassword(Console.ReadLine().Trim());

            while (true)
            {
                if (validatedPwFirst == validatedPwSecond)
                {
                    Util.setTypingEffect("\nCongratulations! you have successfully made an account.");
                    break;
                }
                else
                {
                    Util.setTypingEffect("\nPasswords are not matching.\nTry again: ");
                    validatedPwSecond = validatePassword(Console.ReadLine().Trim());
                }
            }
        }

        public void MakeAccount() 
        {
            Util.setTypingEffect("Enter your name: ");
            accountHolder = Console.ReadLine();
            if (string.IsNullOrEmpty(accountHolder))
            {
                Util.setTypingEffect("\nPlease enter your name: ");
                accountHolder = Console.ReadLine();
            }
            Util.setTypingEffect("\nChoose your gender.");
            string chosenGender = Service.PromptAndTakeOption(["Male", "Female"]);
            bool isValid = Util.ValidateOption(chosenGender, 2);
            if (isValid)
            {
                gender = chosenGender == "1" ? 'M' : 'F';
            }
            string prefix = gender == 'M' ? "Mr." : "Ms.";
            Util.setTypingEffect($"\nAnd please enter your NRC ID here, {prefix}{accountHolder}: ");
            nrcId = Console.ReadLine();
            setPassword();
            
        }
    }
}
