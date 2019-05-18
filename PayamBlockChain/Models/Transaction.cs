using System;
using System.Text;
using Newtonsoft.Json;

namespace PayamBlockChain.Models
{
    public class Transaction:ITransaction
    {
        private readonly IComputeHash _computeHash;
        public string ClaimNumber { get; set; }
        public decimal SettlementAmount { get; private set; }
        public DateTime SettlementDate { get; private set; }
        public string CarRegistration { get; private set; }
        public int Milage { get; private set; }
        public ClaimType ClaimType { get; private set; }

        public Transaction(string claimNumber,decimal settlementAmount, DateTime settlementDate, string carRegistration, int milage,ClaimType claimType)
        {
            this.ClaimNumber = claimNumber;
            this.SettlementAmount = settlementAmount;
            this.SettlementDate = settlementDate;
            this.CarRegistration = carRegistration;
            this.Milage = milage;
            this.ClaimType = claimType;
            _computeHash = new ComputeHash();
        }
        public string CalculateTransactionHash()
        {
            
            string txStr = this.ClaimNumber + this.SettlementAmount + this.SettlementDate + this.CarRegistration +
                            this.Milage + this.ClaimType;

            return Convert.ToBase64String(_computeHash.ComputeHashSha256(Encoding.UTF8.GetBytes(txStr)));
        }
    }
}