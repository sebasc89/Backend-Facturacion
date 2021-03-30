using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace DigitalWare.Facturacion.Common.Classes.DTO.Domain
{
    [DataContract()]
    public class ProductDTO
    {
        [DataMember()]
        [UIHint("Hidden")]
        [Editable(false)]
        public int ProductId { get; set; }

        [DataMember()]
        public string Code { get; set; }

        [DataMember()]
        public string ProductName { get; set; }

        [DataMember()]
        public DateTime CreateDate { get; set; }

        [DataMember()]
        public decimal Price { get; set; }
        
        [DataMember()]
        public int Units { get; set; }

        [DataMember()]
        public int Discount { get; set; }

        [DataMember()]
        public int Tax { get; set; }

        [DataMember()]
        public int CategoryId { get; set; }

        public ProductDTO()
        {

        }
    }
}
