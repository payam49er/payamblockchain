using System.Security.Cryptography;

namespace PayamBlockChain
{
    public interface IComputeHash
    {
        byte[] ComputeHashSha256(byte[] toBeHashed);
        
    }
}