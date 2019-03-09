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
    public class ArticuloController : Controller
    {
        private ApplicationDbContext context;
        private List<IdentityError> errorList = new List<IdentityError>();
        private ArticuloModels articulo;


        public ArticuloController(ApplicationDbContext context)
        {
            this.context = context;
            articulo = new ArticuloModels(context);
        }


        public IActionResult Index()
        {
            return View();
        }

        public List<Categoria> GetCategorias()
        {
            return articulo.GetCategorias();
        }

        public List<IdentityError> GuardarArticulo(Articulo art)
        {
            return articulo.GuardarArticulo(art);
        }

        public List<object[]> ListarArticulos()
        {
            return articulo.ListarArticulos();
        }

        public List<Articulo> GetArticulo(int id)
        {
            return articulo.GetArticulo(id);
        }

        public List<IdentityError> EditarArt(Articulo art)
        {
            return articulo.EditarArt(art);
        }

        public List<IdentityError> Delete(int id)
        {
            return articulo.Delete(id);
        }

    }
}