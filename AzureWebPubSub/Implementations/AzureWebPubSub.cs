using Azure.Messaging.WebPubSub;
using AzureWebPubSub.Contracts;

namespace AzureWebPubSub.Implementations
{
    public class AzureWebPubSub: IPubSub
    {
        public readonly WebPubSubServiceClient _serviceClient;

        public AzureWebPubSub(IConfiguration configuration)
        {
            _serviceClient = new WebPubSubServiceClient(configuration["PubSubConnectionString"], configuration["PubSubHub"]);
        }

        public string GetGroupWebSocketUri(string userId)
        {
            return _serviceClient.GetClientAccessUri(userId: userId).AbsoluteUri;
        }

        public string GetUserWebSocketUri(string group)
        {
            return _serviceClient.GetClientAccessUri(groups: new List<string>() { group }).AbsoluteUri;
        }

        public async Task SendToAllAsync(string message)
        {
            await _serviceClient.SendToAllAsync(message);
        }

        public async Task SendToGroupAsync(string groupId, string message)
        {
            await _serviceClient.SendToGroupAsync(groupId, message);
        }

        public async Task SendToUserAsync(string userId, string message)
        {
            await _serviceClient.SendToUserAsync(userId, message);
        }
    }
}
