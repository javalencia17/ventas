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

        internal List<object[]> loadTable()
        {
            List<object[]> data = new List<object[]>();
            var tbody = "";

            var ingresos = context.Ingreso.OrderBy(i => i.IngresoID).ToList();

            foreach (var item in ingresos)
            {
                var proveedor = this.GetProveedor(item.PersonaID);
                var comprobante = this.GetComprobante(item.ComprobanteID);
                var tipoFactura = this.getTipoFactura(Convert.ToInt32(comprobante[0].Tipo));
                var estado = this.getEstado(item.Estado, item.IngresoID);
                var total = this.getTotal(item.IngresoID);

                tbody += "<tr>" +
                        "<td>" + item.Fecha + "</td>" +
                        "<td>" + proveedor[0].Nombre + "</td>" +
                        "<td>" +  tipoFactura + "</td>" +
                        "<td>" + item.Impuesto + "</td>" +
                        "<td>" + estado + "</td>" +
                        "<td>" + total + "</td>" +
                        "<td><a class='btn btn-primary' onclick='modalDetalles("+ item.IngresoID +")'>Detalles</a><a class='btn btn-danger'>Anular</a></td>" +
                        "</tr>";
            }

            Object[] dataObj = { tbody };
            data.Add(dataObj);
            return data;
        }

        private string getTotal(int ingresoID)
        {
            var ingreso = context.Ingreso
                                 .Join(context.DetalleIngreso,
                                        ing => ing.IngresoID,
                                        detail => detail.IngresoID,
                                        (ing, detail) => new { ing, detail })
                                        .Where(ing => ing.detail.IngresoID == ingresoID)
                                        .Sum(t => t.detail.PrecioCompra);

            return Convert.ToString(ingreso);
        }

        private string getEstado(int estado, int id)
        {
            string buton = "";
            if (estado == 1)
            {
                buton = "<a class='btn btn-success' onclick='editStateEntry("+id+")'>Activo<a/>";
            }
            else
            {
                buton = "<a class='btn btn-danger' onclick='editStateEntry(" + id + ")'>Activo<a/>";
            }

            return buton;
        }

        private string getTipoFactura(int tipo)
        {
            string valor = (tipo == 1) ? "Factura de venta" : "remision de ingreso";

            return valor;
        }

        private List<Comprobante> GetComprobante(int comprobanteID)
        {
            return context.Comprobante.Where(c => c.ComprobanteID == comprobanteID).ToList();
        }

        private List<Persona> GetProveedor(int personaID)
        {
            return context.Persona.Where(p => p.PersonaID == personaID).ToList();
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
                        PersonaID = ingreso.Persona
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
