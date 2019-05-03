using System.Collections.Generic;
using easyFood.Models;
using easyFood.Services;
using Microsoft.AspNetCore.Mvc;

namespace easyFood.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
        private readonly FoodService _foodService;

        public FoodsController(FoodService foodService)
        {
            _foodService = foodService;
        }

        // GET api/foods
        [HttpGet]
        public ActionResult<List<Food>> Get()
        {
            return _foodService.Get();
        }

        // GET api/foods/5
        [HttpGet("{id:length(24)}", Name = "GetFood")]
        public ActionResult<Food> Get(string id)
        {
            var food = _foodService.Get(id);

            if (food == null)
            {
                return NotFound();
            }

            return food;
        }

        // POST api/foods
        [HttpPost]
        public ActionResult<Food> Create(Food food)
        {
            _foodService.Create(food);

            return CreatedAtRoute("GetFood", new { id = food.Id.ToString() }, food);
        }

        // PUT api/foods/5
        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Food foodIn)
        {
            var food = _foodService.Get(id);

            if (food == null)
            {
                return NotFound();
            }

            _foodService.Update(id, foodIn);

            return NoContent();
        }

        // DELETE api/foods/5
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var food = _foodService.Get(id);

            if (food == null)
            {
                return NotFound();
            }

            _foodService.Remove(food.Id);

            return NoContent();
        }
    }
}