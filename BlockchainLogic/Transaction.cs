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
    }
}