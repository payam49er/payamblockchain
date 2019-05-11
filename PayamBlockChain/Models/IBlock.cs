using System;

namespace PayamBlockChain.Models
{
    public interface IBlock
    {
        //Data Block
        BlockData BlockData { get; set; }        
        // Block Header
        int BlockNumber { get; set; }
        DateTime CreatedDate { get; set; }
        string BlockHash { get; }
        string PreviousBlockHash { get; set; }
        IBlock NextBlock { get; set; }
        
        
        //Crypto methods
        string CalculateBlockHash (string previousBlockHash);
        void SetBlockHash (IBlock parent);
        bool IsValidChain (string prevBlockHash, bool verbose);
    }
}