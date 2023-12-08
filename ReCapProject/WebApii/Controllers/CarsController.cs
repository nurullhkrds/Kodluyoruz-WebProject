using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApii.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {

        ICarService carService;
        public CarsController(ICarService carService)
        {
            this.carService = carService;
            
        }

        [HttpGet("getall")]
        public IActionResult GetAll() {
            var result = carService.GetAll();
          
            if (result.Succes) {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result=carService.Get(id);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = carService.Add(car);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }


        [HttpPost("update")]
        public IActionResult Update(Car car) { 
            var result = carService.Update(car);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


    }
}
