using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroeSearchWeb.Controllers
{
    public class ErrorController : Controller
    {
        /// <summary>
        /// Controlador que entraliza los errores para mostrar la página not found. Se hace una configuración en el
        /// Startup.cs. 
        /// </summary>
        /// <param name="statusCode"></param>
        /// <returns></returns>
        [Route("Error/{statusCode}")]
        public IActionResult HttStatusCodeHandler(int statusCode)
        {

            switch (statusCode)
            {

                case 404:
                    ViewBag.ErrorMessage = "Sorry, the resource you requested could not be found!";
                    ViewBag.ErrorHeader = "404 NOT FOUND";
                    break;
            }
            return View("_NotFound");
        }
    }
}
