using System;
using Spectre.Console;

namespace CLIInterface
{
    public static class Menu
    {
        private static string MenuOptions()
        {
            var choose = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("--------- CRYPTOCURRENCY MENU ---------")
                    .PageSize(9)
                    .AddChoices(new[] {
                        "Genesis Block", "Last Block", 
                        "Send Coin", "Create Block (mining)", "Check Balance",
                        "Transaction History", "Blockchain Explorer", "Exit"
                    }));

            return choose;
        }

        public static void PerformMenuActions()
        {
            var choose = MenuOptions();

            switch (choose)
            {
                case "Genesis Block":
                    Console.WriteLine("DoGenesisBlock()");
                    
                    break;
                case "Last Block":
                    
                    Console.WriteLine("DoLastBlock();");
                    break;
                case "Send Coin":
                    
                    Console.WriteLine("DoSendCoin();");
                    break;
                case "Create Block (mining)":
                    
                    Console.WriteLine("DoCreateBlock();");
                    break;
                case "Check Balance":
                    
                    Console.WriteLine("DoCheckBalance();");
                    break;
                case "Transaction History":
                    
                    Console.WriteLine("DoTransactionHistory();");
                    break;
                case "Blockchain Explorer":
                    
                    Console.WriteLine("DoBlockchain();");
                    break;
                case "Exit":
                    Environment.Exit(0);
                    break;
            }
        }
    }
}