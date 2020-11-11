using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    [Table("Category")]
    public class Category
    {
        [Required]
        public int id { get; set; }
        [Required(ErrorMessage = "Missing Category's Name")]
        public string Name { get; set; }
        public bool Active { get; set; }
    }

}
