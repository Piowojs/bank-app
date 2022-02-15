using System;
using System.Collections.Generic;

namespace bank_app.Models
{
    public class User
    {
        public string UserName  {get; }

        public string Password {get; }

        public string[] name = {"USD", "EUR", "GBP", "CHF", "AED", "AUD", "CAD", "UAH", "HRK", "DKK", "NOK", "SEK", "RON", "BGN", "TRY", "XDR", "ZAR", "RUB", "CNY"};

        public List<Guid> Accounts = new List<Guid>();

        public User(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public void addPersonalAccount(ref List<PersonalAccount> accs)
        {
            Console.WriteLine("Provide this account's initial balance:");
            int balance = int.Parse(Console.ReadLine());
            PersonalAccount acc = new PersonalAccount(balance);
            accs.Add(acc);
            Accounts.Add(acc.Id);
        }

        public void addSavingsAccount(ref List<SavingsAccount> accs)
        {
            Console.WriteLine("Provide this account's initial balance:");
            int balance = int.Parse(Console.ReadLine());
            SavingsAccount acc = new SavingsAccount(balance);
            accs.Add(acc);
            Accounts.Add(acc.Id);
        }

        public void addCurrencyAccount(ref List<CurrencyAccount> accs)
        {
            string curr = " ";
            while (!name.Contains(curr))
            {
                Console.WriteLine("Provide this account's currency:");
                curr = Console.ReadLine();
                if (!name.Contains(curr))
                {
                    Console.WriteLine("Unvalid currency, try again! Choose one of those: USD , EUR, GBP, CHF, AED, AUD, CAD, UAH, HRK, DKK, NOK, SEK, RON, BGN, TRY, XDR, ZAR, RUB, CNY.");
                }

            }

            Console.WriteLine("Provide this account's initial balance:");
            int balance = int.Parse(Console.ReadLine());
            CurrencyAccount acc = new CurrencyAccount(balance, curr);
            accs.Add(acc);
            Accounts.Add(acc.Id);
        }

        public void myPersonalAccounts(List<PersonalAccount> accs){
            Console.WriteLine("Your Personal Accounts:\n");
            Console.WriteLine("\tUsername:\t" + UserName + "\n");
            foreach(var id in Accounts)
            {
                // if(accs.Exists(x => x.Id == id))
                // {
                var item = accs.FirstOrDefault(x => x.Id == id);
                if(item != null){
                    item.AccInformation();
                }

                Console.WriteLine("\n");
            }
        }

        public void mySavingsAccounts(List<SavingsAccount> accs){
            Console.WriteLine("Your Savings Accounts:\n");
            Console.WriteLine("\tUsername:\t" + UserName + "\n");
            foreach(var id in Accounts)
            {
                // if(accs.Exists(x => x.Id == id))
                // {
                var item = accs.FirstOrDefault(x => x.Id == id);
                if(item != null){
                    item.AccInformation();
                }

                Console.WriteLine("\n");
            }
        }

        public void myCurrencyAccounts(List<CurrencyAccount> accs){
            Console.WriteLine("Your Currency Accounts:\n");
            Console.WriteLine("\tUsername:\t" + UserName + "\n");
            foreach(var id in Accounts)
            {
                var item = accs.FirstOrDefault(x => x.Id == id);
                if(item != null){
                    item.AccInformation();
                }

                Console.WriteLine("\n");
            }
        }

        public void myAccounts(List<PersonalAccount> accs1, List<SavingsAccount> accs2, List<CurrencyAccount> accs3)
        {
            this.myPersonalAccounts(accs1);
            this.mySavingsAccounts(accs2);
            this.myCurrencyAccounts(accs3);

        }

        public void Transfer(List<PersonalAccount> accs1, List<SavingsAccount> accs2, List<CurrencyAccount> accs3)
        {
            // Guid ReceiverId;

            // PersonalAccount SenderPersonal;
            // SavingsAccount SenderSavings;
            // CurrencyAccount SenderCurrency;

            // PersonalAccount ReceiverPersonal;
            // SavingsAccount ReceiverSavings;
            // CurrencyAccount ReceiverCurrency;
            string curr;


            int Index;
            int i = 0;
            foreach(var id in Accounts)
            {

                if(accs1.Exists(x => x.Id == id))
                {
                    Console.WriteLine("Account's index is (" + i + ")");
                    var item = accs1.FirstOrDefault(x => x.Id == id);
                    if(item != null){
                        item.AccInformation();
                    }
                    i++;
                }
                else if(accs2.Exists(x => x.Id == id))
                {
                    // Console.WriteLine("Account's index is (" + i + ")");
                    var item = accs2.FirstOrDefault(x => x.Id == id);
                    if(item != null){
                        item.AccInformation();
                    }
                    i++;
                }
                else if(accs3.Exists(x => x.Id == id))
                {
                    // Console.WriteLine("Account's index is (" + i + ")");
                    var item = accs3.FirstOrDefault(x => x.Id == id);
                    if(item != null){
                        item.AccInformation();
                    }
                    i++;
                }
            }


            Console.WriteLine("Choose account's index from which you'd like to transfer money:");
            string inp = Console.ReadLine();
            if(!int.TryParse(inp, out Index)){
                return;
            }
            if(Index < 0 || Index > Accounts.Count)
            {
                return;
            }
            Console.WriteLine("Paste account's id which would recieve money:");
            Guid ReceiverId = Guid.Parse(Console.ReadLine());
            Console.WriteLine("type in the amount of founds to transfer:");
            int Amount;
            string inp2 = Console.ReadLine();
            if(!int.TryParse(inp2, out Amount))
            {
                return;
            }
            if(accs1.Exists(x => x.Id == Accounts[Index]))
                {
                    var SenderAccount = accs1.FirstOrDefault(x => x.Id == Accounts[Index]);
                    SenderAccount.Withdraw(Amount);
                    curr = SenderAccount.Currency;


                }
                // else if(accs2.Exists(x => x.Id == Accounts[Index]))
                // {

                //     var SenderAccount = accs2.FirstOrDefault(x => x.Id == Accounts[Index]);
                //     SenderAccount.Withdraw(100);
                //     curr = SenderAccount.Currency;

                // }
                // else if(accs3.Exists(x => x.Id == Accounts[Index]))
                // {
                //     var SenderAccount = accs3.FirstOrDefault(x => x.Id == Accounts[Index]);
                //     SenderAccount.Withdraw(100);
                //     curr = SenderAccount.Currency;
                // }

            if(accs1.Exists(x => x.Id == ReceiverId))
                {
                    var ReceiverAccount = accs1.FirstOrDefault(x => x.Id == ReceiverId);
                    ReceiverAccount.Deposit(Amount);
                }

        }

        public void myWithdraw(List<PersonalAccount> accs1, List<SavingsAccount> accs2, List<CurrencyAccount> accs3)
        {

            // Guid ReceiverId;

            // PersonalAccount SenderPersonal;
            // SavingsAccount SenderSavings;
            // CurrencyAccount SenderCurrency;

            // PersonalAccount ReceiverPersonal;
            // SavingsAccount ReceiverSavings;
            // CurrencyAccount ReceiverCurrency;
            // string curr;


            int Index;
            int i = 0;
            foreach(var id in Accounts)
            {

                if(accs1.Exists(x => x.Id == id))
                {
                    Console.WriteLine("Account's index is (" + i + ")");
                    var item = accs1.FirstOrDefault(x => x.Id == id);
                    if(item != null){
                        item.AccInformation();
                    }
                    i++;
                }
                else if(accs2.Exists(x => x.Id == id))
                {
                    Console.WriteLine("Account's index is (" + i + ")");
                    var item = accs2.FirstOrDefault(x => x.Id == id);
                    if(item != null){
                        item.AccInformation();
                    }
                    i++;
                }
                else if(accs3.Exists(x => x.Id == id))
                {
                    Console.WriteLine("Account's index is (" + i + ")");
                    var item = accs3.FirstOrDefault(x => x.Id == id);
                    if(item != null){
                        item.AccInformation();
                    }
                    i++;
                }
            }
            Console.WriteLine("Choose account's index from which you'd like to withdraw money:");
            string inp = Console.ReadLine();
            if(!int.TryParse(inp, out Index)){
                return;
            }
            if(Index < 0 || Index > Accounts.Count)
            {
                return;
            }            Console.WriteLine("type in the amount of founds to withdraw:");
            int Amount = int.Parse(Console.ReadLine());
            if(accs1.Exists(x => x.Id == Accounts[Index]))
                {
                    var SenderAccount = accs1.FirstOrDefault(x => x.Id == Accounts[Index]);
                    SenderAccount.Withdraw(Amount);
                    // curr = SenderAccount.Currency;


                }
                else if(accs2.Exists(x => x.Id == Accounts[Index]))
                {

                    var SenderAccount = accs2.FirstOrDefault(x => x.Id == Accounts[Index]);
                    SenderAccount.Withdraw(Amount);
                    // curr = SenderAccount.Currency;

                }
                else if(accs3.Exists(x => x.Id == Accounts[Index]))
                {
                    var SenderAccount = accs3.FirstOrDefault(x => x.Id == Accounts[Index]);
                    SenderAccount.Withdraw(Amount);
                    // curr = SenderAccount.Currency;
                }

            // if(accs1.Exists(x => x.Id == ReceiverId))
            //     {
            //         var ReceiverAccount = accs1.FirstOrDefault(x => x.Id == ReceiverId);
            //         ReceiverAccount.Deposit(Amount);
            //     }
        }

        public void myDeposit(List<PersonalAccount> accs1, List<SavingsAccount> accs2, List<CurrencyAccount> accs3)
        {

            // Guid ReceiverId;

            // PersonalAccount SenderPersonal;
            // SavingsAccount SenderSavings;
            // CurrencyAccount SenderCurrency;

            // PersonalAccount ReceiverPersonal;
            // SavingsAccount ReceiverSavings;
            // CurrencyAccount ReceiverCurrency;
            // string curr;


            int Index;
            int i = 0;
            foreach(var id in Accounts)
            {

                if(accs1.Exists(x => x.Id == id))
                {
                    Console.WriteLine("Account's index is (" + i + ")");
                    var item = accs1.FirstOrDefault(x => x.Id == id);
                    if(item != null){
                        item.AccInformation();
                    }
                    i++;
                }
                else if(accs2.Exists(x => x.Id == id))
                {
                    Console.WriteLine("Account's index is (" + i + ")");
                    var item = accs2.FirstOrDefault(x => x.Id == id);
                    if(item != null){
                        item.AccInformation();
                    }
                    i++;
                }
                else if(accs3.Exists(x => x.Id == id))
                {
                    Console.WriteLine("Account's index is (" + i + ")");
                    var item = accs3.FirstOrDefault(x => x.Id == id);
                    if(item != null){
                        item.AccInformation();
                    }
                    i++;
                }
            }
            Console.WriteLine("Choose account's index from which you'd like to deposit money:");
            string inp = Console.ReadLine();
            if(!int.TryParse(inp, out Index)){
                return;
            }
            if(Index < 0 || Index > Accounts.Count)
            {
                return;
            }
            Console.WriteLine("type in the amount of founds to Deposit:");
            int Amount = int.Parse(Console.ReadLine());
            if(accs1.Exists(x => x.Id == Accounts[Index]))
                {
                    var SenderAccount = accs1.FirstOrDefault(x => x.Id == Accounts[Index]);
                    SenderAccount.Deposit(Amount);
                    // curr = SenderAccount.Currency;


                }
                else if(accs2.Exists(x => x.Id == Accounts[Index]))
                {

                    var SenderAccount = accs2.FirstOrDefault(x => x.Id == Accounts[Index]);
                    SenderAccount.Deposit(Amount);
                    // curr = SenderAccount.Currency;

                }
                else if(accs3.Exists(x => x.Id == Accounts[Index]))
                {
                    var SenderAccount = accs3.FirstOrDefault(x => x.Id == Accounts[Index]);
                    SenderAccount.Deposit(Amount);
                    // curr = SenderAccount.Currency;
                }

            // if(accs1.Exists(x => x.Id == ReceiverId))
            //     {
            //         var ReceiverAccount = accs1.FirstOrDefault(x => x.Id == ReceiverId);
            //         ReceiverAccount.Deposit(Amount);
            //     }
        }

        public void myForecast(List<PersonalAccount> accs1, List<SavingsAccount> accs2, List<CurrencyAccount> accs3)
        {
            int Index;
            int i = 0;
            foreach(var id in Accounts)
            {

                if(accs1.Exists(x => x.Id == id))
                {
                    // Console.WriteLine("Account's index is (" + i + ")");
                    var item = accs1.FirstOrDefault(x => x.Id == id);
                    // if(item != null){
                    //     item.AccInformation();
                    // }
                    i++;
                }
                else if(accs2.Exists(x => x.Id == id))
                {
                    Console.WriteLine("Account's index is (" + i + ")");
                    var item = accs2.FirstOrDefault(x => x.Id == id);
                    if(item != null){
                        item.AccInformation();
                    }
                    i++;
                }
                else if(accs3.Exists(x => x.Id == id))
                {
                    //Console.WriteLine("Account's index is (" + i + ")");
                    var item = accs3.FirstOrDefault(x => x.Id == id);
                    // if(item != null){
                    //     item.AccInformation();
                    // }
                    i++;
                }
            }


            Console.WriteLine("Choose account's index on wich you'd like to preform a forecast:");
            string inp = Console.ReadLine();
            if(!int.TryParse(inp, out Index)){
                return;
            }
            if(Index < 0 || Index > Accounts.Count)
            {
                return;
            }

            if(accs2.Exists(x => x.Id == Accounts[Index]))
                {
                    var SenderAccount = accs2.FirstOrDefault(x => x.Id == Accounts[Index]);
                    int years;
                    Console.WriteLine("How many years would you like to predict:");
                    string inp2 = Console.ReadLine();
                    if(!int.TryParse(inp2, out years))
                    {
                        return;
                    }
                    double forcastedBalance;
                    forcastedBalance = SenderAccount.Forecast(years);
                    Console.WriteLine("Your balance in " + years + " years will be equal to:" + forcastedBalance);
                }
                // else if(accs2.Exists(x => x.Id == Accounts[Index]))
                // {

                //     var SenderAccount = accs2.FirstOrDefault(x => x.Id == Accounts[Index]);
                //     SenderAccount.Withdraw(100);
                //     curr = SenderAccount.Currency;

                // }
                // else if(accs3.Exists(x => x.Id == Accounts[Index]))
                // {
                //     var SenderAccount = accs3.FirstOrDefault(x => x.Id == Accounts[Index]);
                //     SenderAccount.Withdraw(100);
                //     curr = SenderAccount.Currency;
                // }

            // if(accs1.Exists(x => x.Id == ReceiverId))
            //     {
            //         var ReceiverAccount = accs1.FirstOrDefault(x => x.Id == ReceiverId);
            //         ReceiverAccount.Deposit(Amount);
            //     }
        }

        public void myConvert(List<PersonalAccount> accs1, List<SavingsAccount> accs2, List<CurrencyAccount> accs3)
        {
            int Index;
            int i = 0;
            foreach(var id in Accounts)
            {

                if(accs1.Exists(x => x.Id == id))
                {
                    // Console.WriteLine("Account's index is (" + i + ")");
                    var item = accs1.FirstOrDefault(x => x.Id == id);
                    // if(item != null){
                    //     item.AccInformation();
                    // }
                    i++;
                }
                else if(accs2.Exists(x => x.Id == id))
                {
                    // Console.WriteLine("Account's index is (" + i + ")");
                    var item = accs2.FirstOrDefault(x => x.Id == id);
                    // if(item != null){
                    //     item.AccInformation();
                    // }
                    i++;
                }
                else if(accs3.Exists(x => x.Id == id))
                {
                    Console.WriteLine("Account's index is (" + i + ")");
                    var item = accs3.FirstOrDefault(x => x.Id == id);
                    if(item != null){
                        item.AccInformation();
                    }
                    i++;
                }
            }


            Console.WriteLine("Choose account's index on wich you'd like to preform a currency convert on:");
            string inp = Console.ReadLine();
            if(!int.TryParse(inp, out Index)){
                return;
            }
            if(Index < 0 || Index > Accounts.Count)
            {
                return;
            }

            if(accs3.Exists(x => x.Id == Accounts[Index]))
                {
                    var SenderAccount = accs3.FirstOrDefault(x => x.Id == Accounts[Index]);
                    string curr;
                    double Amount;
                    Console.WriteLine("Choose one of those: USD , EUR, GBP, CHF, AED, AUD, CAD, UAH, HRK, DKK, NOK, SEK, RON, BGN, TRY, XDR, ZAR, RUB, CNY.");
                    Console.WriteLine("type the currency in which you'd like to add money to your currency account:");
                    curr = Console.ReadLine();
                    Console.WriteLine("Provide amount of money that you'd like to deposite on your currency account:");
                    Amount = int.Parse(Console.ReadLine());
                    SenderAccount.Convert(curr, Amount);
                    Console.WriteLine("Your new balance is equal to " + SenderAccount.Balance);
                }
                // else if(accs2.Exists(x => x.Id == Accounts[Index]))
                // {

                //     var SenderAccount = accs2.FirstOrDefault(x => x.Id == Accounts[Index]);
                //     SenderAccount.Withdraw(100);
                //     curr = SenderAccount.Currency;

                // }
                // else if(accs3.Exists(x => x.Id == Accounts[Index]))
                // {
                //     var SenderAccount = accs3.FirstOrDefault(x => x.Id == Accounts[Index]);
                //     SenderAccount.Withdraw(100);
                //     curr = SenderAccount.Currency;
                // }

            // if(accs1.Exists(x => x.Id == ReceiverId))
            //     {
            //         var ReceiverAccount = accs1.FirstOrDefault(x => x.Id == ReceiverId);
            //         ReceiverAccount.Deposit(Amount);
            //     }
        }
    }
}
