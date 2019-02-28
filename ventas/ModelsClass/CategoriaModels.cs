using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ventas.Data;
using ventas.Models;

namespace ventas.ModelsClass
{
    public class CategoriaModels
    {
        private ApplicationDbContext context;
        private List<IdentityError> errorList = new List<IdentityError>();
        private string code = "", des = "";

        public CategoriaModels(ApplicationDbContext context)
        {
            this.context = context;
        }

        internal List<IdentityError> Crear(string nombre, string descripcion)
        {

            var categoria = new Categoria
            {
                Nombre = nombre,
                Descripcion = descripcion
            };

            try
            {
                context.Categoria.Add(categoria);
                context.SaveChanges();
                code = "Save";
                des = "Save";
            }
            catch (Exception ex)
            {
                code = "No save";
                des = ex.Message;

            }
            errorList.Add(new IdentityError
            {
                Code = code,
                Description = des
            });

            return errorList;
        }

        internal List<IdentityError> Editar(int id, string nombre, string descripcion)
        {

            try
            {
                var categoria = context.Categoria.SingleOrDefault(c => c.CategoriaID == id);
                categoria.Nombre = nombre;
                categoria.Descripcion = descripcion;
                context.SaveChanges();
                code = "Save";
                des = "Save";

            }
            catch (Exception ex)
            {
                code = "Not save";
                des = ex.Message;

            }

            errorList.Add(new IdentityError
            {
                Code = code,
                Description = des
            });

            return errorList;
        }

        internal List<IdentityError> Eliminar(int id)
        {
            var categoria = context.Categoria.SingleOrDefault(c => c.CategoriaID == id);

            try
            {
                context.Remove(categoria);
                context.SaveChanges();
                code = "Save";
                des = "Save";

            }
            catch (Exception ex)
            {
                code = "Not Save";
                des = ex.Message;

            }

            errorList.Add(new IdentityError
            {
                Code = code,
                Description = des
            });

            return errorList;

        }

        internal List<IdentityError> EditarEstado(int idCategoria)
        {
            try
            {
                var categoria = context.Categoria.SingleOrDefault(c => c.CategoriaID == idCategoria);
                if (categoria != null)
                {
                    if (categoria.Condicion == 1)
                    {
                        categoria.Condicion = 0;
                    }
                    else
                    {
                        categoria.Condicion = 1;
                    }
                    context.SaveChanges();
                }

                code = "Save";
                des = "Save";

            }
            catch (Exception ex)
            {
                code = "No save";
                des = ex.Message;
                throw;
            }

            errorList.Add(new IdentityError
            {
                Code = code,
                Description = des
            });

            return errorList;
        }

        internal List<Categoria> GetCategoria(int id)
        {
            return context.Categoria.Where(c => c.CategoriaID == id).ToList();
        }

        internal List<object[]> Listar()
        {
            string rows = "";
            string estado = "";
            List<object[]> data = new List<object[]>();
            List<Categoria> categorias;
            categorias = context.Categoria.ToList();

            foreach (var item in categorias)
            {
                if (item.Condicion == 1)
                {
                    estado = "<a onclick='editarEstadoCategoria(" + item.CategoriaID + ")'  class='btn btn-success'>" +
                       "Activo</a> ";
                }
                else
                {
                    estado = "<a onclick='editarEstadoCategoria(" + item.CategoriaID + ")'  class='btn btn-danger'>" +
                        "No activo</a> ";
                }

                rows += "<tr>" +
                      "<td>" + item.Nombre + "</td>" +
                      "<td>" + item.Descripcion + "</td>" +
                      "<td>" + estado + "</td>" +
                      "<td><a onclick='editarCategoria(" + item.CategoriaID + ',' + 1 + ")'  class='btn btn-success'>" +
                       "Editar</a><a onclick='eliminarCategoria(" + item.CategoriaID + ")'  class='btn btn-danger'>" +
                       "Borrar</a>" +
                       "</td>" +
                      "</tr>";
            }


            object[] dataObj = { rows };
            data.Add(dataObj);

            return data;
        }
    }
}
