using Job_assignment_management.Application.Services;
using Job_assignment_management.Domain.Entities;
using Microsoft.AspNetCore.SignalR;
using Quartz.Util;
using System.Collections.Concurrent;

namespace Job_assignment_management.Api.Hubs
{
    public class myHub:Hub
    {
        private readonly ManagerConnectionService _managerConnectionService;
        public myHub(ManagerConnectionService managerConnectionService)
        {
            _managerConnectionService = managerConnectionService;
        }
        public override Task OnConnectedAsync()
        {
            var userId = Context.User?.Claims.FirstOrDefault(c => c.Type == "MaTaiKhoan")?.Value;
            if (userId != null)
            {
                _managerConnectionService.AddConnection(userId, Context.ConnectionId);
            }
            return base.OnConnectedAsync();
        }
        public async Task TraoDoiThongTin(string maCongViec)
        {
            await Clients.Group(maCongViec).SendAsync("ReceiveMessage");
        }

        public async Task NhanTin(string maNhanVien, string message)
        {
            await Clients.User(maNhanVien).SendAsync("ReceiveMessage", message);
        }
        public async Task ThamGiaNhom(string maCongViec)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, maCongViec);
            await Clients.Group(maCongViec).SendAsync("UserJoined", $"{Context.User?.Claims.FirstOrDefault(c => c.Type == "MaNhomQuyen")?.Value} has joined the group {maCongViec}");
        }
        public async Task ThongBao(string maCongViec,string message)
        {
            await Clients.Group(maCongViec).SendAsync("ReceiveNotification",message);
        }
        public async Task RoiNhom(string maCongViec)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, maCongViec);
        }
        public async Task SendMessageToUser(string targetUserId, string message)
        {
            var connections = _managerConnectionService.GetConnections(targetUserId);
            var size=_managerConnectionService.GetUserOnline();
            foreach (var connectionId in connections)
            {
                await Clients.Client(connectionId).SendAsync("ReceiveMessageTest", $"{message} user online {size} id {targetUserId}");
            }
        }
        public async Task JoinCallVideo(string maCongViec)
        {
            await Clients.Group(maCongViec).SendAsync("CallVideo",maCongViec);
        }
        public async Task ChatCallVideo(string maCongViec,string message)
        {
            await Clients.Group(maCongViec).SendAsync("ReceiveMessageCall",new { 
                maCongViec=maCongViec,
                message=message
            });
            await Clients.All.SendAsync("NotifiGroup", "new message in group");
        }
        public override Task OnDisconnectedAsync(Exception exception)
        {
            _managerConnectionService.RemoveConnection(Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }
    }
}
