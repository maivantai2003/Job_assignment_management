﻿using Job_assignment_management.Domain.Entities;
using Microsoft.AspNetCore.SignalR;

namespace Job_assignment_management.Api.Hubs
{
    public class myHub:Hub
    {
        public override Task OnConnectedAsync()
        {
            var connectionId = Context.ConnectionId;
            var userId = Context.UserIdentifier;
            return base.OnConnectedAsync();
        }
        public async Task TraoDoiThongTin(string maCongViec, string maNhanVien, string message)
        {
            await Clients.Group(maCongViec).SendAsync("ReceiveMessage", maNhanVien, message);
        }

        public async Task NhanTin(string maNhanVien, string message)
        {
            await Clients.User(maNhanVien).SendAsync("ReceiveMessage", message);
        }

        public async Task ThamGiaNhom(string maCongViec)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, maCongViec);
            await Clients.Group(maCongViec).SendAsync("UserJoined", $"{Context.ConnectionId} has joined the group {maCongViec}");
        }
        public async Task ThongBao(string maCongViec,string message)
        {
            await Clients.Group(maCongViec).SendAsync("ReceiveNotification",message);
        }
        public async Task RoiNhom(string maCongViec)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, maCongViec);
        }
        public override Task OnDisconnectedAsync(Exception exception)
        {
            var connectionId = Context.ConnectionId;
            var userId = Context.UserIdentifier;
            return base.OnDisconnectedAsync(exception);
        }
    }
}
