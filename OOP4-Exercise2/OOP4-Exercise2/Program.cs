using System;
using System.Collections;

using System.IO;

namespace OOP4_Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 0;

            AccountList accountList = new AccountList();
            while (n == 0)
            {
                Console.WriteLine("__________________---------------___________________");
                Console.WriteLine("Enter one least method below: ");
                Console.WriteLine("1. 'add' : add an account into list account");
                Console.WriteLine("2. 'save' : save list account into file");
                Console.WriteLine("3. 'load' : load list account from file");
                Console.WriteLine("4. 'Remove' : Remove account in list accounts");
                Console.WriteLine("5. 'Sort' : Sort account by Account ID | First Name | Balance");
                Console.WriteLine("6. 'exit' : Exit");
                string scan = Console.ReadLine();
                if ("add" == scan)
                {
                    accountList.NewAccount();
                    accountList.Report();
                }
                else if ("save" == scan)
                {
                    accountList.SaveFile();
                }
                else if ("load" == scan)
                {
                    accountList.LoadFile();
                    accountList.Report();
                }
                else if ("remove" == scan)
                {
                    accountList.RemoveAcc();
                    accountList.Report();
                }
                else if ("sort" == scan)
                {
                    Console.WriteLine("Choose style sort list accounts : ");
                    Console.WriteLine("1. Sort by Account ID");
                    Console.WriteLine("2. Sort by First Name");
                    Console.WriteLine("3. Sort by First Balance");
                    string scan2 = Console.ReadLine();
                    if (scan2 == "1")
                    {
                        accountList.SortByAccountID();
                        accountList.Report();
                    }
                    else if (scan2 == "2")
                    {
                        accountList.SortByFirstName();
                        accountList.Report();
                    }
                    else
                    {
                        accountList.SortByBalance();
                        accountList.Report();
                    }
                }
                else
                {
                    n = 1;
                    
                }
            }
        }
    }
    class Account
    {
        private int accountID;
        private string firstName;
        private string lastName;
        private int balance;
        
        public Account()
        {

        }
        public Account(int accountid, string firstname, string lastname, int balance)
        {
            this.accountID = accountid;
            this.firstName = firstname;
            this.lastName = lastname;
            this.balance = balance;
        }

        public int AccountID { get => accountID; set => accountID = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public int Balance { get => balance; set => balance = value; }

        public void FillInfo()
        {
            Console.WriteLine("AccountID: ");
            AccountID = int.Parse(Console.ReadLine());
            Console.WriteLine("FirstName: ");
            FirstName = Console.ReadLine();
            Console.WriteLine("LastName: ");
            LastName = Console.ReadLine();
            Console.WriteLine("Balance: ");
            Balance = int.Parse(Console.ReadLine());


        }
        public void Query()
        {
            Console.WriteLine("________________________");
            Console.WriteLine("AccountID: " + AccountID);
            Console.WriteLine("FirstName: " + FirstName);
            Console.WriteLine("LastName: " + LastName);
            Console.WriteLine("Balance: " + Balance);
            Console.WriteLine("________________________");

        }
    }
    class AccountList
    {
        private ArrayList List = new ArrayList();   


        public void NewAccount()
        {
           // int n;
           // Console.WriteLine("Amount of accounts: ");
          //  n = int.Parse(Console.ReadLine());
          //  while (n > 0)
          //  {
                Account account = new Account();
                account.FillInfo();
                List.Add(account);
               // n--;
            //}

           
        }
        public void SaveFile()
        {
            Console.WriteLine("Input file name to save: ");
            string filename = Console.ReadLine();
            try
            {
                FileStream output = new FileStream(filename, FileMode.CreateNew, FileAccess.Write);
                StreamWriter writer = new StreamWriter(output);
                foreach (Account acc in List)
                {
                    writer.WriteLine("{0}, {1}, {2}, {3}", acc.AccountID, acc.FirstName, acc.LastName, acc.Balance);


                }
                writer.Close();
                output.Close();
                Console.WriteLine("Save file successful: ");

            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void LoadFile()
        {
            Console.WriteLine("Input file name to load: ");
            string fileName = Console.ReadLine();
            List.Clear();
            try
            {
                FileStream input = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(input);
                string str;
                while ((str = reader.ReadLine()) != null)
                {
                    string[] lists = str.Split(',');
                    Account acc = new Account(int.Parse(lists[0]), lists[1], lists[2], int.Parse(lists[3]));
                    List.Add(acc);
                }
                input.Close();
                reader.Close();
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void Report()
        {
            foreach (Account l in List)
            {
                l.Query();
            }
        } 
        public void RemoveAcc()
        {
            Console.WriteLine("Input account ID to the account be remove out the list acccounts : ");
            int id = int.Parse(Console.ReadLine());
           
            if (id != 0)
            {
                int index = List.BinarySearch(id, new AccIDcompare());
                List.RemoveAt(index);
            }
        }
        public void SortByAccountID()
        {
           
            Console.WriteLine("Sort list accounts by accounts ID : ");
            List.Sort(new AccIDcompare());
           
        }
        public void SortByFirstName()
        {
            Console.WriteLine("Sort list accounts by First name : ");
            List.Sort(new FirstNameCompare());
        }
        public void SortByBalance()
        {
            Console.WriteLine("Sort list accounts by balance : ");
            List.Sort(new BalanceCompare());
        }
    }
    public class AccIDcompare : IComparer
    {
        public int Compare(object x, object y)
        {
            Account a1 = x as Account;
            Account a2 = y as Account;
            if (a1 == null || a2 == null)
            {
                throw new InvalidOperationException();
            }
            else
            {
                if (a1.AccountID > a2.AccountID)
                {
                    return 1;
                }
                else if (a1.AccountID == a2.AccountID)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
        }
    }
    public class FirstNameCompare : IComparer
    {
        public int Compare(object x, object y)
        {
            Account xx = x as Account;
            Account yy = y as Account;
            return xx.FirstName.CompareTo(yy.FirstName);
        }
    }
    public class BalanceCompare : IComparer
    {
        public int Compare(object x, object y)
        {
            Account a1 = x as Account;
            Account a2 = y as Account;
            if (a1 == null || a2 == null)
            {
                throw new InvalidOperationException();
            }
            else
            {
                if (a1.Balance > a2.Balance)
                {
                    return 1;
                }
                else if (a1.Balance == a2.Balance)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
        }
    }
}
