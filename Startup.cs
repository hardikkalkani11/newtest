services.AddSignalR();
app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<MyHub>("/myhub");
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});
public class MyHub : Hub
{
    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
}
