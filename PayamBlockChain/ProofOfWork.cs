using Clifton.Core.ExtensionMethods;

namespace PayamBlockChain
{
    public class ProofOfWork
    {
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
            
        }
    }
}