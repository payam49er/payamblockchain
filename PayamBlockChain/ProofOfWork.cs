using System;
using System.Text;
using Clifton.Core.ExtensionMethods;

namespace PayamBlockChain
{
    public class ProofOfWork
    {
        private readonly IComputeHash _computeHash = new ComputeHash();
        public string _dataToHash { get; private set; }
        public int DegreeOfDifficulty { get; private set; }
        public int Nonce { get; private set; }

        public ProofOfWork(string dataToHash, int degreeOfDifficulty)
        {
            _dataToHash = dataToHash;
            DegreeOfDifficulty = degreeOfDifficulty;
        }

        public string CalculateProofOfWork()
        {
            string difficulty = DegreeOfDifficulty.to_s();

            while (true)
            {
                string hashedData =
                    Convert.ToBase64String(_computeHash.ComputeHashSha256(Encoding.UTF8.GetBytes(Nonce + _dataToHash)));
                if (hashedData.StartsWith(difficulty,StringComparison.Ordinal))
                {
                    Console.WriteLine($"Difficulty level is {difficulty} with the nonce of {Nonce}");
                    return hashedData;
                }

                Nonce++;
            }
            
        }
    }
}