using System;
using System.Collections.Generic;

namespace OutletCore.Models
{
    public partial class ProdProducto
    {
        public int ProductoId { get; set; }
        public int TipoProductoId { get; set; }
        public int UnidadDeMedidaId { get; set; }
        public bool PuedeSerVendido { get; set; }
        public bool PuedeSerComprado { get; set; }
        public string NombreProducto { get; set; }
        public string CodigoDeBarrasEan13 { get; set; }
        public string Descripcion { get; set; }
        public string ReferenciaInterna { get; set; }
    }
}
