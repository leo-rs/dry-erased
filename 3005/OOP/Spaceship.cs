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
    //this class contains a listing of Aliens
    class Spaceship
    {
        private List<Alien> _aliens;
        private string _name;
        private int _maximumCapacity;

        //constructor with spaceship name
        public Spaceship(string name)
        {
            _aliens = new List<Alien>();
            _name = name;
            _maximumCapacity = 0;
        }

        //overloading constructor
        public Spaceship()
        {
            _aliens = new List<Alien>();
            _name = "";
            _maximumCapacity = 100;
        }

        public List<Alien> Aliens() 
        { 
            return _aliens; 
        }

        public Alien GetAlien(int i)
        {
            
            return _aliens.ElementAt(i);
            
        }

        //add an alien unless capacity is reached
        public void AddAlien(Alien alien)
        {
            if (MaximumCapacity > this.Count())
            {
                _aliens.Add(alien);
            }
            else
                Console.WriteLine("Maximum occupancy reached. Cannot add more aliens to this spaceship.");
        }

        

        //return count of aliens
        public int Count()
        {
            return _aliens.Count;
        }

        //overloaded count method
        //take boolean goodOrEvil param
        //counts number of good or evil aliens
        public int Count(bool goodOrEvil)
        {
            int i = 0;
            foreach (Alien x in _aliens)
            {
                if (x.IsGood == goodOrEvil)
                    i++;
            }
            return i;
        }

        //return oldest alien
        public Alien Oldest()
        {
            Alien oldie = null;
            long age = 0;

            foreach (Alien x in _aliens)
            {
                if (x.Age >= age) 
                {
                    age = x.Age;
                    oldie = x;
                }
            }
            return oldie;
        }

        //overloaded oldest method
        //take string color param
        //counts number of color aliens
        public Alien Oldest(string color)
        {
            Alien oldie = null;
            long age = 0;

            foreach (Alien x in _aliens)
            {
                if (x.Age >= age && x.Color == color)
                {
                    age = x.Age;
                    oldie = x;
                }
            }
            return oldie;
        }

        //returns true if color exists in list
        public bool IsAColor(string color)
        {
            foreach (Alien x in _aliens)
                if (x.Color == color)
                    return true;
            return false;
        }

        //max capacity getter/setter
        public int MaximumCapacity
        {
            get { return _maximumCapacity; }
            set { _maximumCapacity = value; }
        }

        //name getter/setter
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        //override parent ToString
        public override string ToString()
        {
            string passengers = "\n";
            if (Count() == 0)
                passengers += "\nThis spaceship has no aliens aboard.";
            else 
            {
                for (int i = 0; i < Count(); i++)
                    passengers += _aliens[i].ToString();
            }
            return "\nSpaceship \'" + Name + "\'" + passengers;
        }
        
    }
}
