using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services;
using webapp.Models;

namespace webapp.Controllers
{

  
    public class HomeController : Controller
    {
        private readonly MysqlDbContext _context;

        public HomeController(MysqlDbContext context)
        {
            _context = context;
        } 

        public IActionResult Index()
        {
            ViewData["username"]="welcome jimtang";
             var users=  _context.Users.ToList().Select(fg=>new UserViewModel() { UserName = fg.UserName, Phone = fg.Phone }).ToList();
            return View(users);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Title"] = "New";
            return View();
        }

        [HttpPost]
        public  IActionResult Create(UserViewModel user)
        {
            var userd = _context.Users.Add(new Users()
            {
                Phone = user.Phone,
                UserName = user.UserName

            });
            _context.SaveChanges();
            return Redirect("index");
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
