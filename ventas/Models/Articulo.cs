using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ventas.Models
{
    public class Articulo
    {
        public int ArticuloID { get; set; }

        public String Codigo { get; set; }

        public String Nombre { get; set; }

        public int Stock { get; set; }

        [Column(TypeName = "text")]
        public string Descripcion { get; set; }

        [Column(TypeName = "tinyint")]
        public int Estado { get; set; } = 1;

        public int CategoriaID { get; set; }

        public Categoria categoria { get; set; }

        public int? UbicacionID { get; set; }

        public virtual Ubicacion ubicacion { get; set; }

        public ICollection<DetalleIngreso> DetalleIngresos { get; set; }

        public ICollection<SaleDetail> SaleDetails { get; set; }

    }
}
