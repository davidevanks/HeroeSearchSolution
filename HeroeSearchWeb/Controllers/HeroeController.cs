using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeroeSearchWeb.Data.Interfaces;
using HeroeSearchWeb.Data.Models;
using Microsoft.AspNetCore.Http;

namespace HeroeSearchWeb.Controllers
{
    public class HeroeController : Controller
    {
        private readonly IDetailsRepository _Details;

        public HeroeController(IDetailsRepository DetailsRepository)
        {
            _Details = DetailsRepository;
        }
        [HttpGet("character/{id}")]
        public IActionResult Details(int id)
        {

            Task<Heroe> Response;
            Response = _Details.HeroesDetails(id);
            Response.Result.ValueSearch = HttpContext.Session.GetString("searchString");
            return View(Response);
        }
    }
}
