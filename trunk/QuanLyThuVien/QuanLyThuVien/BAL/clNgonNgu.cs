using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace QuanLyThuVien.BAL
{
    class clNgonNgu
    {
        public Decimal MaNN { get; set; }
        public String TenNN { get; set; }
        public String GhiChu { get; set; }
        public Boolean TrangThai { get; set; }
        ClConn conn = new ClConn();
        public Decimal Them(clNgonNgu obj)// tra ve ma tu tang
        {
            bool completed = false;//True - Thanh cong, False - Khong thuc hien duoc
            Decimal Ma = 0;// Lay ma vua moi them
            DataTable tb;
            try
            {
                string Str = "INSERT INTO TV_NgonNgu   (TenNN, GhiChu, TrangThai) VALUES (@TenNN, @GhiChu, @TrangThai)";
                conn.AddParameter("@TenNN", obj.TenNN);
                conn.AddParameter("@GhiChu", obj.GhiChu);
                conn.AddParameter("@TrangThai", obj.TrangThai);
                completed = conn.ExecuteUpdate(Str, false);
                if (completed == true)
                {
                    try
                    {
                        string str = " SELECT Top(1) * FROM TV_NgonNgu ORDER BY  MaNN DESC";
                        tb = conn.ExecuteQuery(str);
                        Ma = Decimal.Parse(tb.Rows[0]["MaNN"].ToString());
                    }
                    catch (Exception)
                    {
                        Ma = 0;
                    }
                }
            }
            catch (Exception )
            {
                completed = false;
                //throw new Exception(ex.Message);
            }
            return Ma;
        }
        public bool Sua(clNgonNgu obj)
        {
            bool completed = false;
            //True - Thanh cong, False - Khong thuc hien duoc
            try
            {
                string Str = "UPDATE TV_NgonNgu SET   TenNN=@TenNN, GhiChu=@GhiChu, TrangThai=@TrangThai  WHERE MaNN = @MaNN ";
                conn.AddParameter("@MaNN", obj.MaNN);
                conn.AddParameter("@TenNN", obj.TenNN);
                conn.AddParameter("@GhiChu", obj.GhiChu);
                conn.AddParameter("@TrangThai", obj.TrangThai);
                completed = conn.ExecuteUpdate(Str, false);
            }
            catch (Exception )
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
                string Str = " DELETE  TV_NgonNgu WHERE MaNN =" + Ma.ToString();
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
            catch (Exception )
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
                tb = conn.ExecuteQuery("SELECT * FROM TV_NgonNgu WHERE MaNN=" + Ma);
            }
            catch (Exception )
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
                string str = " SELECT Row_number() OVER( ORDER BY MaNN DESC) STT, MaNN= 'NN00' + convert( nvarchar(200),MaNN), TenNN, GhiChu, TrangThai FROM TV_NgonNgu ";
                tb = conn.ExecuteQuery(str);
            }
            catch (Exception )
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
                string str = " SELECT Row_number() OVER( ORDER BY MaNN DESC) STT, MaNN= 'NN00' + convert( nvarchar(200),MaNN), TenNN, GhiChu, TrangThai FROM TV_NgonNgu  WHERE TrangThai='True'";
                tb = conn.ExecuteQuery(str);
            }
            catch (Exception )
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
                string str = "SELECT Count(MaNN) As Tong FROM TV_NgonNgu ";
                if (!conn.runSQLReturnValuseSo(str, out Tong))
                {
                    Tong = 0;
                }
            }
            catch (Exception )
            {
                //throw new Exception(ex.Message);
            }
            return Tong;
        }
        public clNgonNgu LayDS_Ma(Decimal Ma)
        {
            DataTable tb = new DataTable();
            clNgonNgu obj = new clNgonNgu();
            try
            {
                tb = conn.ExecuteQuery("SELECT * FROM TV_NgonNgu WHERE MaNN=" + Ma);
                if (tb.Rows.Count > 0)
                {
                    obj.MaNN = Decimal.Parse(tb.Rows[0]["MaNN"].ToString());
                    obj.TenNN = tb.Rows[0]["TenNN"].ToString();
                    obj.GhiChu = tb.Rows[0]["GhiChu"].ToString();
                    obj.TrangThai = Boolean.Parse(tb.Rows[0]["TrangThai"].ToString());
                }
            }
            catch (Exception  )
            {
                //throw new Exception(ex.Message);
            }
            return obj;
        } 
    }
}
