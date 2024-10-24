using EventStorage.Events;
using EventStorage.Projections;
using OrderBooking.Events;

namespace OrderBooking.Projections;

public class OrderProjection : Projection<Order>
{
    public static Order Project(OrderPlaced orderPlaced) => 
        new(orderPlaced.SourceId?.ToString()?? "", OrderStatus.Placed, orderPlaced.Version);
    public static Order Project(Order order, OrderPlaced orderPlaced) =>
        order with { OrderStatus = OrderStatus.Placed, VersionNo = orderPlaced.Version };
    public static Order Project(Order order, OrderConfirmed orderConfirmed) =>
        order with { OrderStatus = OrderStatus.Confirmed, VersionNo = orderConfirmed.Version };
}