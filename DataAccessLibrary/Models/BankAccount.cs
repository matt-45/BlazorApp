namespace DataAccessLibrary.Models
{
    public class BankAccount
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public AccountType Type { get; set; }
        public string UserId { get; set; }
    }
}