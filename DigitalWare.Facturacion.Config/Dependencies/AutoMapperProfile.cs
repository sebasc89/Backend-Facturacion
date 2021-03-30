using AutoMapper;
using DigitalWare.Facturacion.Common.Classes.DTO.Domain;
using DigitalWare.Facturacion.Infrastructure.Database.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalWare.Facturacion.Config.Dependencies
{
    /// <summary>
    /// Generamos un match entre dos diferentes clases que poseen propiedades similares o iguales
    /// </summary>
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailDTO>().ReverseMap();
        }
    }
}
