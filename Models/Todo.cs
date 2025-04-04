using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Todo
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("title")]
    public string Title { get; set; } = String.Empty;

    [BsonElement("completed")]
    public bool Completed { get; set; } = false;

    [BsonElement("description")]
    public string Description { get; set; } = String.Empty;

    [BsonElement("createdat")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [BsonElement("plannedat")]
    public DateTime PlannedAt { get; set; }

}