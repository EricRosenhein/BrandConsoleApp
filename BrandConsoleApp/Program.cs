using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BrandConsoleApp.Model;
using BrandConsoleApp.Util;
using IniParser;
using IniParser.Model;


namespace BrandConsoleApp
{
    class Program
    {
        public static void Main(string[] args)
        {


            Utilities.EstablishConnection("C:\\Users\\Sweet Baby Jay\\Source\\Repos\\BrandConsoleApp\\BrandConsoleApp\\dbConfig.ini");

            // REALLY IMPORTANT TO READ THIS FROM A FILE. Otherwise, stupid old teachers forget to do all this stuff
            // Us young and smart kids don't!

            Console.WriteLine("Testing Brand Console App");

            int choice = -1;
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



                // ----------------START-----------BRAND-----------------------------------
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

                    Console.WriteLine(someBrand2.RetrieveSaveMessage().Message);
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

                    Console.WriteLine(someBrand2.RetrieveSaveMessage().Message);
                }
                else if (choice == 6)
                {
                    string usName = "";
                    Console.WriteLine("Enter the username of a new User: ");
                    usName = Console.ReadLine();

                    string usPwd = "";
                    Console.WriteLine("Enter the new password for this user: ");
                    usPwd = Console.ReadLine();

                    AuthorizedUser newUser = new AuthorizedUser(usName, usPwd);

                    newUser.Save();

                    Console.WriteLine(newUser.RetrieveSaveMessage().Message);
                }

                // ----------------END-----------BRAND-----------------------------------
                //-----------------START---------SPECIESWOOD-----------------------------
                else if (choice == 6)
                {
                    int idRead = 0;

                    Console.WriteLine("Please enter the id of an existing wood species you know: ");
                    idRead = Convert.ToInt32(Console.ReadLine());

                    SpeciesWood someSpecies = new SpeciesWood();

                    someSpecies.Populate(idRead);

                    Console.WriteLine("Result: Wood species: " + someSpecies);
                }
                else if (choice == 7)
                {
                    string namePattern = "";

                    Console.WriteLine("Please enter the wood species name pattern string: ");
                    namePattern = Console.ReadLine();


                    SpeciesWoodCollection someSpeciesColl = new SpeciesWoodCollection();


                    someSpeciesColl.PopulateViaName(namePattern);

                    Console.WriteLine("Result: " + someSpeciesColl);
                }
                else if (choice == 8)
                {
                    string notesPattern = "";

                    Console.WriteLine("Please enter the wood species notes pattern string: ");
                    notesPattern = Console.ReadLine();


                    SpeciesWoodCollection someSpeciesColl = new SpeciesWoodCollection();


                    someSpeciesColl.PopulateViaNotes(notesPattern);

                    Console.WriteLine("Result: " + someSpeciesColl);
                }
                else if (choice == 9)
                {
                    string bName = "";
                    Console.WriteLine("Enter the name of a new wood species: ");
                    bName = Console.ReadLine();

                    string bNotes = "";
                    Console.WriteLine("Enter the notes for this wood species: ");
                    bNotes = Console.ReadLine();

                    SpeciesWood someSpecies2 = new SpeciesWood(bName, bNotes);

                    someSpecies2.Save();

                    Console.WriteLine(someSpecies2.RetrieveSaveMessage().Message);
                }
                else if (choice == 10)
                {
                    Console.Write("Enter the ID of the wood species to update: ");
                    int idToChange = Convert.ToInt32(Console.ReadLine());

                    string bName = "";
                    Console.WriteLine("Enter the new name of the wood species: ");
                    bName = Console.ReadLine();

                    string bNotes = "";
                    Console.WriteLine("Enter the new notes for this wood species: ");
                    bNotes = Console.ReadLine();

                    SpeciesWood someSpecies2 = new SpeciesWood();


                    someSpecies2.Populate(idToChange);
                    someSpecies2.SetValues(bName, bNotes);
                    someSpecies2.Save();

                    Console.WriteLine(someSpecies2.RetrieveSaveMessage().Message);
                }
            }
        }
    }
}