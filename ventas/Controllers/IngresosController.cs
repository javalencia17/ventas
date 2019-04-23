using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ventas.Data;
using ventas.Models;
using ventas.ModelsClass;

namespace ventas.Controllers
{
    public class IngresosController : Controller
    {

        private ApplicationDbContext context;
        private IngresoModels ingresoModels;

        public IngresosController(ApplicationDbContext context)
        {
            this.context = context;
            ingresoModels = new IngresoModels(context);

        }

        public IActionResult Index()
        {
            return View();
        }

        public List<Persona> GetProveedores()
        {
            return ingresoModels.GetProveedores();
        }
          
        public List<Comprobante> GetComprobantes()
        {
            return ingresoModels.GetComprobantes();
        }

        public List<Articulo> GetArticulos()
        {
            return ingresoModels.GetArticulos();
        }
        
        public List<IdentityError> GuardarIngresos(IngresoTemp ingreso)
        {
            return ingresoModels.GuardarIngresos(ingreso);  
        }

        
        
    }

 
}