using State_Managment.Models;
using State_Managment.ViewModels;

namespace State_Managment.Mappers
{
    public class TodoMapper
    {

        public static Todo VMtoObject(ToDoVM vm)
        {
            return new Todo { Libelle = vm.Libelle , DateLimit = vm.DateLimit , State = vm.State , Description = vm.Description };
        }

        public static ToDoEditVM TodoToEditVM(Todo tood)
        {
            return new ToDoEditVM { DateLimit = tood.DateLimit , Description = tood.Description  , Id = tood.Id , Libelle=tood.Libelle , State=tood.State};
        }
        public static Todo EditVmToTodo(ToDoEditVM toDoEditVM)
        {
            return new Todo { Id = toDoEditVM.Id, DateLimit = toDoEditVM.DateLimit, Description = toDoEditVM.Description, Libelle = toDoEditVM.Libelle, State = toDoEditVM.State };
        }
    }
}
