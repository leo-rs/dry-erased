using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    class FullMenu
    {

        public static void Main()
        {

            //declare and initialize variables
            Spaceship mySpaceship;
            string capIn, choice, ageIn, color, alliance;
            PlanetBuilder myPlanetBuilder = new PlanetBuilder();

            //set default planet value
            Planet unknown = new Planet("UNKNOWN", 1, 1);


            Console.WriteLine("Assignment 3: Aliens in the Galaxy\n");

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
                    "\n(7) Display Aliens that are at least (?) years old or older." +
                    "\n(8) Quit");
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

                        Console.WriteLine("Choose Alien subclass: ");
                        Console.WriteLine("(A) Alpha Alien\n(B) Beta Alien\n(C) Gamma Alien\n(D) Other");
                        string ac = Console.ReadLine();

                        AlphaAlien aa;
                        BetaAlien bb;
                        GammaAlien gg;

                        while (ac == "")
                        {
                            Console.WriteLine("Please choose from the following options: ");
                            Console.WriteLine("(A) Alpha Alien\n(B) Beta Alien\n(C) Gamma Alien\n(D) Other");
                            ac = Console.ReadLine();
                        }

                        if (ac == "A" || ac == "a")
                        {
                            aa = new AlphaAlien(newAlien.Name, newAlien.Age, newAlien.IsGood);
                            aa.Planet = newAlien.Planet;
                            mySpaceship.AddAlien(aa);
                        }
                        else if (ac == "B" || ac == "b")
                        {
                            bb = new BetaAlien(newAlien.Name, newAlien.Age, newAlien.IsGood);
                            bb.Planet = newAlien.Planet;
                            mySpaceship.AddAlien(bb);
                        }
                        else if (ac == "C" || ac == "c")
                        {
                            gg = new GammaAlien(newAlien.Name, newAlien.Age, newAlien.IsGood);
                            gg.Planet = newAlien.Planet;
                            mySpaceship.AddAlien(gg);
                        }
                        else if (ac == "D" || ac == "d")
                        {
                            mySpaceship.AddAlien(newAlien);
                        }
                        else
                            mySpaceship.AddAlien(newAlien);

                        mySpaceship.ToString();
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
                            Console.WriteLine("There are no " + color + " colored Aliens in this spaceship.");
                    }
                }
                //choice 5 - count good aliens
                if (choice == "5")
                    Console.WriteLine("\nCounting good Aliens...\n[There are {0} good Aliens in Spaceship {1}.]", mySpaceship.Count(true), mySpaceship.Name);
                //choice 6 - count evil aliens
                if (choice == "6")
                    Console.WriteLine("\nCounting evil Aliens...\n[There are {0} evil Aliens in Spaceship {1}.]", mySpaceship.Count(false), mySpaceship.Name);
                //choice 7 - display aliens with an age greater than or equal to an input value
                if (choice == "7")
                {
                    if (mySpaceship.Count() == 0)
                        Console.WriteLine("[There are 0 Aliens in Spaceship {0}.]", mySpaceship.Name);
                    else
                    {
                        Console.WriteLine("Enter age value: ");
                        ageIn = Console.ReadLine();

                        while (ageIn == "" || long.Parse(ageIn) < 0)
                        {
                            Console.WriteLine("Age cannot be less than 0.");
                            Console.WriteLine("Enter age value: ");
                            ageIn = Console.ReadLine();
                        }

                        string listOfAliens = "";
                        int count = 0;
                        foreach (Alien x in mySpaceship.Aliens())
                        {
                            if (x.Age >= long.Parse(ageIn))
                            {
                                listOfAliens += x.ToString();
                                count++;
                            }
                        }

                        if (count == 0)
                            Console.WriteLine("\nNo aliens are {0} year/s old or older.", ageIn);
                        else
                            Console.WriteLine("\nAliens that are {0} year/s old or older are: \n{1}", ageIn, listOfAliens);
                    }
                }
            }
            //exit condition
            while (choice != "8");
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

        //public static void Assignment4()
        //{
        //    string name, type;
        //    long age;
        //    bool isGood;
        //    Spaceship arena = new Spaceship();
        //    Planet alienPlanet = new Planet("X", 10, 10);
        //    BattlePlanContext alienBattle = new BattlePlanContext();

        //    Console.WriteLine("The Good Alien. \n");
        //    Console.WriteLine("Enter name: ");
        //    name = Console.ReadLine();

        //    Console.WriteLine("Enter age: ");
        //    age = long.Parse(Console.ReadLine());

        //    Console.WriteLine("Enter type: [A]lpha, [B]eta, [G]amma, [O]ther");
        //    type = Console.ReadLine();

        //    if (type == "A")
        //    {
        //        AlphaAlien _goodAlien = new AlphaAlien(name, age, true);
        //        _goodAlien.Planet = alienPlanet;
        //        arena.AddAlien(_goodAlien);
        //    }
        //    if (type == "B")
        //    {
        //        BetaAlien _goodAlien = new BetaAlien(name, age, true);

        //        _goodAlien.Planet = alienPlanet;
        //        arena.AddAlien(_goodAlien);
        //    }
        //    if (type == "G")
        //    {
        //        GammaAlien _goodAlien = new GammaAlien(name, age, true);

        //        _goodAlien.Planet = alienPlanet;
        //        arena.AddAlien(_goodAlien);
        //    }
        //    if (type == "O")
        //    {
        //        Alien _goodAlien = new Alien(name);
        //        _goodAlien.IsGood = true;
        //        _goodAlien.Age = age;
        //        _goodAlien.Planet = alienPlanet;
        //        arena.AddAlien(_goodAlien);
        //    }

        //    Console.WriteLine("\nThe Evil Alien. \n");
        //    Console.WriteLine("Enter name: ");
        //    name = Console.ReadLine();

        //    Console.WriteLine("Enter age: ");
        //    age = long.Parse(Console.ReadLine());

        //    Console.WriteLine("Enter type: [A]lpha, [B]eta, [G]amma, [O]ther");
        //    type = Console.ReadLine();

        //    if (type == "A")
        //    {
        //        AlphaAlien _evilAlien = new AlphaAlien(name, age, false);
        //        _evilAlien.Planet = alienPlanet;
        //        arena.AddAlien(_evilAlien);
        //    }
        //    if (type == "B")
        //    {
        //        BetaAlien _evilAlien = new BetaAlien(name, age, false);
        //        _evilAlien.Planet = alienPlanet;
        //        arena.AddAlien(_evilAlien);
        //    }
        //    if (type == "G")
        //    {
        //        GammaAlien _evilAlien = new GammaAlien(name, age, false);
        //        _evilAlien.Planet = alienPlanet;
        //        arena.AddAlien(_evilAlien);
        //    }
        //    if (type == "O")
        //    {
        //        Alien _evilAlien = new Alien(name);
        //        _evilAlien.IsGood = false;
        //        _evilAlien.Age = age;
        //        _evilAlien.Planet = alienPlanet;
        //        arena.AddAlien(_evilAlien);
        //    }

        //    Console.WriteLine("\n\n");

        //    foreach (Alien alien in arena.Aliens())
        //    {
        //        Console.WriteLine(alien.ToString());
        //    }

        //    Console.WriteLine("Press a key to begin battle...");
        //    Console.ReadLine();

        //    Console.WriteLine("*The good Alien attacked the evil Alien*");
        //    long damageDealt = alienBattle.ComputeDamage(arena.GetAlien(0), arena.GetAlien(1));
        //    Console.WriteLine("The good Alien dealt " + damageDealt +
        //        " damage to the evil Alien.");
        //}
    }
}
