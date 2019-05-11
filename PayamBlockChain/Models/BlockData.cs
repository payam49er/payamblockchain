using System;
using Newtonsoft.Json;

namespace PayamBlockChain.Models
{
    public class BlockData
    {
        [JsonProperty("ClaimNumber",NullValueHandling = NullValueHandling.Ignore)]
        public string ClaimNumber { get; set; }
        
        [JsonProperty("SettlementAmount",NullValueHandling = NullValueHandling.Ignore)]
        public decimal SettlementAmount { get; set; }
        
        [JsonProperty("SettlementDate",NullValueHandling = NullValueHandling.Ignore)]
        public DateTime SettlementDate { get; set; }
        
        [JsonProperty("CarRegistration",NullValueHandling = NullValueHandling.Ignore)]
        public string CarRegistration { get; set; }
        
        [JsonProperty("Milage",NullValueHandling = NullValueHandling.Ignore)]
        public int Milage { get; set; }
        
        [JsonProperty("ClaimType",NullValueHandling = NullValueHandling.Ignore)]
        public ClaimType ClaimType { get; set; }
    }
}