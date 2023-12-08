using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApii.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsControllers : ControllerBase
    {

        IColorService _colorService;

        public ColorsControllers(IColorService colorService)
        {
            _colorService = colorService;
        }



        [HttpPost("delete")]
        public IActionResult Delete(Color entity)
        {

            var result = _colorService.Delete(entity);

            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }



        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _colorService.GetAll();

            if (result.Succes)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _colorService.GetAllColorById(id);

            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



        [HttpPost("add")]
        public IActionResult Add(Color entity)
        {
            var result = _colorService.Add(entity);

            if (result.Succes)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }





        [HttpPost("update")]
        public IActionResult Update(Color entity)
        {
            var result = _colorService.Update(entity);

            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
