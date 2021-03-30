using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DigitalWare.Facturacion.Infrastructure.Database.Entities
{
    [Table("Order", Schema = "dbo")]
    public class Order
    {
        public Order()
        {
            OrderDetail = new HashSet<OrderDetail>();
        }

        [Key]
        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public string OrderNumber { get; set; }

        public DateTime CreateDate { get; set; }

        public decimal TotalTax { get; set; }

        public decimal TotalDiscount { get; set; }

        public decimal TotalOrder { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
