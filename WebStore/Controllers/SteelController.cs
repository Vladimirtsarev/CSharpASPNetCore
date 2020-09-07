using Microsoft.AspNetCore.Mvc;
using WebStore.Interfaces.Infrastructure;
using WebStore.ViewModels;

namespace WebStore.Controllers
{
    [Route("steels")]
    public class SteelController : Controller
    {
        private readonly ISteelsService _steelsService;

        public SteelController(ISteelsService steelsService)
        {
            _steelsService = steelsService;
        }
        
        [Route("all")]
        /// <summary>
        /// Мой экшен
        /// </summary>
        /// <returns></returns>
        public IActionResult Steels()
        {
            return View(_steelsService.GetAll());
        }

        [Route("{id}")]
        /// <summary>
        /// Мой экшен детали
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult SteelDetails(int id)
        {
            //Получаем сталь по Id
            var steel = _steelsService.GetById(id);

            //Если такого не существует
            if (steel == null)
                return NotFound();// Возвращаем результат 404 Not Found

            //Иначе возвращаем сталь
            return View(steel);
        }

        /// <summary>
        /// Добавление или редактирование стали
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("edit/{id?}")]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return View(new SteelViewModel());

            var model = _steelsService.GetById(id.Value);
            if (model == null)
                return NotFound();// возвращаем результат 404 Not Found

            return View(model);
        }

        [HttpPost]
        [Route("edit/{id?}")]
        public IActionResult Edit(SteelViewModel model)
        {
            if (model.Id > 0) // если есть Id, то редактируем модель
            {
                var dbItem = _steelsService.GetById(model.Id);

                if (ReferenceEquals(dbItem, null))
                    return NotFound();// возвращаем результат 404 Not Found

                dbItem.Name = model.Name;
                dbItem.GOSTName = model.GOSTName;               
            }
            else // иначе добавляем модель в список
            {
                _steelsService.AddNew(model);
            }
            _steelsService.Commit(); // станет актуальным позднее (когда добавим БД)

            return RedirectToAction(nameof(Steels));
        }

        /// <summary>
        /// Удаление стали
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("delite/{id?}")]
        public IActionResult Delite(int? id)
        {
            if (!id.HasValue)
                return View(new SteelViewModel());

            _steelsService.Delete(id.Value);

            return RedirectToAction(nameof(Steels));
        }
    }
}
