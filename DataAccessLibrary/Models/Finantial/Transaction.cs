using System;

namespace DataAccessLibrary.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        
        public decimal Amount { get; set; }
        
        public string Memo { get; set; }
        
        public DateTime Created { get; set; }
        
        public TransactionType Type { get; set; }
        
        public string CreatorId { get; set; }
        
        public int GroupId { get; set; }
        
        public int? BudgetId { get; set; }
        
        public int? BudgetItemId { get; set; }
        
        public int BankAccountId { get; set; }
    }
}