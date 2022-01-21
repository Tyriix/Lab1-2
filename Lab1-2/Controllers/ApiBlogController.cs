using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab1_2.Models;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Filters;
using static Lab1_2.Models.BasicAuthorizationFilter;

namespace Lab1_2.Controllers
{
    [ApiController]
    [Route("api/items")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class ApiBlogController : ControllerBase
    {
        private ICRUDBlogItemRepository items;

        public class MyExceptionAttribute : ExceptionFilterAttribute
        {
            public override void OnException(ExceptionContext context)
            {
                if (context.Exception is MyException)
                {
                    var body = new Dictionary<string, Object>();
                    body["error"] = context.Exception.Message;
                    context.Result = new BadRequestObjectResult(body);
                }
            }
        }
        public class MyException : Exception
        {
            public MyException(string message) : base(message)
            {
            }
        }
        public ApiBlogController(ICRUDBlogItemRepository items)
        {
            this.items = items;
        }

        [HttpGet]
        public IList<BlogItem> GetAll()
        {
            return items.FindAll();
        }

        [HttpGet]
        [Route("{id}")]
        [MyException]
        [DisableBasicAuthentication]
        public ActionResult GetOne(int id)
        {
            BlogItem blogItem = items.FindById(id);
            if (blogItem != null)
            {
                return new OkObjectResult(blogItem);
            }
            else
            {
                throw new MyException("Brak indentyfikatora zasobu");
            }
        }

        [HttpPost]
        public ActionResult Add([FromBody] BlogItem item)
        {
            if (ModelState.IsValid)
            {
                BlogItem blogItem = items.Save(item);
                return new CreatedResult($"/api/items/{blogItem.Id}", blogItem);

            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            if (items.FindById(id) != null)
            {
                items.Delete(id);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult Update(int id, [FromBody] BlogItem item)
        {
            item.Id = id;
            BlogItem blogItem = items.Update(item);
            if (blogItem == null)
            {
                return NotFound();
            }
            else
            {
                return NoContent();
            }
        }
    }
}
