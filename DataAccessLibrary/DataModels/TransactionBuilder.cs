using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DataAccessLibrary.Models;
using DataAccessLibrary.Services;

namespace DataAccessLibrary.DataModels
{
    public class CreateTransactionViewModel
    {
        private FinancialService _financialService;

        public async Task Build(FinancialService _service)
        {
            _financialService = _service;
            User = (User) await _service.GetUserByEmail("mattpark102@gmail.com");
            Group = (Group) await _service.GetGroupById(User.GroupId);
            BankAccounts = (List<BankAccount>) await _service.GetBankAccountsByUserId(User.Id);
            Budgets = (List<Budget>) await _service.GetBudgetsByGroupId(Group.Id);
        }
        
        public User User { get; set; }
        public Group Group { get; set; }
        public List<BankAccount> BankAccounts { get; set; }
        public List<Budget> Budgets { get; set; }
        public List<BudgetItem> BudgetItems { get; set; }

        public TransactionType SelectedType { get; set; } = TransactionType.Deposit;
        public BankAccount SelectedBankAccount { get; set; }
        public Budget SelectedBudget { get; set; }
        public BudgetItem SelectedBudgetItem { get; set; }
        public string Memo { get; set; }
        public decimal Amount { get; set; }
        
        public async Task<HttpResponseMessage> CreateTransaction()
        {
            return await _financialService.CreateTransaction(
                Amount, 
                Memo, 
                SelectedType, 
                User.Id, 
                Group.Id, 
                SelectedBudget.Id, 
                SelectedBudgetItem.Id, 
                SelectedBankAccount.Id
            );
        }
    }
}