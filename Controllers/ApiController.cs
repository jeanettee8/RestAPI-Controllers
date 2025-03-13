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
        public IActionResult Get([FromQuery]QueryDTO? dto) {
            if (dto is not null) {
                return Ok(dto.QueryBuilder(context.Cats.ToList().AsQueryable()));
            }
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

        [HttpPatch("{catId}")]
        public IActionResult Patch(int catId, [FromBody]CatModelDTO dto) {
            var existingCat = context.Cats.FirstOrDefault(cat=>cat.CatId==catId);
            if (existingCat == null) return NotFound();
            existingCat.BodyType = dto.BodyType;
            existingCat.Breed = dto.Breed;
            existingCat.Coat = dto.Coat;
            existingCat.Country = dto.Country;
            existingCat.Pattern = dto.Pattern;
            context.SaveChanges();
            return Created();
        }

        [HttpDelete("{catId}")]
        public IActionResult Delete(int catId) {
        var existingCat = context.Cats.FirstOrDefault(cat=>cat.CatId==catId);
        if (existingCat == null) return NotFound();  
        context.Cats.Remove(existingCat);
        context.SaveChanges();
        return NoContent();
        }
    }
}
