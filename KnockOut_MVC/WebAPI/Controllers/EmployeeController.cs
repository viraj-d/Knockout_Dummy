using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Mvc;
using ValueObjects;



namespace WebAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        /// <summary>
        /// Get Employee List
        /// </summary>
        /// <returns></returns>
        [System.Web.Http.Route("api/employee")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetEmployeeInformation(string sidx, string sord, int page, int rows, bool _search, string searchField, string searchOper, string searchString)
        {
            //var response = "Welcome";

            //return response;
            List<EmployeeVO> employeeVOList = new List<EmployeeVO>();

            employeeVOList.Add(new EmployeeVO
            {
                FirstName = "Viraj",
                LastName = "Deshpande",
                EMail = "viraj.d@gmail.com",
                DateOfBirth = DateTime.Parse("05/07/1989"),
                MobileNumber = 8511578905,
                ExpertiseId = 1,
                Gender = "Male",
                Graduation = true,
                PostGraduation = true
            });
            //EmployeeVO employeeVO = new EmployeeVO();

            //employeeVO.FirstName = "Viraj";
            //employeeVO.LastName = "Deshpande";
            //employeeVO.EMail = "viraj.d@gmail.com";
            //employeeVO.DateOfBirth = DateTime.Parse("05/07/1989");
            //employeeVO.MobileNumber = 8511578905;
            //employeeVO.ExpertiseId = 0;
            //employeeVO.Gender = "0";
            //employeeVO.Graduation = true;

            //employeeVO.DivisionList.Add(new KeyValuePair<int, string>(1, "Java"));
            //employeeVO.DivisionList.Add(new KeyValuePair<int, string>(2, "Asp.Net"));

            var result = new { total = 1, page = 1, records = employeeVOList.Count, rows = employeeVOList };
            var response = new HttpResponseMessage();
            response = Request.CreateResponse(HttpStatusCode.OK, result);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return response;
        }

        /// <summary>
        /// Save Employee
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        [System.Web.Http.Route("api/employeesave")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage SaveEmployee(EmployeeVO emp)
        {
            string logFilePath = string.Empty;
            StreamWriter writer = null;
            try
            {
                if (string.IsNullOrEmpty(logFilePath))
                {
                    logFilePath = @"C:\PBS\KnockOutJs";
                }

                if (!Directory.Exists(logFilePath))
                {
                    Directory.CreateDirectory(logFilePath);
                }

                //Set the file path having dd-MM-yy HH.mm.ss format in file name                
                logFilePath += "\\KnockOut_" + GetCurrentDateTime() + ".txt";
                string Gender = "Male";
                string graduation = "No";
                string postGraduation = "No";
                string Expertise = "Asp.Net";

                if (emp.Gender == "1")
                {
                    Gender = "Female";
                }

                if (emp.Graduation == true)
                {
                    graduation = "Graduate";
                }

                if (emp.PostGraduation == true)
                {
                    postGraduation = "Post Graduate";
                }

                if (emp.ExpertiseId == 1)
                {
                    Expertise = "Java";
                }

                //Write data to file
                //writer = new StreamWriter(logFilePath, false);
                writer = new StreamWriter(logFilePath);
                writer.WriteLine(emp.FirstName);
                writer.WriteLine(emp.LastName);
                writer.WriteLine(emp.FullName);
                writer.WriteLine(emp.DateOfBirth);
                writer.WriteLine(Gender);
                writer.WriteLine(emp.MobileNumber);
                writer.WriteLine(graduation);
                writer.WriteLine(postGraduation);
                writer.WriteLine(Expertise);
                writer.WriteLine("-----------------------------------------------------------------------------------------");
                //for (int i = 0; i < error.Count; i++)
                //{
                //    //string message = GetCurrentDateTime() + " : " + error[i]; // +Environment.NewLine;   
                //    writer.WriteLine(error[i]);
                //    writer.WriteLine("-----------------------------------------------------------------------------------------");
                //}
                //return logFilePath;
            }
            finally
            {
                //Cleanup buffers and
                //close the writer
                if (writer != null)
                {
                    writer.Flush();
                    writer.Close();
                }
            }
            var response = new HttpResponseMessage();
            response = Request.CreateResponse(HttpStatusCode.OK, emp);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return response;            
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
    }
}
