using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class AdminOperation
    {
        public List<Admin> adminlist { get; set; }
        public Admin admin { get; set; }

        public void AdminData()
        {
            adminlist = new List<Admin>();
            adminlist.Add(new Admin { id = 1, name = "admin1", password = "admin1" });
            adminlist.Add(new Admin { id = 2, name = "admin2", password = "admin12" });
            adminlist.Add(new Admin { id = 3, name = "admin3", password = "admin123" });
        }

        public void AdminDisplay()
        {
            Console.Clear();
            Console.WriteLine("Admin Details");
            Console.WriteLine("ID     Name");
            foreach (Admin admin in adminlist)
            {
                Console.WriteLine($"{admin.id}     {admin.name}");
            }
        }

        public bool match()
        {
            bool flag = false;
            Console.WriteLine("Choose your Id to login from above");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your password");
            string pass = Console.ReadLine();
            PrintDotAnimation();
            foreach (Admin admin1 in adminlist)
            {
                if ((admin1.id == id) && (admin1.password == pass))
                {
                    Console.Clear();
                    Console.WriteLine($"Welcome! {admin1.name}" + "\n");
                    flag = true;

                }
            }

            return flag;
        }

        public void menu()
        {
            Console.WriteLine("-------Please Choose -------");
            Console.WriteLine(":                           :");
            Console.WriteLine("1. View PoolBooth Detail    :");
            Console.WriteLine("2. Add New PoolBooth        :");
            Console.WriteLine("3. Delete PoolBooth         :");
            Console.WriteLine("4. View Voter Details    :");
            Console.WriteLine("5. Add Voter Details     :");
            Console.WriteLine("6. Display Party Detail     :");
            Console.WriteLine("7. Insert Party Details     :");
            Console.WriteLine("8. View vote count details  :");
        }
        public void PrintDotAnimation(int timer = 10)
        {
            Console.WriteLine("Please wait while we are logging you in");
            for (int i = 0; i < timer; i++)
            {
                Console.Write(".");
                Thread.Sleep(200);
            }
            Console.WriteLine();
        }

        public void AdminInput(int a)
        {
            VoterOperation oVoterOperation = new VoterOperation();
            switch (a)
            {
                case 1:
                    
                    break;
                case 2:
                    
                    break;
                case 3:
                    
                    break;
                case 4:
                    oVoterOperation.display();
                    break;
                case 5:
                    oVoterOperation.Add();
                    break;
                case 6:
                    
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }
        }

    }
}
