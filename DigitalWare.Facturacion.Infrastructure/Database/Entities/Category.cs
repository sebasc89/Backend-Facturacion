using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DigitalWare.Facturacion.Infrastructure.Database.Entities
{
    [Table("Category", Schema = "dbo")]
    public class Category
    {
        public Category()
        {
        }

        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
