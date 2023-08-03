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
                    "\n 6: Search wood species by known id" +
                    "\n 7: Search a wood species by name pattern" +
                    "\n 8: Search wood species by notes pattern" +
                    "\n 9: Enter a new wood species" +
                    "\n 10: Update an existing wood species" +
                    "\n 11: Search location by known id" +
                    "\n 12: Search location by area pattern" +
                    "\n 13: Search location by area and locus pattern" +         //DEBUG THIS ONE -- IT IS FINE, VOUS VOUS AVEZ TROMPE
                    "\n 14: Enter a new location" +
                    "\n 15: Update an existing location" +
                    "\n 16: Add an authorized user" +
                    "\n 17: Retrieve an existing authorized user" +
                    "\n 18: Check for login" +
                    "\n 19: Update password for authorized user" +
                    "\n 20: Login and Enter a new Brand - v1" +
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
                // ----------------END-----------SPECIESWOOD----------------------------
                // ----------------START---------LOCATION-------------------------------
                else if (choice == 11)
                {
                    int idRead = 0;

                    Console.WriteLine("Please enter the id of an existing location you know: ");
                    idRead = Convert.ToInt32(Console.ReadLine());

                    Location someLocation = new Location();

                    someLocation.Populate(idRead);

                    Console.WriteLine("Result: Location: " + someLocation);
                }
                else if (choice == 12)
                {
                    string areaPattern = "";

                    Console.WriteLine("Please enter the area pattern string: ");
                    areaPattern = Console.ReadLine();


                    LocationCollection someLocationColl = new LocationCollection();


                    someLocationColl.PopulateViaArea(areaPattern);

                    Console.WriteLine("Result: " + someLocationColl);
                }
                else if (choice == 13)
                {
                    string areaPattern = "";
                    string locPattern = "";

                    Console.WriteLine("Please enter the area string: ");
                    areaPattern = Console.ReadLine();
                    Console.WriteLine("Please enter the locus string: ");
                    locPattern = Console.ReadLine();

                    LocationCollection someLocationColl = new LocationCollection();

                    someLocationColl.PopulateViaAreaAndLocus(areaPattern, locPattern);

                    Console.WriteLine("Result: " + someLocationColl);
                }
                else if (choice == 14)
                {
                    string bArea = "";
                    Console.WriteLine("Enter the area of a new location: ");
                    bArea = Console.ReadLine();

                    string bLocus = "";
                    Console.WriteLine("Enter a locus of the new area: ");
                    bLocus = Console.ReadLine();

                    Location someLocation2 = new Location(bArea, bLocus);

                    someLocation2.Save();

                    Console.WriteLine(someLocation2.RetrieveSaveMessage().Message);
                }
                else if (choice == 15)
                {
                    Console.Write("Enter the ID of the location to update: ");
                    int idToChange = Convert.ToInt32(Console.ReadLine());

                    string bArea = "";
                    Console.WriteLine("Enter the new area of the location: ");
                    bArea = Console.ReadLine();

                    string bLocus = "";
                    Console.WriteLine("Enter a new locus of the area: ");
                    bLocus = Console.ReadLine();

                    Location someLocation2 = new Location();


                    someLocation2.Populate(idToChange);
                    someLocation2.SetValues(bArea, bLocus);
                    someLocation2.Save();

                    Console.WriteLine(someLocation2.RetrieveSaveMessage().Message);
                }
                // ----------------END-----------LOCATION----------------------------
                else if (choice == 16)
                {
                    string username = "";
                    string password = "";

                    Console.WriteLine("Please enter the user name: ");
                    username = Console.ReadLine();
                    Console.WriteLine("Please enter the password: ");
                    password = Console.ReadLine();

                    AuthorizedUser someUser = new AuthorizedUser(username, password);

                    someUser.Save();

                    Console.WriteLine(someUser.RetrieveSaveMessage().Message);
                }
                else if (choice == 17)
                {
                    string username = "";


                    Console.WriteLine("Please enter the user name of the authorized user to retrieve: ");
                    username = Console.ReadLine();

                    AuthorizedUser someUser = new AuthorizedUser();

                    someUser.Populate(username);

                    Console.WriteLine("Result: " + someUser);
                }
                else if (choice == 18)
                {
                    string username = "";
                    string password = "";

                    Console.WriteLine("Please enter the user name of user who wishes to login: ");
                    username = Console.ReadLine();

                    AuthorizedUser someUser = new AuthorizedUser();

                    someUser.Populate(username);

                    Console.WriteLine("Result: " + someUser);

                    if (someUser.IsPopulated())
                    {
                        Console.WriteLine(" You exist! Enter your password: ");
                        password = Console.ReadLine();

                        if (someUser.CheckIfPasswordsMatch(password))
                        {
                            Console.WriteLine(" Passwords match: login successful! ");
                        }
                        else
                        {
                            Console.WriteLine(" Password don't match: you are an intruder - get out!");
                        }

                    }
                }
                else if (choice == 19)
                {
                    string username = "";
                    string password = "";

                    Console.WriteLine("Please enter the user name of user you wish to find: ");
                    username = Console.ReadLine();

                    AuthorizedUser someUser = new AuthorizedUser();

                    someUser.Populate(username);

                    Console.WriteLine("Result: " + someUser);

                    if (someUser.IsPopulated())
                    {
                        Console.WriteLine(" You exist! Enter your old password: ");
                        password = Console.ReadLine();

                        if (someUser.CheckIfPasswordsMatch(password))
                        {
                            Console.WriteLine(" Passwords match: enter your new password! ");
                            password = Console.ReadLine();

                            someUser.SetPasswordWithPlainText(password);

                            someUser.Save();

                            Console.WriteLine(someUser.RetrieveSaveMessage().Message);
                        }
                        else
                        {
                            Console.WriteLine(" Password don't match: you are an intruder - get out!");
                        }

                    }
                }
                else if (choice == 20)
                {
                    AddBrandTransaction Abt = new AddBrandTransaction();
                    Abt.Execute();
                }
            }
        }
    }
}