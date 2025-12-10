using State_Managment.Enums;
using System.ComponentModel.DataAnnotations;

namespace State_Managment.ViewModels
{
    public class ToDoVM
    {
        [Required(ErrorMessage ="La libelle est obligatoire !")]
        public string Libelle { get; set; }
        [Required(ErrorMessage = "La description est obligatoire !")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public TodoState State { get; set; } = TodoState.ToDo;
        [Required(ErrorMessage = "La date de limite est obligatoire !")]
        public DateTime DateLimit { get; set; }
    }
}
