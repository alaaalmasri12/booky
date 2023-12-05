using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booky.DAL.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; } //Pk Identity
        [Required(ErrorMessage ="Category Name is Required")]
        [MaxLength(30)]
        public string Name { get; set; }//.Net 6  =>Required
        [Required(ErrorMessage = "Order is Required")]
        [Range(1,100)]
        public int DisplayOrder { get; set; }   
    }
}
