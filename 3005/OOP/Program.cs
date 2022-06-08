/* Jan Leo Ras
 * CSCI 3005
 * Assignment 1 - The Galaxy
 * Dr. Dana
 */

using System;

namespace OOP
{
    class Program
    {
        static void Main() 
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

                Console.WriteLine("\n" + first.Name + "'s volume = " + first.ComputeVolume());
                Console.WriteLine(second.Name + "'s volume = " + second.ComputeVolume());
                Console.WriteLine(third.Name + "'s volume = " + third.ComputeVolume());

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