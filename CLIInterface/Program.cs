using System;
using BlockchainLogic;
using Utils;

namespace CLIInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            var bc = new Blockchain();

            while (true)
            {
                Menu.PerformMenuActions();
            }

        }
    }
}