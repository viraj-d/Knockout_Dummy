using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnockOut_MVC.Models
{
    public class CheckBoxBinding
    {
        public int ID { get; set; }

        public List<KeyValuePair<string,bool>> CountryList { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public CheckBoxBinding() 
        {
            CountryList = new List<KeyValuePair<string,bool>>();
        }
    }
}