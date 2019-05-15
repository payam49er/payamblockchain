using System;
using System.Collections.Generic;

namespace PayamBlockChain.Models
{
    public class BlockChain:IBlockChain
    {
        public IBlock CurrentBlock { get; private set; }
        public IBlock HeadBlock { get; private set; }
        
        public List<IBlock> Blocks { get; }

        public BlockChain()
        {
            Blocks = new List<IBlock>();
        }
        
        public void AcceptBlock(IBlock block)
        {
            //first block, so it is the genesis block
            if (HeadBlock == null)
            {
                HeadBlock = block;
                HeadBlock.PreviousBlockHash = null;
            }

            CurrentBlock = block;
            Blocks.Add(block);
        }

        public void VerifyChain()
        {
            if (HeadBlock == null)
            {
                throw new InvalidOperationException("Genesis block is not set");
            }

            bool isValid = HeadBlock.IsValidChain(null, true);

            if (isValid)
            {
                Console.WriteLine("Block chain integrity intact");
            }
            else
            {
                Console.WriteLine("Blockchain is not valid. Data has been tampered");
            }
        }
    }
}