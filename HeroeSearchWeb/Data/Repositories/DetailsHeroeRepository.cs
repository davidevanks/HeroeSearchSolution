using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HeroeSearchWeb.Data.Interfaces;
using HeroeSearchWeb.Data.Models;
using Newtonsoft.Json;

namespace HeroeSearchWeb.Data.Repositories
{
    public class DetailsHeroeRepository:IDetailsRepository
    {
        /// <summary>
        /// Metodo utilizado para tyraer la información especifica del personaje seleccionado, se utiliza en el bóton See Details
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Detalle del heroe o villano seleccionado en la pantalla principal de busqueda</returns>
        public async Task<Heroe> HeroesDetails(int Id)
        {
            Heroe HeroesDetails = new Heroe();

            using (var httpclient = new HttpClient())
            {

                using (var response = httpclient.GetAsync($"https://www.superheroapi.com/api.php/10221230922474980/{Id}"))
                {
                    string jsonResponse = await response.Result.Content.ReadAsStringAsync();
                    HeroesDetails = JsonConvert.DeserializeObject<Heroe>(jsonResponse);


                }

            }

            return HeroesDetails;
        }
    }
}
