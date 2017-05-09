using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Backery.Models;
using Backery.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Backery.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        private readonly IBreadRepository _breadRepository;
        public HomeController(IBreadRepository breadRepository)
        {
            _breadRepository = breadRepository;
        }

        public ViewResult Index()
        {
            var Item = new HomeViewModel
            {
                BreadOfTheWeek = _breadRepository.BreadOfTheWeek,
            };

            return View(Item);
        }
    }
}
