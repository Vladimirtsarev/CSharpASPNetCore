using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebStore.ViewModels;

namespace WebStore.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly List<EmployeeViewModel> _employees = new List<EmployeeViewModel>
        {
            new EmployeeViewModel
            {
                Id = 1,
                FirstName = "Иван",
                SurName = "Иванов",
                Patronymic = "Иванович",
                Age = 22,
                Position = "Начальник"
            },
            new EmployeeViewModel
            {
                Id = 2,
                FirstName = "Владислав",
                SurName = "Петров",
                Patronymic = "Иванович",
                Age = 35,
                Position = "Программист"
            }
        };

        // /home/index
        public IActionResult Index()
        {
            //return Content("Hello from controller");
            return View();
        }

        public IActionResult Employees()
        {
            return View(_employees);
        }

        public IActionResult EmployeeDetails(int id)
        {
            //Получаем сотрудника по Id
            var employee = _employees.FirstOrDefault(t => t.Id == id);
            
            //Если такого не существует
            if (employee == null)
                return NotFound(); // возвращаем результат 404 Not Found
 
            //Иначе возвращаем сотрудника
            return View(employee);
        }
    }
}
