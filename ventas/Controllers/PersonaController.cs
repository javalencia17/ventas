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
    public class PersonaController : Controller
    {
        private ApplicationDbContext context;
        private PersonaModels persona;

        public PersonaController(ApplicationDbContext context)
        {
            this.context = context;
            persona = new PersonaModels(context);
        }

        public IActionResult Index()
        {
            return View();
        }


        public List<IdentityError> Save(Persona people)
        {
            return persona.save(people);
        }

        public List<Object[]> ListPerson()
        {
            return persona.ListPerson();
        }

        public List<Persona>getPersona(int id)
        {
            return persona.getPersona(id);
        }

        public List<IdentityError> EditPersona(Persona people)
        {
            return persona.EditPersona(people);
        }

        public List<IdentityError> DeletePersona(int id)
        {
            return persona.DeletePersona(id);
        }
    }
}