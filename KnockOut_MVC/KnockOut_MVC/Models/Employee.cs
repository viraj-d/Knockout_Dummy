using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnockOut_MVC.Models
{
    public class Employee
    {
        public int EmpId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; set; }

        public string EMail { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; }

        public IList<string> EducationList { get; set; }

        public List<KeyValuePair<int, string>> DivisionList { get; set; }        

        public List<string> DepartmentList { get; set; }

        public string Division { get; set; }

        public bool Graduation { get; set; }

        public bool PostGraduation { get; set; }

        public long MobileNumber { get; set; }

        //public string Expertise { get; set; }

        public int ExpertiseId { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Employee()
        {
            DivisionList = new List<KeyValuePair<int, string>>();
            DepartmentList = new List<string>();
        }        
    }

    //Enum for Gender
    public enum Gender
    {
        Male = 0,
        FeMale = 1
    } 
}