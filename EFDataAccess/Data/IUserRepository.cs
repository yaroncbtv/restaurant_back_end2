using EFDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccess.Data
{
    public interface IUserRepository
    {
        Users Create(Users user);

        Users GetByPhone (string phone);
        Users GetById(int id);


    }
}
