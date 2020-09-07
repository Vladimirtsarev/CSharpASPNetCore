using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Interfaces.Infrastructure;
using WebStore.ViewModels;

namespace WebStore.Infrastructure.Services
{
    public class InMemorySteelsService : ISteelsService
    {
        private readonly List<SteelViewModel> _steels = new List<SteelViewModel>
        {
            new SteelViewModel
            {
                Id = 1,
                Name = "Сталь 05кп",
                GOSTName = "ГОСТ 1050-74",
                Description = "Описание1"
            },
            new SteelViewModel
            {
                Id = 2,
                Name = "Ст0",
                GOSTName = "ГОСТ 380-71",
                Description = "Описание2"
            }
        };

        public IEnumerable<SteelViewModel> GetAll()
        {
            return _steels;
        }

        public SteelViewModel GetById(int id)
        {
            return _steels.FirstOrDefault(e => e.Id.Equals(id));
        }

        public void Commit()
        {
            // ничего не делаем
        }

        public void AddNew(SteelViewModel model)
        {
            model.Id = _steels.Max(e => e.Id) + 1;
            _steels.Add(model);
        }

        public void Delete(int id)
        {
            var employee = GetById(id);
            if (employee is null)
                return;

            _steels.Remove(employee);
        }

    }
}
