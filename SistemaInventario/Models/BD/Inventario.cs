using System;
using System.Collections.Generic;

namespace SistemaInventario.Models.BD
{
    public partial class Inventario
    {
        public int Idregistro { get; set; }
        public int? Entradastock { get; set; }
        public int? Salidastock { get; set; }
        public int? Idusuario { get; set; }
        public string? Codproducto { get; set; }
        public string? Observaciones { get; set; }
        public int? Idproveedor { get; set; }
        public int? Idsucursal { get; set; }
        public int? Idestante { get; set; }

        public virtual Producto? CodproductoNavigation { get; set; }
        public virtual Estante? IdestanteNavigation { get; set; }
        public virtual Proveedor? IdproveedorNavigation { get; set; }
        public virtual Sucursal? IdsucursalNavigation { get; set; }
        public virtual Usuario? IdusuarioNavigation { get; set; }
    }
}
