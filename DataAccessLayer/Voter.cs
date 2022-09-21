using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Voter
    {
        public int voterId { get; set; }
        public string voterName { get; set; }

        public string DOB { get; set; }
        public string AdharCard { get; set; }
        public string Pancard { get; set; }
        public string Password { get; set; }
    }
}
