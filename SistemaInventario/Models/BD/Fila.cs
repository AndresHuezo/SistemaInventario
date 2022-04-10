using System;
using System.Collections.Generic;

namespace SistemaInventario.Models.BD
{
    public partial class Fila
    {
        public int Idfila { get; set; }
        public string? Nombre { get; set; }
        public int? Idestante { get; set; }

        public virtual Estante? IdestanteNavigation { get; set; }
    }
}
