using ShapesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ShapesApi
{
    public class ShapesContext : DbContext
    {
        public ShapesContext(DbContextOptions<ShapesContext> options) : base(options)
        {
        }

        public DbSet<Shape> Shapes {get; set;}
        public DbSet<ShapeCurrentAmt> ShapesCurrentAmt { get; set; }//
    }
}