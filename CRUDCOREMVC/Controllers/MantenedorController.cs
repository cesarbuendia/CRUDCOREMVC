using Microsoft.AspNetCore.Mvc;

using CRUDCOREMVC.Datos;
using CRUDCOREMVC.Models;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace CRUDCOREMVC.Controllers
{
    public class MantenedorController : Controller
    {


        ContactoDatos _ContactoDatos = new ContactoDatos(); 


        public IActionResult Listar()
        {
            // muestra la lista de contactos
            var oLista = _ContactoDatos.Listar();

            return View(oLista);
        }


        public IActionResult Guardar() 
        {            
            // solo devuelve la lista
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(ContactoModel oContacto)
        {
            // recibe el objeto para guardarlo en bd

            if(!ModelState.IsValid)
            {
                return View();
            }

            var respuesta = _ContactoDatos.Guardar(oContacto);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }


    }
}
