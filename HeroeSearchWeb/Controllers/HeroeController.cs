using System;
using System.Threading.Tasks;
using HeroeSearchWeb.Data.Interfaces;
using HeroeSearchWeb.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace HeroeSearchWeb.Controllers
{
    public class HeroeController : Controller
    {
        private readonly IDetailsRepository _Details;
        private readonly IMemoryCache _memoryCache;

        public HeroeController(IDetailsRepository DetailsRepository, IMemoryCache memoryCache)
        {
            _Details = DetailsRepository;
            _memoryCache = memoryCache;
        }

        [HttpGet("character/{id}")]
        public IActionResult Details(int id)
        {
            var cacheKey = id;
            //Implementamos el sistema de cache para almacenar valores buscados y mejorar experiencia de usario.
            if (!_memoryCache.TryGetValue(cacheKey, out Task<Heroe> Response))
            {
                Response = _Details.HeroesDetails(id);

                var cacheExpirationsOptions =
                    new MemoryCacheEntryOptions
                    {
                        AbsoluteExpiration = DateTime.Now.AddHours(1),
                        Priority = CacheItemPriority.Normal,
                        SlidingExpiration = TimeSpan.FromMinutes(10)
                    };

                _memoryCache.Set(cacheKey, Response, cacheExpirationsOptions);
            }

            //Variable que guarda el valor buscado para utilizar en el boton regresar y mostrar criterio de busqueda ingresado
            Response.Result.ValueSearch = HttpContext.Session.GetString("searchString");
            //Si no encontramos resultados, retornamos la pagina NOT FOUND
            if (Response.Result.Id == null)
            {
                ViewBag.ErrorMessage = "Sorry, the resource you requested could not be found!";
                ViewBag.ErrorHeader = "HERO O VILLIAN NOT FOUND";
                return View("_NotFound");
            }

            ViewData["searchString"] = HttpContext.Session.GetString("searchString");
            return View(Response);
        }
    }
}