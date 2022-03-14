using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccess.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string fullname { get; set; }
        public string phone { get; set; }

        //public List<Email> Emails { get; set; } = new List<Email>();
    }
}
