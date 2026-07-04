namespace VideoGameStore.Domain.Models.Response
{
    public class Base
    {
        public int StatusCode { get; set; }

        public string StatusDesc { get; set; } = string.Empty;

        public List<AdditionalInfo> AdditionalInfos { get; set; } = new();
    }
}