using EFDataAccess.DataAccess;
using EFDataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace restaurant_back_end2.Controllers
{
    
    public class test : Controller
    {
        private UsersContext _usersContext;
        // GET: test
        public test(UsersContext usersContext)
        {
            _usersContext = usersContext;
        }
        public ActionResult Index()
        {
            
            return View();
        }
        [HttpGet]
        public ActionResult AddPepole()
        {
            Users user = new Users();
            //user.Id = 123;
            user.name = "yaron";
            user.age = "123";
            user.lastName = "cohen";
            _usersContext.user.AddRange(user);
            _usersContext.SaveChanges();

            return View();
        }

        // GET: test/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: test/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: test/Create
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

        // GET: test/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: test/Edit/5
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

        // GET: test/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: test/Delete/5
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
