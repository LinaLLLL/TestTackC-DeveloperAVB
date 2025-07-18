namespace OrderService.Orders.DeleteOrderCommand
{
    public record DeleteOrderCommand(Guid Id) : ICommand<DeleteOrderResult>;
    public record DeleteOrderResult(bool IsSuccess);

    public class DeleteOrderCommandHandler(IDocumentSession session)
        : ICommandHandler<DeleteOrderCommand, DeleteOrderResult>
    {
        public async Task<DeleteOrderResult> Handle(DeleteOrderCommand command, CancellationToken cancellationToken)
        {
            var order = await session.LoadAsync<Order>(command.Id, cancellationToken);
            if (order == null)
            {
                throw new Exception();
            }

            session.Delete(order);
            await session.SaveChangesAsync(cancellationToken);
            return new DeleteOrderResult(true);
        }
    }
}