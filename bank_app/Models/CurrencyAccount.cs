using System;
using System.Collections;
using System.Linq;

namespace bank_app.Models
{
    public class CurrencyAccount : PersonalAccount
    {        
        public double[] sell = {4.1292, 4.7028, 5.6019, 4.3954, 1.1030, 2.9545, 3.2483, 0.1497, 0.6254, 0.6322, 0.4665, 0.4453, 0.9510, 2.4045, 0.3128, 5.7974, 0.2724, 0.0547, 0.6504};
        public double[] buy = {3.8239, 4.3565, 5.1869, 4.1855, 1.0197, 2.7356, 3.0078, 0.1338, 0.5778, 0.5856, 0.4321, 0.4124, 0.8807, 2.2274, 0.2772, 5.3687, 0.2523, 0.0506, 0.6009};
        public string[] name = {"USD", "EUR", "GBP", "CHF", "AED", "AUD", "CAD", "UAH", "HRK", "DKK", "NOK", "SEK", "RON", "BGN", "TRY", "XDR", "ZAR", "RUB", "CNY"};
        public string Currency { get; set; } = "USD";
        
        public CurrencyAccount(double initialBalance) : base(initialBalance){}
        public void Transfer(double value, string curr){
            
            if(Currency != curr){
                if(name.Contains(curr)){
                    Balance += value / sell[Array.IndexOf(name, curr)];
                }
                else{
                    Console.WriteLine("Invalid currency");
                }
            }
            else{
                Balance += value;
            }
        }
        
    }
    
}