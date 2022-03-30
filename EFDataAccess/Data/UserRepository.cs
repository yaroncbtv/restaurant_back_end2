using EFDataAccess.DataAccess;
using EFDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccess.Data
{
    public class UserRepository : IUserRepository
    {

        private readonly UsersContext _context;

        public UserRepository(UsersContext context)
        {
            _context = context;
        }
        public Users Create(Users user)
        {
            if(user.Id != 0)
                user.Id = 0;
            _context.user.Add(user);
            _context.SaveChanges();

            return user;
        }

        public Users GetByPhone(string phone)
        {
            return _context.user.FirstOrDefault(user => user.phone == phone);
        }
        public Users GetById(int id)
        {
            return _context.user.FirstOrDefault(user => user.Id == id);
        }
    }
}
