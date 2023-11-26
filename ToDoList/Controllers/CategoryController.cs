using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    [Route("categorycontroller")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _categoryContext;
        public CategoryController(ApplicationDbContext categoryContext)
        {
            _categoryContext = categoryContext;
        }

        [HttpGet]
        public IActionResult GetCategory()
        {
            IEnumerable<Category> category = _categoryContext.Categories.ToList();
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateCategory(Category obj)
        {
            _categoryContext.Add(obj);
            _categoryContext.SaveChanges();
            return Ok();
        }

        [HttpPut("id: int")]
        public IActionResult UpdateCategory(Category obj, int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            _categoryContext.Update(obj);
            _categoryContext.SaveChanges();
            return Ok();
        }

        [HttpDelete("id: int")]
        public IActionResult DeleteCategory(int id)
        {
            var findId = _categoryContext.Categories.Find(id);
            if (findId == null)
            {
                return BadRequest();
            }
            _categoryContext.Remove(findId);
            _categoryContext.SaveChanges();
            return Ok();
        }
    }
}
