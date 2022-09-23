
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

    public class PoolBoothOperation: IMethod
    {
        PoolBooth oPoolBooth = new PoolBooth();
        SqlConnection con = new SqlConnection(@"server=BHAVNAWKS651\SQLEXPRESS;database=votingSystem;Integrated Security=true;");

        public void display()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblBooth", con);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                Console.WriteLine("Booth id : " + sdr.GetValue(0) + "\n" + "Booth Location : " + sdr.GetValue(1) + "\n" + "Start Timing : " + sdr.GetValue(2) + "\n" + "End Timing : " + sdr.GetValue(3) + "\n");
                Console.WriteLine("\n");
            }
            con.Close();
        }

        public void Add()
        {

            Console.WriteLine("Enter Booth Location");
            oPoolBooth.Location = Console.ReadLine();
            Console.WriteLine("Enter Start time {Format : YYYY-MM-DD HH:MM:SS AM/PM}");
            oPoolBooth.StartTime = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Enter End time {Format : YYYY-MM-DD HH:MM:SS AM/PM}");
            oPoolBooth.EndTime = Convert.ToDateTime(Console.ReadLine());

            con.Open();
            Console.WriteLine($"insert into tblBooth values('{oPoolBooth.Location}','{oPoolBooth.StartTime}','{oPoolBooth.EndTime}')");
            SqlCommand cmd = new SqlCommand($"insert into tblBooth values('{oPoolBooth.Location}','{oPoolBooth.StartTime}','{oPoolBooth.EndTime}')", con);

            cmd.ExecuteNonQuery();
            con.Close();
            Console.WriteLine("Inserted successfully");

        }

        public void delete()
        {

            Console.WriteLine("Enter the  Booth Id that you want to delete ");
            oPoolBooth.BoothId = int.Parse(Console.ReadLine());
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from tblBooth where BoothID=" + oPoolBooth.BoothId + "", con);
            cmd.ExecuteNonQuery();
            Console.WriteLine("product with id:" + oPoolBooth.BoothId + " deleted successfully");
            con.Close();

        }

    }
}
