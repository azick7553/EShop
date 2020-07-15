using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : ControllerBase
    {

        public static List<Value> List = new List<Value>
        {
            new Value{ Id = Guid.NewGuid() , Title = "Title1", Body = "Body1"},
            new Value{ Id = Guid.NewGuid(), Title = "Title2", Body = "Body2"},
            new Value{ Id = Guid.NewGuid(), Title = "Title3", Body = "Body3"},
            new Value{ Id = Guid.NewGuid(), Title = "Title4", Body = "Body4"},
            new Value{ Id = Guid.NewGuid(), Title = "Title5", Body = "Body5"},
         };

        [HttpGet]
        public JsonResult GetAll()
        {
            return new JsonResult(List);
        }

        [HttpGet]
        [Route("{id}")]
        public JsonResult GetOne([FromRoute] Guid id)
        {
            return new JsonResult(List.Find(p => p.Id == id));
        }

        [HttpPost]
        public IActionResult Create([FromBody] Value model)
        {
            model.Id = Guid.NewGuid();
            List.Add(model);
            return Ok(model);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            List.Remove(List.Find(p => p.Id == id));
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Edit([FromRoute] Guid id, [FromBody] Value model)
        {
            foreach (var value in List)
            {
                if (value.Id == id)
                {
                    value.Title = model.Title;
                }
            }
            return Ok(List.Find(p => p.Id == id));
        }
    }
}
