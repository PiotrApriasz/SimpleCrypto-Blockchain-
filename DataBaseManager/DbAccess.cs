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
        /// Returns all data from selected table
        /// </summary>
        /// <param name="tableName">Selected table</param>
        /// <typeparam name="T">Type of data in selected table</typeparam>
        /// <returns></returns>
        public static ILiteCollection<T> GetEntries<T>(Tables tableName)
        {
            var coll = Db.GetCollection<T>(tableName.ToString());
            return coll;
        }

        /// <summary>
        /// Get first entry from data base, for example genesis block
        /// </summary>
        /// <param name="tableName">Selected table</param>
        /// <typeparam name="T">Type of data in selected table</typeparam>
        /// <returns></returns>
        public static T GetFirstEntry<T>(Tables tableName)
        {
            var entries = GetEntries<T>(tableName);
            var entry = entries.FindOne(Query.All(Query.Ascending));

            return entry;
        }

        /// <summary>
        /// Get last entry from data base, for example last block
        /// </summary>
        /// <param name="tableName">Selected table</param>
        /// <typeparam name="T">Type of data in selected table</typeparam>
        /// <returns></returns>
        public static T GetLastEntry<T>(Tables tableName)
        {
            var entries = GetEntries<T>(tableName);
            var entry = entries.FindOne(Query.All(Query.Descending));

            return entry;
        }

        public static void AddEntry<T>(T element, Tables tableName)
        {
            var entries = GetEntries<T>(tableName);
            entries.Insert(element);
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