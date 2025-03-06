using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestAPI_Controllers.DatabaseContext;
using RestAPI_Controllers.Models;

namespace RestAPI_Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatController(CatDatabaseContext context) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() {
            return Ok(context.Cats);
        }
        [HttpGet("{catId}")]
        public IActionResult Get(int catId) {
            return Ok(context.Cats.FirstOrDefault(cat=>cat.CatId==catId));

        } 
       
        [HttpPost]
        public IActionResult Post([FromBody]CatModelDTO dto) {
            context.Cats.Add(dto.MapToCatModel());
            context.SaveChanges();
            return Created();
        }

    }
}
