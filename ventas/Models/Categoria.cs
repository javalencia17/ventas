using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ventas.Models
{
    public class Categoria
    {
        public int CategoriaID { get; set; }

        public string Nombre { get; set; }

        [Column(TypeName = "text")]
        public string Descripcion { get; set; }

        [Column(TypeName = "tinyint")]
        public int Condicion { get; set; } = 1;

        public ICollection<Articulo> Articulos { get; set; }
    }
}
