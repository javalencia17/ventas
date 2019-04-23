using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ventas.Data;
using ventas.Models;

namespace ventas.ModelsClass
{
    public class IngresoModels
    {
        private ApplicationDbContext context;
        private List<IdentityError> errorList = new List<IdentityError>();
        private string cod = "";
        private string des = "";


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

        internal List<IdentityError> GuardarIngresos(IngresoTemp ingreso)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {

                    var comprobante = new Comprobante
                    {
                        Tipo = Convert.ToString(ingreso.Comprobante),
                        Serie = Convert.ToString(ingreso.Serie),
                        Numero = Convert.ToString(ingreso.Numero)
                    };

                    context.Comprobante.Add(comprobante);

                    DateTime now = DateTime.Now;

                    var ing = new Ingreso
                    {
                        Fecha = now,
                        Impuesto = 16,
                        ComprobanteID = comprobante.ComprobanteID,
                        PersonaID = ingreso.Proveedor 
                    };

                    context.Ingreso.Add(ing);


                    for (int i = 0; i < ingreso.detalles.Count(); i++)
                    {
                       
                        var detalles = new DetalleIngreso
                        {
                            Cantidad = ingreso.detalles[i].Cantidad,
                            PrecioCompra = ingreso.detalles[i].PrecioCompra,
                            PrecioVenta = ingreso.detalles[i].PrecioVenta,
                            IngresoID = ing.IngresoID,
                            ArticuloID = ingreso.detalles[i].ArticuloID
                        };

                        context.DetalleIngreso.Add(detalles);
                    }

                    context.SaveChanges();
                    // Commit transaction if all commands succeed, transaction will auto-rollback
                    // when disposed if either commands fails
                    transaction.Commit();

                    cod = "SAVE";
                    des = "SAVE";

                }
                catch (Exception e)
                {
                    cod = "NOT SAVE";
                    des = e.Message;

                    transaction.Rollback();
                }
            }
            errorList.Add(new IdentityError
            {
                Code = cod,
                Description = des
            });

            return errorList;
        }

        internal void addStock(int ArticuloID, int Cantidad)
        {
            var articulo = context.Articulo.FirstOrDefault(a => a.ArticuloID == ArticuloID);
            articulo.Stock = articulo.Stock + Cantidad;
            context.SaveChanges();
        }
    }
}
