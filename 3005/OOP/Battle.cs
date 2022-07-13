/* Jan Leo Ras
 * CSCI 3005
 * Assignment 4 - Battle
 * Dr. Dana
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    class Battle
    {
        public static void Main()
        {
            string name, type;
            long age;
            bool isGood;
            Spaceship arena = new Spaceship();
            Planet alienPlanet = new Planet("X", 10, 10);
            BattlePlanContext alienBattle = new BattlePlanContext() ;

            Console.WriteLine("The Good Alien. \n");
            Console.WriteLine("Enter name: ");
            name = Console.ReadLine();

            Console.WriteLine("Enter age: ");
            age = long.Parse(Console.ReadLine());

            Console.WriteLine("Enter type: [A]lpha, [B]eta, [G]amma, [O]ther");
            type = Console.ReadLine();

            if (type == "A")
            {
                AlphaAlien _goodAlien = new AlphaAlien(name, age, true);
                _goodAlien.Planet = alienPlanet;
                arena.AddAlien(_goodAlien);
            }
            if (type == "B")
            {
                BetaAlien _goodAlien = new BetaAlien(name, age, true);

                _goodAlien.Planet = alienPlanet;
                arena.AddAlien(_goodAlien);
            }
            if (type == "G")
            {
                GammaAlien _goodAlien = new GammaAlien(name, age, true);

                _goodAlien.Planet = alienPlanet;
                arena.AddAlien(_goodAlien);
            }
            if (type == "O")
            {
                Alien _goodAlien = new Alien(name);
                _goodAlien.IsGood = true;
                _goodAlien.Age = age;
                _goodAlien.Planet = alienPlanet;
                arena.AddAlien(_goodAlien);
            }

            Console.WriteLine("\nThe Evil Alien. \n");
            Console.WriteLine("Enter name: ");
            name = Console.ReadLine();

            Console.WriteLine("Enter age: ");
            age = long.Parse(Console.ReadLine());

            Console.WriteLine("Enter type: [A]lpha, [B]eta, [G]amma, [O]ther");
            type = Console.ReadLine();

            if (type == "A")
            {
                AlphaAlien _evilAlien = new AlphaAlien(name, age, false);
                _evilAlien.Planet = alienPlanet;
                arena.AddAlien(_evilAlien);
            }
            if (type == "B")
            {
                BetaAlien _evilAlien = new BetaAlien(name, age, false);
                _evilAlien.Planet = alienPlanet;
                arena.AddAlien(_evilAlien);
            }
            if (type == "G")
            {
                GammaAlien _evilAlien = new GammaAlien(name, age, false);
                _evilAlien.Planet = alienPlanet;
                arena.AddAlien(_evilAlien);
            }
            if (type == "O")
            {
                Alien _evilAlien = new Alien(name);
                _evilAlien.IsGood = false;
                _evilAlien.Age = age;
                _evilAlien.Planet = alienPlanet;
                arena.AddAlien(_evilAlien);
            }

            Console.WriteLine("\n\n");

            foreach(Alien alien in arena.Aliens())
            {
                Console.WriteLine(alien.ToString());
            }

            Console.WriteLine("Press a key to begin battle...");
            Console.ReadLine();

            Console.WriteLine("*The good Alien attacked the evil Alien*");
            long damageDealt = alienBattle.ComputeDamage(arena.GetAlien(0), arena.GetAlien(1));
            Console.WriteLine("The good Alien dealt " + damageDealt +
                " damage to the evil Alien.");
        }
    }
}