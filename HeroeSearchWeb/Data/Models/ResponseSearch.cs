using System.Collections.Generic;
using Newtonsoft.Json;

namespace HeroeSearchWeb.Data.Models
{
    /// <summary>
    /// Clase utilizada para recibir el response.
    /// </summary>
    public class ResponseSearch
    {
        [JsonProperty("response")]
        public string MessageResponse { get; set; }
        [JsonProperty("results-for")]
        public string Resultsfor { get; set; }
        [JsonProperty("results")]
        public List<Heroe> ListHeroes { get; set; }
        [JsonProperty("error")]
        public string MessageError { get; set; }
        public string ValueSearch { get; set; }
    }
}
