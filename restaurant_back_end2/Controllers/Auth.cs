using EFDataAccess.Data;
using EFDataAccess.DataAccess;
using EFDataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using restaurant_back_end2.Classes;
using restaurant_back_end2.Helpers;
using System;

namespace restaurant_back_end2.Controllers
{
    [Route("api")]
    public class Auth : Controller
    {
        private readonly UsersContext _usersContext;
        private readonly IUserRepository _repository;
        private readonly JwtService _jwtService;
        public IConfiguration Configuration { get; }
        // GET: Auth

        public Auth(UsersContext usersContext, IConfiguration configuration, IUserRepository repository, JwtService jwtService)
        {
            _usersContext = usersContext;
            Configuration = configuration;
            _repository = repository;
            _jwtService = jwtService;
        }
        public ActionResult Index()
        {
            return View();
        }



        [HttpPost("register")]
        public ActionResult Register([FromBody] RegisterDto dto)
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

            return Created("Succsses!", user);
        }
        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginDto dto)
        {

            var user = _repository.GetByPhone(dto.phone);

            if (user == null) return BadRequest(new { message = "Invalid Credentials" });

            if (!BCrypt.Net.BCrypt.Verify(dto.password, user.password)) 
            {
                return BadRequest(new { message = "Invalid Credentials" });

            }

            var jwt = _jwtService.Generate(user.Id);


            Response.Cookies.Append("jwt", jwt, new CookieOptions
            {
                HttpOnly = true
            });

            return Ok(new
            {
                message = "success"
            });
        }
        [HttpGet("getuserdata")]
        public ActionResult GetUserData()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];
                var token = _jwtService.Verify(jwt);

                int userId = int.Parse(token.Issuer);

                var user = _repository.GetById(userId);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }

        }

        // GET: Auth/Create
        [HttpPost("logout")]
        public ActionResult Logout()
        {
            Response.Cookies.Delete("jwt");
            return Ok(new
            {
                message = "sucsses"
            });
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
