
namespace OrderService.Orders.GetOrderQuery
{
    public record GetOrdersRequest(int? PageNumber = 1, int? PageSize = 5);
    public record GetOrdersResponse(IEnumerable<Order> orders);
    public class GetOrdersEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/orders", async ([AsParameters] GetOrdersRequest request, ISender sender) =>
            {
                GetOrdersQuery query = request.Adapt<GetOrdersQuery>();
                GetOrdersResult result = await sender.Send(query);
                GetOrdersResponse response = result.Adapt<GetOrdersResponse>();
                return Results.Ok(response);
            })
            .WithName("GetOrders")
            .WithSummary("Получить список заказов")
            .WithDescription("Возвращает постраничный список заказов.");
        }
    }
}
