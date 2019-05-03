using System.Collections.Generic;
using easyFood.Models;
using easyFood.Services;
using Microsoft.AspNetCore.Mvc;

namespace easyFood.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TablesController : ControllerBase
    {
        private readonly TableService _tableService;

        public TablesController(TableService tableService)
        {
            _tableService = tableService;
        }

        // GET api/tables
        [HttpGet]
        public ActionResult<List<Table>> Get()
        {
            return _tableService.Get();
        }

        // GET api/tables/5
        [HttpGet("{id:length(24)}", Name = "GetTable")]
        public ActionResult<Table> Get(string id)
        {
            var table = _tableService.Get(id);

            if (table == null)
            {
                return NotFound();
            }

            return table;
        }

        // POST api/tables
        [HttpPost]
        public ActionResult<Table> Create(Table table)
        {
            _tableService.Create(table);

            return CreatedAtRoute("GetTable", new { id = table.Id.ToString() }, table);
        }

        // PUT api/tables/5
        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Table tableIn)
        {
            var table = _tableService.Get(id);

            if (table == null)
            {
                return NotFound();
            }

            _tableService.Update(id, tableIn);

            return NoContent();
        }

        // DELETE api/tables/5
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var table = _tableService.Get(id);

            if (table == null)
            {
                return NotFound();
            }

            _tableService.Remove(table.Id);

            return NoContent();
        }
    }
}