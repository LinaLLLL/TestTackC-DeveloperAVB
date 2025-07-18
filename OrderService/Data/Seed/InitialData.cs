namespace OrderService.Data.Seed
{
    public class InitialData
    {
        public static IEnumerable<Order> Orders => new List<Order>
        {
            new Order()
            {
                Id = new Guid("00000000-0000-0000-0000-000000000001"),
                CreatedAt = DateTime.UtcNow.AddDays(-5),
                Status = "Completed",
                Items = new List<OrderItem>
                {
                    new OrderItem { ProductId = Guid.NewGuid(), Quantity = 2 },
                    new OrderItem { ProductId = Guid.NewGuid(), Quantity = 1 },
                }
            },
            new Order
            {
                Id = new Guid("00000000-0000-0000-0000-000000000002"),
                CreatedAt = DateTime.UtcNow.AddDays(-2),
                Status = "Pending",
                Items = new List<OrderItem>
                {
                    new OrderItem { ProductId = Guid.NewGuid(), Quantity = 5 },
                }
            }
        };
    }
}
