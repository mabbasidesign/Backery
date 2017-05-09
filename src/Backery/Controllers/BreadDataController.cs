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
    [Route("api/[controller]")]
    public class BreadDataController : Controller
    {
        private readonly IBreadRepository _breadRepository;
        public BreadDataController(IBreadRepository breadRepository)
        {
            _breadRepository = breadRepository;
        }

        [HttpGet]
        public IEnumerable<BreadViewModel> LoadMoreBreads()
        {
            IEnumerable<Bread> dbBread = null;

            dbBread = _breadRepository.Breads.OrderBy(b => b.BreadId).Take(10);

            List<BreadViewModel> bread = new List<BreadViewModel>();

            foreach (var dbbread in dbBread)
            {
                bread.Add(MapDbBreadToPieViewModel(dbbread));
            }
            return bread;
        }

        private BreadViewModel MapDbBreadToPieViewModel(Bread dbBread)
        {
            return new BreadViewModel()
            {
                BreadId = dbBread.BreadId,
                Name = dbBread.Name,
                Price = dbBread.Price,
                ShortDescription = dbBread.ShortDescription,
                ImageThumbnailUrl = dbBread.ImageThumbnailUrl
            };
        }

    }
}
