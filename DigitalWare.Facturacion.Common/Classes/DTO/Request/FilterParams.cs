﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalWare.Facturacion.Common.Classes.DTO.Request
{
    public class FilterParams
    {
        public string PropertyName { get; set; }
        public string Operator { get; set; }
        public object Value { get; set; }
    }
}
