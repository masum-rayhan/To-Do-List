using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Controllers;

[Route("task-handler")]
[ApiController]
public class TaskListController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public TaskListController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetTask()
    {
        IEnumerable<TaskList> taskLists = _context.Tasks.ToList();
        return Ok(taskLists);
    }

    [HttpPost]
    public IActionResult CreateTask(TaskList obj)
    {
        _context.Tasks.Add(obj);
        _context.SaveChanges();
        return Ok();
    }
}
