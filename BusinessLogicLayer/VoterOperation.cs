using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using votingSystemApp.BusinessLogicLayer;

namespace BusinessLayer
{
    public class VoterOperation : IMethod
    {

        Voter oVoter = new Voter();
        SqlConnection con = new SqlConnection(@"server=BHAVNAWKS651\SQLEXPRESS;database=votingSystem;Integrated Security=SSPI;");

        public void display()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblVoter", con);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                Console.WriteLine("Voter id : " + sdr.GetValue(0) + "\n" + "Voter Name : " + sdr.GetValue(1) + "\n" + "Date of Birth : " + sdr.GetValue(2).ToString().Substring(0, 10) + "\n" + "AdharCard : " + sdr.GetValue(3) + "\n" + "Pancard : " + sdr.GetValue(4));
                Console.WriteLine("\n");
            }
            con.Close();
        }

        public void Add()
        {

            Console.WriteLine("Enter Voter Name");
            oVoter.voterName = Console.ReadLine();
            Console.WriteLine("Enter Date of Birth {Format : YYYY-MM-DD}");
            oVoter.DOB = Console.ReadLine();
            string formatedDate = (oVoter.DOB.ToString());
            int finalDOB = formatedDate.Length;
            //Console.WriteLine(finalDOB);
            Console.WriteLine("Enter Adharcard Number");
            oVoter.AdharCard = Console.ReadLine();
            Console.WriteLine("Enter PanCard Number");
            oVoter.Pancard = Console.ReadLine();
            Console.WriteLine("Enter Password");
            oVoter.Password = Console.ReadLine();

            con.Open();
            //Console.WriteLine($"insert into tblVoter(voterName,) values('{oVoter.voterName}','{oVoter.DOB}','{oVoter.AdharCard}','{oVoter.Pancard}','{oVoter.Password}')");
            SqlCommand cmd = new SqlCommand($"insert into tblVoter values('{oVoter.voterName}','{oVoter.DOB}','{oVoter.AdharCard}','{oVoter.Pancard}','{oVoter.Password}')", con);

            cmd.ExecuteNonQuery();
            con.Close();
            Console.WriteLine("Inserted successfully");

        }

        public void delete()
        {

            Console.WriteLine("Enter the  Booth Id that you want to delete ");
            oVoter.voterId = int.Parse(Console.ReadLine());
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from sales where id=" + oVoter.voterId + "", con);
            cmd.ExecuteNonQuery();
            Console.WriteLine("product with id:" + oVoter.voterId + " deleted successfully");
            con.Close();

        }

        public int loggedIn()
        {
            PartyOperation opartyOperation = new PartyOperation();
            Console.WriteLine("Here is party details");
            opartyOperation.display();
            Console.WriteLine("Enter the Party Id for which you want to cast the vote");
            int voted = int.Parse(Console.ReadLine());

            Console.WriteLine("You have voted successfully\nTHANK YOU");
            return voted;

        }


        public void login()
        {
            int voterID=0;
            int voted = 0;
            Console.WriteLine("Enter your Id");
            int loginId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your Password");
            string loginPassword = Console.ReadLine();
            con.Open();
            SqlCommand cmd = new SqlCommand("LocationAssignDetails", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                if (int.Parse(sdr["voterID"].ToString()) == loginId && sdr["password"].ToString() == loginPassword)
                {
                    voterID = Convert.ToInt32(sdr.GetValue(5));
                    Console.Clear();
                    Console.WriteLine($"Welcome {sdr.GetValue(0)}\nStatus : Online\nYou can caste your vote here\nPress 'yes' to continue as online user\nPress 'Offline' to check offline details");
                    string voterchoice = Console.ReadLine();
                    if (voterchoice.ToUpper() == "YES")
                    {
                        voted=loggedIn();

                        break;
                    }
                    else if (voterchoice.ToUpper() == "OFFLINE")
                    {

                        Console.WriteLine($"Voter Name : {sdr.GetValue(0)}\nLocation : {sdr.GetValue(1)}\nStart Timing : {sdr.GetValue(2)}\nEnd timing : {sdr.GetValue(3)}");
                        Console.WriteLine("Is the voter ready to vote offline {yes/no}");
                        string a = Console.ReadLine();
                        if (a.ToUpper() == "YES")
                        {
                            voted=loggedIn();
                            string myfile = @"D:\\output.txt";

                            if (File.Exists(myfile))
                            {
                                File.Delete(myfile);
                            }
                            if (!File.Exists(myfile))
                                using (StreamWriter sw = File.CreateText(myfile))
                                {
                                    sw.WriteLine($"Record : Voter Name - {sdr.GetValue(0)}, Location - {sdr.GetValue(1)}, Start Timing - {sdr.GetValue(2)}, End timing - {sdr.GetValue(3)}"); Console.WriteLine("File Creation done");
                                }

                            break;
                        }
                        else
                        {
                            Console.WriteLine("Caste your vote at location");
                            break;
                        }

                    }


                }
                else
                {
                    continue;
                }
                Console.WriteLine("Wrong Id or Password");
                break;
            }

            con.Close();
            

            con.Open();
            SqlCommand cmd1 = new SqlCommand($"insert into voterCount values('{voted}','{voterID}')", con);
            cmd1.ExecuteNonQuery();
            con.Close();
        }
    }
}
