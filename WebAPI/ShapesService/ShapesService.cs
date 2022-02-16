using ShapesApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShapesApi.ShapesService
{
    public class ShapeService : IShapesService
    {
        public ShapesContext _shapeDbContext;
        public ShapeService(ShapesContext shapeDbContext)
        {
            _shapeDbContext = shapeDbContext;
        }
        public Shape CreateShape(Shape shape)
        {
            _shapeDbContext.Shapes.Add(shape);
            _shapeDbContext.SaveChanges();
            return (shape);
        }
        public List<Shape> GetShapes()
        {
            return _shapeDbContext.Shapes.ToList();
        }
        public void UpdateShape(Shape shape)
        {
            _shapeDbContext.Update(shape);
            _shapeDbContext.SaveChanges();
            // var Shape = _shapeDbContext.Shapes.FirstOrDefault(x => x.Id == shape.Id);
            //if(Shape == null)
            // {

            // }
            // else
            // {
            //     Shape.CurrentAmt = shape.CurrentAmt;

            //    // _shapeDbContext.Shapes.Update(shape);
            //     _shapeDbContext.SaveChanges();
            // }



        }

        public void DeleteShape(int Id)
        {
            var Shape = _shapeDbContext.Shapes.FirstOrDefault(x => x.Id == Id);
            if (Shape != null)
            {
                _shapeDbContext.Remove(Shape);
                _shapeDbContext.SaveChanges();
            }
        }
     
        public Shape GetShape(int Id)
        {
            return _shapeDbContext.Shapes.FirstOrDefault(x => x.Id == Id);
        }

        public void UpdateCurrentAmt(ShapeCurrentAmt shape)
        {
            var Shape = _shapeDbContext.Shapes.FirstOrDefault(x => x.Id == shape.Id);
            if (Shape == null)
            {

            }
            else
            {
                Shape.CurrentAmt = shape.CurrentAmt;

                // _shapeDbContext.Shapes.Update(shape);
                _shapeDbContext.SaveChanges();
            }

        }
    }
}