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

    [HttpPut]
    public IActionResult UpdateTask(TaskList taskListToUpdate, int id)
    {
        if(id != taskListToUpdate.Id)
            return BadRequest();

        if(id == taskListToUpdate.Id)
            _context.Tasks.Update(taskListToUpdate);
            _context.SaveChanges();
            return Ok();
    }

    [HttpDelete]
    public IActionResult DeleteTask(int id)
    {
        var taskList = _context.Tasks.Find(id);
        if(taskList == null)
            return NotFound();

        _context.Tasks.Remove(taskList);
        _context.SaveChanges();
        return Ok();
    }
}
