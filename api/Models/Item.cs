using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    [Table("Item")]
    public class Item
    {
        [Required]
        public int id { get; set; }
        [Required(ErrorMessage = "Missing CategoryID for this Item")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Missing Item's Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Missing Item's Cost")]
        public decimal Price { get; set; }
        public DateTime DateCreated { get; set; }
        public bool Active { get; set; }
    }
}