using System;
using BlockchainLogic;
using Utils;

namespace CLIInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create new transaction
            var trx1 = new Transaction
            {
                TimeStamp = DateTime.Now.Ticks,
                Sender = "Bob",
                Recipient = "Billy",
                Amount = 10,
                Fee = 0.01
            };
            
            var trx2 = new Transaction
            {
                TimeStamp = DateTime.Now.Ticks,
                Sender = "John",
                Recipient = "Ivanka",
                Amount = 20,
                Fee = 0.01
            };

            var trx3 = new Transaction
            {
                TimeStamp = DateTime.Now.Ticks,
                Sender = "Robert",
                Recipient = "Antonio",
                Amount = 30,
                Fee = 0.01
            };
        }
    }
}