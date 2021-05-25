﻿using System;
using System.Collections.Generic;
using System.Threading;
using BlockchainLogic.Utils;
using LiteDB;
using Newtonsoft.Json;

namespace BlockchainLogic
{
    public class Blockchain
    {
        #region Constructor

        public Blockchain()
        {
            Initialize();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Create genesis bolock adn transaction for the genesis account. 
        /// </summary>
        private static void Initialize()
        {
            var blocks = 

            if (blocks.Count() < 1)
            {
                var gnsBlock = Block.Genesis();
                blocks.Insert(gnsBlock);

                CreateGenesisTransaction();
            }
        }

        /// <summary>
        /// Create transaction for genesis account.
        /// </summary>
        public static void CreateGenesisTransaction()
        {
            var newTrx = new Transaction()
            {
                TimeStamp = DateTime.Now.Ticks,
                Sender = "system",
                Recipient = "ga1",
                Amount = 1000000,
                Fee = 0
            };

            Transaction.AddToPool(newTrx);
            
            newTrx = new Transaction()
            {
                TimeStamp = DateTime.Now.Ticks,
                Sender = "system",
                Recipient = "ga2",
                Amount = 2000000,
                Fee = 0
            };
            Transaction.AddToPool(newTrx);
            
            var trxPool = Transaction.GetPool();
            var transactions = trxPool.FindAll();
            string tempTransactions = JsonConvert.SerializeObject(transactions);
            var lastBlock = GetLastBlock();
            var block = new Block(lastBlock, tempTransactions);
            
            AddBlock(block);
            
            foreach (Transaction trx in transactions)
            {
                Transaction.Add(trx);
            }

            // clear pool
            trxPool.DeleteAll();
        }

        /// <summary>
        /// Add a transaction to pool
        /// </summary>
        /// <param name="trx">Transaction</param>
        public void AddTransactionToPool(Transaction trx)
        {
            TransactionPool.Add(trx);
        }

        /// <summary>
        /// Clear transaction pool
        /// </summary>
        public void ClearPool()
        {
            TransactionPool = new List<Transaction>();
        }

        /// <summary>
        /// Get last block of blockchain
        /// </summary>
        /// <returns></returns>
        public Block GetLastBlock()
        {
            return Blocks[^1];
        }

        /// <summary>
        /// Create genesis block and add it to blockchain
        /// </summary>
        /// <returns></returns>
        private static Block CreateGenesisBlock()
        {
            var trx = new Transaction
            {
                Amount = 1000,
                Sender = "Founder",
                Recipient = "Genesis Account",
                Fee = 0.0001
            };

            var trxList = new List<Transaction> {trx};

            return new Block(1, string.Empty.ConvertToBytes(), trxList, "Admin");
        }

        /// <summary>
        /// Create new block
        /// </summary>
        public void CreateBlock()
        {
            var lastBlock = GetLastBlock();
            var nextHeight = lastBlock.Height + 1;
            var prevHash = lastBlock.Hash;
            var transactions = TransactionPool;
            var block = new Block(nextHeight, prevHash, transactions, "Admin");
            Blocks.Add(block);
        }

        /// <summary>
        /// Get transaction by name
        /// </summary>
        /// <param name="name">Sender or recipient name</param>
        public void PrintTransactionHistory(string name)
        {
            Console.WriteLine($"\n\n===== Transaction history for {name} =====");

            foreach (Block block in Blocks)
            {
                var transactions = block.Transactions;

                foreach (Transaction transaction in transactions)
                {
                    var sender = transaction.Sender;
                    var recipient = transaction.Recipient;

                    if (name.ToLower().Equals(sender.ToLower()) || name.ToLower().Equals(recipient.ToLower()))
                    {
                        Console.WriteLine($"Timestamp : {transaction.TimeStamp}");
                        Console.WriteLine($"Sender    : {transaction.Sender}");
                        Console.WriteLine($"Recipient : {transaction.Recipient}");
                        Console.WriteLine($"Amount    : {transaction.Amount}");
                        Console.WriteLine($"Fee       : {transaction.Fee}");
                        Console.WriteLine("------------------------------------");
                    }
                }
            }
        }

        /// <summary>
        /// Print balance by name
        /// </summary>
        /// <param name="name">Sender or recipient name</param>
        public void PrintBalance(string name)
        {
            Console.WriteLine($"\n\n==== Balance for {name} ====");
            double balance = 0;
            double spending = 0;
            double income = 0;
            
            foreach (Block block in Blocks)
            {
                var transactions = block.Transactions;

                foreach (var transaction in transactions)
                {

                    var sender = transaction.Sender;
                    var recipient = transaction.Recipient;

                    if (name.ToLower().Equals(sender.ToLower()))
                    {
                        spending += transaction.Amount + transaction.Fee;
                    }


                    if (name.ToLower().Equals(recipient.ToLower()))
                    {
                        income += transaction.Amount;
                    }

                    balance = income - spending;
                }
            }
            Console.WriteLine($"Balance : {balance}");
            Console.WriteLine("---------");
        }

        /// <summary>
        /// Print last block
        /// </summary>
        public void PrintLastBlock()
        {
            var lastBlock = GetLastBlock();
            PrintBlock(lastBlock);
        }
        
        /// <summary>
        /// Print first block from blockchain
        /// </summary>
        public void PrintGenesisBlock()
        {
            var block = Blocks[0];
            PrintBlock(block);
        }
        
        /// <summary>
        /// Print all blocks in blockchain
        /// </summary>
        public void PrintBlocks()
        {
            Console.WriteLine("\n\n====== Blockchain Explorer =====");

            foreach (Block block in Blocks)
            {
                PrintBlock(block);
            }
        }
        
        private void PrintBlock(Block block)
        {
            Console.WriteLine($"Height       :{block.Height}");
            Console.WriteLine($"Timestamp    :{block.TimeStamp.ConvertToDateTime()}");
            Console.WriteLine($"Prev. Hash   :{block.PrevHash.ConvertToHexString()}");
            Console.WriteLine($"Hash         :{block.Hash.ConvertToHexString()}");
            Console.WriteLine($"Transactions :{block.Transactions.ConvertToString()}");
            Console.WriteLine($"Creator      :{block.Creator}");
            Console.WriteLine("--------------");
        }

        #endregion
        
    }
}