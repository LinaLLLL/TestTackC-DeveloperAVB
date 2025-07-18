namespace OrderService.Orders.DeleteOrderCommand
{
    public record DeleteOrderRequest(Guid Id);
    public record DeleteOrderResponse(bool IsSuccess);
    public class DeleteOrderEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/order/{id}", async (Guid id, ISender sender) =>
            {
                var command = new DeleteOrderCommand(id);
                var result = await sender.Send(command);
                var response = new DeleteOrderResponse(result.IsSuccess);
                return Results.Ok(response);
            })
            .WithName("DeleteOrder")
            .WithSummary("Удаление заказа")
            .WithDescription("Удаляет заказ по переданному идентификатору");
        }
    }
}