using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalWare.Facturacion.Infrastructure.Database.Context
{
    public static class DbInitializer
    {
        public static void Initialize(FacturacionContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
