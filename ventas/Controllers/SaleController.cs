using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ventas.Data;
using ventas.Models;
using ventas.ModelsClass;

namespace ventas.Controllers
{
    public class SaleController : Controller
    {
        private ApplicationDbContext context;
        private SaleModels SaleModels;


        public SaleController(ApplicationDbContext context)
        {
            this.context = context;
            SaleModels = new SaleModels(context);
        }
        

        public IActionResult Index()
        {
            return View();
        }

        public List<Persona> GetClients()
        {
            return SaleModels.GetClients();
        }

        public List<Articulo> GetArticles()
        {
            return SaleModels.GetArticles();
        }


        public List<IdentityError> SaveSale(IngresoTemp venta)
        {
            return SaleModels.SaveSale(venta);
        }
    }
}