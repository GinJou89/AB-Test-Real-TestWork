using AB_Test_Real_TestWork.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace AB_Test_Real_TestWork.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserContext _db;
        private readonly ILogger<HomeController> _logger;

        public HomeController(UserContext context, ILogger<HomeController> logger)
        {
            _db = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }   
        [HttpPost]
        public IActionResult AddUsers(User[] users)
        {
            foreach (var user in users)
            {
                if (ModelState.IsValid)
                {
                    if (_db.Users.Any(x => x.Id == user.Id))
                    {
                        continue;
                    }
                    else
                    {
                        _db.Users.Add(user);
                    }
                }
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /// <summary>
        ///  Расчет rollingRetention
        /// </summary>
        [HttpPost]
        public JsonResult GetUserRetention(int days) 
        {
            DateTime date = DateTime.Now.Subtract(new TimeSpan(days, 0, 0, 0));
            var registeredUser = _db.Users.Count(x => x.DateRegistration <= date);
            var lastActivityUser = _db.Users.Count(x => x.DateLastActivity >= date);
            var rollingRetention = (double)lastActivityUser / registeredUser * 100;
            

            return Json( new {rollingRetention} );
        }
        /// <summary>
        ///  Расчет времени жизни пользователей
        /// </summary>
        public JsonResult CalculateLifeSpanAllUsers()
        {
            List<User> users = _db.Users.ToList();
            var UsersLifeSpan = new List<int>();
            foreach (User user in users)
            {
                TimeSpan lifeSpan = user.DateLastActivity.Date.Subtract(user.DateRegistration.Date);
                UsersLifeSpan.Add(lifeSpan.Days);
            }

            var lifespan = UsersLifeSpan.Distinct()
                .OrderBy(i => i)
                .Select(i => new UserLifeSpan()
                {
                    LifeSpanDays = i,
                    Count = UsersLifeSpan.Count(lifeSpan => lifeSpan == i)
                });

            return Json(new { lifespan });
        }

    }
}
    