namespace DataAccessLibrary.Models
{
    public class Budget
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public decimal Spent { get; set; }
        
        public decimal Target { get; set; }
        
        public int GroupId { get; set; }
    }
}