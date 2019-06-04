using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Clifton.Blockchain;
using Newtonsoft.Json;

namespace PayamBlockChain.Models
{
    public class Block:IBlock
    {
        private readonly IComputeHash _computeHash;
        private MerkleTree _merkleTree = new MerkleTree();
        
        public IList<ITransaction> Transactions { get; }
        public BlockData BlockData { get;}

        [JsonProperty("BlockNumber")]
        public int BlockNumber { get; private set; }
        
        [JsonProperty("CreatedDate")]
        public DateTime CreatedDate { get; private set; }
        public string BlockHash { get; private set; }
        
        public string PreviousBlockHash { get; set; }
        public IBlock NextBlock { get; set; }



        public Block(int blockNumber)
        {
            BlockNumber = blockNumber;
            CreatedDate = DateTime.UtcNow;
            Transactions = new List<ITransaction>();
            _computeHash = new ComputeHash();
        }

        public Block(int blockNumber,IKeyStore keyStore)
        {
            BlockNumber = blockNumber;
            Transactions = new List<ITransaction>();
            KeyStore = keyStore;
        }

        public void AddTransaction(ITransaction transaction)
        {
            Transactions.Add(transaction);
        }

        public string BlockSigniture { get; private set; }
        public IKeyStore KeyStore { get; private set; }


        public string CalculateBlockHash(string previousBlockHash)
        {
            //block header
            var blockHeader = BlockNumber + CreatedDate.ToString(CultureInfo.InvariantCulture) +
                              PreviousBlockHash;
            //get the json string of the data
            //var blockDataJsonString = JsonConvert.SerializeObject(BlockData);
            var combined = blockHeader + _merkleTree.RootNode;
            if (KeyStore == null)
            {
                return Convert.ToBase64String(_computeHash.ComputeHashSha256(Encoding.UTF8.GetBytes(combined)));                
            }

            return Convert.ToBase64String(HMAC.ComputeHmacsha256(Encoding.UTF8.GetBytes(combined),KeyStore.AuthenticatedHashKey));
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

            BuildMerkleTree();

            BlockHash = CalculateBlockHash(PreviousBlockHash);
        }

        private void BuildMerkleTree()
        {
            _merkleTree = new MerkleTree();
            foreach (ITransaction transaction in Transactions)
            {
                _merkleTree.AppendLeaf(MerkleHash.Create(transaction.CalculateTransactionHash()));
            }

            _merkleTree.BuildTree();
        }


        public bool IsValidChain(string prevBlockHash, bool verbose)
        {
            bool isValid = true;
            BuildMerkleTree();
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