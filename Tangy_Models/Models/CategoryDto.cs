using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangy_Models.Models
{
    public class CategoryDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please enter name...")]
        public string Name { get; set; }
    }
}
