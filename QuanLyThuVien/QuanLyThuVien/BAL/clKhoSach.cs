using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.BAL
{
    class clKhoSach
    {
        public decimal MaK { get; set; }
        public string TenK { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string GhiChu { get; set; }
        public int TrangThai { get; set; }

        ClConn conn = new ClConn();

        public DataTable LayDS()
        {
            DataTable tb = new DataTable();
            try
            {
                string str = @"SELECT Row_number() OVER( ORDER BY MaK DESC) STT,MaK,
                                TenK,DiaChi,SoDienThoai,GhiChu,TrangThai FROM TV_KhoSach";

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
                string str = "SELECT Count(MaK) As Tong FROM TV_KhoSach ";
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

        public clKhoSach LayDS_MaK(Decimal Ma)
        {
            DataTable tb = new DataTable();
            clKhoSach obj = new clKhoSach();
            try
            {
                tb = conn.ExecuteQuery("SELECT * FROM TV_KhoSach WHERE MaK = " + Ma);
                if (tb.Rows.Count > 0)
                {
                    obj.MaK = Decimal.Parse(tb.Rows[0]["MaK"].ToString());
                    obj.TenK = tb.Rows[0]["TenK"].ToString();
                    obj.DiaChi = tb.Rows[0]["DiaChi"].ToString();
                    obj.SoDienThoai = tb.Rows[0]["SoDienThoai"].ToString();
                    obj.GhiChu = tb.Rows[0]["GhiChu"].ToString();
                    obj.TrangThai = int.Parse(tb.Rows[0]["TrangThai"].ToString());
                }
            }
            catch (Exception)
            {
                //throw new Exception(ex.Message);
            }
            return obj;
        }

        public Decimal Them(clKhoSach obj)// tra ve ma tu tang
        {
            bool completed = false;//True - Thanh cong, False - Khong thuc hien duoc
            Decimal Ma = 0;// Lay ma vua moi them
            DataTable tb;

            try
            {
                string Str = @"INSERT INTO TV_KhoSach (TenK) VALUES (@TenK), (DiaChi) VALUES (@DiaChi),
                                (SoDienThoai) VALUES (@SoDienThoai),
                                (GhiChu) VALUES (@GhiChu), (TrangThai) VALUES (@TrangThai)";

                conn.AddParameter("@TenK", obj.TenK);
                conn.AddParameter("@DiaChi", obj.DiaChi);
                conn.AddParameter("@SoDienThoai", obj.SoDienThoai);
                conn.AddParameter("@GhiChu", obj.GhiChu);
                conn.AddParameter("@TrangThai", obj.TrangThai);

                completed = conn.ExecuteUpdate(Str, false);

                if (completed == true)
                {
                    try
                    {
                        string str = " SELECT Top(1) * FROM TV_KhoSach ORDER BY MaK DESC";
                        tb = conn.ExecuteQuery(str);
                        Ma = Decimal.Parse(tb.Rows[0]["MaK"].ToString());
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

        public bool Sua(clKhoSach obj)
        {
            bool completed = false;
            //True - Thanh cong, False - Khong thuc hien duoc

            try
            {
                string Str = @"UPDATE TV_NhaCungCap SET TenK = @TenK, DiaChi = @DiaChi,
                                SoDienThoai = @SoDienThoai, 
                                GhiChu = @GhiChu, TrangThai = @TrangThai
                                WHERE MaK = @MaK";

                conn.AddParameter("@MaK", obj.MaK);
                conn.AddParameter("@TenK", obj.TenK);
                conn.AddParameter("@DiaChi", obj.DiaChi);
                conn.AddParameter("@SoDienThoai", obj.SoDienThoai);
                conn.AddParameter("@GhiChu", obj.GhiChu);
                conn.AddParameter("@TrangThai", obj.TrangThai);

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
                string Str = "DELETE TV_KhoSach WHERE MaK = " + Ma.ToString();

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
                tb = conn.ExecuteQuery("SELECT * FROM TV_KhoSach WHERE MaK = " + Ma);
            }
            catch (Exception)
            {
                //throw new Exception(ex.Message);
            }
            return (tb.Rows.Count > 0);
        }
    }
}
