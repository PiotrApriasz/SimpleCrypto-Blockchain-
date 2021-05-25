using System;
using System.Collections.Generic;
using System.Threading;
using BlockchainLogic.Utils;
using DataBaseManager;
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
        /// Create genesis block and transaction for the genesis account. 
        /// </summary>
        private static void Initialize()
        {
            var blocks = DbAccess.GetEntries<Block>(Tables.tbl_blocks);
            blocks.EnsureIndex(x => x.Height);

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
            
            // Add transaction to pool
            DbAccess.AddEntry(newTrx, Tables.tbl_transaction_pool);
            
            newTrx = new Transaction()
            {
                TimeStamp = DateTime.Now.Ticks,
                Sender = "system",
                Recipient = "ga2",
                Amount = 2000000,
                Fee = 0
            };
            
            // Add transaction to pool
            DbAccess.AddEntry(newTrx, Tables.tbl_transaction_pool);

            var trxPool = DbAccess.GetEntries<Transaction>(Tables.tbl_transactions);
            var transactions = trxPool.FindAll();
            string tempTransactions = JsonConvert.SerializeObject(transactions);
            var lastBlock = DbAccess.GetLastEntry<Block>(Tables.tbl_blocks);
            var block = new Block(lastBlock, tempTransactions);
            
            DbAccess.AddEntry(block, Tables.tbl_blocks);
            
            foreach (Transaction trx in transactions)
            {
                DbAccess.AddEntry(trx, Tables.tbl_transactions);
            }

            // clear pool
            trxPool.DeleteAll();
        }

        /// <summary>
        /// Returns blockchain height
        /// </summary>
        /// <returns></returns>
        public static int GetHeight()
        {
            var lastBlock = DbAccess.GetLastEntry<Block>(Tables.tbl_blocks);
            return lastBlock.Height;
        }
        
        #endregion
        
    }
}