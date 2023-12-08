using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApii.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
         ICarImageService carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            this.carImageService = carImageService;
            
        }



        [HttpPost("add")]
        public IActionResult Add(IFormFile file,[FromForm] CarImage carImage)
        {
            var result = carImageService.Add(file, carImage);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



        [HttpPost("delete")]
        public IActionResult Delete(CarImage carImage)
        {
            var carDeleteImage = carImageService.GetByImageId(carImage.Id).Data;
            var result = carImageService.Delete(carDeleteImage);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }




        [HttpPost("update")]
        public IActionResult Update([FromForm] IFormFile formFile, [FromForm] CarImage carImage)
        {
            var result = carImageService.Update(formFile, carImage);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = carImageService.GetAll();
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbycarid")]
        public IActionResult GetByCarId(int carId)
        {
            var result = carImageService.GetByCarId(carId);
            if (result.Succes)
            {
                return Ok(result);
            }
            return Ok(result);
        }

        [HttpGet("getbyimageid")]
        public IActionResult GetByImageId(int imageId)
        {
            var result = carImageService.GetByImageId(imageId);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
