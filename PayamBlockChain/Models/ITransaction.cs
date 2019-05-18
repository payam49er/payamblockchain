using System;
using System.Security.Claims;

namespace PayamBlockChain.Models
{
    public interface ITransaction
    {
        string ClaimNumber { get; set; }
        decimal SettlementAmount { get; }
        DateTime SettlementDate { get; }
        string CarRegistration { get; }
        int Milage { get; }
        ClaimType ClaimType { get; }
        string CalculateTransactionHash();
    }
}