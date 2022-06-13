/* Jan Leo Ras
 * CSCI 3005
 * Assignment 2 - Aliens
 * Dr. Dana
 */

using System;

namespace OOP
{
    //this class contains main method
    //the user interface for managing aliens in a spaceship
    class Program
    {
        public static void Main()
        {
            //declare and initialize variables
            Spaceship mySpaceship;
            string capIn, choice, ageIn, color, alliance;
            PlanetBuilder myPlanetBuilder = new PlanetBuilder();

            //set default planet value
            Planet unknown = new Planet("UNKNOWN", 1, 1);

            Console.WriteLine("Assignment 2: Aliens\n");

            //create spaceship
            Console.WriteLine("Enter spaceship's name: ");
            mySpaceship = new Spaceship(Console.ReadLine());

            Console.WriteLine("Enter spaceship's maximum capacity: ");
            capIn = Console.ReadLine();

            //verify input for spaceship cap
            while (capIn == "" || int.Parse(capIn) <= 0)
            {
                Console.WriteLine("Max capacity cannot be blank or less than or equal to 0.");
                Console.WriteLine("Enter spaceship's maximum capacity: ");
                capIn = Console.ReadLine();
            }
            mySpaceship.MaximumCapacity = int.Parse(capIn);

            //print spaceship
            Console.WriteLine(mySpaceship.ToString());

            //loop to control menu and user choices
            do
            {
                Console.WriteLine("\nSelect from the following options:" +
                    "\n(1) Add an Alien." +
                    "\n(2) Get number of Aliens in the spaceship." +
                    "\n(3) Find the oldest Alien." +
                    "\n(4) Find the oldest Alien of a color." +
                    "\n(5) Get the count of good Aliens." +
                    "\n(6) Get the count of bad Aliens." +
                    "\n(7) Quit");
                choice = Console.ReadLine();

                //choice 1 - add alien unless max occupancy has been reached
                if (choice == "1")
                {
                    //check if max occupancy has been reached, proceed otherwise
                    if (mySpaceship.MaximumCapacity == mySpaceship.Count())
                        Console.WriteLine("Maximum occupancy has been reached. Cannot add more Aliens.");

                    //user interface to enter alien and planet information
                    else
                    {
                        Console.WriteLine("Enter Alien name: ");
                        Alien newAlien = new Alien(Console.ReadLine());

                        Console.WriteLine("Enter Alien age: ");
                        ageIn = Console.ReadLine();
                        while (ageIn == "" || long.Parse(ageIn) < 0)
                        {
                            Console.WriteLine("Age cannot be less than 0.");
                            Console.WriteLine("Enter Alien age: ");
                            ageIn = Console.ReadLine();
                        }
                        newAlien.Age = long.Parse(ageIn);

                        Console.WriteLine("Enter Alien color: ");
                        newAlien.Color = Console.ReadLine();

                        Console.WriteLine("Enter Alien alliance: [0] for Good, [1] for Evil");
                        alliance = Console.ReadLine();

                        while (alliance != "0" && alliance != "1")
                        {
                            Console.WriteLine("Enter Alien alliance: [0] for Good, [1] for Evil");
                            alliance = Console.ReadLine();
                        }
                        if (alliance == "0")
                            newAlien.IsGood = true;
                        else
                            newAlien.IsGood = false;

                        Console.WriteLine("[Alien's planet information]");

                        //create alien's planet using PlanetBuilder.cs
                        try
                        {
                            myPlanetBuilder.BuildPlanet();
                            newAlien.Planet = myPlanetBuilder.GetPlanet();
                        }
                        //invalid input sets planet to default
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine("Planet set to UNKNOWN.");
                            newAlien.Planet = unknown;
                        }
                        catch (NullReferenceException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        //add alien to spaceship
                        mySpaceship.AddAlien(newAlien);
                    }
                }
                //choice 2 - count aliens and print manifest
                if (choice == "2")
                {
                    Console.WriteLine("\nCounting Aliens...\n[There are {0} Aliens in Spaceship {1}.]", mySpaceship.Count(), mySpaceship.Name);
                    Console.WriteLine("\n* * * * * * * * * * * * * * * * * ");
                    Console.WriteLine(mySpaceship.ToString());
                    Console.WriteLine("\n* * * * * * * * * * * * * * * * * ");
                }
                //choice 3 - find oldest aliens, unless there are no aliens aboard the spaceship
                if (choice == "3")
                {
                    if (mySpaceship.Count() == 0)
                        Console.WriteLine("\nCounting Aliens...\n[There are 0 Aliens in Spaceship {0}.]", mySpaceship.Name);
                    else
                        Console.WriteLine("\nThe oldest Alien in the spaceship is: {0}", mySpaceship.Oldest().ToString());
                }
                //choice 4 - find oldest alien of a color, unless there are no aliens/aliens of the color on the spaceship
                if (choice == "4")
                {
                    if (mySpaceship.Count() == 0)
                        Console.WriteLine("\nCounting Aliens...\n[There are 0 Aliens in Spaceship {0}.]", mySpaceship.Name);
                    else
                    {
                        Console.WriteLine("Enter a color: ");
                        color = Console.ReadLine();

                        if (mySpaceship.IsAColor(color))
                            Console.WriteLine("\nThe oldest " + color + " Alien in the spaceship is: {0}", mySpaceship.Oldest(color).ToString());
                        else
                            Console.WriteLine("There are no " + color + "colored Aliens in this spaceship.");
                    }
                }
                //choice 5 - count good aliens
                if (choice == "5")
                    Console.WriteLine("\nCounting good Aliens...\n[There are {0} good Aliens in Spaceship {1}.]", mySpaceship.Count(true), mySpaceship.Name);
                //choice 6 - count evil aliens
                if (choice == "6")
                    Console.WriteLine("\nCounting evil Aliens...\n[There are {0} evil Aliens in Spaceship {1}.]", mySpaceship.Count(false), mySpaceship.Name);
            } 
            //exit condition
            while (choice != "7");
        }

        public static void Assignment1()
        {
            Console.WriteLine("Assignment 1: The Galaxy \n");
            try
            {
                PlanetBuilder builder = new();
                Planet first, second, third;

                builder.BuildPlanet();
                first = builder.GetPlanet();

                builder.BuildPlanet();
                second = builder.GetPlanet();

                builder.BuildPlanet();
                third = builder.GetPlanet();

                Console.WriteLine("\n" + first.Name + "'s volume = " + first.ComputeVolume()
                    + "; distance from Sun  = " + first.DistanceFromSun);
                Console.WriteLine(second.Name + "'s volume = " + second.ComputeVolume()
                    + "; distance from Sun  = " + second.DistanceFromSun);
                Console.WriteLine(third.Name + "'s volume = " + third.ComputeVolume()
                    + "; distance from Sun  = " + third.DistanceFromSun);

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);

            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}