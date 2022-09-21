using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using votingSystemApp.BusinessLogicLayer;

namespace BusinessLayer
{
    class PartyOperation: IMethod
    {
        Party oParty = new Party();
        SqlConnection con = new SqlConnection(@"server=BHAVNAWKS651\SQLEXPRESS;database=votingSystem;Integrated Security=true;");
        
        public void display()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblparty", con);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                Console.WriteLine("Party id : " + sdr.GetValue(0) + "\n" + "Party Name : " + sdr.GetValue(1) + "\n" + "Party Symbol : " + sdr.GetValue(2) + "\n");
                Console.WriteLine("\n");
            }
            con.Close();
        }

        public void Add()
        {

            Console.WriteLine("Enter Party Name");
            oParty.PartyName = Console.ReadLine();
            Console.WriteLine("Enter Party Symbol");
            oParty.PartySymbol = Console.ReadLine();
            

            con.Open();
            //Console.WriteLine($"insert into admin values('{name}','{password}')");

            SqlCommand cmd = new SqlCommand($"insert into tblParty values('{oParty.PartyName}','{oParty.PartySymbol}')", con);

            cmd.ExecuteNonQuery();
            con.Close();
            Console.WriteLine("Inserted successfully");

        }

        public void delete()
        {

            Console.WriteLine("Enter the  Party Id that you want to delete ");
            oParty.PartyID = int.Parse(Console.ReadLine());
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from sales where id=" + oParty.PartyID + "", con);
            cmd.ExecuteNonQuery();
            Console.WriteLine("product with id:" + oParty.PartyID + " deleted successfully");
            con.Close();

        }
    }
}
