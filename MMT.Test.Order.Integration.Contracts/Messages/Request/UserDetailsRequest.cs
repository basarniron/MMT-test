using Newtonsoft.Json;

namespace MMT.Test.Order.Integration.Contracts.Messages.Request
{
    public class UserDetailsRequest
    {
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
