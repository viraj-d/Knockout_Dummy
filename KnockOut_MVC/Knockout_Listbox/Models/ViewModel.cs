using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Knockout.Models
{
    public class ViewModel
    {
        public List<Product> AvailableProducts { get; set; }
        public List<Product> RequestedProducts { get; set; }

        public decimal RequestedTotal
        {
            get
            {
                if (RequestedProducts == null)
                    return 0m;
                else
                    return RequestedProducts.Sum(p => p.Price);
            }
        }

        public int[] AvailableSelected { get; set; }
        public int[] RequestedSelected { get; set; }
        public string SavedRequested { get; set; }   
    }
}
