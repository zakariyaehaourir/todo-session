using State_Managment.Models;
using State_Managment.ViewModels;
using State_Managment.Mappers;
using System.Text.Json;
using System.Diagnostics;
namespace State_Managment.Services
{
    public class TodoService
    {
        private readonly ISessionManager _sessionManager;
        private readonly string Key = "todos";
        private static int  Cpt=0;

       public TodoService(ISessionManager sm)
        {
            _sessionManager = sm;
        }

        private List<Todo> _todoList;
        public List<Todo> TodoList
        {
            get
            {
                if (_todoList == null)
                {
                    _todoList = _sessionManager.GetSession<List<Todo>>(Key) ?? new List<Todo>();
                }
                return _todoList;
            }
            set
            {
            
            }
        }
        //public List<Todo> TodoList { get; set; }
        public bool AddTodo(ToDoVM todo)
        {
            /**if (!_sessionManager.IsExist(Key))
            {
                TodoList = new();
            }
            else
            {
                TodoList = _sessionManager.GetSession<List<Todo>>(Key);
            }*/

            var t = TodoMapper.VMtoObject(todo);
            t.Id = ++Cpt;
            TodoList.Add(t);
            _sessionManager.SetSession<List<Todo>>(Key, TodoList);

            return true;
        }

        public List<Todo> GetAllTodos()
        {
            if (!_sessionManager.IsExist(Key))
                return [];
            
            return TodoList?? [];
        }

        public bool DeleteTodo(int id)
        {

            Todo todoASupprm = TodoList.FirstOrDefault(t => t.Id == id);
            if (todoASupprm == null)
                return false;

            TodoList.Remove(todoASupprm);
            _sessionManager.SetSession<List<Todo>>(Key, TodoList);
            return true;
        }
        public ToDoEditVM GetTodoById(int id)
        {
            Todo todo = TodoList.FirstOrDefault(t => t.Id == id);
            if (todo == null)
                return null;
            return TodoMapper.TodoToEditVM(todo);
        }
        public bool UpdateTodo(ToDoEditVM todoEditVm)
        {
            var existingTodo = TodoList.FirstOrDefault(t => t.Id == todoEditVm.Id);
            if (existingTodo == null)
                return false;
            //Modification :
            existingTodo.Description= todoEditVm.Description;
            existingTodo.Libelle = todoEditVm.Libelle;
            existingTodo.DateLimit = todoEditVm.DateLimit;
            existingTodo.State = todoEditVm.State;

            _sessionManager.SetSession<List<Todo>>(Key, TodoList);
            return true;
        }

        
    }
}
