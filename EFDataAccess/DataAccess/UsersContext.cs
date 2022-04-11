using EFDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccess.DataAccess
{
    public class UsersContext : DbContext
    {
        public UsersContext()
        {
        }

        public UsersContext(DbContextOptions<UsersContext> options) : base(options) { }
        public DbSet<Users> user { get; set; }
        public DbSet<Posts> post { get; set; }
        public DbSet<ContentPosts> contentPosts { get; set; }

        //public DbSet<Email> email { get; set; }
    }
}
