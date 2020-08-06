using ExpressiveAnnotations.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ValidationsDemo.Controllers
{
    public class DemoController : Controller
    {
        // GET: Demo
        public ActionResult Create()
        {
            var model = new SampleModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(SampleModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Create",model);
            }
            return RedirectToAction("Done");
        }
        public ActionResult Done()
        {
            return View();
        }

        public class SampleModel
        {
            public SampleModel()
            {
                Departments = new List<Department>
                {
                    new Department {Id=1, Name="Department 1"},
                    new Department {Id=2, Name="Department 2"}
                };
            }
            [Required]
            public string Name { get; set; }

            [RequiredIf("Name == 'John'")]          
            [Display(Name ="Age")]
            public int? Age { get; set; }

            [Display(Name="Department")]
            [RequiredIf("Age >= 18",ErrorMessage ="Department is required when Age is greater than 18")]
            public int? SelectedDepartmentId { get; set; }

            [Display(Name = "I confirm this one")]
            [AssertThat("Age == 20 ? ConfirmationOne == true:true",ErrorMessage ="Confirmation is required when age is 20")]
            public bool ConfirmationOne { get; set; }
            [Display(Name = "I confirm this two")]
            public bool ConfirmationTwo { get; set; }
            [Display(Name = "I confirm this three")]
            public bool ConfirmationThree { get; set; }

            public IEnumerable<Department> Departments { get; set; }

        }

        public class Department
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public  static string Test {get;set;}
        }
    }
}