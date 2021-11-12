using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeroeSearchWeb.Data.Models;

namespace HeroeSearchWeb.Data.Interfaces
{
    public interface ISearchRepository
    {
        public Task<ResponseSearch> Heroes(string valueSearch);
    }
}
