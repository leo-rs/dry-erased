/* Jan Leo Ras
 * CSCI 3005
 * Assignment 6 - Testing
 * Dr. Dana
 * 7/3/2022
 * This project implements unit testing on a simple math problem
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting
{
    public class NumberFun
    {
        public static void Main()
        {

        }

        public static bool ThirdGradeMath(int a, int b, int c)
        {
            bool addRes = (a + b) == c;
            bool subRes = (a - b) == c || (b - a) == c;
            bool multRes = (a * b) == c;
            bool divRes1 = (a / b) == c && a % b == 0;
            bool divRes2 = (b / a) == c && b % a == 0;

            return addRes || subRes || multRes || divRes1 || divRes2;
        }
    }
}
