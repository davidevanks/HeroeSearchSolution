using HeroeSearchWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HeroeSearchWeb.Data.Interfaces;
using HeroeSearchWeb.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;

namespace HeroeSearchWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISearchRepository _search;

        public HomeController(ISearchRepository SearchRepository)
        {
            _search = SearchRepository;
        }
        [HttpGet]
        public IActionResult Home()
        {
            return View();

        }

        public IActionResult Index(string searchString)
        {
            var cacheKey = "";
            searchString = searchString == null ? cacheKey = "" : cacheKey = searchString;

            ViewData["searchString"] = searchString;

            HttpContext.Session.SetString("searchString", cacheKey);
            Task<ResponseSearch> Heroes;
            Heroes = _search.Heroes(searchString);
            return View(Heroes);
        }

     
    }
}
