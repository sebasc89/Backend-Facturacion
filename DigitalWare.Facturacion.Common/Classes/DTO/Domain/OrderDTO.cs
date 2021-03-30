using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace DigitalWare.Facturacion.Common.Classes.DTO.Domain
{
    [DataContract()]
    public class OrderDTO
    {
        [DataMember()]
        [UIHint("Hidden")]
        [Editable(false)]
        public int OrderId { get; set; }

        [DataMember()]
        public int CustomerId { get; set; }

        [DataMember()]
        public string OrderNumber { get; set; }

        [DataMember()]
        public DateTime CreateDate { get; set; }

        [DataMember()]
        public decimal TotalTax { get; set; }

        [DataMember()]
        public decimal TotalDiscount { get; set; }

        [DataMember()]
        public decimal TotalOrder { get; set; }

        [DataMember]
        public List<OrderDetailDTO> OrderDetail { get; set; }

        public OrderDTO()
        {

        }
    }
}
