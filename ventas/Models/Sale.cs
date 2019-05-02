using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ventas.Models
{
    public class Sale
    {

        public int SaleID { get; set; }

        [Column(TypeName = "Date")]
        public DateTime Fecha { get; set; }

        [Column(TypeName = "Time")]
        public TimeSpan Hora { get; set; }

        public int Impuesto { get; set; }

        [Column(TypeName = "Tinyint")]
        public int Estado { get; set; } = 1;

        public int ComprobanteID { get; set; }

        public Comprobante comprobante { get; set; }

        public int PersonaID { get; set; }

        public Persona persona { get; set; }

        public ICollection<SaleDetail> saleDetails { get; set; }



    }
}
