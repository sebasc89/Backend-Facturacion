using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DigitalWare.Facturacion.Infrastructure.Database.Entities
{
    [Table("OrderDetail", Schema = "dbo")]
    public class OrderDetail
    {
        public OrderDetail()
        {
        }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public decimal Price { get; set; }

        public int Units { get; set; }

        public decimal Tax { get; set; }

        public decimal Discount { get; set; }

        public decimal Total { get; set; }

        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}
