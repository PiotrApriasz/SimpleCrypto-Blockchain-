using System;
using System.Text;
using BlockchainLogic;
using Newtonsoft.Json;

namespace Utils
{
    public static class Converter
    {
        /// <summary>
        ///     Convert string to array of byte
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public static byte[] ConvertToBytes(this string arg)
        {
            return Encoding.UTF8.GetBytes(arg);
        }

        /// <summary>
        ///     Convert transaction array to bytes array
        /// </summary>
        /// <param name="lsTrx">Transactions array</param>
        /// <returns></returns>
        public static byte[] ConvertToByte(this Transaction[] lsTrx)
        {
            var transactionsString = JsonConvert.SerializeObject(lsTrx);
            Console.WriteLine(transactionsString);
            return transactionsString.ConvertToBytes();
        }

        /// <summary>
        ///     Convert transaction array to string
        /// </summary>
        /// <param name="lsTrx"></param>
        /// <returns></returns>
        public static string ConvertToString(this Transaction[] lsTrx)
        {
            return JsonConvert.SerializeObject(lsTrx);
        }

        /// <summary>
        ///     Convert array of bytes to hex string
        /// </summary>
        /// <param name="ba">Bytes array</param>
        /// <returns></returns>
        public static string ConvertToHexString(this byte[] ba)
        {
            var hex = new StringBuilder(ba.Length * 2);

            foreach (var b in ba) hex.AppendFormat($"{b:x2}");

            return hex.ToString();
        }

        /// <summary>
        ///     Convert timestamp to datetime
        /// </summary>
        /// <param name="timestamp">Int64 timestamp</param>
        /// <returns></returns>
        public static string ConvertToDateTime(this long timestamp)
        {
            var myDate = new DateTime(timestamp);
            var strDate = myDate.ToString("dd MMM yyyy hh:mm:ss");
            return strDate;
        }
    }
}