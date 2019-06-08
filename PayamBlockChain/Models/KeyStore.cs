using System;

namespace PayamBlockChain.Models
{
    public class KeyStore:IKeyStore
    {
        private readonly DigitalSigniture _digitalSigniture;
        public byte[] AuthenticatedHashKey { get; }

        public KeyStore(byte[] authenticatedHashKey)
        {
            AuthenticatedHashKey = authenticatedHashKey;
            _digitalSigniture = new DigitalSigniture();
            _digitalSigniture.AssignNewKey();
        }
        public string SignBlock(string blockHash)
        {
            return Convert.ToBase64String(_digitalSigniture.SignData256(Convert.FromBase64String(blockHash)));
        }

        public bool VerifyBlock(string blockHash, string signiture)
        {
            return _digitalSigniture.VerifySigniture(Convert.FromBase64String(blockHash),
                Convert.FromBase64String(signiture));
        }
    }
}