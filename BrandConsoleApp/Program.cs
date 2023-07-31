using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BrandConsoleApp.Model;
using BrandConsoleApp.Util;


namespace BrandConsoleApp
{
    class Program
    {
        public static void Main(string[] args)
        {


            Utilities.EstablishConnection("C:\\Users\\emr19\\source\\repos\\BrandConsoleApp\\BrandConsoleApp\\dbConfig.ini");

            // REALLY IMPORTANT TO READ THIS FROM A FILE. Otherwise, stupid old teachers forget to do all this stuff
            // Us young and smart kids don't!

            Console.WriteLine("Testing Brand Console App");

            int choice = 10;
            while (choice != 0)
            {
                Console.WriteLine("\n ----------------------------------------");
                Console.WriteLine("Please enter the number corresonding to your desired action:" +
                    "\n 1: Search brand by known id" +
                    "\n 2: Search brand by name pattern" +
                    "\n 3: Search brand by notes pattern" +
                    "\n 4: Enter a new brand" +
                    "\n 5: Update an existing brand" +
                    "\n 0: Exit");

                choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    int idRead = 0;

                    Console.WriteLine("Please enter the id of an existing brand you know: ");
                    idRead = Convert.ToInt32(Console.ReadLine());

                    Brand someBrand = new Brand();

                    someBrand.Populate(idRead);

                    Console.WriteLine("Result: Brand: " + someBrand);
                }
                else if (choice == 2)
                {
                    string namePattern = "";

                    Console.WriteLine("Please enter the brand name pattern string: ");
                    namePattern = Console.ReadLine();


                    BrandCollection someBrandColl = new BrandCollection();


                    someBrandColl.PopulateViaName(namePattern);

                    Console.WriteLine("Result: " + someBrandColl);
                }
                else if (choice == 3)
                {
                    string notesPattern = "";

                    Console.WriteLine("Please enter the brand notes pattern string: ");
                    notesPattern = Console.ReadLine();


                    BrandCollection someBrandColl = new BrandCollection();


                    someBrandColl.PopulateViaNotes(notesPattern);

                    Console.WriteLine("Result: " + someBrandColl);
                }
                else if (choice == 4)
                {
                    string bName = "";
                    Console.WriteLine("Enter the name of a new brand: ");
                    bName = Console.ReadLine();

                    string bNotes = "";
                    Console.WriteLine("Enter the notes for this brand: ");
                    bNotes = Console.ReadLine();

                    Brand someBrand2 = new Brand(bName, bNotes);

                    someBrand2.Save();
                }
                else if (choice == 5)
                {
                    Console.Write("Enter the ID of the Brand to update: ");
                    int idToChange = Convert.ToInt32(Console.ReadLine());

                    string bName = "";
                    Console.WriteLine("Enter the new name of the brand: ");
                    bName = Console.ReadLine();

                    string bNotes = "";
                    Console.WriteLine("Enter the new notes for this brand: ");
                    bNotes = Console.ReadLine();

                    Brand someBrand2 = new Brand();


                    someBrand2.Populate(idToChange);
                    someBrand2.SetValues(bName, bNotes);
                    someBrand2.Save();
                }

            }
        }
    }
}