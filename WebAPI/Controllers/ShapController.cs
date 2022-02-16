using ShapesApi.Models;
using ShapesApi.ShapesService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ShapesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShapeController : ControllerBase
    {
        private readonly IShapesService _ShapeService;
        public ShapeController(IShapesService ShapeService)
        {
            _ShapeService = ShapeService;
        }

        [HttpGet]
        [Route("[action]")]
        public IEnumerable<Shape> GetShapes()
        {
            return _ShapeService.GetShapes();
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult CreateShape(Shape Shape)
        {
            _ShapeService.CreateShape(Shape);
            return Ok();
        }

        [HttpPut]
        [Route("[action]")]
        public IActionResult UpdateShape(Shape shape)
        {
            _ShapeService.UpdateShape(shape);
            return Ok();
        }

        [HttpPut]
        [Route("[action]")]
        public IActionResult UpdateCurrentAmt(ShapeCurrentAmt shape)
        {
            _ShapeService.UpdateCurrentAmt(shape);
            return Ok();
        }

        [HttpDelete]
        [Route("[action]")]
        public IActionResult DeleteShape(int id)
        {
            var existingShape = _ShapeService.GetShape(id);
            if (existingShape != null)
            {
                _ShapeService.DeleteShape(existingShape.Id);
                return Ok();
            }
            return NotFound($"Shape Not Found with ID : {existingShape.Id}");
        }

        [HttpGet]
        [Route("[action]")]
        public Shape GetShape(int id)
        {
            return _ShapeService.GetShape(id);
        }
    }
}