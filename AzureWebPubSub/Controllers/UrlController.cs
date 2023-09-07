using Azure.Messaging.WebPubSub;
using AzureWebPubSub.Contracts;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AzureWebPubSub.Controllers
{
    [Route("api/")]
    [ApiController]
    public class UrlController : ControllerBase
    {
        private readonly IPubSub _clientPubSub;

        public UrlController(IPubSub clientPubSub)
        {
            _clientPubSub = clientPubSub;
        }

        [HttpGet("negotiate/{groupId}")]
        public ActionResult<string> GetAsync(string groupId)
        {
            var url = _clientPubSub.GetGroupWebSocketUri(groupId);
            return Ok(url);
        }

        [HttpGet("update/{groupId}/{value}")]
        public async Task<ActionResult> GetAsync(string groupId, string value)
        {
            await _clientPubSub.SendToGroupAsync(groupId, value);
            return Ok();
        }
    }
}
