using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;


namespace BusinessLayer
{
    public class VoterOperation
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
                Console.WriteLine("Voter id : " + sdr.GetValue(0) + "\n" + "Voter Name : " + sdr.GetValue(1) + "\n" + "Date of Birth : " + sdr.GetValue(2) + "\n" + "AdharCard : " + sdr.GetValue(3) + "\n" + "Pancard : " + sdr.GetValue(4));
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
            Console.WriteLine("Enter Adharcard Number");
            oVoter.AdharCard = Console.ReadLine();
            Console.WriteLine("Enter PanCard Number");
            oVoter.Pancard = Console.ReadLine();
            Console.WriteLine("Enter Password");
            oVoter.Password = Console.ReadLine();

            con.Open();
            Console.WriteLine($"insert into tblVoter values('{oVoter.voterName}','{oVoter.DOB}','{oVoter.AdharCard}','{oVoter.Pancard}','{oVoter.Password}')");
            SqlCommand cmd = new SqlCommand($"insert into tblBooth values('{oVoter.voterName}','{oVoter.DOB}','{oVoter.AdharCard}','{oVoter.Pancard}','{oVoter.Password}')", con);

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

        public void login()
        {
            Console.WriteLine("Enter your Id");
            int loginId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your Password");
            string loginPassword = Console.ReadLine();
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblVoter", con);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                if (int.Parse(sdr["voterID"].ToString()) ==loginId)
                {
                    if (sdr["password"].ToString()==loginPassword)
                    {
                        Console.WriteLine("Welcome voter");
                        break;
                    }
                }
                Console.WriteLine("Wrong Id or Password");
                break;
            }
            
            con.Close();
        }
    }
}
