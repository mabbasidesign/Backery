using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backery.Models
{
    public class BreadRepository : IBreadRepository
    {
        private readonly AppDbContext _appDbcontext;

        public BreadRepository(AppDbContext appDbContext)
        {
            _appDbcontext = appDbContext;
        }
        
        public IEnumerable<Bread> BreadOfTheWeek
        {
            get
            {
                return _appDbcontext.Breads.Include(c => c.Category).Where(c => c.IsBreadOfTheWeek);
            }
        }

        public IEnumerable<Bread> Breads
        {
            get
            {
                return _appDbcontext.Breads.Include(c => c.Category);
            }
        }

        public Bread GetBreadById(int id)
        {
            return _appDbcontext.Breads.FirstOrDefault(c => c.BreadId == id);
        }
    }
}
