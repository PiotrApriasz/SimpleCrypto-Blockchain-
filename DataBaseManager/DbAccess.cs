using LiteDB;

namespace DataBaseManager
{
    public class DbAccess
    {
        public static LiteDatabase Db { get; set; }
        public const string DbName = @"node.db";

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
        public static void ClearDb<T>(Tables tableName)
        {
            var coll = Db.GetCollection<T>(tableName.ToString());
            coll.DeleteAll();
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