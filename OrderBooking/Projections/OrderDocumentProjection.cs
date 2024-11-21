using EventStorage.Projections;
using OrderBooking;
using OrderBooking.Events;
using OrderBooking.Projections;

public class OrderDocumentProjection : Projection<OrderDocument>
{
    public static OrderDocument Project(OrderPlaced orderPlaced) => new()
    {
        SourceId = orderPlaced.SourceId?.ToString(),
        Version = orderPlaced.Version,
        Status = OrderStatus.Placed
    };
}