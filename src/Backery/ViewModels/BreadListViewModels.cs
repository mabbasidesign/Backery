using Backery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backery.ViewModels
{
    public class BreadListViewModels
    {
        public IEnumerable<Bread> Breads { get; set; }
        public string CurrentCategory { get; set; }
    }
}
