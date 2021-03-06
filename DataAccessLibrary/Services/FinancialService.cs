using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DataAccessLibrary.Models;
using Newtonsoft.Json;

namespace DataAccessLibrary.Services
{
    public class FinancialService
    {
        // User
        public async Task<dynamic> GetUserByEmail(string email)
        {
            string queryString = $"https://financialwebapi.azurewebsites.net/GetUserByEmail?Email={email}";
            dynamic results = await DataService.GetDataFromServiceAsync(queryString).ConfigureAwait(false);

            if (results != null)
            {
                User user = new User();
                user = JsonConvert.DeserializeObject<User>(results);

                return user;
            }
            else
            {
                return null;
            }
        }

        // Transactions
        public async Task<HttpResponseMessage> CreateTransaction(decimal Amount, string Memo, TransactionType Type, string CreatorId, int GroupId, int BudgetId, int BudgetItemId, int BankAccountId)
        {
            string queryString = $"https://financialwebapi.azurewebsites.net/api/Transactions/AddTransaction?Amount={Amount}&Memo={Memo}&Type={Type}&CreatorId={CreatorId}&GroupId={GroupId}&BudgetId={BudgetId}&BudgetItemId={BudgetItemId}&BankAccountId={BankAccountId}";
            return await DataService.PostDataServiceAsync(queryString);
        }
        public void CalculateTransaction(int TransactionId)
        {
            string queryString = $"https://financialwebapi.azurewebsites.net/api/Transactions/CalculateTransaction?Id={TransactionId}";
            DataService.PutDataServiceAsync(queryString);
        }
        public async Task<dynamic> GetTransactionsByGroupId(int Id)
        {
            string queryString = $"https://financialwebapi.azurewebsites.net/api/Transactions/GetTransactionsByGroup?GroupId={Id}";
            dynamic results = await DataService.GetDataFromServiceAsync(queryString).ConfigureAwait(false);

            if (results != null)
            {
                List<Transaction> transactions = new List<Transaction>();
                transactions = JsonConvert.DeserializeObject<List<Transaction>>(results);
                
                return transactions;
            }
            else
            {
                return null;
            }
        }
        public async Task<dynamic> GetTransactionsByBankAccountId(int Id)
        {
            string queryString = $"https://financialwebapi.azurewebsites.net/api/Transactions/GetTransactionsByBank?BankId={Id}";
            dynamic results = await DataService.GetDataFromServiceAsync(queryString).ConfigureAwait(false);

            if (results != null)
            {
                List<Transaction> transactions = new List<Transaction>();
                transactions = JsonConvert.DeserializeObject<List<Transaction>>(results);
                
                return transactions;
            }
            else
            {
                return null;
            }
        }
        public async Task<dynamic> GetTransactionsByUserId(string UserId)
        {
            string queryString = $"https://financialwebapi.azurewebsites.net/api/Transactions/GetTransactionsByUser?UserId={UserId}";
            dynamic results = await DataService.GetDataFromServiceAsync(queryString).ConfigureAwait(false);

            if (results != null)
            {
                List<Transaction> Transactions = new List<Transaction>();
                Transactions = JsonConvert.DeserializeObject<List<Transaction>>(results);

                return Transactions;
            }
            else
            {
                return null;
            }

        }
        public void DeleteTransaction(int GroupId)
        {
            string queryString = $"https://financialwebapi.azurewebsites.net/api/Transactions/DeleteTransaction?Id={GroupId}";
            DataService.DeleteDataServiceAsync(queryString);
        }

        // Group
        public void CreateGroup(string Name)
        {
            string queryString = $"https://financialwebapi.azurewebsites.net/api/Groups/AddGroup?Name={Name}";
            DataService.PostDataServiceAsync(queryString);
        }
        public void EditGroup(int GroupId, string Name, decimal Balance, decimal StartAmount)
        {
            string queryString = $"https://financialwebapi.azurewebsites.net/api/Groups/EditGroup?Id={GroupId}&Name={Name}&Balance={Balance}&StartAmount={StartAmount}";
            DataService.PutDataServiceAsync(queryString);
        }
        public async Task<dynamic> GetGroupById(int Id)
        {
            string queryString = $"https://financialwebapi.azurewebsites.net/api/Groups/GetGroupDetails?Id={Id}";
            dynamic results = await DataService.GetDataFromServiceAsync(queryString).ConfigureAwait(false);

            if (results != null)
            {
                Group Group = new Group();
                Group = JsonConvert.DeserializeObject<Group>(results);
                
                return Group;
            }
            else
            {
                return null;
            }
        }

        // Budgets
        public void CreateBudget(string Name, int GroupId)
        {
            string queryString = $"https://financialwebapi.azurewebsites.net/AddBudget?Name={Name}&GroupId={GroupId}";
            DataService.PostDataServiceAsync(queryString);
        }
        public void EditBudget(int BudgetId, string Name, decimal Spent, decimal Target)
        {
            string queryString = $"https://financialwebapi.azurewebsites.net/EditBudget?Id={BudgetId}&Name={Name}&Spent={Spent}&Target={Target}";
            DataService.PutDataServiceAsync(queryString);
        }
        public async Task<dynamic> GetBudgetById(int Id)
        {
            string queryString = $"https://financialwebapi.azurewebsites.net/GetBudgetDetails?Id={Id}";
            dynamic results = await DataService.GetDataFromServiceAsync(queryString).ConfigureAwait(false);

            if (results != null)
            {
                Budget budget = new Budget();
                budget = JsonConvert.DeserializeObject<Budget>(results);
                
                return budget;
            }
            else
            {
                return null;
            }
        }
        public async Task<dynamic> GetBudgetsByGroupId(int Id)
        {
            string queryString = $"https://financialwebapi.azurewebsites.net/GetBudgetsByGroup?GroupId={Id}";
            dynamic results = await DataService.GetDataFromServiceAsync(queryString).ConfigureAwait(false);

            if (results != null)
            {
                List<Budget> budgets = new List<Budget>();
                budgets = JsonConvert.DeserializeObject<List<Budget>>(results);

                return budgets;
            }
            else
            {
                return null;
            }
        }
        public void DeleteBudget(int BudgetId)
        {
            string queryString = $"https://financialwebapi.azurewebsites.net/DeleteBudget?Id={BudgetId}";
            DataService.DeleteDataServiceAsync(queryString);
        }

        // Budget Items
        public void CreateBudgetItem(string Name, int BudgetId)
        {
            string queryString = $"https://financialwebapi.azurewebsites.net/api/BudgetItems/AddBudgetItem?Name={Name}&BudgetId={BudgetId}";
            DataService.PostDataServiceAsync(queryString);
        }
        public async Task<dynamic> GetBudgetItemById(int Id)
        {
            string queryString = $"https://financialwebapi.azurewebsites.net/api/BudgetItems/GetBudgetItemDetails?Id={Id}";
            dynamic results = await DataService.GetDataFromServiceAsync(queryString).ConfigureAwait(false);

            if (results != null)
            {
                BudgetItem budgetItem = new BudgetItem();
                budgetItem = JsonConvert.DeserializeObject<BudgetItem>(results);
                
                return budgetItem;
            }
            else
            {
                return null;
            }
        }
        public void EditBudgetItem(int BudgetItemId, string Name, decimal Spent, decimal Target)
        {
            string queryString = $"https://financialwebapi.azurewebsites.net/api/BudgetItems/EditBudgetItem?Id={BudgetItemId}&Name={Name}&Spent={Spent}&Target={Target}";
            DataService.PutDataServiceAsync(queryString);
        }
        public async Task<dynamic> GetBudgetItemsByBudgetId(int Id)
        {
            string queryString = $"https://financialwebapi.azurewebsites.net/api/BudgetItems/GetBudgetItemsByBudget?BudgetId={Id}";
            dynamic results = await DataService.GetDataFromServiceAsync(queryString).ConfigureAwait(false);

            if (results != null)
            {
                List<BudgetItem> budgetItems = new List<BudgetItem>();
                budgetItems = JsonConvert.DeserializeObject<List<BudgetItem>>(results);
                
                return budgetItems;
            }
            else
            {
                return null;
            }
        }
        public void DeleteBudgetItem(int BudgetItemId)
        {
            string queryString = $"https://financialwebapi.azurewebsites.net/api/BudgetItems/DeleteBudgetItem?Id={BudgetItemId}";
            DataService.DeleteDataServiceAsync(queryString);
        }

        // Bank Accounts
        public void CreateBankAccount(string Name, decimal Balance, AccountType Type, string UserId)
        {
            string queryString = $"https://financialwebapi.azurewebsites.net/api/BankAccounts/AddAccount?Name={Name}&Balance={Balance}&Type={Type}&UserId={UserId}";
            DataService.PostDataServiceAsync(queryString);
        }
        public void EditBankAccount(int BankAccountId, string UserId, string Name, decimal Balance, AccountType Type)
        {
            string queryString = $"https://financialwebapi.azurewebsites.net/api/BankAccounts/EditBankAccount?Id={BankAccountId}&UserId={UserId}&Name={Name}&Balance={Balance}&Type={Type}";
            DataService.PutDataServiceAsync(queryString);
        }
        public async Task<dynamic> GetBankAccountById(int Id)
        {
            string queryString = $"https://financialwebapi.azurewebsites.net/api/BankAccounts/GetBankAccountDetails?Id={Id}";
            dynamic results = await DataService.GetDataFromServiceAsync(queryString).ConfigureAwait(false);

            if (results != null)
            {
                BankAccount bankAccount = new BankAccount();
                bankAccount = JsonConvert.DeserializeObject<BankAccount>(results);
                
                return bankAccount;
            }
            else
            {
                return null;
            }
        }
        public async Task<dynamic> GetBankAccountsByUserId(string Id)
        {
            string queryString = $"https://financialwebapi.azurewebsites.net/api/BankAccounts/GetBankAccountsByUser?UserId={Id}";
            dynamic results = await DataService.GetDataFromServiceAsync(queryString).ConfigureAwait(false);

            if (results != null)
            {
                List<BankAccount> bankAccounts = new List<BankAccount>();
                bankAccounts = JsonConvert.DeserializeObject<List<BankAccount>>(results);

                return bankAccounts;
            }
            else
            {
                return null;
            }
        }
        public void DeleteBankAccount(int BankAccountId)
        {
            string queryString = $"https://financialwebapi.azurewebsites.net/api/BankAccounts/DeleteBankAccount?Id={BankAccountId}";
            DataService.DeleteDataServiceAsync(queryString);
        }
    }
}