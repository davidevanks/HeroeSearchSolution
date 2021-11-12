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
    public class SearchRepository:ISearchRepository
    {
        /// <summary>
        /// Metodo que recibe el nombre del supervillano o superheroe, consume un api
        ///publica y gratuita. Este metodo se utiliza para la implementación de la busqueda en la pantalla principal
        /// </summary>
        /// <param name="ValueSearch"></param>
        /// <returns>Modelo con el response</returns>

        public async Task<ResponseSearch> Heroes(string ValueSearch)
        {
            ResponseSearch Heroes = new ResponseSearch();

            using (var httpclient = new HttpClient())
            {

                using (var response = httpclient.GetAsync($"https://superheroapi.com/api/10221230922474980/search/{ValueSearch}"))
                {
                    string jsonResponse = await response.Result.Content.ReadAsStringAsync();
                    Heroes = JsonConvert.DeserializeObject<ResponseSearch>(jsonResponse);
                    Heroes.ValueSearch = ValueSearch;

                }

            }

            return Heroes;
        }

    }
}
