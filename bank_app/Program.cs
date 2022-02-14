using System;
using System.Collections.Generic;
using bank_app.Models;

namespace bank_app{
    class Program
    {
        static void Main()
        {
            string actionType;

            string actionType2;

            string name;
            
            string ps;

            List<User> Users = new List<User>();
            List<PersonalAccount> PersonalAccounts = new List<PersonalAccount>();
            List<SavingsAccount> SavingsAccounts = new List<SavingsAccount>();
            List<CurrencyAccount> CurrencyAccounts = new List<CurrencyAccount>();
            
            
            while(true){
                Console.WriteLine("What would you like to do");
                Console.WriteLine("Choose one (1-4):");
                Console.WriteLine("1) Add User");
                Console.WriteLine("2) Login");
                Console.WriteLine("3) List usernames");
                Console.WriteLine("4) Exit");

                actionType = Console.ReadLine();

                switch(actionType)
                {
                    case "1":
                        Console.WriteLine("What is your username:\n");
                        name = Console.ReadLine();
                        while (Users.Exists(x => x.UserName == name))
                        {
                            Console.WriteLine("Username unavailable, try again!");
                            Console.WriteLine("What is your username:\n");
                            name = Console.ReadLine();
                        }
                        ps = " ";
                        while (ps.Length < 6)
                        {
                            Console.WriteLine("Set your password:\n");
                            ps = Console.ReadLine();
                            if (ps.Length < 6)
                            {
                                Console.WriteLine("Too short! The password must be at least 6 characters long, try again.\n");
                            }
                            else
                            {
                                User us = new User(name, ps);
                                Users.Add(us);
                            }
                        }
                    break;

                    case "2":
                        bool logout;
                        logout = false;
                        while(true)
                        {
                            name = "";
                            Console.WriteLine("Enter username:");
                            name = Console.ReadLine();
                            if(!Users.Exists(x => x.UserName == name))
                            {
                                Console.WriteLine("Wrong username");
                            }
                            else
                            {
                                Console.WriteLine("Enter password:\n+");
                                ps = Console.ReadLine();
                                if(Users.Exists(x => x.UserName == name && x.Password ==  ps))
                                {
                                    while(true){
                                        var item = Users.FirstOrDefault(x => x.UserName == name);
                                        Console.WriteLine("What would you like to do");
                                        Console.WriteLine("Choose one (1-4):");
                                        Console.WriteLine("1) Display your accounts");
                                        Console.WriteLine("2) Create new account");
                                        Console.WriteLine("3) Transfer founds");
                                        Console.WriteLine("4) Withdraw founds");
                                        Console.WriteLine("5) Deposit founds");
                                        Console.WriteLine("6) Forecast founds on savings account");
                                        Console.WriteLine("7) Add founds in different currenc to your currency account");
                                        Console.WriteLine("8) Logout");

                                        actionType = Console.ReadLine();

                                        switch(actionType)
                                        {
                                            case "1":
                                                if(item != null)
                                                {
                                                    item.myAccounts(PersonalAccounts, SavingsAccounts, CurrencyAccounts);
                                                }
                                            break;

                                            case "2":
                                                Console.WriteLine("Choose account type (1-3)");
                                                Console.WriteLine("1) Personal accout");
                                                Console.WriteLine("2) Savings account");
                                                Console.WriteLine("3) Currency account");
                                                
                                                actionType = Console.ReadLine();                                    
                                                
                                                switch (actionType)
                                                {
                                                    case "1":
                                                        item.addPersonalAccount(ref PersonalAccounts);
                                                        item.myPersonalAccounts(PersonalAccounts);
                                                    break;
                                                    case "2":
                                                        item.addSavingsAccount(ref SavingsAccounts);
                                                        item.mySavingsAccounts(SavingsAccounts);
                                                    break;
                                                    case "3":
                                                        item.addCurrencyAccount(ref CurrencyAccounts);
                                                        item.myCurrencyAccounts(CurrencyAccounts);
                                                    break;
                                                    default:
                                                        Console.WriteLine("Invalid option");
                                                    break;
                                                }
                                            break;

                                            case "3":
                                                item.Transfer(PersonalAccounts, SavingsAccounts, CurrencyAccounts);
                                            break;
                                            
                                            case "4":
                                                item.myWithdraw(PersonalAccounts, SavingsAccounts, CurrencyAccounts);
                                            break;
                                            
                                            case "5":
                                                item.myDeposit(PersonalAccounts, SavingsAccounts, CurrencyAccounts);
                                            break;
                                            
                                            case "6":
                                                item.myForecast(PersonalAccounts, SavingsAccounts, CurrencyAccounts);
                                            break;
                                            
                                            case "7":
                                                item.myConvert(PersonalAccounts, SavingsAccounts, CurrencyAccounts);
                                            break;

                                            case "8":
                                                logout = true;
                                            break;
                                        }
                                        if(logout == true)
                                        {
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Password is incorrect!");
                                }
                            }
                            if(logout == true)
                            {
                                break;
                            }
                        }
                    break;

                    case "3":
                        foreach(var user in Users)
                        {
                            Console.WriteLine(user.UserName);
                        }
                    break;
                    
                    case "4":
                        Environment.Exit(1);
                    break;
                    default:
                        Console.WriteLine("Please enter a number between 1 and 4.");
                        Environment.Exit(1);
                    break;
                }
            }
        }
    }
}