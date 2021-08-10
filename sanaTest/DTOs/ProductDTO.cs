using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sanaTest.DTOs
{
    public class ProductDTO
    {
        public int Id { get; }
        [Required(ErrorMessage = "the Number is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public int Number { get; set; }
        [Required(ErrorMessage = "the Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "the Price is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        [DataType(DataType.Currency)]
        [DisplayFormat(NullDisplayText = "n/a", ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public decimal Price { get; set; }
    }
}
