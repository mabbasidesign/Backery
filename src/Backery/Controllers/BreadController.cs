using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Backery.Models;
using Backery.ViewModels;

namespace Backery.Controllers
{
    public class BreadController : Controller
    {
        private readonly IBreadRepository _breadRepository;
        private readonly ICategoryRepository _categoryRepository;

        public BreadController(IBreadRepository breadRepository, ICategoryRepository categoryRepository)
        {
            _breadRepository = breadRepository;
            _categoryRepository = categoryRepository;
        }

        public ViewResult List(string category)
        {
            IEnumerable<Bread> bread;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(category))
            {
                bread = _breadRepository.Breads.OrderBy(b => b.BreadId);
                currentCategory = "All pies";
            }
            else
            {
                bread = _breadRepository.Breads.Where(b => b.Category.CategoryName == category)
                   .OrderBy(b => b.BreadId);
                currentCategory = _categoryRepository.Categories.FirstOrDefault(c => c.CategoryName == category).CategoryName;
            }

            return View(new BreadListViewModels
            {
                Breads = bread,
                CurrentCategory = currentCategory
            });
        }

        public IActionResult Details(int id)
        {
            var item = _breadRepository.GetBreadById(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

    }
}