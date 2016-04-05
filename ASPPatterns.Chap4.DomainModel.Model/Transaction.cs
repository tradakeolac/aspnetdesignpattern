using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPPatterns.Chap4.DomainModel.Model
{
    public class Transaction
    {
        public Transaction(decimal deposite, decimal withdrawal, string reference, DateTime date)
        {
            this.Deposite = deposite;
            this.Withdrawal = withdrawal;
            this.Reference = reference;
            this.Date = date;
        }
        public decimal Deposite { get; set; }
        public decimal Withdrawal { get; set; }
        public string Reference { get; set; }
        public DateTime Date { get; set; }
    }
}
