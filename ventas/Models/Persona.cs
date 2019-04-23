using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ventas.Models
{
    public class Persona
    {
        public int PersonaID { get; set; }

        [Column(TypeName = "tinyint")]
        public int TipoPersona { get; set; }

        public String Nombre { get; set; }

        [Column(TypeName = "tinyint")]
        public int TipoDocumento { get; set; }

        public int NumeroDocumento { get; set; }

        public String Direccion { get; set; }

        public String  Telefono { get; set; }

        public String Email { get; set; }

        public ICollection<Ingreso> ingresos { get; set; }
    }
}
