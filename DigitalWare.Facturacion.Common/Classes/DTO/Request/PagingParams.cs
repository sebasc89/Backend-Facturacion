using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalWare.Facturacion.Common.Classes.DTO.Request
{
    public partial class PagingParams
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SortProperty { get; set; }
        public string SortType { get; set; }
        public List<FilterParams> Filters { get; set; }
    }
}
