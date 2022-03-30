using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccess.Models
{
    public class Users
    {
        public Users(string fullname, string phone, string password)
        {
            this.fullname = fullname;
            this.phone = phone;
            this.password = password;
        }

        public Users() { }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string fullname { get; set; }
        public string phone { get; set; }
        public string password { get; set; }


        //public List<Email> Emails { get; set; } = new List<Email>();
    }
}
