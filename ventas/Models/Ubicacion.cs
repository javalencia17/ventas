using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ventas.Models
{
    public class Ubicacion
    {
        public int UbicacionID { get; set; }

        public string Nombre { get; set; }

        [Column(TypeName = "text")]
        public string Descripcion { get; set; }

        [Column(TypeName = "tinyint")]
        public int Estado { get; set; } = 1;

        public ICollection<Articulo> articulo { get; set; }
    }
}
