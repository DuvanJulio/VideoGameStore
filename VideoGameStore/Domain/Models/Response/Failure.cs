using System.Text.Json.Serialization;

namespace VideoGameStore.Domain.Models.Response
{
    public class Failure<T> : Base
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]

        public T? Data { get; set; }
    }
}