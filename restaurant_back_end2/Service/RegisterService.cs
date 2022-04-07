using EFDataAccess.Data;
using EFDataAccess.DataAccess;
using EFDataAccess.Models;
using Microsoft.Extensions.Configuration;
using restaurant_back_end2.Classes;
using restaurant_back_end2.Helpers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace restaurant_back_end2.Service
{
   
    public interface IRegisterService
    {
        public Task<IsSucessesRegister> AddUser(RegisterDto dto);
    }
    public class IsSucessesRegister
    {
        public Users users { get; set; }
        public int isSucesses { get; set; }
        public string message { get; set; }
    }
    public class RegisterService : IRegisterService
    {
        private readonly UsersContext _usersContext;
        private readonly IUserRepository _repository;
        private readonly JwtService _jwtService;
        public IConfiguration Configuration { get; }

        public RegisterService(UsersContext usersContext, IConfiguration configuration, IUserRepository repository, JwtService jwtService)
        {
            _usersContext = usersContext;
            Configuration = configuration;
            _repository = repository;
            _jwtService = jwtService;
        }
        public async Task<IsSucessesRegister> AddUser(RegisterDto dto)
        {
            IsSucessesRegister isSucessesRegister = new IsSucessesRegister();
            try
            {
                if (_usersContext.user.Any(p => p.phone == dto.phone)) 
                {
                    isSucessesRegister.isSucesses = 0;
                    isSucessesRegister.message = "User is Exsis";

                    return isSucessesRegister;
                }
                else
                {
                    var user = new Users
                    (
                       dto.fullname,
                       dto.phone,
                       BCrypt.Net.BCrypt.HashPassword(dto.password)
                    );
                    //_usersContext.user.Add(user);
                    //_usersContext.SaveChanges();
                    _repository.Create(user);
                    isSucessesRegister.isSucesses = 1;
                    isSucessesRegister.users = user;
                    isSucessesRegister.message = "User Create sucessfully";

                    return isSucessesRegister;
                }
            }
            catch(Exception ex)
            {
                isSucessesRegister.isSucesses = -1;
                isSucessesRegister.message = "Error!, " + ex.Message;
                return isSucessesRegister;
            }
        }
    }
}
