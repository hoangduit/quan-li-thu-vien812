using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.BAL
{
    class clPhieuNhap
    {
        public decimal MaPN { get; set; }
        public string MaPhieuNhap { get; set; }
        public decimal MaTinhChatNguonNhap { get; set; }
        public DateTime NgayNhap { get; set; }
        public decimal MaNhanVien { get; set; }
        public decimal MaNhaCungCap { get; set; }
        public decimal MaKho { get; set; }
        public DateTime NgayTao { get; set; }
        public string GhiChu { get; set; }

        ClConn conn = new ClConn();

        public DataTable LayDS()
        {
            DataTable tb = new DataTable();
            try
            {
                string str = @"SELECT Row_number() OVER(ORDER BY MaPN DESC) STT,MaPhieuNhap = 'PN000',
                                MaTinhChatNguonNhap,NgayNhap,MaNhanVien,MaNhaCungCap,MaKho,NgayTao,GhiChu FROM TV_PhieuNhap";

                tb = conn.ExecuteQuery(str);
            }
            catch (Exception)
            {
                //throw new Exception(ex.Message);
            }
            return tb;
        }

        public Decimal Dem()
        {
            Decimal Tong = 0;
            try
            {
                string str = "SELECT Count(MaPN) As Tong FROM TV_PhieuNhap";

                if (!conn.runSQLReturnValuseSo(str, out Tong))
                {
                    Tong = 0;
                }
            }
            catch (Exception)
            {
                //throw new Exception(ex.Message);
            }
            return Tong;
        }

        public clPhieuNhap LayDS_MaPN(Decimal Ma)
        {
            DataTable tb = new DataTable();
            clPhieuNhap obj = new clPhieuNhap();
            try
            {
                tb = conn.ExecuteQuery("SELECT * FROM TV_PhieuNhap WHERE MaPN = " + Ma);
                if (tb.Rows.Count > 0)
                {
                    obj.MaPN = Decimal.Parse(tb.Rows[0]["MaPN"].ToString());
                    obj.MaPhieuNhap = tb.Rows[0]["MaPhieuNhap"].ToString();
                    obj.MaTinhChatNguonNhap = Decimal.Parse(tb.Rows[0]["MaTinhChatNguonNhap"].ToString());
                    obj.NgayNhap = DateTime.Parse(tb.Rows[0]["NgayNhap"].ToString());
                    obj.MaNhanVien = Decimal.Parse(tb.Rows[0]["MaNhanVien"].ToString());
                    obj.MaNhaCungCap = Decimal.Parse(tb.Rows[0]["MaNhaCungCap"].ToString());
                    obj.MaKho = Decimal.Parse(tb.Rows[0]["MaKho"].ToString());
                    obj.NgayTao = DateTime.Parse(tb.Rows[0]["NgayTao"].ToString());
                    obj.GhiChu = tb.Rows[0]["GhiChu"].ToString();
                }
            }
            catch (Exception)
            {
                //throw new Exception(ex.Message);
            }
            return obj;
        }

        public Decimal Them(clPhieuNhap obj)// tra ve ma tu tang
        {
            bool completed = false;//True - Thanh cong, False - Khong thuc hien duoc
            Decimal Ma = 0;// Lay ma vua moi them
            DataTable tb;

            try
            {
                string Str = @"INSERT INTO TV_PhieuNhap (MaPhieuNhap) VALUES (@MaPhieuNhap),
                                (MaTinhChatNguonNhap) VALUES (@MaTinhChatNguonNhap),
                                (NgayNhap) VALUES (@NgayNhap), (MaNhanVien) VALUES (@MaNhanVien),
                                (MaNhaCungCap) VALUES (@MaNhaCungCap), (MaKho) VALUES (@MaKho),
                                (NgayTao) VALUES (@NgayTao), (GhiChu) VALUES (@GhiChu)";

                conn.AddParameter("@MaPhieuNhap", obj.MaPhieuNhap);
                conn.AddParameter("@MaTinhChatNguonNhap", obj.MaTinhChatNguonNhap);
                conn.AddParameter("@NgayNhap", obj.NgayNhap);
                conn.AddParameter("@MaNhanVien", obj.MaNhanVien);
                conn.AddParameter("@MaNhaCungCap", obj.MaNhaCungCap);
                conn.AddParameter("@MaKho", obj.MaKho);
                conn.AddParameter("@NgayTao", obj.NgayTao);
                conn.AddParameter("@GhiChu", obj.GhiChu);

                completed = conn.ExecuteUpdate(Str, false);

                if (completed == true)
                {
                    try
                    {
                        string str = " SELECT Top(1) * FROM TV_PhieuNhap ORDER BY MaPN DESC";
                        tb = conn.ExecuteQuery(str);
                        Ma = Decimal.Parse(tb.Rows[0]["MaPN"].ToString());
                    }
                    catch (Exception)
                    {
                        Ma = 0;
                    }
                }
            }
            catch (Exception)
            {
                completed = false;
                //throw new Exception(ex.Message);
            }

            return Ma;
        }

        public bool Sua(clPhieuNhap obj)
        {
            bool completed = false;
            //True - Thanh cong, False - Khong thuc hien duoc

            try
            {
                string Str = @"UPDATE TV_PhieuNhap SET MaPhieuNhap = @MaPhieuNhap, MaTinhChatNguonNhap = @MaTinhChatNguonNhap, 
                                 NgayNhap = @NgayNhap, MaNhanVien = @MaNhanVien,
                                MaNhaCungCap = @MaNhaCungCap, MaKho = @MaKho,
                                NgayTao = @NgayTao, GhiChu = @GhiChu
                                WHERE MaPN = @MaPN ";

                conn.AddParameter("@MaPN", obj.MaPN);
                conn.AddParameter("@MaPhieuNhap", obj.MaPhieuNhap);
                conn.AddParameter("@MaTinhChatNguonNhap", obj.MaTinhChatNguonNhap);
                conn.AddParameter("@NgayNhap", obj.NgayNhap);
                conn.AddParameter("@MaNhanVien", obj.MaNhanVien);
                conn.AddParameter("@MaNhaCungCap", obj.MaNhaCungCap);
                conn.AddParameter("@MaKho", obj.MaKho);
                conn.AddParameter("@NgayTao", obj.NgayTao);
                conn.AddParameter("@GhiChu", obj.GhiChu);

                completed = conn.ExecuteUpdate(Str, false);
            }
            catch (Exception)
            {
                completed = false;
                //throw new Exception(ex.Message);
            }

            return completed;
        }

        public Int32 Xoa(Decimal Ma)
        {
            int completed = 0;
            //2: Error; 0: Exist; 1: Success 
            try
            {
                string Str = "DELETE TV_PhieuNhap WHERE MaPN = " + Ma.ToString();
                if (IsExist(Ma) == true)
                {
                    if (conn.ExecuteUpdate(Str, false))
                    {
                        completed = 1;
                    }
                }
                else
                {
                    completed = 0;
                }
            }
            catch (Exception)
            {
                completed = 2;
                //throw new Exception(ex.Message);
            }
            return completed;
        }

        public bool IsExist(Decimal Ma)
        {
            DataTable tb = new DataTable();
            try
            {
                tb = conn.ExecuteQuery("SELECT * FROM TV_PhieuNhap WHERE MaPN = " + Ma);
            }
            catch (Exception)
            {
                //throw new Exception(ex.Message);
            }
            return (tb.Rows.Count > 0);
        }
    }
}
