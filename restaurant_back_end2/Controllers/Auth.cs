using EFDataAccess.Data;
using EFDataAccess.DataAccess;
using EFDataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using restaurant_back_end2.Classes;
using restaurant_back_end2.Helpers;
using restaurant_back_end2.Service;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace restaurant_back_end2.Controllers
{
    [Route("api")]
    public class Auth : Controller
    {
        private readonly UsersContext _usersContext;
        private readonly IUserRepository _repository;
        private readonly JwtService _jwtService;
        private readonly IRegisterService _registerService;
        private readonly ILoginService _loginService;
        public IConfiguration Configuration { get; }
        // GET: Auth

        public Auth(
            UsersContext usersContext, 
            IConfiguration configuration, 
            IUserRepository repository, 
            JwtService jwtService,
            IRegisterService registerService,
            ILoginService loginservice
            )
        {
            _usersContext = usersContext;
            Configuration = configuration;
            _repository = repository;
            _jwtService = jwtService;
            _registerService = registerService;
            _loginService = loginservice;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegisterDto dto)
        {
            IsSucessesRegister isSucessesRegister = await _registerService.AddUser(dto);
            return Json(Newtonsoft.Json.JsonConvert.SerializeObject(isSucessesRegister));
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginDto dto)
        {
            UserLogin userLogin = await _loginService.LoginUser(dto);

            if (dto.stayLogin)
            {
                Response.Cookies.Append("jwt", userLogin.jwt, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.None
                });
            }
            
            //return Ok(new
            //{
            //    message = "success"
            //});
            return Json(Newtonsoft.Json.JsonConvert.SerializeObject(userLogin));
        }
        [HttpGet("getuserdata")]
        public ActionResult GetUserData()
        {
            try
            
            {
                var jwt = Request.Cookies["jwt"];

                if(jwt == null)
                    return Unauthorized(-1);
                

                var token = _jwtService.Verify(jwt);

                int userId = int.Parse(token.Issuer);

                var user = _repository.GetById(userId);

                return Json(Newtonsoft.Json.JsonConvert.SerializeObject(user));
                //return Ok(user);
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }

        }

        // GET: Auth/Create
        [HttpPost("logout")]
        public async Task<ActionResult> Logout()
        {
            //Response.Cookies.Delete("jwt");
            //Response.Cookies.Append("jwt", "", new CookieOptions
            //{
            //    HttpOnly = true,
            //    Secure = true,
            //    SameSite = SameSiteMode.None
            //});

            CookieOptions option = new CookieOptions();

            option.Expires = DateTime.Now.AddDays(-100000);

            option.HttpOnly = true;

            option.Secure = true;

            option.IsEssential = true;

            option.SameSite = SameSiteMode.None;

            Response.Cookies.Append("jwt", string.Empty, option);

            //Then delete the cookie

            //Response.Cookies.Delete(cookie);
            return Json("OK");
        }

        // POST: Auth/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Auth/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Auth/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Auth/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Auth/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
