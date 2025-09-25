using Hung_Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hung_Models.Controllers
{
    public class EmployeeController : Controller
    {
        // Danh sách tạm để lưu nhân viên
        private static List<Employee> employees = new List<Employee>()
        {
            new Employee { Id = 1, FullName = "Nguyen Van An", Gender = "Male", Phone = "0123456789", Email = "a@gmail.com", Salary = 1000, Status = true },
            new Employee { Id = 2, FullName = "Tran Thi Binh", Gender = "Female", Phone = "0987654321", Email = "b@gmail.com", Salary = 1200, Status = false },
            new Employee { Id = 3, FullName = "Le Van Nam", Gender = "Male", Phone = "0912345678", Email = "nam.le@gmail.com", Salary = 1500, Status = true },
            new Employee { Id = 4, FullName = "Pham Thi Hoa", Gender = "Female", Phone = "0938765432", Email = "hoa.pham@gmail.com", Salary = 1100, Status = true },
            new Employee { Id = 5, FullName = "Tran Van Minh", Gender = "Male", Phone = "0978888999", Email = "minh.tran@gmail.com", Salary = 1300, Status = false },
            new Employee { Id = 6, FullName = "Nguyen Thi Lan", Gender = "Female", Phone = "0961122334", Email = "lan.nguyen@gmail.com", Salary = 1400, Status = true },
            new Employee { Id = 7, FullName = "Hoang Van Tuan", Gender = "Male", Phone = "0909090909", Email = "tuan.hoang@gmail.com", Salary = 1250, Status = true },
            new Employee { Id = 8, FullName = "Dang Thi Mai", Gender = "Female", Phone = "0923456781", Email = "mai.dang@gmail.com", Salary = 1350, Status = false },
            new Employee { Id = 9, FullName = "Bui Van Long", Gender = "Male", Phone = "0945566778", Email = "long.bui@gmail.com", Salary = 1600, Status = true },
            new Employee { Id = 10, FullName = "Nguyen Thi Huong", Gender = "Female", Phone = "0956677889", Email = "huong.nguyen@gmail.com", Salary = 1450, Status = true },
            new Employee { Id = 11, FullName = "Vo Van Phuc", Gender = "Male", Phone = "0932112233", Email = "phuc.vo@gmail.com", Salary = 1550, Status = false },
            new Employee { Id = 12, FullName = "Tran Thi Thu", Gender = "Female", Phone = "0988112233", Email = "thu.tran@gmail.com", Salary = 1200, Status = true }
        };

        public IActionResult Index()
        {
            ViewBag.Employees = employees;
            return View();
        }

        public IActionResult Details(int id)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);
            return View(emp);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            emp.Id = employees.Max(e => e.Id) + 1;
            employees.Add(emp);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);
            return View(emp);
        }

        [HttpPost]
        public IActionResult Edit(Employee emp)
        {
            var old = employees.FirstOrDefault(e => e.Id == emp.Id);
            if (old != null)
            {
                old.FullName = emp.FullName;
                old.Gender = emp.Gender;
                old.Phone = emp.Phone;
                old.Email = emp.Email;
                old.Salary = emp.Salary;
                old.Status = emp.Status;
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);
            return View(emp);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp != null) employees.Remove(emp);
            return RedirectToAction("Index");
        }
    }
}
