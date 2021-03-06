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
    //this class stores the properties of an Alien
    class Alien
    {
        private string _name;
        private string _color;
        private long _age;
        private bool _isGood;
        private Planet? _planet;
      
        //constructor with all fields
        public Alien(string name, string color, long age, bool isGood, Planet planet)
        {
            Name = name;
            Color = color;
            Age = age;
            IsGood = isGood;
            Planet = planet;
        }

        //constructor with name only
        public Alien(string name)
        {
            Name = name;
            Color = "";
            Age = 0;
            IsGood = false;
            Planet = null;
        }

        //getters/setters for all fields
        public Planet Planet
        {
            get { return _planet; }
            set { _planet = value; }
        }

        public bool IsGood
        {
            get { return _isGood; }
            set { _isGood = value; }
        }

        public long Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        //override parent ToString, can be implemented by child class
        public virtual string ToString()
        {
            string side = "good";
            if (!IsGood)
                side = "evil";
            return "\n\"" + Name + "\" (" + Color + "), " + Age + " Years Old [" + side + " Alien]";
        }
    }
}
