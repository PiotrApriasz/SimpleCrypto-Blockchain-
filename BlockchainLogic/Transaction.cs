using System.Collections.Generic;
using DataBaseManager;

namespace BlockchainLogic
{
    public class Transaction
    {
        #region Properties

        public long TimeStamp { get; set; }
        public string Sender { get; set; }
        public string Recipient { get; set; }
        public double Amount { get; set; }
        public double Fee { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Get transaction list by name
        /// </summary>
        /// <param name="name">Sender or Recipient name</param>
        /// <returns></returns>
        public static IEnumerable<Transaction> GetHistory(string name)
        {
            var coll = DbAccess.GetEntries<Transaction>(Tables.tbl_transactions);
            var transactions = coll.Find(x => x.Sender == name ||
                                              x.Recipient == name);
            return transactions;
        }

        /// <summary>
        /// Get balance by name
        /// </summary>
        /// <param name="name">Sender or Recipient name</param>
        /// <returns></returns>
        public static double GetBalance(string name)
        {
            double balance = 0;
            double spending = 0;
            double income = 0;

            var coll = DbAccess.GetEntries<Transaction>(Tables.tbl_transactions);
            var transactions = coll.Find(x => x.Sender == name ||
                                              x.Recipient == name);

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

            return balance;
        }

        #endregion
    }
}