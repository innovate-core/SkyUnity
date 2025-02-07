using SkyUnityCore.Enums;

namespace SkyUnityCore.Dto
{
    public class RequestTPC<T>
    {
        public T Model { get; set; }
        public ServiceType Type { get; set; }
    }
}
