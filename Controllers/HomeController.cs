using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            Contact contacts = new Contact()
            {
            Id = 1,
            FirstName = "ike",
            LastName = "A"
            };

            Customer customer = new Customer()
            {
                Id = 1,
                CustomerName = "A"
            };

            HomeIndexViewModel homeIndexViewModel = new HomeIndexViewModel()
            {

                Cutomer = customer,
                Contacts = contacts

            };


            return View(homeIndexViewModel);
        }
    }
}
