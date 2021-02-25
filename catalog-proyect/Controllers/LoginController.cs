using catalog_proyect.Data;
using catalog_proyect.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace catalog_proyect.Controllers
{
    public class LoginController : Controller
    {

        private readonly ApplicationDbContext _db;

        public LoginController(ApplicationDbContext db)
        {
            _db = db;

        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult login(User user)
        {

            return View();
            // notify the user of fai   lure
        }
    }
}
