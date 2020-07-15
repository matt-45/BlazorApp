namespace DataAccessLibrary.Models
{
    public class Group
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public decimal Balance { get; set; }
        
        public decimal StartAmount { get; set; }
       
        public decimal Spent
        {
            get
            {
                return StartAmount - Balance;
            }
        }
    }
}