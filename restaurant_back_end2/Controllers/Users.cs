using EFDataAccess.DataAccess;
using EFDataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;

namespace restaurant_back_end2.Controllers
{

    public class UsersAction : Controller
    {
        // GET: UsersAction
        private readonly UsersContext _usersContext;
        public IConfiguration Configuration { get; }
        // GET: test
        //public UsersAction(IConfiguration configuration)

        //{

        //    Configuration = configuration;

        //}
        public UsersAction(UsersContext usersContext, IConfiguration configuration)
        {
            _usersContext = usersContext;
            Configuration = configuration;
        }
        [HttpPost]

        public JsonResult InsertNewUser([FromBody] NewUser data)
        {
            
            try
            {
                var test2 = Configuration.GetSection("test").Value;
                //if (_usersContext.user.Any(p => p.phone == data.phone)) return Json("User is Exsis");
                var test = _usersContext.user.Where(p => p.phone == data.phone).ToList();
                //if (String.IsNullOrEmpty(test)) return Json("User is Exsis");
                Users user = new Users();

                user.fullname = data.fullname;
                user.phone = data.phone;
                user.password = data.password;
                _usersContext.user.AddRange(user);
                _usersContext.SaveChanges();
                return Json("Succsses Create New User!");
            }
            catch (Exception e)
            {
                
                return Json("Error! " + e.Message);
            }
            
        }
        public ActionResult Index()
        {
            var test = Configuration.GetSection("test2").GetValue<string>("test");
            return View();
        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
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

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Users/Edit/5
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

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Users/Delete/5
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

public class NewUser
{
    public string fullname { get; set; }
    public string phone { get; set; }
    public string password { get; set; }
}
