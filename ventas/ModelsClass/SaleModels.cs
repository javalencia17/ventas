using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ventas.Data;
using ventas.Models;

namespace ventas.ModelsClass
{
    public class SaleModels
    {
        private ApplicationDbContext context;

        public SaleModels(ApplicationDbContext context)
        {
            this.context = context;
        }

        internal List<Persona> GetClients()
        {
            return context.Persona.Where(p => p.TipoPersona == 1).ToList();
        }

        internal List<Articulo> GetArticles()
        {
            return context.Articulo.OrderBy(a => a.ArticuloID).ToList();
        }
    }
}
