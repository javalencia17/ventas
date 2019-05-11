using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ventas.Data;
using ventas.Models;

namespace ventas.ModelsClass
{
    public class SaleModels
    {
        private ApplicationDbContext context;
        private List<IdentityError> errorlist = new List<IdentityError>(); 
        private string cod = "";
        private string des = "";


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

        internal List<IdentityError> SaveSale(IngresoTemp venta)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
            
                    var comprobante = new Comprobante
                    {
                        Serie = Convert.ToString(venta.Serie),
                        Numero = Convert.ToString(venta.Numero),
                        Tipo = Convert.ToString(venta.Comprobante)
                    };

                    context.Comprobante.Add(comprobante);

                    DateTime now = DateTime.Now;

                    var sale = new Sale
                    {
                        Fecha = now,
                        PersonaID = venta.Persona,
                        ComprobanteID = comprobante.ComprobanteID,
                        Impuesto = 16
                    };

                    context.Sale.Add(sale);

                    for (int i = 0; i < venta.detalles.Count(); i++)
                    {
                        var detalle = new SaleDetail
                        {
                            ArticuloID = venta.detalles[i].ArticuloID,
                            PrecioVenta = venta.detalles[i].PrecioVenta,
                            Cantidad = venta.detalles[i].Cantidad,
                            SaleID = sale.SaleID
                        };

                        context.SaleDetail.Add(detalle);
                    }

                    context.SaveChanges();

                    transaction.Commit();

                    cod = "SAVE";
                    des = "SAVE";


                }
                catch (Exception e)
                {
                    transaction.Rollback();

                    cod = "NOT SAVE";
                    des = e.Message;
                }

                errorlist.Add(new IdentityError
                {
                    Code = cod,
                    Description = des
                });

                return errorlist;

            }
        }
    }
}
