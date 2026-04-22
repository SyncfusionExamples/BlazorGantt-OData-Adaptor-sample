using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using ODataAdaptor.Models;

namespace ODataAdaptor.Controllers
{
    public class GanttController : ODataController
    {
        private readonly OdataContext _db;

        public GanttController(OdataContext context)
        {
            _db = context;
        }

        [EnableQuery]
        public IQueryable<TaskDatum> Get()
        {
            return _db.TaskData;
        }

        public async Task<IActionResult> Post([FromBody] TaskDatum data)
        {
            _db.TaskData.Add(data);
            await _db.SaveChangesAsync();
            return Created(data);
        }

        public async Task<IActionResult> Patch([FromODataUri] int key, Delta<TaskDatum> delta)
        {
            var entity = await _db.TaskData.FindAsync(key);
            if (entity == null) return NotFound();

            delta.Patch(entity);
            await _db.SaveChangesAsync();
            return Updated(entity);
        }

        public async Task<IActionResult> Delete([FromODataUri] int key)
        {
            var entity = await _db.TaskData.FindAsync(key);
            if (entity == null) return NotFound();

            _db.TaskData.Remove(entity);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
