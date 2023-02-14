using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Signal.Server.Hubs;
using Signal.Shared;

namespace Signal.Server.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class TestController : Controller
{
    private IHubContext<TestHub, ITestHub> _hubContext;

    public TestController(IHubContext<TestHub, ITestHub> hubContext)
    {
        _hubContext = hubContext;
    }

    [HttpPost]
    public async Task<IActionResult> Post()
    {
        await _hubContext.Clients.All.ReceiveNotification("To all");
        return Ok();
    }
}