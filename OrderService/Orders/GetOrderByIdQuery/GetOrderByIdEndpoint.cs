namespace OrderService.Orders.GetOrderQuery
{
    public record GetOrderByIdRequest(Guid Id);
    public record GetOrderByIdResponse(Order order);
    public class GetOrderByIdEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/orders/{id}", async (Guid id, ISender sender) =>
            {
                var query = new GetOrderByIdQuery(id);
                var result = await sender.Send(query);
                if (result.Order == null)
                {
                    return Results.NotFound();
                }
                    
                var response = result.Adapt<GetOrderByIdResponse>();
                return Results.Ok(response);
            })
            .WithName("GetOrderById")
            .WithSummary("Получение заказа по ID")
            .WithDescription("Выдает заказ по переданному идентификатору");
        }
    }
}
