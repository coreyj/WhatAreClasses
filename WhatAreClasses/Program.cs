using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatAreClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            FractionTest1();
            FractionTest2();

            Console.ReadLine();
        }

        static void FractionTest1()
        {
            Console.WriteLine("--------------------TEST 1--------------------");
            var f1 = new Fraction
            {
                Numerator = 1,
                Denominator = 3
            };

            var f2 = new Fraction
            {
                Numerator = 3,
                Denominator = 7
            };

            var f3 = new Fraction
            {
                Numerator = 4,
                Denominator = 8
            };

            // Which version do you prefer?
            var answer = f1.Add(2);
            Console.WriteLine(answer);
            answer = f1 + 2;
            Console.WriteLine(answer);

            Console.WriteLine(f1 + " + 2 = " + (f1 + 2));
            Console.WriteLine(f1 + " + " + f2 + " = " + (f1 + f2));
            Console.WriteLine(f2 + " - " + f1 + " = " + (f2 - f1));
            Console.WriteLine(f1 + " - " + f2 + " = " + (f1 - f2));
            Console.WriteLine(f1 + " * " + f2 + " = " + (f1 * f2));
            Console.WriteLine(f1 + " / " + f2 + " = " + (f1 / f2));
            Console.WriteLine(f2 + " = " + f2.Simplified);
            Console.WriteLine(f3 + " = " + f3.Simplified);
            Console.WriteLine(f1 + "'s reciprocal is " + f1.Reciprocal());
            Console.WriteLine(f2 + "'s reciprocal is " + f2.Reciprocal());
            Console.WriteLine(f3 + "'s reciprocal is " + f3.Reciprocal());
            Console.WriteLine(f1 + " = " + f1.Evaluate());
            Console.WriteLine(f2 + " = " + f2.Evaluate());
            Console.WriteLine(f3 + " = " + f3.Evaluate());
        }

        public static void FractionTest2()
        {
            Console.WriteLine("--------------------TEST 2---------------------");

            Console.WriteLine("----------Using Assignment----------");
            Fraction f1 = new Fraction()
            {
                Numerator = 2,
                Denominator = 5
            };

            Fraction f2 = f1;

            f2.Numerator = 4; // f1 is now equal to 4/5
            Console.WriteLine("f1 = " + f1);
            Console.WriteLine("f2 = " + f2);

            Console.WriteLine("----------Using Copy Constructor----------");
            Fraction f3 = new Fraction(f1);

            f1.Set(2, 5);
            f3.Set(4, 5);
            Console.WriteLine("f1 = " + f1);
            Console.WriteLine("f3 = " + f3);


        }
    }

    public class DummyClass
    {

    }
}
