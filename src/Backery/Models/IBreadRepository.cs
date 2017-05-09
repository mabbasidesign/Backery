using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backery.Models
{
    public interface IBreadRepository
    {
        IEnumerable<Bread> Breads { get; }
        IEnumerable<Bread> BreadOfTheWeek { get;}
        Bread GetBreadById(int id);
    }
}
