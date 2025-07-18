using Marten.Schema;

namespace OrderService.Data.Seed
{
    public class InitializeOrderDatabase : IInitialData
    {
        public async Task Populate(IDocumentStore store, CancellationToken cancellation)
        {
            using var session = store.LightweightSession();
            if (!await session.Query<Order>().AnyAsync()) 
            {
                session.Store<Order>(InitialData.Orders);
                await session.SaveChangesAsync(); 
            }
        }
    }
}
