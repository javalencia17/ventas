using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ventas.Data;
using ventas.ModelsClass;

namespace ventas.Controllers
{
    public class MisIngresosController : Controller
    {
        private  IngresoModels ingresos;
        private ApplicationDbContext context;

        public MisIngresosController(ApplicationDbContext context)
        {
            this.context = context;
            this.ingresos = new IngresoModels(context);
        }

        public IActionResult Index()
        {
            return View();
        }

        public List<object[]> loadTable()
        {
            return ingresos.loadTable();
        }
    }
}