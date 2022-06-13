/* Jan Leo Ras
 * CSCI 3005
 * Assignment 1 - The Galaxy
 * Dr. Dana
 */

using System;

namespace OOP
{
    //this class builds and returns a Planet object
    class PlanetBuilder
    {
        private Planet? _planet;

        //constructor initializes a null object
        public PlanetBuilder()
        {
            _planet = null;
        }

        //returns Planet object
        //throws an exception if the Planet is null
        public Planet GetPlanet()
        {
            if (_planet == null)
            {
                throw new NullReferenceException("No planets have been built.");
            }
            
            return _planet; 
        }

        //prompts user for name, diameter, and distance and creates Planet object
        //throws exceptions for invalid input
        public void BuildPlanet()
        {
            string name, diameter, distance;

            Console.WriteLine("Enter planet name: ");
            name = Console.ReadLine();
            if (name.Length == 0)
            {
                throw new ArgumentException("The name cannot be an empty string.");
            }

            Console.WriteLine("Enter planet diameter: ");
            diameter = Console.ReadLine();
            if (diameter.Length == 0)
            {
                throw new ArgumentException("The diameter cannot be less than 0.");
            }

            Console.WriteLine("Enter planet's distance from the Sun: ");
            distance = Console.ReadLine();
            if (distance.Length == 0)
            {
                throw new ArgumentException("The distance cannnot be less than 0.");
            }

            Planet newPlanet = new Planet(name, Convert.ToDecimal(diameter), Convert.ToDecimal(distance));
            _planet = newPlanet;
        }
    }
}
