using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Position
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public string? Title { get; set; }
    }
}
