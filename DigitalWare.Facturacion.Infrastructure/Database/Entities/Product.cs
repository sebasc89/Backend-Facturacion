using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DigitalWare.Facturacion.Infrastructure.Database.Entities
{
    [Table("Product", Schema = "dbo")]
    public class Product
    {
        public Product()
        {
            OrderDetail = new HashSet<OrderDetail>();
        }

        [Key]
        public int ProductId { get; set; }

        public string Code { get; set; }

        public string ProductName { get; set; }

        public DateTime CreateDate { get; set; }

        public decimal Price { get; set; }

        public int Units { get; set; }

        public int Discount { get; set; }

        public int Tax { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Cateogry { get; set; }

        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
