namespace OrderService.Orders.UpdateOrderCommand
{
    public record UpdateOrderRequest(Guid Id, DateTime CreatedAt, List<OrderItem> Items, string Status);

    public record UpdateOrderResponse(bool IsSuccess);
    public class UpdateOrderEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/orders", async (UpdateOrderRequest request, ISender sender) =>
            {
                var command = request.Adapt<UpdateOrderCommand>();
                var result = await sender.Send(command);
                var response = result.Adapt<UpdateOrderResponse>();
                return Results.Ok(response);
            });
        }
    }
}
