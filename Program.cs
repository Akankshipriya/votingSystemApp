using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace votingSystemApp
{

    public delegate void AddDelegate();
    class Program
    {
        static void Main(string[] args)
        {

            string choice;
            do
            {
                Console.Clear();
                Console.WriteLine("Enter Your Choices:\n1 to login as Admin\n2 to login as Voter");
                int inputChoice = int.Parse(Console.ReadLine());
                if (inputChoice == 1)
                {
                    AdminOperation oAdminOperation = new AdminOperation();
                    oAdminOperation.AdminData();
                    oAdminOperation.AdminDisplay();

                    if (oAdminOperation.match())
                    {
                        oAdminOperation.menu();
                        int menuInput = int.Parse(Console.ReadLine());
                        oAdminOperation.AdminInput(menuInput);

                    }
                    else
                    {
                        Console.WriteLine("Sorry Can't log you in! Either Id or Password is wrong");
                    }
                }
                else if (inputChoice == 2)
                {
                    VoterOperation ovoterOperation = new VoterOperation();
                    ovoterOperation.login();
                }
                else
                {
                    Console.WriteLine("Invalid Entry");
                }

                Console.WriteLine("Do you want to continue(yes/no):");
                choice = Console.ReadLine().ToUpper();

            } while (choice == "YES");
        }
    }
}
