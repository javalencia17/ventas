using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ventas.Data;
using ventas.Models;

namespace ventas.ModelsClass
{
    public class IngresoModels
    {
        private ApplicationDbContext context;

        public IngresoModels(ApplicationDbContext context)
        {
            this.context = context;        
        }


        internal List<Persona> GetProveedores()
        {
            return context.Persona.Where(p => p.TipoPersona == 2).ToList();
        }

        internal List<Comprobante> GetComprobantes()
        {
            return context.Comprobante.OrderBy(c => c.Tipo).ToList();
        }

        internal List<Articulo> GetArticulos()
        {
            return context.Articulo.OrderBy(a => a.Nombre).ToList();
        }
    }
}
