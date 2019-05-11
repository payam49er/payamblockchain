using System;
using System.Security.Claims;
using Newtonsoft.Json;

namespace PayamBlockChain.Models
{
    public class Block:IBlock
    {
        public BlockData BlockData { get; set; }

        [JsonProperty("BlockNumber")]
        public int BlockNumber { get; set; }
        
        [JsonProperty("CreatedDate")]
        public DateTime CreatedDate { get; set; }
        public string BlockHash { get; }
        
        public string PreviousBlockHash { get; set; }
        public IBlock NextBlock { get; set; }




        public Block(int blockNumber,string claimNumber, decimal settlementAmount, DateTime settlementDate, string carRegistration, int milage, ClaimType claimType, IBlock parent)
        {
            BlockNumber = blockNumber;
            BlockData.ClaimNumber = claimNumber;
            BlockData.SettlementAmount = settlementAmount;
            BlockData.SettlementDate = settlementDate;
            BlockData.CarRegistration = carRegistration;
            BlockData.Milage = milage;
            BlockData.ClaimType = claimType;
            CreatedDate = DateTime.UtcNow;
            SetBlockHash(parent);
        }
        
        
        public string CalculateBlockHash(string previousBlockHash)
        {
            //get the json string of the data
            //JsonConvert.ToString()
        }

        public void SetBlockHash(IBlock parent)
        {
            throw new NotImplementedException();
        }

      
        public bool IsValidChain(string prevBlockHash, bool verbose)
        {
            throw new NotImplementedException();
        }
    }
}