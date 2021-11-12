using System;
using System.Threading.Tasks;
using HeroeSearchWeb.Data.Interfaces;
using HeroeSearchWeb.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace HeroeSearchWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISearchRepository _search;
        private readonly IMemoryCache _memoryCache;

        public HomeController(ISearchRepository SearchRepository, IMemoryCache memoryCache)
        {
            _search = SearchRepository;
            _memoryCache = memoryCache;
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

            if (!_memoryCache.TryGetValue(cacheKey, out Task<ResponseSearch> Heroes))
            {
                Heroes = _search.Heroes(searchString);

                var cacheExpirationsOptions =
                    new MemoryCacheEntryOptions
                    {
                        AbsoluteExpiration = DateTime.Now.AddHours(1),
                        Priority = CacheItemPriority.Normal,
                        SlidingExpiration = TimeSpan.FromMinutes(10)
                    };

                _memoryCache.Set(cacheKey, Heroes, cacheExpirationsOptions);
            }

            return View(Heroes);
        }
    }
}