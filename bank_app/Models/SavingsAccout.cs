using System;
using System.Collections;

namespace bank_app.Models
{
    public class SavingsAccount : PersonalAccount
    {   
        public SavingsAccount(double initialBalance) : base(initialBalance){} 
        public double Interest { get; set; } = 0.05;
        
        public double Forecast(int years){
            return Balance * System.Math.Pow((1 + Interest/100), years);
        }
    }
    
}