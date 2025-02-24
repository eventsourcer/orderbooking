using EventStorage.Events;
using OrderBooking.Commands;

namespace OrderBooking.Events;

public record OrderPlaced(PlaceOrder Command) : SourcedEvent;