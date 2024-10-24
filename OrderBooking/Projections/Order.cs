namespace OrderBooking.Projections;
using Redis.OM;
using Redis.OM.Modeling;

[Document(StorageType = StorageType.Json, Prefixes = ["Order"])]
public record Order(string Id, OrderStatus OrderStatus, long VersionNo)
{
    [RedisIdField]
    public string SourceId => Id;
    [Searchable]
    public OrderStatus Status => OrderStatus;
    public long Version => VersionNo;
}
[Document(StorageType = StorageType.Json, Prefixes = ["OrderDetail"])]
public record OrderDetail(string Id, OrderStatus OrderStatus, long VersionNo)
{
    [RedisIdField]
    public string SourceId => Id;
    [Searchable]
    public OrderStatus Status => OrderStatus;
    public long Version => VersionNo;
}

[Document(StorageType = StorageType.Json)]
public class RedisModel
{
    [RedisIdField]
    public string Id { get; set; } = string.Empty;
    [Searchable]
    public string Name { get; set; } = string.Empty;
}