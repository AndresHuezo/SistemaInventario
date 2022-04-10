using System;
using System.Collections.Generic;

namespace SistemaInventario.Models.BD
{
    public partial class Usuario
    {
        public Usuario()
        {
            Inventarios = new HashSet<Inventario>();
        }

        public int Id { get; set; }
        public string? Usuario1 { get; set; }
        public string? Password { get; set; }
        public string? Nombre { get; set; }
        public string? Dui { get; set; }
        public int? Rol { get; set; }

        public virtual ICollection<Inventario> Inventarios { get; set; }
    }
}
