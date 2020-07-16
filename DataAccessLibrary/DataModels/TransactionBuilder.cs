using DataAccessLibrary.Models;

namespace DataAccessLibrary.DataModels
{
    public class TransactionBuilder
    {
        public User User { get; set; }
        public TransactionType SelectedType { get; set; }
        public Budget SelectedBudget { get; set; }
        public BudgetItem SelectedBudgetItem { get; set; }
        public string Memo { get; set; }


        public async void SubmitTransaction()
        {
            
        }
    }
}