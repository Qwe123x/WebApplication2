using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле 'Имя' должно быть заполнено.")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Поле 'Фамилия' должно быть заполнено.")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Поле 'Отчество' должно быть заполнено.")]
        public string? MiddleName { get; set; }

        [Required(ErrorMessage = "Поле 'Должность' должно быть заполнено.")]
        public string? Position { get; set; }
        
        [DataType(DataType.Currency)]
        public DateTime HireDate { get; set; }
    }
}
