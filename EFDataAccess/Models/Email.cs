using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccess.Models
{
    public class Email
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string email { get; set; }
    }
}
