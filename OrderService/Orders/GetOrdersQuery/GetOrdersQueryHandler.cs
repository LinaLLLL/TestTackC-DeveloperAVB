namespace OrderService.Orders.GetOrderQuery
{
    public record GetOrdersQuery(int? PageNumber = 1, int? PageSize = 5) : IQuery<GetOrdersResult>;
    public record GetOrdersResult(IEnumerable<Order> Orders);
    public class GetOrdersQueryHandler(IDocumentSession session) : IQueryHandler<GetOrdersQuery, GetOrdersResult>
    {
        public async Task<GetOrdersResult> Handle(GetOrdersQuery query, CancellationToken cancellationToken)
        {
            var orders = await session.Query<Order>().ToPagedListAsync(query.PageNumber ?? 1,
                query.PageSize ?? 5, cancellationToken);
            return new GetOrdersResult(orders);
        }
    }
}
