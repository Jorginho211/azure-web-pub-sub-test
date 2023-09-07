namespace AzureWebPubSub.Contracts
{
    public interface IPubSub
    {
        string GetUserWebSocketUri(string group);
        string GetGroupWebSocketUri(string userId);

        Task SendToAllAsync(string message);
        Task SendToGroupAsync(string groupId, string message);
        Task SendToUserAsync(string userId, string message);
    }
}
