using System;
using System.Collections.Generic;

namespace bank_app.Models
{
    public class User
    {
        public string UserName  {get; }

        public string Password {get; }

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
        
        public void myPersonalAccounts(List<PersonalAccount> accs){
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
    }
}