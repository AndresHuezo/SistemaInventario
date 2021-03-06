using System;
using System.Collections.Generic;

namespace SistemaInventario.Models.BD
{
    public partial class Proveedor
    {
        public Proveedor()
        {
            Inventarios = new HashSet<Inventario>();
        }

        public int Idproveedor { get; set; }
        public string? Empresa { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }

        public virtual ICollection<Inventario> Inventarios { get; set; }
    }
}
