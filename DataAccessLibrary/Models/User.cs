namespace DataAccessLibrary.Models
{
    public class User
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GroupId { get; set; }
        public decimal IncomeAmount { get; set; }
        
        public IncomeType IncomeType { get; set; }
        
        public string Email { get; set; }
    }
}