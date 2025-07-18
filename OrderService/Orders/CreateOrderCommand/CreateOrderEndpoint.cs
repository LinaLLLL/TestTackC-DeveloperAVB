using Carter;
using Mapster;


namespace OrderService.Orders.CreateOrderCommand
{
    public record CreateOrderRequest(DateTime CreatedAt, List<OrderItem> Items, string Status);
    public record CreateOrderResponse(Guid id);
    public class CreateOrderEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/order", async (CreateOrderRequest request, ISender sender) =>
            {
                var command = request.Adapt<CreateOrderCommand>();
                var result = await sender.Send(command);
                var response = result.Adapt<CreateOrderResponse>();
                return Results.Ok(response);
            })
            .WithName("CreateOrder")
            .WithSummary("Создание нового заказа")
            .WithDescription("Создаёт заказ с переданными товарами и статусом через MediatR");
        }
    }
}
