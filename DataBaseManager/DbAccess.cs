using BlockchainLogic;
using LiteDB;

namespace DataBaseManager
{
    public class DbAccess
    {
        public static LiteDatabase Db { get; set; }
        public const string DbName = @"node.db";
        
        /// <summary>
        ///  Table. Store all created blocks.
        /// </summary>
        public const string TblBlocks = "tbl_blocks";
        
        /// <summary>
        /// Table. Store all unconfirmed transactions.
        /// The contents of this table will be deleted after the block is created.
        /// </summary>
        public const string TblTransactionPool = "tbl_transaction_pool";
        
        /// <summary>
        /// Table. Store all confirmed transactions.
        /// </summary>
        public const string TblTransactions = "tbl_transactions";

        /// <summary>
        /// Create data base with  name node.db
        /// </summary>
        public static void Initialize()
        {
            Db = new LiteDatabase(DbName);
        }

        /// <summary>
        /// Delete all rows for all table
        /// </summary>
        public static void ClearDb()
        {
            var coll1 = Db.GetCollection<Block>(TblBlocks);
            coll1.DeleteAll();

            var coll2 = Db.GetCollection<Transaction>(TblTransactionPool);
            coll2.DeleteAll();

            var coll3 = Db.GetCollection<Transaction>(TblTransactions);
            coll3.DeleteAll();
        }

        /// <summary>
        /// Close data base when app closed
        /// </summary>
        public static void CloseDb()
        {
            Db.Dispose();
        }
    }
}