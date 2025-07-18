using Marten.Linq.QueryHandlers;
using OrderService.Orders.DeleteOrderCommand;

namespace OrderService.Orders.GetOrderQuery
{
    public record GetOrderByIdQuery(Guid Id) : IQuery<GetOrderByIdResult>;
    public record GetOrderByIdResult(Order? Order);
    public class GetOrderByIdQueryHandler(IDocumentSession session)
        : IQueryHandler<GetOrderByIdQuery, GetOrderByIdResult>
    {
        public async Task<GetOrderByIdResult> Handle(GetOrderByIdQuery query, CancellationToken cancellationToken)
        {
            var order = await session.LoadAsync<Order>(query.Id, cancellationToken);
            if (order == null)
            {
                return new GetOrderByIdResult(null);
            }
            return new GetOrderByIdResult(order);
        }
    }
}
