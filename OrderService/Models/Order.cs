namespace OrderService.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; } = default!;
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public string Status { get; set; } = string.Empty;
    }
}
