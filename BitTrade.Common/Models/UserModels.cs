using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitTrade.Common.Models
{
    public class UserModels
    {

        [JsonIgnore]
        public int ID { get; set; }
        public string FirstName { get; set; }

        [JsonProperty("Gmail")]
        public string Email { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? DateOfBirth { get; set; }
    }
}
