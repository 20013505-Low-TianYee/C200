
using System.ComponentModel.DataAnnotations;

namespace ShapesApi.Models
{
    public class Shape
    {
        [Key]
        public int Id {get;set;}
      
        public string ShapeName {get;set;}
       
        public string ProductName {get;set;}
        public int RestockAmt {get;set;}
        
        public int CurrentAmt {get;set;}
    }
}