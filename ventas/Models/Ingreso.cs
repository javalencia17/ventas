using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ventas.Models
{
    public class Ingreso
    {

        public int IngresoID { get; set; }

        [Column(TypeName = "Date")]
        public DateTime Fecha { get; set; }

        [Column(TypeName = "time")]
        public TimeSpan hora { get; set; }

        public int Impuesto { get; set; }

        [Column(TypeName = "tinyint")]
        public int Estado { get; set; } = 1;

        public int ComprobanteID { get; set; }

        public Comprobante comprobante { get; set; }

        public ICollection<DetalleIngreso> DetalleIngresos { get; set; }



    }
}
