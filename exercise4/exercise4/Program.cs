using System;
using System.Collections.Generic;

namespace exercise4
{
    class Program
    {
        static void Main(string[] args)
        {
            bool run = true;
            while (run)
            {
                Console.WriteLine("___________________________________________________________________________________________");
                Console.WriteLine("__________________Perform arithmetic operations with fractional numbers____________________");
                Console.WriteLine("_______________________________Chosse the number to perform________________________________");
                Console.WriteLine("__________________1. Add two fractions");
                Console.WriteLine("__________________2. Subtract two fractions");
                Console.WriteLine("__________________3. Multipy two fractions");
                Console.WriteLine("__________________4. Divide two fractions");
                Console.WriteLine("__________________5. Exit");
                Fraction fraction = new Fraction();

                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        fraction.Input();
                        Console.WriteLine("The result of add two fractions: " + fraction.Display(fraction.AddFraction()));
                        Console.WriteLine("The result of add two fractions is a decimal number: " + fraction.ConvertDecimalNum(fraction.AddFraction()));
                        break;
                    case 2:
                        fraction.Input();
                        Console.WriteLine("The result of add two fractions: " + fraction.Display(fraction.Subtract()));
                        Console.WriteLine("The result of add two fractions is a decimal number: " + fraction.ConvertDecimalNum(fraction.Subtract()));
                        break;
                    case 3:
                        fraction.Input();
                        Console.WriteLine("The result of add two fractions: " + fraction.Display(fraction.Multiply()));
                        Console.WriteLine("The result of add two fractions is a decimal number: " + fraction.ConvertDecimalNum(fraction.Multiply()));
                        break;
                    case 4:
                        fraction.Input();
                        Console.WriteLine("The result of add two fractions: " + fraction.Display(fraction.Divide()));
                        Console.WriteLine("The result of add two fractions is a decimal number: " + fraction.ConvertDecimalNum(fraction.Divide()));
                        break;
                    case 5:
                        run = false;
                        break;
                }

            }
        }
        
    }
    class Fraction
    {
        public List<Fraction> fractions;
        public int Numerator
        {
            get; set;
        }
        public int Denominator
        {
            get; set;
        }
        public Fraction()
        {

        }
        public Fraction(int Num, int Den)
        {
            this.Numerator = Num;
            this.Denominator = Den;

        }
        public void Input()
        {
            Console.WriteLine("Enter Fraction 1 : A/B ");
            string data1 = Console.ReadLine();
            string[] fraction1 = (data1.Contains("/")) ? data1.Split("/") : null ;
            Console.WriteLine("Enter Fraction 2 : A/B ");
            string data2 = Console.ReadLine();
            string[] fraction2 = (data2.Contains("/")) ? data2.Split("/") : null;
            if (fraction2.Length != 0 && fraction1.Length != 0)
            {
                fractions = new List<Fraction>();  
                Fraction frac1 = new Fraction();
                int f1 = int.Parse(fraction1[0]);
                int f2 = int.Parse(fraction1[1]);
                //setter method sign values for attributes on Fraction class
                frac1.Numerator = f1; 
                frac1.Denominator = f2;
                Fraction frac2 = new Fraction();
                int f3 = int.Parse(fraction2[0]);
                int f4 = int.Parse(fraction2[1]);
                //setter method sign values for attributes on Fraction class
                frac2.Numerator = f3;
                frac2.Denominator = f4;
                fractions.Add(frac1);
                fractions.Add(frac2);        
            }
            else
            {
                Console.WriteLine("Please enter correct form A/B fraction");
            }
            
        }
        public Fraction AddFraction()   
        {
            int r1 = fractions[0].Numerator * fractions[1].Denominator + fractions[1].Numerator * fractions[0].Denominator;
            int r2 = (CheckEqualDenominator()) ? fractions[0].Denominator : fractions[0].Denominator * fractions[1].Denominator;
            return new Fraction(r1, r2);
        }

        public Fraction Subtract()
        {
            int r1 = fractions[0].Numerator * fractions[1].Denominator - fractions[1].Numerator * fractions[0].Denominator;
            int r2 = (CheckEqualDenominator()) ? fractions[0].Denominator : fractions[0].Denominator * fractions[1].Denominator;
            return new Fraction(r1, r2);

        }
        public Fraction Multiply()
        {
            int r1 = fractions[0].Numerator * fractions[1].Numerator;
            int r2 = fractions[0].Denominator * fractions[1].Denominator;
            return new Fraction(r1, r2);

        }
        public Fraction Divide()
        {
            int r1 = fractions[0].Numerator * fractions[1].Denominator;
            int r2 = fractions[0].Denominator * fractions[1].Numerator;
            return new Fraction(r1, r2);

        }
        public string Display(Fraction fraction)
        {           
            return (fraction.Denominator == 1) ? fraction.Numerator.ToString() : fraction.Numerator+"/"+fraction.Denominator;

        }
        bool CheckEqualDenominator()
        {
            return fractions[0].Denominator == fractions[1].Denominator;
        }
        public decimal ConvertDecimalNum(Fraction fraction)
        {
            decimal result = (decimal)fraction.Numerator / fraction.Denominator;
            return result; 
        }



    }
    
}
