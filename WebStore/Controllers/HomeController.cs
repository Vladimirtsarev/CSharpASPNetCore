﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.ViewModels;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly List<EmployeeViewModel> _employees = new List<EmployeeViewModel>
        {
            new EmployeeViewModel
            {
                id = 1,
                FirstName = "Иван",
                SurName = "Иванов",
                Patronymic = "Иванович",
                Age = 22,
                Position = "Начальник"
            },
            new EmployeeViewModel
            {
                id = 2,
                FirstName = "Владимир",
                SurName = "Петров",
                Patronymic = "Сергеевич",
                Age = 35,
                Position = "Программист"
            }
        };

        public IActionResult Index()
        {
            //return Content("Hello from controller");
            return View();
        }

        public IActionResult Employees()
        {
            return View(_employees);
        }
    }
}
