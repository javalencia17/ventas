using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ventas.Models
{
    public class Comprobante
    {
        public int ComprobanteID { get; set; }

        public string Tipo { get; set; }

        public string Serie{ get; set; }

        public string Numero { get; set; }

        public ICollection<Ingreso> Ingresos { get; set; }

    }
}
