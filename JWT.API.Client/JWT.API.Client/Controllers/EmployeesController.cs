using JWT.API.Client.CustomFilters;
using JWT.API.Client.JWTAPICall;
using JWT.API.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utility;

namespace JWT.API.Client.Controllers
{
    [CheckSessionFilterAttribute]
    public class EmployeesController : Controller
    {
        public ActionResult Index()
        {
            string error = string.Empty;
            var Userdata = EmployeeManager.GetAllEmp(Helper.GetTokenWithUser(), ref error);
            if (string.IsNullOrEmpty(error))
            {
                return View(Userdata);
            }
            else
            {
                TempData[Sessions.Error] = error;
                return View(nameof(Index));
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            try
            {
                string error = string.Empty;
                var Userdata = EmployeeManager.InsEmp(ref error,employee, Helper.GetTokenWithUser());
                if (string.IsNullOrEmpty(error))
                {
                    return View();
                }
                else
                {
                    TempData[Sessions.Error] = error;
                    return View(nameof(Index));
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            Employee employee = new Employee();
            employee.EmpId = id;
            string error = string.Empty;
            var Userdata = EmployeeManager.GetEmpBy(ref error ,employee, Helper.GetTokenWithUser());
            if (string.IsNullOrEmpty(error))
            {
                return View(Userdata);
            }
            else
            {
                TempData[Sessions.Error] = error;
                return View(nameof(Index));
            }
        }

        [HttpPost]
        public ActionResult Edit(int id, Employee employee)
        {
            try
            {
                string error = string.Empty;
                employee.EmpId = id;
                var Userdata = EmployeeManager.UpdEmp(ref error, employee, Helper.GetTokenWithUser());
                if (string.IsNullOrEmpty(error))
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData[Sessions.Error] = error;
                    return View(nameof(Index));
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                string error = string.Empty;
                var Userdata = EmployeeManager.DelEmp(ref error, id, Helper.GetTokenWithUser());
                if (string.IsNullOrEmpty(error))
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData[Sessions.Error] = error;
                    return View(nameof(Index));
                }
            }
            catch
            {
                return View();
            }
        }


    }
}
