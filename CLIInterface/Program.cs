using System;
using BlockchainLogic;
using Utils;

namespace CLIInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            var bc = new Blockchain();
            
            // Create new transaction
            var trx1 = new Transaction
            {
                TimeStamp = DateTime.Now.Ticks,
                Sender = "Bob",
                Recipient = "Ricardo",
                Amount = 10,
                Fee = 0.01
            };
            
            //Add transaction to a pool
            bc.AddTransactionToPool(trx1);
            
            var trx2 = new Transaction
            {
                TimeStamp = DateTime.Now.Ticks,
                Sender = "John",
                Recipient = "Ivanka",
                Amount = 20,
                Fee = 0.01
            };
            
            //Add transaction to a pool
            bc.AddTransactionToPool(trx2);

            var trx3 = new Transaction
            {
                TimeStamp = DateTime.Now.Ticks,
                Sender = "Robert",
                Recipient = "Frodo",
                Amount = 30,
                Fee = 0.01
            };
            
            //Add transaction to a pool
            bc.AddTransactionToPool(trx3);
            
            //Add a block to a blockchain
            bc.CreateBlock();
            
            //Clear transaction pool after block created
            bc.ClearPool();
            
            //Create new transaction again
            var trx4 = new Transaction
            {
                TimeStamp = DateTime.Now.Ticks,
                Sender = "Ricardo",
                Recipient = "Madona",
                Amount = 20,
                Fee = 0.0001
            };
            
            // add transaction to pool
            bc.AddTransactionToPool(trx4);
            
            //Add a block to a blockchain
            bc.CreateBlock();
            
            // clear transaction pool again
            bc.ClearPool();
            
            //Created 4 transactions and two blocks
            //All block already added to a blockchain
            
            //Some data from blockchain
            
            // print genesis block
            bc.PrintGenesisBlock();

            Console.WriteLine();
            
            // print last block
            bc.PrintLastBlock();

            Console.WriteLine();
            
            //check balance for Ricardo
            bc.PrintBalance("Ricardo");

            Console.WriteLine();
            
            //check balance for Frodo
            bc.PrintBalance("Frodo");

            Console.WriteLine();

            //check balance for Ivanka
            bc.PrintBalance("Ivanka");
            
            Console.WriteLine();

            bc.PrintTransactionHistory("Ricardo");
            
            Console.WriteLine();

            // print all block in Blockchain
            bc.PrintBlocks();

        }
    }
}