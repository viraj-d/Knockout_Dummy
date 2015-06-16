using KnockOut_MVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace KnockOut_MVC.Controllers
{
    public class EmployeeController : Controller
    {
        //
        // GET: /Employee/
        public ActionResult EmployeeIndex()
        {
            //Employee employee = new Employee();

            //employee.FirstName = "Viraj";
            //employee.LastName = "Deshpande";
            //employee.EMail = "viraj.d@gmail.com";
            //employee.DateOfBirth = DateTime.Parse("05/07/1989");            
            //employee.MobileNumber = 8511578905;
            //employee.ExpertiseId = 1;
            //employee.Gender = Gender.Male;
            
            return View();
        }


        /// <summary>
        /// Get Employee Information
        /// </summary>
        public JsonResult GetEmployeeInformation()
        {
            Employee employee = new Employee();
            List<Employee> employeeList = new List<Employee>();

            //employeeList.Add(new Employee {FirstName = "Viraj", LastName = "Deshpande", EMail = "viraj.d@gmail.com", DateOfBirth = DateTime.Parse("05/07/1989"),
              //                             MobileNumber = 8511578905, ExpertiseId = 1, Gender = "Male", Graduation = true, PostGraduation = true});
            employee.FirstName = "Viraj";
            employee.LastName = "Deshpande";
            employee.EMail = "viraj.d@gmail.com";
            employee.DateOfBirth = DateTime.Parse("05/07/1989");
            employee.MobileNumber = 8511578905;
            employee.ExpertiseId = 2;
            employee.Gender = "0";
            employee.Graduation = true;

            employee.DivisionList.Add(new KeyValuePair<int, string>(1, "Java"));
            employee.DivisionList.Add(new KeyValuePair<int, string>(2, "Asp.Net"));


            //var result = new { total = 1,page = 1, records = employeeList.Count, rows = employeeList };
            return Json(employee, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Save employee
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        //[HttpPost]
        //public ActionResult SaveEmployee(Employee emp)
        //{
        //    //Employee emp = new Employee();
        //    //emp.FirstName = firstName;
        //    string logFilePath = string.Empty;
        //    StreamWriter writer = null;
        //    try
        //    {
        //        if (string.IsNullOrEmpty(logFilePath))
        //        {
        //            logFilePath = @"C:\PBS\KnockOutJs";
        //        }

        //        if (!Directory.Exists(logFilePath))
        //        {
        //            Directory.CreateDirectory(logFilePath);
        //        }

        //        //Set the file path having dd-MM-yy HH.mm.ss format in file name                
        //        logFilePath += "\\KnockOut_" + GetCurrentDateTime() + ".txt";
        //        string Gender = "Male";
        //        string graduation = "No";
        //        string postGraduation = "No";
        //        string Expertise = "Asp.Net";

        //        if (emp.Gender == "1")
        //        {
        //            Gender = "Female";
        //        }                
                
        //        if (emp.Graduation == true)
        //        {
        //            graduation = "Graduate";
        //        }

        //        if (emp.PostGraduation == true)
        //        {
        //            postGraduation = "Post Graduate";
        //        }

        //        if (emp.ExpertiseId == 1)
        //        {
        //            Expertise = "Java";
        //        }


        //        //Write data to file
        //        //writer = new StreamWriter(logFilePath, false);
        //        writer = new StreamWriter(logFilePath);
        //        writer.WriteLine(emp.FirstName);
        //        writer.WriteLine(emp.LastName);
        //        writer.WriteLine(emp.FullName);
        //        writer.WriteLine(emp.DateOfBirth);
        //        writer.WriteLine(Gender);
        //        writer.WriteLine(emp.MobileNumber);
        //        writer.WriteLine(graduation);
        //        writer.WriteLine(postGraduation);
        //        writer.WriteLine(Expertise);
        //        writer.WriteLine("-----------------------------------------------------------------------------------------");
        //        //for (int i = 0; i < error.Count; i++)
        //        //{
        //        //    //string message = GetCurrentDateTime() + " : " + error[i]; // +Environment.NewLine;   
        //        //    writer.WriteLine(error[i]);
        //        //    writer.WriteLine("-----------------------------------------------------------------------------------------");
        //        //}
        //        //return logFilePath;
        //    }
        //    finally
        //    {
        //        //Cleanup buffers and
        //        //close the writer
        //        if (writer != null)
        //        {
        //            writer.Flush();
        //            writer.Close();
        //        }
        //    }
        //    return Json(emp, JsonRequestBehavior.AllowGet);
        //    //return View("EmployeeIndex", emp);
        //}

        public ActionResult JqGridEmployeeIndex()
        {
            return View();
        }

        public ActionResult TestIndex()
        {
            return View();
        }

        /// <summary>
        /// New Employee
        /// </summary>
        /// <returns></returns>
        public ActionResult NewEmployee()
        {
            Employee emp = new Employee();
            return View("EmployeeIndex", emp);
        }

        /// <summary>
        /// Returns the current date and time
        /// with proper format
        /// </summary>
        /// <returns>Current date and time</returns>
        private static string GetCurrentDateTime()
        {
            return String.Format("{0:dd-MM-yyyy_HH-mm-ss}", DateTime.Now);
        }

        public JsonResult GetCountryInformation()
        {
            CheckBoxBinding checkboxBinding = new CheckBoxBinding();
            checkboxBinding.ID = 1;
            checkboxBinding.CountryList.Add(new KeyValuePair<string, bool>("India", true));
            checkboxBinding.CountryList.Add(new KeyValuePair<string, bool>("UK", false));
            checkboxBinding.CountryList.Add(new KeyValuePair<string, bool>("US", false));
            checkboxBinding.CountryList.Add(new KeyValuePair<string, bool>("Germany", true));
            checkboxBinding.CountryList.Add(new KeyValuePair<string, bool>("Japan", false));

            return Json(checkboxBinding, JsonRequestBehavior.AllowGet);
        }
	}
}