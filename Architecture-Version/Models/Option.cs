namespace DecideWise.Models
{
    public class Option
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Score { get; set; }

        public double ValueScore => Price == 0 ? 0 : Score / (double)Price;
    }
}