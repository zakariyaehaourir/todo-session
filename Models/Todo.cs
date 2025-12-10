using State_Managment.Enums;
using System.ComponentModel.DataAnnotations;

namespace State_Managment.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string Libelle { get; set; }

        public string Description { get; set; }
        public TodoState State { get; set; } = TodoState.ToDo;
        public DateTime DateLimit { get; set; }

        
    }
}
