using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.BAL
{
    class clPhieuNhapCT
    {
        public decimal MaCTPN { get; set; }
        public decimal MaPhieu { get; set; }
        public decimal MaSach { get; set; }
        public int SoLuong { get; set; }
        public decimal Gia { get; set; }
        public decimal Thue { get; set; }
        public decimal ChietKhau { get; set; }

        ClConn conn = new ClConn();

        public DataTable LayDS()
        {
            DataTable tb = new DataTable();
            try
            {
                string str = @"SELECT Row_number() OVER(ORDER BY MaCTPN DESC) STT,MaPhieuNhap = 'PN000',
                                MaTinhChatNguonNhap,NgayNhap,MaNhanVien,MaNhaCungCap,MaKho,NgayTao,GhiChu FROM TV_PhieuNhap";

                tb = conn.ExecuteQuery(str);
            }
            catch (Exception)
            {
                //throw new Exception(ex.Message);
            }
            return tb;
        }
    }
}
