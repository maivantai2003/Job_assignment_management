namespace Job_assignment_management.Shared.Common;

public class ThongBaoModel
{
    public int MaThongBao { get; set; } 
    public int MaCongViec {  get; set; }
    public int MaNhanVien {  get; set; }
    public DateTime NgayGui { get; set; }
    public string NoiDungThongBao { get; set; }
    public bool TrangThai { get; set; }
}