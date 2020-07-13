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

        public static List<Value> List = new Value[]
        {
            new Value{ Id = 1, Title = "Title1"},
            new Value{ Id = 2, Title = "Title2"},
            new Value{ Id = 3, Title = "Title3"},
            new Value{ Id = 4, Title = "Title4"},
            new Value{ Id = 5, Title = "Title5"},
         }.ToList();

        [HttpGet]
        public JsonResult GetAll()
        {
            return new JsonResult(List);
        }

        [HttpGet]
        [Route("{id}")]
        public JsonResult GetOne([FromRoute] int? id)
        {
            return new JsonResult(List.Find(p => p.Id == id));
        }

        [HttpPost]
        public IActionResult Create([FromBody] Value model)
        {
            List.Add(model);
            return Ok(model);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            List.Remove(List.Find(p => p.Id == id));
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Edit([FromRoute] int id, [FromBody] Value model)
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
