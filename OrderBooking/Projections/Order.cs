namespace OrderBooking.Projections;
using Redis.OM;
using Redis.OM.Modeling;

public record Order(string SourceId, OrderStatus Status, long Version);

public record OrderDetail(string SourceId, OrderStatus Status, long Version);

[Document(StorageType = StorageType.Json)]
public class OrderDocument
{
    [RedisIdField][Indexed]
    public string? SourceId { get; set; } = string.Empty;
    [Searchable]
    public OrderStatus Status { get; set; }
    public long Version { get; set; }
}