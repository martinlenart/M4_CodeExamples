using System;

namespace TryLogin
{
    class Program
    {
        static void Main(string[] args)
        {
            const string userNameFromDB = "Mupp";
            const string userPasswordFromDB = "Mupparnasjulsaga";

            bool loginSuccessful = TryLogin(userNameFromDB, userPasswordFromDB);

            if (loginSuccessful)
                Console.WriteLine("Welcome");
            else
                Console.WriteLine("Login failure");

        }

        private static bool TryLogin(string userNameFromDB, string userPasswordFromDB)
        {
            bool loginSuccessful = false;
            bool continueAttempts = true;
            int attempts = 0;
            while (continueAttempts && !loginSuccessful && attempts < 3)
            {
                string Password = null;
                string Name = null;
                continueAttempts = UserInput.TryReadString("Enter username:", out Name) &&
                           UserInput.TryReadString("Enter password:", out Password);

                if (!continueAttempts)
                    continue;

                if ((Name == userNameFromDB) && (Password == userPasswordFromDB))
                {
                    loginSuccessful = true;
                }
                else
                {
                    Console.WriteLine("Wrong name or password. Try again!");
                    attempts++;
                }
            }

            return loginSuccessful;
        }
    }
}
//2.    Make a small Login program that asks a user for a user name and a password. The password
//      should be compared HashCode wise to stored password hash code. If Login 
//      successful write a welcome message
//3.    Extend the program to allow the user 3 login attempts
//4.    Refracture the Login code into a Method - bool TryLogin(string User, string password)
