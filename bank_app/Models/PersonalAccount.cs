using System;
using System.Collections;
using System.Collections.Generic;

namespace bank_app.Models
{
    public class PersonalAccount
    {
        public Guid Id { get;  }
        public double Balance { get; set; }
        
        public string Currency { get; set; } = "PLN";

        // public bool Exists { get; set; } = true;

        public PersonalAccount(double initialBalance){
            Id = Guid.NewGuid();
            Balance = initialBalance;
        }
        
        public void Deposit(double value){
            Balance += value;
            Console.WriteLine("Success!\n");

        }
        
        public void Withdraw(double value){
            if(Balance >= value){
                Balance -= value;
                Console.WriteLine("Success!'\n");
            }
            else{
                Console.WriteLine("You do not have enough funds to execute this operation\n");
            }
        }
        
        // public void Transfer(double value, Guid Id){
            
        // }
        
        public double MyBalance(){
            return Balance;
        }
        
        public void AccInformation(){
            Console.WriteLine(
                "\tAccount Id:\t" + Id + "\n" +
                "\tBalance:\t" + Balance + Currency + "\n");
        }
        
    }
    
}