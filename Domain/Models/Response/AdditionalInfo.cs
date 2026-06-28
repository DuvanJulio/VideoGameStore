namespace VideoGameStore.Domain.Models.Response
{
    public class AdditionalInfo
    {
        public string Code { get; set; }

        public string Detail { get; set; }

        public AdditionalInfo(string code, string detail)
        {
            Code = code;
            Detail = detail;
        }

        public static AdditionalInfo Create(string code, string detail)
        {
            return new AdditionalInfo(code, detail);
        }
    }
}