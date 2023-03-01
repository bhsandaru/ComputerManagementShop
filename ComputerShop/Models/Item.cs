namespace ComputerShop.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public string? ItemName { get; set; }
        public double Price { get; set; }
        public string? Availability { get; set; }
        public int ItemTypeId { get; set; }
        public int AdminId { get; set; }

    }
}
