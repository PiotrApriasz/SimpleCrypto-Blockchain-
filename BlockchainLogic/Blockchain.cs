using System;
using System.Collections.Generic;
using BlockchainLogic.Utils;

namespace BlockchainLogic
{
    public class Blockchain
    {
        #region Properties

        /// <summary>
        /// Transaction pool
        /// </summary>
        public List<Transaction> TransactionPool { get; set; }

        /// <summary>
        /// Simulating database to hold blocks in blockchain
        /// </summary>
        public IList<Block> Blocks { get; set; }
        
        #endregion

        #region Constructor

        public Blockchain()
        {
            TransactionPool = new List<Transaction>();

            Blocks = new List<Block>
            {
                CreateGenesisBlock()
            };
        }

        #endregion

        #region Methods

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

        #endregion
        
    }
}