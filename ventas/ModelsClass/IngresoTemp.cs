using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ventas.ModelsClass
{
    public class IngresoTemp
    {
        public int Persona { get; set; }
        public int Comprobante { get; set; }
        public int Serie { get; set; }
        public int Numero { get; set; }
        public List<detalleTemp> detalles { get; set; }
    }

    public class detalleTemp
    {
        public int Cantidad { get; set; }
        public int PrecioCompra { get; set; }
        public int PrecioVenta { get; set; }
        public int ArticuloID { get; set; }
    }

}
