using System.Text.Json.Serialization;

namespace TaskSystem.Core.Domain.Enums.Status
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StatusEnum
    {
        Pending,
        InProgress,
        Completed
    }
}
