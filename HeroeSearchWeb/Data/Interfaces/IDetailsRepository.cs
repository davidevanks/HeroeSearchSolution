using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeroeSearchWeb.Data.Models;

namespace HeroeSearchWeb.Data.Interfaces
{
    public interface IDetailsRepository
    {
        public Task<Heroe> HeroesDetails(int Id);
    }
}
