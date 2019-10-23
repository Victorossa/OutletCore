using System;
using System.Collections.Generic;

namespace OutletCore.Models
{
    public partial class ProdPrecRegistroPrecio
    {
        public int RegistroPrecio { get; set; }
        public int ProductoId { get; set; }
        public int TipoPrecioId { get; set; }
        public decimal Precio { get; set; }
    }
}
