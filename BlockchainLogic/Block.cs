using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using BlockchainLogic.Utils;

namespace BlockchainLogic
{
    public class Block
    {
        #region Properties

        /// <summary>
        /// Sequence number of blocks
        /// </summary>
        public int Height { get; set; }
        /// <summary>
        /// The time when the block was created
        /// </summary>
        public long TimeStamp { get; set; }
        /// <summary>
        /// Hash of previous block
        /// </summary>
        public string PrevHash { get; set; }
        /// <summary>
        /// Unique Hash of the block
        /// </summary>
        public string Hash { get; set; }
        /// <summary>
        /// Collections of transactions that occur
        /// </summary>
        public string Transactions { get; set; }
        /// <summary>
        /// Creator of block identified by the public key
        /// </summary>
        //public string Creator { get; set; }

        #endregion

        #region Constructor

        public Block(Block lastBlock, string transactions)
        {
            Height = lastBlock.Height + 1;
            PrevHash = lastBlock.Hash;
            TimeStamp = DateTime.Now.Ticks;
            Transactions = transactions;
            Hash = GetHash(TimeStamp, lastBlock.Hash, transactions);
            //Creator = creator;    
        }
        
        public Block(int height, long timestamp, string lastHash, string hash, string transactions)
        {
            Height = height;
            TimeStamp = timestamp;
            PrevHash = lastHash;
            Hash = hash;
            Transactions = transactions;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Create genesis block
        /// </summary>
        /// <returns></returns>
        public static Block Genesis()
        {
            var ts = new DateTime(2021, 05, 25);
            var genesisTrx = "Genesis Block created by Aether on 2021 05 25";
            var hash = GetHash(ts.Ticks, "-", genesisTrx);
            var block = new Block(1, ts.Ticks, 
                Convert.ToBase64String(Encoding.ASCII.GetBytes("-")), hash, genesisTrx);
            return block;
        }
        
        /// <summary>
        /// Generate hash of current block
        /// </summary>
        /// <param name="timestamp"></param>
        /// <param name="lastHash"></param>
        /// <param name="transactions"></param>
        /// <returns></returns>
        public static string GetHash(long timestamp, string lastHash, string transactions)
        {
            SHA256 sha256 = SHA256.Create();
            var strSum = timestamp + lastHash + transactions;
            byte[] sumBytes = Encoding.ASCII.GetBytes(strSum);
            byte[] hashBytes = sha256.ComputeHash(sumBytes);
            return Convert.ToBase64String(hashBytes);
        }

        /*/// <summary>
        /// Generate hash of current block
        /// </summary>
        /// <returns></returns>
        public byte[] GenerateHash()
        {
            var sha = SHA256.Create();
            byte[] timeStamp = BitConverter.GetBytes(TimeStamp);
            var transactionHash = Transactions.ConvertToByte();
            byte[] headerBytes = new byte[timeStamp.Length + PrevHash.Length + transactionHash.Length];
            
            Buffer.BlockCopy(timeStamp, 0, headerBytes, 0, timeStamp.Length);
            Buffer.BlockCopy(PrevHash, 0, headerBytes, timeStamp.Length, PrevHash.Length);
            Buffer.BlockCopy(transactionHash, 0, headerBytes, timeStamp.Length
                                                                    + PrevHash.Length, transactionHash.Length);

            byte[] hash = sha.ComputeHash(headerBytes);
            
            return hash;
        }*/

        #endregion
    }
}