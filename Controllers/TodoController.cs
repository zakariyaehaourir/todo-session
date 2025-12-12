using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using State_Managment.Filters;
using State_Managment.Mappers;
using State_Managment.Models;
using State_Managment.Services;
using State_Managment.ViewModels;
using System.Diagnostics;
using System.Text.Json;

namespace State_Managment.Controllers
{
    [AuthFilter]
    //[LoggerFilter]
    public class TodoController : Controller
    {
        private readonly TodoService _todoService;
        public TodoController(TodoService todoService)
        {
            _todoService = todoService;
        }
        public IActionResult Index()
        {
            List<Todo> list=_todoService.GetAllTodos();
            //ViewBag.List = list; nécessite unc caste dans Razor view
            return View(list);
        }
        
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ToDoVM todo)
        {
            if(!ModelState.IsValid) //error dans les champs retour au formulaire
                return View();

            _todoService.AddTodo(todo);
            return RedirectToAction(nameof(Index));

        }
        [HttpPost]
        public IActionResult Delete(int id)
        {

            if(_todoService.DeleteTodo(id))
                return RedirectToAction(nameof(Index)); //Suppr succeed

            return RedirectToAction(nameof(Index)); //Error dans la suppr à ajouter
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            //processus pour recupérer la tache
            var todoEditVm =_todoService.GetTodoById(id);
            if(todoEditVm != null)
            {
                return View(todoEditVm);
            }
            return RedirectToAction(nameof(Index)); //Invalide id : error a ajouter
            
        }
        [HttpPost]
        public IActionResult Update(ToDoEditVM toDoEditVM)
        {
            if (!ModelState.IsValid)
                return View("Edit");
            //processus pour updater
            if(_todoService.UpdateTodo(toDoEditVM))
                return RedirectToAction(nameof(Index)); //flash resposne a ajouter un message
            return RedirectToAction(nameof(Update));
        }
    }
}
