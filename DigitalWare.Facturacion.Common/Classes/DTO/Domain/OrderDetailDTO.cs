using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace DigitalWare.Facturacion.Common.Classes.DTO.Domain
{
    [DataContract()]
    public class OrderDetailDTO
    {
        [DataMember()]
        [UIHint("Hidden")]
        [Editable(false)]
        public int OrderId { get; set; }

        [DataMember()]
        [UIHint("Hidden")]
        [Editable(false)]
        public int ProductId { get; set; }

        [DataMember()]
        public decimal Price { get; set; }

        [DataMember()]
        public int Units { get; set; }

        [DataMember()]
        public decimal Tax { get; set; }

        [DataMember()]
        public decimal Discount { get; set; }

        [DataMember()]
        public decimal Total { get; set; }
    }
}
