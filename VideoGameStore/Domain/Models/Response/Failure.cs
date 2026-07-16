using System.Text.Json.Serialization;

namespace VideoGameStore.Domain.Models.Response
{
    public class Failure<T> : Base
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]

        public T? Data { get; set; }
    }
}