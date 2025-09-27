using Microsoft.AspNetCore.Mvc;
using Hung_Models.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hung_Models.Controllers
{
    public class StudentController : Controller
    {
        public static List<Student> students = new List<Student>()
{
            new Student
            {
                Id = 1,
                Name = "Nguyen Van An",
                Email = "vana@gmail.com",
                Password = "Password123",
                Branch = "Computer Science",
                Gender = "Male",
                IsRegular = true,
                Address = "Ha Noi, Viet Nam",
                DateOfBorth = new DateTime(1998, 5, 21)
            },
            new Student
            {
                Id = 2,
                Name = "Tran Thi Binh",
                Email = "thib@gmail.com",
                Password = "BTran@123",
                Branch = "Information Technology",
                Gender = "Female",
                IsRegular = false,
                Address = "Da Nang, Viet Nam",
                DateOfBorth = new DateTime(2000, 10, 15)
            },
            new Student
            {
                Id = 3,
                Name = "Le Van Cong",
                Email = "c.le@gmail.com",
                Password = "LeVanC456",
                Branch = "Electronics",
                Gender = "Male",
                IsRegular = true,
                Address = "Hai Phong, Viet Nam",
                DateOfBorth = new DateTime(1995, 3, 12)
            },

};
        public IActionResult Index()
        {
            ViewBag.Students = students;
            return View();
        }

        public IActionResult Create()
        {
            ViewBag.AllBranches = new List<SelectListItem>
            {
                new SelectListItem { Value = "Computer Science", Text = "Computer Science" },
                new SelectListItem { Value = "Information Technology", Text = "Information Technology" },
                new SelectListItem { Value = "Electronics", Text = "Electronics" },
                new SelectListItem { Value = "Mechanical Engineering", Text = "Mechanical Engineering" },
                new SelectListItem { Value = "Civil Engineering", Text = "Civil Engineering" }
            };
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student s)
        {

            // Tự động tăng Id
            s.Id = students.Max(e => e.Id) + 1;
            students.Add(s);
            return RedirectToAction("Index");
        }

    }
}
