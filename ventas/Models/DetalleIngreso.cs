using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ventas.Models
{
    public class DetalleIngreso
    {
        public int DetalleIngresoID { get; set; }

        public int Cantidad { get; set; }

        [Column(TypeName = "money")]
        public decimal PrecioCompra { get; set; }

        [Column(TypeName = "money")]
        public decimal PrecioVenta { get; set; }

        public int IngresoID  { get; set; }

        public int ArticuloID { get; set; }

        public Ingreso ingreso { get; set; }


        public Articulo  articulo { get; set; }




    }
}
