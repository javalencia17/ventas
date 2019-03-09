using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ventas.Data;
using ventas.Models;

namespace ventas.ModelsClass
{
    public class PersonaModels
    {
        private ApplicationDbContext context;
        private List<IdentityError> errorList = new List<IdentityError>();
        private string cod = "";
        private string des = "";

        public PersonaModels (ApplicationDbContext context)
        {
            this.context = context;
        }

        internal List<IdentityError> save(Persona people)
        {
            var persona = new Persona()
            {
                Nombre = people.Nombre,
                TipoDocumento = people.TipoDocumento,
                TipoPersona = people.TipoPersona,
                NumeroDocumento = people.NumeroDocumento,
                Direccion = people.Direccion,
                Telefono = people.Telefono,
                Email = people.Email
            };

            try
            {
                context.Persona.Add(persona);
                context.SaveChanges();

                cod = "Save";
                des = "Save";
            }
            catch (Exception e)
            {
                cod = "Not save";
                des = e.Message;

            }

            errorList.Add(new IdentityError {
                Code = cod,
                Description = des
            });

            return errorList;
        }

        internal List<IdentityError> DeletePersona(int id)
        {
            try
            {
                var persona = context.Persona.FirstOrDefault(p => p.PersonaID == id);
                context.Remove(persona);
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

        internal List<IdentityError> EditPersona(Persona people)
        {

            try
            {
                var persona = context.Persona.SingleOrDefault(p => p.PersonaID == people.PersonaID);
                persona.Nombre = people.Nombre;
                persona.TipoPersona = people.TipoPersona;
                persona.TipoDocumento = people.TipoDocumento;
                persona.NumeroDocumento = people.NumeroDocumento;
                persona.Direccion = people.Direccion;
                persona.Telefono = people.Telefono;
                persona.Email = people.Email;
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

        internal List<Persona> getPersona(int id)
        {
            return context.Persona.Where(p => p.PersonaID == id).ToList();
        }

        internal List<Object[]> ListPerson()
        {

            List<Object[]> objeto = new List<object[]>();
            var data = "";
            var personas = context.Persona.OrderBy(c => c.Nombre).ToList();

            foreach (var item in personas)
            {
                data += "<tr>" +
                    "<td>" + item.Nombre + "</td>" +
                    "<td>" + this.tipoPersona(item.TipoPersona) + "</td>" +
                    "<td>" + this.tipoDocumento(item.TipoDocumento) + "</td>" +
                    "<td>" + item.NumeroDocumento + "</td>" +
                    "<td>" + item.Direccion + "</td>" +
                    "<td>" + item.Telefono + "</td>" +
                    "<td>" + item.Email + "</td>" +
                    "<td> " +
                        "<a class='btn btn-warning' onclick='modalEditar("+ item.PersonaID
                        +")'>Editar</a>" +
                        "<a class='btn btn-danger' onclick='eliminarPersona(" + item.PersonaID + ")'>Borrar</a>" +
                    "</td>" +
                    "</tr>";
            }

            object[] dataObj =  { data };
            objeto.Add(dataObj);

            return objeto;
            
        }

        internal String tipoPersona(int tipo)
        {
            string data = "";

            switch (tipo)
            {
                case 1:
                    data = "Cliente";
                    break;
                case 2:
                    data = "Proveedor";
                    break;
                default:
                    break;

            }
            return data;
        }

        internal String tipoDocumento(int tipo)
        {
            string data = "";

            switch (tipo)
            {
                case 1:
                    data = "CC";
                    break;
                case 2:
                    data = "NIT";
                    break;
                case 3:
                    data = "CE";
                    break;
                default:
                    break;

            }
            return data;
        }
    }
}
