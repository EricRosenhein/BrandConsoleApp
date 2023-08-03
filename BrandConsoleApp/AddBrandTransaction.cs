using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrandConsoleApp.Model;

namespace BrandConsoleApp
{
    public class AddBrandTransaction
    {

        public AddBrandTransaction() { }

        protected bool LoginUser()
        {
            Console.WriteLine("Enter the name of the login user: ");
            string userName = Console.ReadLine();

            AuthorizedUser user = new AuthorizedUser();
            user.Populate(userName);

            if (user.IsPopulated())
            {
                Console.WriteLine("Enter your password: ");
                string passwd = Console.ReadLine();

                if (user.CheckIfPasswordsMatch(passwd))
                {
                    Console.WriteLine("Login successful!");
                    return true;
                }
                else
                {
                    Console.WriteLine("Login Failed: Get the hell out!");
                    return false;
                }

            }
            else
            {
                Console.WriteLine("You don't exist - get the f.. out!");
                return false;
            }
        }
        public void Execute()
        {
            Console.WriteLine("Add a new Brand");
            bool flag = LoginUser();
            if (flag)
            {
                string bName = "";
                string bNotes = "";

                Console.WriteLine("Enter the name of a new brand: ");
                bName = Console.ReadLine();

                Console.WriteLine("Enter the notes for this brand: ");
                bNotes = Console.ReadLine();

                Brand someBrand2 = new Brand(bName, bNotes);

                someBrand2.Save();

                Console.WriteLine(someBrand2.RetrieveSaveMessage().Message);
            }
        }
    }
}
