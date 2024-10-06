using Job_assignment_management.Domain.Entities;
using Microsoft.AspNetCore.SignalR;

namespace Job_assignment_management.Api.Hubs
{
    public class myHub:Hub
    {
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
        }

        public async Task RoiNhom(string maCongViec)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, maCongViec);
        }
    }
}
