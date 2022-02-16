using ShapesApi.Models;
using System.Collections.Generic;

namespace ShapesApi.ShapesService
{
    public interface IShapesService
    {
        Shape CreateShape(Shape shape);

        List<Shape> GetShapes();

        void UpdateShape(Shape shape);
        void DeleteShape(int Id);
        Shape GetShape(int Id);
        void UpdateCurrentAmt(ShapeCurrentAmt shape);
    }
}