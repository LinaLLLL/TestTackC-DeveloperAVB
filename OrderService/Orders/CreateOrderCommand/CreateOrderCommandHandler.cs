namespace OrderService.Orders.CreateOrderCommand
{
    public record CreateOrderCommand(DateTime CreatedAt, List<OrderItem> Items, string Status) 
        : ICommand<CreateOrderResult>;
   
    public record CreateOrderResult(Guid Id);

    public class CreateOrderCommandHandler(IDocumentSession session)
        : ICommandHandler<CreateOrderCommand, CreateOrderResult>
    {
        public async Task<CreateOrderResult> Handle(CreateOrderCommand command, 
            CancellationToken cancellationToken)
        {
            var order = new Order
            {
                CreatedAt = command.CreatedAt,
                Items = command.Items,
                Status = command.Status,
            };
            session.Store(order);
            await session.SaveChangesAsync(cancellationToken);

            return new CreateOrderResult(order.Id);
        }
    }
}
