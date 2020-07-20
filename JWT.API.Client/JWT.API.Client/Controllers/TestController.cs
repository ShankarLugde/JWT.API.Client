using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JWT.API.Client.Controllers
{
    [RoutePrefix("Mama")]
    public class TestController : Controller
    {
        // GET: Test
        [Route("ok")]
        public ActionResult Index()
        
        {
            TestController testController = new TestController();
            var res = testController.GetAllEmp().Single(x => x.Name == "Nilesh");
            var res1 = testController.GetAllEmp().SingleOrDefault(x => x.Name == "jj");
            return View(res);
        }

        public IEnumerable<Employee> GetAllEmp()
        {
            IEnumerable<Employee> developers = new Employee[] {
                new Employee {
                    Id = 101, Name = "Ashutosh"
                },
                new Employee {
                    Id = 102, Name = "Nilesh"
                },
                new Employee {
                    Id = 103, Name = "Amar"
                },
                new Employee {
                    Id = 104, Name = "Ashutosh"
                },
                new Employee {
                    Id = 105, Name = "Ashutosh"
                }
            };
            return developers;
        }

        // GET: Test/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Test/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Test/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Test/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Test/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Test/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Test/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

    }
}


