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
    public class CategoriaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private CategoriaModels categoriaModels;

        public CategoriaController(ApplicationDbContext context)
        {
            _context = context;
            categoriaModels = new CategoriaModels(_context);
        }

        // GET: Categorias
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public List<IdentityError> Crear(string nombre, string descripcion)
        {
            return categoriaModels.Crear(nombre, descripcion);
        }
        public List<Object[]> Listar()
        {
            return categoriaModels.Listar();
        }


        public List<IdentityError> Editar(int id, string nombre, string descripcion)
        {
            return categoriaModels.Editar(id, nombre, descripcion);
        }

        public List<IdentityError> EditarEstado(int idCategoria)
        {
            return categoriaModels.EditarEstado(idCategoria);
        }


        public List<Categoria> GetCategoria(int id)
        {
            return categoriaModels.GetCategoria(id);
        }

        public List<IdentityError> Eliminar(int id)
        {
            return categoriaModels.Eliminar(id);
        }
    }
}