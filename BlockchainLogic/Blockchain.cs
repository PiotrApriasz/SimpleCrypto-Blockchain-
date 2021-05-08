using System.Collections.Generic;

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

        public Blockchain()
        {
            TransactionPool = new List<Transaction>();
        }

        /// <summary>
        /// Add a transaction to pool
        /// </summary>
        /// <param name="trx">Transaction</param>
        public void AddTransactionPool(Transaction trx)
        {
            TransactionPool.Add(trx);
        }
        
    }
}