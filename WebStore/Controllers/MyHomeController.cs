using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.ViewModels;

namespace WebStore.Controllers
{
    public class MyHomeController : Controller
    {
        private readonly List<SteelViewModel> _steels = new List<SteelViewModel>
        {
            new SteelViewModel
            {
                id = 1,
                Name = "Сталь 05кп",
                GOSTName = "ГОСТ 1050-74",
                Description = "Описание1"
            },
            new SteelViewModel
            {
                id = 2,
                Name = "Ст0",
                GOSTName = "ГОСТ 380-71",
                Description = "Описание2"
            }
        };


        public IActionResult Index()
        {
            //return Content("Привет от MyHomeController");
            return View();
        }

        /// <summary>
        /// Мой экшен
        /// </summary>
        /// <returns></returns>
        public IActionResult Steels()
        {
            return View(_steels);
        }

        /// <summary>
        /// Мой экшен детали
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult SteelDetails(int id)
        {
            //Получаем сталь по Id
            var steel = _steels.FirstOrDefault(t => t.id.Equals(id));

            //Если такого не существует
            if (steel == null)
                return NotFound();// Возвращаем результат 404 Not Found

            //Иначе возвращаем сотрудника
            return View(_steels.FirstOrDefault(x => x.id == id));
        }
    }
}
