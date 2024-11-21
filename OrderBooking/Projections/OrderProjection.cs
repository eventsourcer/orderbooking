using EventStorage.Events;
using EventStorage.Projections;
using OrderBooking.Events;

namespace OrderBooking.Projections;

public class OrderProjection : Projection<Order>
{
    public static Order Project(OrderPlaced orderPlaced) => 
        new(orderPlaced.SourceId?.ToString()?? "", OrderStatus.Placed, orderPlaced.Version);
    public static Order Project(Order order, OrderConfirmed orderConfirmed) =>
        order with { Status = OrderStatus.Confirmed, Version = orderConfirmed.Version };
    public static Order Project(Order order, OrderRedied orderRedied) =>
        order with { Status = OrderStatus.Redied, Version = orderRedied.Version };
}