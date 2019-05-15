using System.Security.Cryptography;

namespace PayamBlockChain
{
    public interface IComputeHash
    {
        byte[] ComputeHashSha256(byte[] toBeHashed);
        byte[] ComputeHashSha512(byte[] toBeHashed);
        string GetHash256(string toBeHashed, string key);
        string GetHash512(string toBeHashed, string key);
    }
}