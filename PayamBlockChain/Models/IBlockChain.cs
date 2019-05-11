using PayamBlockChain.Models;

namespace PayamBlockChain
{
    public interface IBlockChain
    {
        void AcceptBlock (IBlock block);
        void VerifyChain ();
    }
}