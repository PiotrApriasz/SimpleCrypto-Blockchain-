using LiteDB;

namespace DataBaseManager
{
    public class DbAccess
    {
        public static LiteDatabase Db { get; set; }
        public const string DbName = @"node.db";
        public const string TblBlocks = "tbl_blocks";
        public const string TblTransactionPool = "tbl_transaction_pool";
        public const string TblTransactions = "tbl_transactions";
    }
}