using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ventas.Models
{
    public class SaleDetail
    {

        public int SaleDetailID { get; set; }

        public int Cantidad { get; set; }

        [Column(TypeName= "Money")]
        public Decimal PrecioVenta { get; set; }

        public int ArticuloID { get; set; }

        public Articulo articulo { get; set; }

        public int SaleID { get; set; }

        public Sale sale { get; set; }



    }
}
