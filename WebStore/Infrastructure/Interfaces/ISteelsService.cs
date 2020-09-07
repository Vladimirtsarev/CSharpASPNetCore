using System.Collections.Generic;
using WebStore.ViewModels;

namespace WebStore.Interfaces.Infrastructure
{
    /// <summary>
    /// Интерфейс для работы со сталями
    /// </summary>
    public interface ISteelsService
    {
        /// <summary>
        /// Получение списка сталей
        /// </summary>
        /// <returns></returns>
        IEnumerable<SteelViewModel> GetAll();

        /// <summary>
        /// Получение стали по id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        SteelViewModel GetById(int id);

        /// <summary>
        /// Сохранить изменения
        /// </summary>
        void Commit();

        /// <summary>
        /// Добавить новую
        /// </summary>
        /// <param name="model"></param>
        void AddNew(SteelViewModel model);

        /// <summary>
        /// Удалить
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);
    }
}

