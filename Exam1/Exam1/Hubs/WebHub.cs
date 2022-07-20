using Exam1.Hubs.Helpers;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Exam1.Hubs
{
    public class WebHub: Hub
    {
        private readonly static ConnectionGroupMapping<string> _connectionGroup = new ConnectionGroupMapping<string>();

        public async Task JoinGroupAsync(string group)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, group);
            if (!_connectionGroup.GetConnections(group).Contains(Context.ConnectionId))
            {
                _connectionGroup.Add(group, Context.ConnectionId);
            }
            await Clients.Group(group).SendAsync("Alert", $"{Context.ConnectionId} has joined the group {group}.");
        }

        public async Task RemoveGroup(string group)
        {
            _connectionGroup.Remove(group, Context.ConnectionId);
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, group);
            await Clients.Groups(group).SendAsync("Alert", $"{Context.ConnectionId} has left the group {group}.");
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            string name = Context.User.FindFirst("userId").Value;

            _connectionGroup.Remove(name, Context.ConnectionId);
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, name);

            await Clients.Groups(name).SendAsync("Alert", $"{Context.ConnectionId}has left the group {name}.");
            await Clients.All.SendAsync("GroupInfor", _connectionGroup.Count, _connectionGroup.ConnectionCount());
            await base.OnDisconnectedAsync(exception);
        }

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }

        public async Task GetGroupInfor()
        {
            await Clients.All.SendAsync("GroupInfor", _connectionGroup.Count, _connectionGroup.ConnectionCount());
        }
    }
}
