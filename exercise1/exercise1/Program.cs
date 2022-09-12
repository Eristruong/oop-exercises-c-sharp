using System;

namespace exercise1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter a number of sides of Dice :");
            int slides = Convert.ToInt32(Console.ReadLine());
            Dice newDice = new Dice(slides);
            int result = newDice.Roll();

            Console.WriteLine("input a guessing number please ! :");
            if (result == Convert.ToInt32(Console.ReadLine()))
            {
                Console.WriteLine("Exactly !!! ,the results of sides of Dice :" + result);
            }
            else
            {
                Console.WriteLine("Wrong !!! ,the results of sides of Dice :" + result);
            }

        }
    }
    class Dice //exercise 1
    {
        private int slides;
        public int randomNum;


        public Dice(int slidesNum)
        {
            slides = slidesNum;
        }
        public int Roll()
        {

            string Numrd_str;
            Random rd = new Random();
            //Numrd = rd.Next(1, 100);
            Numrd_str = rd.Next(1, slides).ToString();
            randomNum = Convert.ToInt32(Numrd_str);

            return randomNum;

        }

    }

}
