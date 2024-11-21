using EventStorage.Events;
using EventStorage.Projections;
using OrderBooking.Events;

namespace OrderBooking.Projections;

public class OrderDetailProjection : Projection<OrderDetail>
{
    public static OrderDetail Project(OrderPlaced orderPlaced) =>
        new(orderPlaced.SourceId?.ToString()?? "", OrderStatus.Placed, orderPlaced.Version);
    public static OrderDetail Project(OrderDetail order, OrderConfirmed orderConfirmed) =>
        order with { Status = OrderStatus.Confirmed, Version = orderConfirmed.Version };
    public static OrderDetail Project(OrderDetail order, OrderRedied orderRedied) =>
        order with { Status = OrderStatus.Redied, Version = orderRedied.Version };
}