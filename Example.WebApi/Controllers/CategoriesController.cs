using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Example.WebApi.Data;
using Microsoft.EntityFrameworkCore;

namespace Example.WebApi.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ProductContex _context;

        public CategoriesController(ProductContex context)
        {
            _context = context;
        }

        [HttpGet("{id}/products")]
        public IActionResult GetWithProducts(int id)
        {
           var data = _context.Categories.Include(x => x.Products).SingleOrDefault(x => x.Id == id);
            if (data == null)
            {
                return NotFound(id);
            }
           return Ok(data);
        }
    }
}
