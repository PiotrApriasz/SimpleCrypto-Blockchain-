using System;
using System.Collections.Generic;
using System.Security.Cryptography;

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
        public Int64 TimeStamp { get; set; }
        /// <summary>
        /// Hash of previous block
        /// </summary>
        public byte[] PrevHash { get; set; }
        /// <summary>
        /// Unique Hash of the block
        /// </summary>
        public byte[] Hash { get; set; }
        /// <summary>
        /// Collections of transactions that occur
        /// </summary>
        public Transaction[] Transactions { get; set; }
        /// <summary>
        /// Creator of block identified by the public key
        /// </summary>
        public string Creator { get; set; }

        #endregion

        #region Constructor

        public Block(int height, byte[] prevHash, List<Transaction> transactions, string creator)
        {
            Height = height;
            PrevHash = prevHash;
            TimeStamp = DateTime.Now.Ticks;
            Transactions = transactions.ToArray();
            Hash = GenerateHash();
            Creator = creator;
        }

        #endregion

        #region Methods

        private byte[] GenerateHash()
        {
            var sha = SHA256.Create();
            byte[] timeStamp = BitConverter.GetBytes(TimeStamp);
        }

        #endregion
    }
}