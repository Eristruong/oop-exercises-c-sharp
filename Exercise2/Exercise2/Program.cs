using System;
using System.Text.RegularExpressions;

namespace Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            Student[] ListStudent;
            Console.WriteLine("Enter number student: ");
            int n = int.Parse(Console.ReadLine());
            ListStudent = new Student[n];
            Console.WriteLine("Enter list student: ");
            for (int i = 0; i < n; i++)
            {
                ListStudent[i] = new Student();
                Console.WriteLine("Enter student name {0}: ", i+1);
                ListStudent[i].name = Console.ReadLine();
                if (!Regex.Match(ListStudent[i].name, "^[A-Z][a-zA-Z]*$").Success)
                {
                    // first name was incorrect
                    Console.WriteLine("Invalid name, please input one more time");
                    return;
                }
                Console.WriteLine("Enter student age {0}: ", i + 1);
                ListStudent[i].age = Console.ReadLine();
                ListStudent[i].Input();//input GPA
            }
            Console.WriteLine("Show list student: ");
            foreach (Student student in ListStudent)
                student.DisplayStudent();

            Console.ReadLine();




        }
    }
    public class Person
    {
        public string age
        {
            get; set;
        }
        public string name
        {
            get; set;
        }
        public Person()
        {

        }
        public Person(string inputAge, string inputName)
        {
            age = inputAge;
            name = inputName;
        }
        public void Input()
        {
            this.age = age;
            this.name = name;


        }
        public void DisplayPerson()
        {
            Console.WriteLine("Infomation student name: " + name + " Age: " + age);
            

        }
        public override string ToString()
        {
            return base.ToString() + ": " + name.ToString() + ":" + age.ToString();
        }
    }
    class Student : Person
    {
        public string GPA
        {
            set; get;
        }
        public Student()
        {

        }
        public Student(string inputGPA)
        {
            GPA = inputGPA;

        }
        public void Input()
        {
            Console.WriteLine("Enter your GPA : ");
            GPA = Console.ReadLine();
        }
        public void DisplayStudent()
        {
            DisplayPerson();
            Console.WriteLine("Student GPA is " + GPA);
        }
    }

}
