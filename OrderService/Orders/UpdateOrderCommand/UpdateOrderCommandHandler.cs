namespace OrderService.Orders.UpdateOrderCommand
{
    public record UpdateOrderCommand(Guid Id, DateTime CreatedAt, List<OrderItem> Items, string Status)
        : ICommand<UpdateOrderResult>;

    public record UpdateOrderResult(bool IsSuccess);

    public class UpdateOrderCommandHandler(IDocumentSession session)
        : ICommandHandler<UpdateOrderCommand, UpdateOrderResult>
    {
        public async Task<UpdateOrderResult> Handle(UpdateOrderCommand command,
            CancellationToken cancellationToken)
        {
            var order = await session.LoadAsync<Order>(command.Id, cancellationToken);

            if (order is null)
            {
                throw new InvalidOperationException($"Order with ID {command.Id} not found."); 
            }

            command.Adapt(order);
            session.Update(order);
            await session.SaveChangesAsync(cancellationToken);
            return new UpdateOrderResult(true);
        }
    }
}
