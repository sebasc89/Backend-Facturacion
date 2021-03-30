using DigitalWare.Facturacion.Common.Classes.DTO.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalWare.Facturacion.Common.Classes.DTO.Response
{
    public class ResponseDTO<T>
    {
        private HeaderDTO _header;
        public HeaderDTO Header
        {
            get
            {
                if (_header == null)
                {
                    _header = new HeaderDTO();
                }

                return _header;
            }
            set
            {
                _header = value;
            }
        }
        public T Data { get; set; }
    }
}
