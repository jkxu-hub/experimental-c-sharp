using Microsoft.AspNetCore.SignalR;

namespace CSharpWebApp.Controllers
{
    public class UserIdProvider : IUserIdProvider
    {
        public string? GetUserId(HubConnectionContext connection)
        {
            return connection.User?.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
        }
    }
}
