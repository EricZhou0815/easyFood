using System.Collections.Generic;
using easyFood.Models;
using easyFood.Services;
using Microsoft.AspNetCore.Mvc;

namespace easyFood.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorysController : ControllerBase
    {
        private readonly CategoryService _categoryService;

        public CategorysController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET api/categorys
        [HttpGet]
        public ActionResult<List<Category>> Get()
        {
            return _categoryService.Get();
        }

        // GET api/categorys/5
        [HttpGet("{id:length(24)}", Name = "GetCategory")]
        public ActionResult<Category> Get(string id)
        {
            var category = _categoryService.Get(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        // POST api/categorys
        [HttpPost]
        public ActionResult<Category> Create(Category category)
        {
            _categoryService.Create(category);

            return CreatedAtRoute("GetCategory", new { id = category.Id.ToString() }, category);
        }

        // PUT api/categorys/5
        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Category categoryIn)
        {
            var category = _categoryService.Get(id);

            if (category == null)
            {
                return NotFound();
            }

            _categoryService.Update(id, categoryIn);

            return NoContent();
        }

        // DELETE api/categorys/5
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var category = _categoryService.Get(id);

            if (category == null)
            {
                return NotFound();
            }

            _categoryService.Remove(category.Id);

            return NoContent();
        }
    }
}