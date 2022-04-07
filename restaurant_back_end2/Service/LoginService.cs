using EFDataAccess.Data;
using EFDataAccess.DataAccess;
using Microsoft.Extensions.Configuration;
using restaurant_back_end2.Classes;
using restaurant_back_end2.Helpers;
using System;
using System.Threading.Tasks;

namespace restaurant_back_end2.Service
{
    public interface ILoginService
    {
        public Task<UserLogin> LoginUser(LoginDto dto);
    }
    public class UserLogin
    {
        public int isSucesses { get; set; }
        public string message { get; set; }
        public string jwt { get; set; }
    }
    public class LoginService : ILoginService
    {

        private readonly UsersContext _usersContext;
        private readonly IUserRepository _repository;
        private readonly JwtService _jwtService;
        public IConfiguration Configuration { get; }

        public LoginService(UsersContext usersContext, IConfiguration configuration, IUserRepository repository, JwtService jwtService)
        {
            _usersContext = usersContext;
            Configuration = configuration;
            _repository = repository;
            _jwtService = jwtService;
        }
        public async Task<UserLogin> LoginUser(LoginDto dto)
        {
            UserLogin userLogin = new UserLogin();
            try
            {
                var user = _repository.GetByPhone(dto.phone);

                if (user == null) {
                    userLogin.isSucesses = 0;
                    userLogin.message = "User is not exist! Go to Sign Up page.";

                    return userLogin;
                } //return BadRequest(new { message = "Invalid Credentials" });

                if (!BCrypt.Net.BCrypt.Verify(dto.password, user.password))
                {
                    //return BadRequest(new { message = "Invalid Credentials" });
                    userLogin.isSucesses = 0;
                    userLogin.message = "Invalid Credentials";

                    return userLogin;
                }

                var jwt = _jwtService.Generate(user.Id);
                userLogin.message = "Login sucessfully";
                userLogin.isSucesses = 1;
                userLogin.jwt = jwt;

                return userLogin;
            }
            catch(Exception ex)
            {
                userLogin.message = "Server Error!, " + ex.Message;
                userLogin.isSucesses = -1;

                return userLogin;
            }
            

        }
    }
}
