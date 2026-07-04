using System.Net;

namespace VideoGameStore.Domain.Models.Response
{
    public class Success<T> : Base
    {
        public T Data { get; set; }

        private Success(T data,
                        List<AdditionalInfo> additionalInfo)
        {
            Data = data;
            StatusCode = (int)HttpStatusCode.OK;
            StatusDesc = HttpStatusCode.OK.ToString();
            AdditionalInfos = additionalInfo;
        }

        public static Success<T> Create(T data)
        {
            var defaultAdditionalInfo = new List<AdditionalInfo>
            {
                AdditionalInfo.Create("200", "Operación exitosa")
            };

            return new Success<T>(
                data,
                defaultAdditionalInfo
            );
        }
    }
}