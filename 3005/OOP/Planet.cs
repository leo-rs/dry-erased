/* Jan Leo Ras
 * CSCI 3005
 * Assignment 3 - Aliens in the Galaxy
 * Dr. Dana
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    //this class holds the information of a planet
    class Planet
    {
        //fields
        //name of planet
        //diameter of planet
        //distance from the sun
        private string _name;
        private decimal _diameter;
        private decimal _distanceFromSun;

        //pi constant
        private const double pi = 3.14;

        public Planet(string name, decimal diameter, decimal distanceFromSun)
        {
            _name = name;
            _diameter = diameter;
            _distanceFromSun = distanceFromSun;
        }

        public decimal DistanceFromSun
        {
            get { return _distanceFromSun; }
        }

        public decimal Diameter
        {
            get { return _diameter; }
        }

        public string Name
        {
            get { return _name; }
        }

        //this method returns the volume of the planet using formula: 4/3 * (pi * radius^3)
        public decimal ComputeVolume()
        {
            return (decimal)(4 * pi * Math.Pow((double)(Diameter / (decimal)2), 3.0)) / 3;

        }
    }
}
