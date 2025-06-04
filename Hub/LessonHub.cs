using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

public class LessonHub : Hub
{
    public async Task SendLessonUpdate(string lessonId, string message)
    {
        await Clients.All.SendAsync("ReceiveLessonUpdate", lessonId, message);
    }
}
