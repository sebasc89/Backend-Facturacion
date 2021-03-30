using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace DigitalWare.Facturacion.Common.Classes.DTO.Domain
{
    [DataContract()]
    public class CustomerDTO
    {
        [DataMember()]
        [UIHint("Hidden")]
        [Editable(false)]
        public int CustomerId { get; set; }

        [DataMember()]
        public string IdentificationType { get; set; }

        [DataMember()]
        public string IdentificationNumber { get; set; }

        [DataMember()]
        public string CustomerType { get; set; }

        [DataMember()]
        public string CustomerName { get; set; }

        [DataMember()]
        public string City { get; set; }

        [DataMember()]
        public string CustomerAddress { get; set; }

        [DataMember()]
        public string Phone { get; set; }

        [DataMember()]
        public string Email { get; set; }
        
        [DataMember()]
        public DateTime BirthDate { get; set; }

        public CustomerDTO()
        {

        }
    }
}
