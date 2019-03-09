using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ventas.Data;
using ventas.Models;

namespace ventas.ModelsClass
{
    public class ArticuloModels
    {
        private ApplicationDbContext context;
        private List<IdentityError> errorList = new List<IdentityError>();
        private string cod = "";
        private string des = "";

        public ArticuloModels(ApplicationDbContext context)
        {
            this.context = context;
        }


        /*
         obtiene las categorias ordenadas por nombre
         @params: null
         @return: lista de categorias
         */
        internal List<Categoria> GetCategorias()
        {
            return context.Categoria.OrderBy(c => c.Nombre).ToList();
        }

        /*
         Guarda Articulo retorna array
         @params: articulo
         @return: array "Save" => ok, "Not save" =>  error
         */
        internal List<IdentityError> GuardarArticulo(Articulo art)
        {
            var articulo = new Articulo
            {
                Nombre = art.Nombre,
                Codigo = art.Codigo,
                Stock = art.Stock,
                Descripcion = art.Descripcion,
                CategoriaID = art.CategoriaID
            };

            try
            {
                context.Add(articulo);
                context.SaveChanges();
                cod = "Save";
                des = "Save";
            }
            catch (Exception ex)
            {
                cod = "Not Save";
                des = ex.Message;
            }

            errorList.Add(new IdentityError
            {
                Code = cod,
                Description = des
            });

            return errorList;

        }

        internal List<IdentityError> Delete(int id)
        {
            var articulo = context.Articulo.FirstOrDefault(a => a.ArticuloID == id);

            try
            {
                context.Remove(articulo);
                context.SaveChanges();

                cod = "Save";
                des = "Save";

            }
            catch (Exception e)
            {
                cod = "Not save";
                des = e.Message;
            }

            errorList.Add(new IdentityError
            {
                Code = cod,
                Description = des
            });

            return errorList;
        }

        internal List<IdentityError> EditarArt(Articulo art)
        {
            try
            {
                var articulo = context.Articulo.SingleOrDefault(a => a.ArticuloID == art.ArticuloID);
                articulo.Codigo = art.Codigo;
                articulo.Nombre = art.Nombre;
                articulo.Stock = art.Stock;
                articulo.Descripcion = art.Descripcion;
                articulo.CategoriaID = art.CategoriaID;
                context.SaveChanges();

                cod = "Save";
                des = "Save";

            }
            catch (Exception ex)
            {
                cod = "Not save";
                des = ex.Message;

            }

            errorList.Add(new IdentityError
            {
                Code = cod,
                Description = des
            });

            return errorList;
        }

        internal List<Articulo> GetArticulo(int id)
        {
            return context.Articulo.Where(a => a.ArticuloID == id).ToList();  
        }


        /*
         buscar todos los articulos y los retorna como html
         @params: null
         @return: objeto html
         */
        internal List<object[]> ListarArticulos()
        {
            List<Object[]> data = new List<object[]>();
            var tbody = "";

            var articulos = context.Articulo.OrderBy(c => c.Nombre).ToList();

            foreach (var item in articulos)
            {
                var categoria = this.GetCategoria(item.CategoriaID);

                tbody += "<tr>" +
                            "<td>" + item.Codigo + "</td>" +
                            "<td>" + item.Nombre + "</td>" +
                            "<td>" + item.Stock + "</td>" +
                            "<td>" + categoria[0].Nombre + "</td>" +
                            "<td>" + item.Descripcion + "</td>" +
                            "<td>" +
                                "'<a href='#' class='btn btn-warning' onclick='editarArticulo("+ item.ArticuloID +", 0)'>" +
                                "<i class='fa fa-edit'></i></a>" +
                                "'<a href='#' class='btn btn-danger' onclick='eliminarArticulo(" + item.ArticuloID + ")'>" +
                                "<i class='fa fa-trash'></i></a>" +
                            "</td>" +

                         "</tr>";

            }

            Object[] dataObject = { tbody };
            data.Add(dataObject);
            return data;
        }

        internal List<Categoria> GetCategoria(int id)
        {
            return context.Categoria.Where(c => c.CategoriaID == id).ToList();
        }

         




        
       
    }
}
