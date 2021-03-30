using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DigitalWare.Facturacion.Infrastructure.Database.Entities
{
    [Table("Customer", Schema = "dbo")]
    public class Customer
    {
        public Customer()
        {

        }

        [Key]
        public int CustomerId { get; set; }

        public string IdentificationType { get; set; }

        public string IdentificationNumber { get; set; }

        public string CustomerType { get; set; }

        public string CustomerName { get; set; }

        public string City { get; set; }

        public string CustomerAddress { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
