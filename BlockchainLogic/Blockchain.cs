using System.Collections.Generic;

namespace BlockchainLogic
{
    public class Blockchain
    {
        /// <summary>
        /// Transaction pool
        /// </summary>
        public List<Transaction> TransactionPool { get; set; }

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