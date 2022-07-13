using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    class AlienTransform
    {
        public delegate int ModifyIntegerOperation(int age);
        public delegate bool ModifyAlignmentOperation(bool alignment);
        public delegate bool FilterByAgeOperation(int age);


        public static Spaceship ModifyAge(Spaceship spaceship, ModifyIntegerOperation op)
        {
            Spaceship newSpaceship = new Spaceship();
            
            for (int i = 0; i < spaceship.Count(); i++)
            {
                long newAge = (long)op((int)spaceship.GetAlien(i).Age);
                newSpaceship.AddAlien(spaceship.GetAlien(i));
                newSpaceship.GetAlien(i).Age = newAge;
            }
            
            return newSpaceship;
        }

        public static Spaceship ModifyAlignment(Spaceship spaceship, ModifyAlignmentOperation op)
        {
            Spaceship newSpaceship = new Spaceship();

            for (int i = 0; i < spaceship.Count(); i++)
            {
                bool newAlignment = op(spaceship.GetAlien(i).IsGood);
                newSpaceship.AddAlien(spaceship.GetAlien(i));
                newSpaceship.GetAlien(i).IsGood = newAlignment;
            }

            return newSpaceship;
        }

        public static Spaceship FilterByAge(Spaceship spaceship, FilterByAgeOperation op)
        {
            Spaceship newSpaceship = new Spaceship();

            for (int i = 0; i < spaceship.Count(); i++)
            {
                bool filter = op((int)spaceship.GetAlien(i).Age);
                if(filter)
                    newSpaceship.AddAlien(spaceship.GetAlien(i));
            }

            return newSpaceship;
        }

        
    }
}
