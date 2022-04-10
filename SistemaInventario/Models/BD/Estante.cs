using System;
using System.Collections.Generic;

namespace SistemaInventario.Models.BD
{
    public partial class Estante
    {
        public Estante()
        {
            Filas = new HashSet<Fila>();
            Inventarios = new HashSet<Inventario>();
        }

        public int Idestante { get; set; }
        public string? Nombre { get; set; }

        public virtual ICollection<Fila> Filas { get; set; }
        public virtual ICollection<Inventario> Inventarios { get; set; }
    }
}
