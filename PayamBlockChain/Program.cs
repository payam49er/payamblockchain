using System;
using Microsoft.Extensions.DependencyInjection;
using PayamBlockChain.Models;

namespace PayamBlockChain
{
    class Program
    {
        static void Main(string[] args)
        {
            IKeyStore keyStore = new KeyStore(HMAC.GenerateKey());
            TransactionPool txnPool = new TransactionPool();
            //todo: restructure the code to be able to use dependency injection. 
//            var serviceProvider = new ServiceCollection().AddSingleton<IComputeHash, ComputeHash>()
//                .BuildServiceProvider();
//            var computeHash = serviceProvider.GetService<IComputeHash>();

            IBlock block1 = new Block(0,keyStore,3);
            IBlock block2 = new Block(1,keyStore,3);
            IBlock block3 = new Block(2,keyStore,3);
            IBlock block4 = new Block(4,keyStore,3);

            BlockChain chain = new BlockChain();
            chain.AcceptBlock(block1.AddTransaction(txnPool.GetTransaction()));
            chain.AcceptBlock(block2);
            chain.AcceptBlock(block3);
            chain.AcceptBlock(block4);
            
            chain.VerifyChain();
            Console.WriteLine();
             
        }
    }
}