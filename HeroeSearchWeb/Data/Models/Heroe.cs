using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HeroeSearchWeb.Data.Models
{
    /// <summary>
    /// Clase principal Heroe. Abajo están las clases secundarias.
    /// </summary>
    public class Heroe
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("powerstats")]
        public Powerstats Powerstats { get; set; }
        [JsonProperty("biography")]
        public Biography Biography { get; set; }
        [JsonProperty("appearance")]
        public Appearance Appearance { get; set; }
        [JsonProperty("work")]
        public Work Work { get; set; }
        [JsonProperty("connections")]
        public Connections Connections { get; set; }

        [JsonProperty("image")]
        public ImageUrl Image { get; set; }
        public string ValueSearch { get; set; }

    }

    public class Powerstats
    {

        [JsonProperty("intelligence")]
        public string Intelligence { get; set; }
        [JsonProperty("strength")]
        public string Strength { get; set; }
        [JsonProperty("speed")]
        public string Speed { get; set; }
        [JsonProperty("durability")]
        public string Durability { get; set; }
        [JsonProperty("power")]
        public string Power { get; set; }
        [JsonProperty("combat")]
        public string Combat { get; set; }

    }

    public class Biography
    {
        [JsonProperty("full-name")]
        public string FullName { get; set; }
        [JsonProperty("alter-egos")]
        public string AlterEgo { get; set; }
        [JsonProperty("aliases")]
        public string[] Aliases { get; set; }

        [JsonProperty("place-of-birth")]
        public string PlaceOfBirth { get; set; }

        [JsonProperty("first-appearance")]
        public string firstappearance { get; set; }
        [JsonProperty("publisher")]
        public string Publisher { get; set; }
        [JsonProperty("alignment")]
        public string Alignment { get; set; }
    }

    public class Appearance
    {
        [JsonProperty("gender")]
        public string Gender { get; set; }
        [JsonProperty("race")]
        public string Race { get; set; }
        [JsonProperty("height")]
        public string[] Height { get; set; }
        [JsonProperty("weight")]
        public string[] Weight { get; set; }

        [JsonProperty("eye-color")]
        public string EyeColor { get; set; }
        [JsonProperty("hair-color")]
        public string HairColor { get; set; }
    }

    public class Work
    {

        [JsonProperty("occupation")]
        public string Occupation { get; set; }

        [JsonProperty("base")]
        public string Base { get; set; }
    }

    public class Connections
    {

        [JsonProperty("group-affiliation")]
        public string GroupAffiliation { get; set; }
        [JsonProperty("relatives")]
        public string Relatives { get; set; }
    }

    public class ImageUrl
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
