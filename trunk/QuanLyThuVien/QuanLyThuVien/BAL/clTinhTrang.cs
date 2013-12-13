using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace QuanLyThuVien.BAL
{
    class clTinhTrang
    {
        public Decimal MaTTS { get; set; }
        public String TenTTS { get; set; }
        public String GhiChu { get; set; }
        public Boolean TrangThai { get; set; }
        ClConn conn = new ClConn();
        public Decimal Them(clTinhTrang obj)// tra ve ma tu tang
        {
            bool completed = false;//True - Thanh cong, False - Khong thuc hien duoc
            Decimal Ma = 0;// Lay ma vua moi them
            DataTable tb;
            try
            {
                string Str = "INSERT INTO TV_TinhTrangSach   (TenTTS, GhiChu, TrangThai) VALUES (@TenTTS, @GhiChu, @TrangThai)";
                conn.AddParameter("@TenTTS", obj.TenTTS);
                conn.AddParameter("@GhiChu", obj.GhiChu);
                conn.AddParameter("@TrangThai", obj.TrangThai);
                completed = conn.ExecuteUpdate(Str, false);
                if (completed == true)
                {
                    try
                    {
                        string str = " SELECT Top(1) * FROM TV_TinhTrangSach ORDER BY  MaTTS DESC";
                        tb = conn.ExecuteQuery(str);
                        Ma = Decimal.Parse(tb.Rows[0]["MaTTS"].ToString());
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
        public bool Sua(clTinhTrang obj)
        {
            bool completed = false;
            //True - Thanh cong, False - Khong thuc hien duoc
            try
            {
                string Str = "UPDATE TV_TinhTrangSach SET   TenTTS=@TenTTS, GhiChu=@GhiChu, TrangThai=@TrangThai  WHERE MaTTS = @MaTTS ";
                conn.AddParameter("@MaTTS", obj.MaTTS);
                conn.AddParameter("@TenTTS", obj.TenTTS);
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
                string Str = " DELETE  TV_TinhTrangSach WHERE MaTTS =" + Ma.ToString();
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
                tb = conn.ExecuteQuery("SELECT * FROM TV_TinhTrangSach WHERE MaTTS=" + Ma);
            }
            catch (Exception)
            {
                //throw new Exception(ex.Message);
            }
            return (tb.Rows.Count > 0);
        }
        public DataTable LayDS()
        {
            DataTable tb = new DataTable();
            try
            {
                string str = " SELECT Row_number() OVER( ORDER BY MaTTS DESC) STT, MaTTS= 'TTr00' + convert( nvarchar(200),MaTTS), TenTTS, GhiChu, TrangThai FROM TV_TinhTrangSach ";
                tb = conn.ExecuteQuery(str);
            }
            catch (Exception)
            {
                //throw new Exception(ex.Message);
            }
            return tb;
        }
        public DataTable LoadCbb()
        {
            DataTable tb = new DataTable();
            try
            {
                string str = " SELECT Row_number() OVER( ORDER BY MaTTS DESC) STT, MaTTS= 'TTr00' + convert( nvarchar(200),MaTTS), TenTTS, GhiChu, TrangThai FROM TV_TinhTrangSach  WHERE TrangThai='True'";
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
                string str = "SELECT Count(MaTTS) As Tong FROM TV_TinhTrangSach ";
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
        public clTinhTrang LayDS_Ma(Decimal Ma)
        {
            DataTable tb = new DataTable();
            clTinhTrang obj = new clTinhTrang();
            try
            {
                tb = conn.ExecuteQuery("SELECT * FROM TV_TinhTrangSach WHERE MaTTS=" + Ma);
                if (tb.Rows.Count > 0)
                {
                    obj.MaTTS = Decimal.Parse(tb.Rows[0]["MaTTS"].ToString());
                    obj.TenTTS = tb.Rows[0]["TenTTS"].ToString();
                    obj.GhiChu = tb.Rows[0]["GhiChu"].ToString();
                    obj.TrangThai = Boolean.Parse(tb.Rows[0]["TrangThai"].ToString());
                }
            }
            catch (Exception)
            {
                //throw new Exception(ex.Message);
            }
            return obj;
        } 
    }
}
