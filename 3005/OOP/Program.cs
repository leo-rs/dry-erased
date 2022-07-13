/* Jan Leo Ras
 * CSCI 3005
 * Assignment 5 - Transform
 * Dr. Dana
 * 7/4/2022
 * This program uses delegates to modify Aliens in a spaceship
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    class Program
    {
        public static void Main()
        {
            string choice, ageIn, alliance;
            Spaceship mySpaceship = new Spaceship();
            Spaceship newSpaceship = new Spaceship();

            do
            {
                Console.WriteLine("\nSelect from the following options:" +
                    "\n(1) Enter a new Alien to the spaceship." +
                    "\n(2) Display all Aliens." +
                    "\n(3) Display all Aliens with doubled age." +
                    "\n(4) Display all Aliens with flipped alignment." +
                    "\n(5) Display all Aliens with age at least 10." +
                    "\n(6) Display all Aliens as good, add 15 to age, but only display those with age less than 100." +
                    "\n(7) Quit");
                choice = Console.ReadLine();

                if (choice == "1")
                {
                    if (mySpaceship.MaximumCapacity == mySpaceship.Count())
                        Console.WriteLine("Maximum occupancy has been reached. Cannot add more Aliens.");

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

                        mySpaceship.AddAlien(newAlien);
                        
                    }
                }

                if (choice == "2")
                {
                    foreach (Alien alien in mySpaceship.Aliens())
                        Console.WriteLine(alien.ToString());
                }

                if (choice == "3")
                {

                    Console.WriteLine(AlienTransform.ModifyAge(mySpaceship, DoubleAge).ToString());
                }

                if (choice == "4")
                {

                    Console.WriteLine(AlienTransform.ModifyAlignment(mySpaceship, FlipAlignment).ToString());
                }

                if (choice == "5")
                {
                    Console.WriteLine(AlienTransform.FilterByAge(mySpaceship, FilterOver10).ToString());
                }


                if (choice == "6")
                {
                    AlienTransform.ModifyAlignment(mySpaceship, ConvertToGood);
                    AlienTransform.ModifyAge(mySpaceship, Add15Years);
                    newSpaceship = AlienTransform.FilterByAge(mySpaceship, FilterOver100);
                    foreach (Alien alien in newSpaceship.Aliens())
                        Console.WriteLine(alien.ToString());
                }


            } while (choice != "7");
        }

        public static int Add15Years(int age)
        {
            return 15 + age;
        }

        public static int DoubleAge(int age)
        {
            return 2 * age;
        }

        public static bool FlipAlignment(bool alignment)
        {
            return !alignment;
        }

        public static bool ConvertToGood(bool alignment)
        {
            return true;
        }

        public static bool FilterOver10(int age)
        {
            return age >= 10;
        }

        public static bool FilterOver100(int age)
        {
            return age < 100;
        }


    }
}
    