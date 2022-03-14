﻿using EFDataAccess.DataAccess;
using EFDataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;

namespace restaurant_back_end2.Controllers
{

    public class UsersAction : Controller
    {
        // GET: UsersAction
        private readonly UsersContext _usersContext;
        // GET: test
        public UsersAction(UsersContext usersContext)
        {
            _usersContext = usersContext;
        }
        [HttpPost]

        public JsonResult InsertNewUser([FromBody] NewUser data)
        {
            
            try
            {
                if (_usersContext.user.Any(p => p.phone == data.phone)) return Json("User is Exsis");

                Users user = new Users();

                user.fullname = data.fullname;
                user.phone = data.phone;
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
}
