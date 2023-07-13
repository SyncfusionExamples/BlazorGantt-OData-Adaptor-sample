using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using ODataAdap.Models;

namespace ODataAdap.Controllers
{
    [Route("api/[controller]")]
    public class GanttController : ODataController
    {
        private OdataContext _db;
        public GanttController(OdataContext context)
        {
            _db = context;
        }
        [HttpGet]
        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_db.TaskData);
        }
        [EnableQuery]
        public async Task<IActionResult> Post([FromBody] TaskDatum data)
        {
            _db.TaskData.Add(data);
            _db.SaveChanges();
            return Created(data);
        }
        [EnableQuery]
        public async Task<IActionResult> Patch([FromODataUri] long key, [FromBody] Delta<TaskDatum> data)
        {
            var entity = await _db.TaskData.FindAsync(key);
            data.Patch(entity);
            await _db.SaveChangesAsync();
            return Updated(entity);
        }
        [EnableQuery]
        public long Delete([FromODataUri] long key)
        {
            var deleterow = _db.TaskData.Find(key);
            _db.TaskData.Remove(deleterow);
            _db.SaveChanges();
            return key;
        }
    }
}
