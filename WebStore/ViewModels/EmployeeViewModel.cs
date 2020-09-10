using System.ComponentModel.DataAnnotations;

namespace WebStore.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings =false, ErrorMessage ="Имя является обязательным")]
        [Display(Name ="Имя")]
        [StringLength(maximumLength:200, MinimumLength =2, ErrorMessage ="В имени должно быть не менее 2х символов и не более 200")]
        public string FirstName { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Фамилия является обязательным")]
        [Display(Name = "Фамилия")]
        public string SurName { get; set; }

        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Возраст является обязательным")]
        [Display(Name = "Возраст")]
        public int Age { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Должность является обязательной")]
        [Display(Name = "Должность")]
        public string Position { get; set; }
    }

}