using System;
using System.Collections;

namespace OOP3_Exercise_4
{
    class Program
    {

        static void Main(string[] args)
        {


            Console.WriteLine("_______________________________________");
            Console.WriteLine("Input number of Scientist");
            int s = int.Parse(Console.ReadLine());
            int NumScie = (s != 0) ? s : 0;
            Scientist[] scientists = new Scientist[NumScie];
            Console.WriteLine("_______________________________________");
            Console.WriteLine("Input number of Manager");
            int m = int.Parse(Console.ReadLine());
            int NumManager = (m != 0) ? m : 0;
            Manager[] managers = new Manager[NumManager];
            Console.WriteLine("_______________________________________");
            Console.WriteLine("Input number of LabStaff");
            int n = int.Parse(Console.ReadLine());
            int NumStaff = (n != 0) ? n : 0;
            LabStaff[] labStaffs = new LabStaff[NumStaff];
            if (NumScie != 0 || NumManager != 0 || NumStaff != 0)
            {
                if (NumScie != 0)
                {
                    int i = 0;
                    while (i < NumScie)
                    {

                        ArrayList list = Input("Scientist", i);
                        scientists[i] = new Scientist((string)list[0], (string)list[1], (string)list[2], (string)list[3], (string)list[4], (int)list[5], (int)list[6]);
                        i++;
                    }
                    ShowScientist();

                }
                if (NumManager != 0)
                {
                    int i = 0;
                    while (i < NumManager)
                    {
                        ArrayList list = Input("Manager", i);
                        managers[i] = new Manager((string)list[0], (string)list[1], (string)list[2], (string)list[3], (int)list[5], (int)list[6]);
                        i++;
                    }
                    ShowManager();
                }
                if (NumStaff != 0)
                {
                    int i = 0;
                    while (i < NumStaff)
                    {
                        ArrayList list = Input("LabStaff", i);
                        labStaffs[i] = new LabStaff((string)list[0], (string)list[1], (string)list[2], (string)list[3], (long)list[7]);
                        i++;

                    }

                    ShowLabStaff();
                }
                else
                {
                    Console.WriteLine("Please input least an object");
                }

                ArrayList Input(string name, int i)
                {
                    Console.WriteLine($"Please input {name}'s name {i + 1}");
                    string Name = Console.ReadLine();
                    Console.WriteLine($"Please input birthday of {Name} ");
                    string Birthday = Console.ReadLine();
                    Console.WriteLine($"Please input degree of {Name} ");
                    string Degree = Console.ReadLine();
                    Console.WriteLine($"Please input position of {Name} ");
                    string Position = Console.ReadLine();

                    string Announce = (name == "Scientist") ? $"Please input number articles of {Name} " : null;
                    Console.WriteLine(Announce);
                    string NumOfArticles = (name == "Scientist") ? Console.ReadLine() : null;

                    Console.WriteLine($"Please input number of working day of {Name} ");
                    int NumOfWorkDay = (name != "LabStaff") ? int.Parse(Console.ReadLine()) : 0;
                    Console.WriteLine($"Please input Salary Scale of {Name} ");
                    int SalaryScale = (name != "LabStaff") ? int.Parse(Console.ReadLine()) : 0;

                    string Announce1 = (name == "LabStaff") ? $"Please input salary of {Name} " : null;
                    Console.WriteLine(Announce1);
                    long salary = (name == "LabStaff") ? long.Parse(Console.ReadLine()) : 0;



                    var list = new ArrayList() { Name, Birthday, Degree, Position, NumOfArticles, NumOfWorkDay, SalaryScale, salary };
                    return list;
                }
            }

            void ShowScientist()
            {
                long total = 0;
                foreach (Scientist scientist in scientists)
                {
                    Console.WriteLine($"Scientist's name : {scientist.Name}, birthday : {scientist.Birthday}, degree : {scientist.Degree}, position : {scientist.Position}, number of articles : {scientist.NumOfArticles}, salary scale : {scientist.SalaryScale}");
                    Console.WriteLine("_______________________________________");
                    total += scientist.Salary;
                }
                Console.WriteLine($"Total salary paid for scientists is {total}");
                Console.WriteLine("_______________________________________");
            }
            void ShowManager()
            {
                long total = 0;
                foreach (Manager manager in managers)
                {
                    Console.WriteLine($"Manager's name : {manager.Name}, birthday : {manager.Birthday}, degree : {manager.Degree}, position : {manager.Position}, salary scale : {manager.SalaryScale}");
                    Console.WriteLine("_______________________________________");
                    total += manager.Salary;
                }
                Console.WriteLine($"Total salary paid for managers is {total}");
                Console.WriteLine("_______________________________________");
            }
            void ShowLabStaff()
            {
                long total = 0;
                foreach (LabStaff labstaff in labStaffs)
                {
                    Console.WriteLine($"Scientist's name : {labstaff.Name}, birthday : {labstaff.Birthday}, degree : {labstaff.Degree}, position : {labstaff.Position}");
                    Console.WriteLine("_______________________________________");
                    total += labstaff.Salary;
                }
                Console.WriteLine($"Total salary paid for labStaffs is {total}");
                Console.WriteLine("_______________________________________");
            }

        }
    }
    abstract class ScienceEducation
    {
        private string name;
        private string birthday;
        private string degree; // bangcap
        private string position; // chuc vu

        public string Name 
        { 
            get => name; 
            set => name = value; 
        }
        public string Birthday 
        { 
            get => birthday; 
            set => birthday = value; 
        }
        public string Degree
        { 
            get => degree; 
            set => degree = value; 
        }
        public string Position 
        { 
            get => position;
            set => position = value; 
        }
        public abstract long Salary // only get value from salary properties
        {
            get;
        }
    }
    class Scientist : ScienceEducation
    {
        private string numOfArticles;
        private int NumOfWorkDay;
        private int salaryScale;// bac luong
 
        public int SalaryScale 
        { 
            get => salaryScale; 
            set => salaryScale = value; 
        }
        public string NumOfArticles
        {
            get => numOfArticles;
            set => numOfArticles = value;
        }

        public Scientist()
        {

        }

        public Scientist(string name, string birthday, string degree, string position, string NumArticles, int NumWork, int SalaryScale)                                //contructor
        {
            base.Name = name;
            base.Birthday = birthday;
            base.Degree = degree;
            base.Position = position;

            this.NumOfArticles = NumArticles;
            this.NumOfWorkDay = NumWork;
            this.SalaryScale = SalaryScale;
            
        }


        public override long Salary
        {
            get
            {
                return NumOfWorkDay * SalaryScale;
            }
        }

    }
    class Manager : ScienceEducation
    {
        private int NumOfWorkDay;
        private int salaryScale;// bac luong

        public int SalaryScale
        {
            get => salaryScale;
            set => salaryScale = value;
        }

        public Manager()
        {

        }
        public Manager(string name, string birthday, string degree, string position, int NumWork, int SalaryScale)
        {
            base.Name = name;
            base.Birthday = birthday;
            base.Degree = degree;
            base.Position = position;

            this.NumOfWorkDay = NumWork;
            this.SalaryScale = SalaryScale;

        }
        public override long Salary
        {
            get
            {
                return NumOfWorkDay * SalaryScale;
            }
        }
    }
    class LabStaff : ScienceEducation
    {
        private long salary;
        public LabStaff()
        {

        }
        public LabStaff(string name, string birthday, string degree, string position, long salary)
        {
            base.Name = name;
            base.Birthday = birthday;
            base.Degree = degree;
            base.Position = position;

            this.salary = salary;
        }
        
        public override long Salary
        {
            get
            {
                return salary;
            }
        }
    }
}
