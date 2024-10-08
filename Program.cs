// the ourAnimals array will store the following:
string animalSpecies = "";
string animalID = "";
string animalAge = "";
string animalPhysicalDescription = "";
string animalPersonalityDescription = "";
string animalNickname = "";

// variables that support data entry
int maxPets = 8;
string? readResult;
string menuSelection = "";

// array used to store runtime data, there is no persisted data
string[,] ourAnimals = new string[maxPets, 6];


// create some initial ourAnimals array entries
for (int i = 0; i < maxPets; i++)
{
    switch (i)
    {
        case 0:
            animalSpecies = "dog";
            animalID = "d1";
            animalAge = "2";
            animalPhysicalDescription = "medium sized cream colored female golden retriever weighing about 65 pounds. housebroken.";
            animalPersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
            animalNickname = "lola";
            break;
        case 1:
            animalSpecies = "dog";
            animalID = "d2";
            animalAge = "9";
            animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
            animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
            animalNickname = "loki";
            break;
        case 2:
            animalSpecies = "cat";
            animalID = "c3";
            animalAge = "1";
            animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
            animalPersonalityDescription = "friendly";
            animalNickname = "Puss";
            break;
        case 3:
            animalSpecies = "cat";
            animalID = "c4";
            animalAge = "?";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            break;
        default:
            animalSpecies = "";
            animalID = "";
            animalAge = "";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            break;
    }
    ourAnimals[i, 0] = "ID #: " + animalID;
    ourAnimals[i, 1] = "Species: " + animalSpecies;
    ourAnimals[i, 2] = "Age: " + animalAge;
    ourAnimals[i, 3] = "Nickname: " + animalNickname;
    ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
    ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;
}

do
{
    // display the top-level menu options
    Console.Clear();

    Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
    Console.WriteLine(" 1. List all of our current pet information");
    Console.WriteLine(" 2. Add a new animal friend to the ourAnimals array");
    Console.WriteLine(" 3. Ensure animal ages and physical descriptions are complete");
    Console.WriteLine(" 4. Ensure animal nicknames and personality descriptions are complete");
    Console.WriteLine(" 5. Edit an animal’s age");
    Console.WriteLine(" 6. Edit an animal’s personality description");
    Console.WriteLine(" 7. Display all cats with a specified characteristic");
    Console.WriteLine(" 8. Display all dogs with a specified characteristic");
    Console.WriteLine();
    Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

    readResult = Console.ReadLine();
    if (readResult != null)
    {
        menuSelection = readResult.ToLower();
    }

    // Console.WriteLine($"You selected menu option {menuSelection}.");
    // Console.WriteLine("Press the Enter key to continue");

    // // pause code execution
    // readResult = Console.ReadLine();

    switch (menuSelection)
    {
        case "1":
            // List all of our current pet imformation
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    Console.WriteLine("----------------------------------------");
                    for (int j = 0; j < ourAnimals.GetLength(1); j++)
                    {
                        Console.WriteLine(ourAnimals[i, j]);
                    }
                }
            }
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        case "2":
            // Add a new animal friend to the ourAnimals array
            string anotherPet = "y";
            int petCount = 0;

            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    petCount++;
                }
            }
            // Display how many spaces available
            if (petCount < maxPets)
            {
                int spacesAvailable = maxPets - petCount;
                Console.WriteLine($"We currently have {petCount} pets that need homes. We can manage {spacesAvailable} more.");
            }
            while (anotherPet == "y" && petCount < maxPets)
            {
                bool validEntry = false;
                ///////////////// GET and validate SPECIE
                do
                {
                    Console.WriteLine("\n\rEnter 'dog' or 'cat' to begin a new entry");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalSpecies = readResult.ToLower();
                        if (animalSpecies != "dog" && animalSpecies != "cat")
                        {
                            validEntry = false;
                        }
                        else
                        {
                            validEntry = true;
                        }
                    }

                } while (validEntry == false);

                // GET ID
                // build the animal ID number - for example C1, C2, D3, (for cat 1, cat 2, Dog 3)
                animalID = animalSpecies.Substring(0, 1) + (petCount + 1).ToString();

                ///////////////// GET and validate AGE
                do
                {
                    int petAge;

                    Console.WriteLine("Enter the pet's age or enter '?' if unknown");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalAge = readResult;
                        if (animalAge != "?")
                        {
                            // TryParse return a bool value (true or false)
                            validEntry = int.TryParse(animalAge, out petAge);
                        }
                        else
                        {
                            validEntry = true;
                        }
                    }


                } while (validEntry == false);

                ///////////////// GET and validate Physical Description
                do
                {
                    Console.WriteLine("Enter a physical description od the pet (size, color, gender, weight, housebroken)");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalPhysicalDescription = readResult.ToLower();
                        if (animalPhysicalDescription == "")
                        {
                            animalPhysicalDescription = "tbd";
                        }
                    }

                } while (animalPhysicalDescription == "");

                ///////////////// GET and validate Personality Description
                do
                {
                    Console.WriteLine("Enter a description of the pet's personality (likes or deslikes, tricks, energy level)");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalPersonalityDescription = readResult.ToLower();
                        if (animalPersonalityDescription == "")
                        {
                            animalPersonalityDescription = "tbd";
                        }
                    }


                } while (animalPersonalityDescription == "");

                ///////////////// GET and validate pets NICKNAME

                do
                {
                    Console.WriteLine("Enter a nickname for the pet");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalNickname = readResult.ToLower();
                        if (animalNickname == "")
                        {
                            animalNickname = "tbd";
                        }
                    }

                } while (animalNickname == "");

                // store the pet information in the ourAnimals array (zero based)
                ourAnimals[petCount, 0] = "ID #: " + animalID;
                ourAnimals[petCount, 1] = "Species: " + animalSpecies;
                ourAnimals[petCount, 2] = "Age: " + animalAge;
                ourAnimals[petCount, 3] = "Nickname: " + animalNickname;
                ourAnimals[petCount, 4] = "Physical description: " + animalPhysicalDescription;
                ourAnimals[petCount, 5] = "Personality: " + animalPersonalityDescription;

                petCount++;

                // check maxPet limit
                if (petCount < maxPets)
                {
                    // another pet ?
                    Console.WriteLine("Do you want to enter info for another pet (y/n)");
                    do
                    {
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            anotherPet = readResult.ToLower();
                        }

                    } while (anotherPet != "y" && anotherPet != "n");
                }
            }

            if (petCount >= maxPets)
            {
                Console.WriteLine("We have reached our limit on the number of pets that we can manage.");
                Console.WriteLine("Press the Enter key to continue.");
                readResult = Console.ReadLine();
            }

            break;

        case "3":

            bool validAge = false;
            int petNewAge = 0;
            petCount = 0;
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: " && ourAnimals[i, 2] == "Age: ?")
                {
                    do
                    {
                        petCount = i;
                        Console.WriteLine($"Enter an age for {ourAnimals[i, 0]}");
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            animalAge = readResult;
                            if (animalAge != "?")
                            {
                                // TryParse return a bool value (true or false)
                                validAge = int.TryParse(animalAge, out petNewAge);
                            }
                            else
                            {
                                validAge = true;
                            }
                        }

                    } while (validAge == false);

                    ourAnimals[petCount, 2] = "Age: " + animalAge;

                    do
                    {
                        if (ourAnimals[petCount, 4] == "Physical description: " || ourAnimals[petCount, 4] == "Physical description: tbd")
                        {
                            Console.WriteLine($"Enter a physical description for {ourAnimals[petCount, 0]} (size, color, breed, gender, weight, housebroken)");
                            readResult = Console.ReadLine();
                            if (readResult != null)
                            {
                                animalPhysicalDescription = readResult;
                            }
                        }
                    } while (animalPhysicalDescription == "");

                    ourAnimals[petCount, 4] = "Physical description: " + animalPhysicalDescription;
                }
            }

            petCount++;

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Age and physical description fields are complete for all of our friends.");
            Console.WriteLine();
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;
        case "4":
            // Ensure animal nicknames and personality descriptions are complete
            petCount = 0;
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: " && (ourAnimals[i, 3] == "Nickname: " || ourAnimals[i, 3] == "Nickname: tbd"))
                {
                    petCount = i;
                    do
                    {
                        if (ourAnimals[petCount, 3] == "Nickname: " || ourAnimals[petCount, 3] == "Nickname: tbd")
                        {
                            Console.WriteLine($"Enter a nickname for {ourAnimals[petCount, 0]}");
                            readResult = Console.ReadLine();
                            if (readResult != null)
                            {
                                animalNickname = readResult;
                            }
                        }

                    } while (animalNickname == "");

                    ourAnimals[petCount, 3] = "Nickname: " + animalNickname;

                    do
                    {
                        if (ourAnimals[petCount, 5] == "Personality: " || ourAnimals[petCount, 5] == "Personality: tbd")
                        {
                            Console.WriteLine($"Enter a personality description for {ourAnimals[petCount, 0]} (likes or dislikes, tricks, energy level)");
                            readResult = Console.ReadLine();
                            if (readResult != null)
                            {
                                animalPersonalityDescription = readResult;
                            }
                        }



                    } while (animalPersonalityDescription == "");

                    ourAnimals[petCount, 5] = "Personality: " + animalPersonalityDescription;
                }
            }

            petCount++;

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Nickname and personality description fields are complete for all of our friends.");
            Console.WriteLine();
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;
        case "5":
            // Edit an animal’s age
            Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;
        case "6":
            // Edit an animal’s personality description
            Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;
        case "7":
            // Display all cats with a specified characteristic
            Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;
        case "8":
            // Display all dogs with a specified characteristic
            Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;
        default:
            break;
    }

} while (menuSelection != "exit");
