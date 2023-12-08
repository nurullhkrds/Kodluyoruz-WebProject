using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApii.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {


        IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }
        [HttpPost("delete")]

        public IActionResult Delete(Rentals entity)
        {
            var result = _rentalService.Delete(entity);

            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }
        [HttpGet("getall")]

        public IActionResult GetAll()
        {
            var result = _rentalService.GetAll();

            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]

        public IActionResult GetById(int id)
        {
            var result = _rentalService.Get(id);

            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]

        public IActionResult Add(Rentals entity)
        {
            var result = _rentalService.Add(entity);

            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]

        public IActionResult Update(Rentals entity)
        {
            var result = _rentalService.Update(entity);

            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
