using Newtonsoft.Json;
using System.Collections.Generic;

namespace Lab09_Linq
{
    public class Geometry
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("coordinates")]
        public List<double> Coordinates { get; set; }
    }
}
