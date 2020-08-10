using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using BroadcastingSignalR.Web.Hubs;

namespace BroadcastingSignalR.Web.Controllers
{
    [ApiController]
    [Route("api/broadcast")]
    public class BroadcastController : ControllerBase
    {
        private readonly IHubContext<ChatHub> _hub;
        
        public BroadcastController(IHubContext<ChatHub> hub)
        {
            _hub = hub;
        }
        
        [HttpGet]
        public async Task Get(string user, string message)
        {
            await _hub.Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}