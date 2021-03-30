using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace DigitalWare.Facturacion.Common.Classes.DTO.Domain
{
    [DataContract()]
    public class CategoryDTO
    {
        [DataMember]
        public int CategoryId { get; set; }
        [DataMember]
        public string CategoryName { get; set; }
        [DataMember]
        public DateTime CreateDate { get; set; }

        public CategoryDTO()
        {
        }
    }
}
