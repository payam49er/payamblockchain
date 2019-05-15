using System;
using System.Globalization;
using System.Text;
using Newtonsoft.Json;

namespace PayamBlockChain.Models
{
    public class Block:IBlock
    {
        private readonly IComputeHash _computeHash;
        public BlockData BlockData { get;}

        [JsonProperty("BlockNumber")]
        public int BlockNumber { get; set; }
        
        [JsonProperty("CreatedDate")]
        public DateTime CreatedDate { get; private set; }
        public string BlockHash { get; private set; }
        
        public string PreviousBlockHash { get; set; }
        public IBlock NextBlock { get; set; }



        public Block(int blockNumber,string claimNumber, decimal settlementAmount, DateTime settlementDate, string carRegistration, int milage, ClaimType claimType, IBlock parent)
        {
            _computeHash = new ComputeHash();
            BlockData = new BlockData();
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
            //block header
            var blockHeader = BlockNumber + CreatedDate.ToString(CultureInfo.InvariantCulture) + PreviousBlockHash;
            //get the json string of the data
            var blockDataJsonString = JsonConvert.SerializeObject(BlockData);
            var combined = blockHeader + blockDataJsonString;
            return Convert.ToBase64String(_computeHash.ComputeHashSha256(Encoding.UTF8.GetBytes(combined)));

        }

        public void SetBlockHash(IBlock parent)
        {
            if (parent != null)
            {
                PreviousBlockHash = parent.BlockHash;
                parent.NextBlock = this;
            }
            else
            {
                PreviousBlockHash = null;
            }

            BlockHash = CalculateBlockHash(PreviousBlockHash);
        }

      
        public bool IsValidChain(string prevBlockHash, bool verbose)
        {
            bool isValid = true;
            //is this a valid block and transaction
            string newBlockHash = CalculateBlockHash(prevBlockHash);

            if (newBlockHash != BlockHash)
            {
                isValid = false;
            }
            else
            {
                isValid |= PreviousBlockHash == prevBlockHash;
            }

            if (NextBlock != null)
            {
                return NextBlock.IsValidChain(newBlockHash, verbose);
            }

            return isValid;
        }

    }
}