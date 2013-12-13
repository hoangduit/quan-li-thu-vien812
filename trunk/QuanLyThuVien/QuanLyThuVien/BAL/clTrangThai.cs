using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace QuanLyThuVien.BAL
{
    class clTrangThai
    {
        public Decimal MaTT { get; set; }
        public String TenTT { get; set; }
        public String GhiChu { get; set; }
        public Boolean TrangThai { get; set; }
        ClConn conn = new ClConn();
        public Decimal Them(clTrangThai obj)// tra ve ma tu tang
        {
            bool completed = false;//True - Thanh cong, False - Khong thuc hien duoc
            Decimal Ma = 0;// Lay ma vua moi them
            DataTable tb;
            try
            {
                string Str = "INSERT INTO TV_TrangThaiSach   (TenTT, GhiChu, TrangThai) VALUES (@TenTT, @GhiChu, @TrangThai)";
                conn.AddParameter("@TenTT", obj.TenTT);
                conn.AddParameter("@GhiChu", obj.GhiChu);
                conn.AddParameter("@TrangThai", obj.TrangThai);
                completed = conn.ExecuteUpdate(Str, false);
                if (completed == true)
                {
                    try
                    {
                        string str = " SELECT Top(1) * FROM TV_TrangThaiSach ORDER BY  MaTT DESC";
                        tb = conn.ExecuteQuery(str);
                        Ma = Decimal.Parse(tb.Rows[0]["MaTT"].ToString());
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
        public bool Sua(clTrangThai obj)
        {
            bool completed = false;
            //True - Thanh cong, False - Khong thuc hien duoc
            try
            {
                string Str = "UPDATE TV_TrangThaiSach SET   TenTT=@TenTT, GhiChu=@GhiChu, TrangThai=@TrangThai  WHERE MaTT = @MaTT ";
                conn.AddParameter("@MaTT", obj.MaTT);
                conn.AddParameter("@TenTT", obj.TenTT);
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
                string Str = " DELETE  TV_TrangThaiSach WHERE MaTT =" + Ma.ToString();
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
                tb = conn.ExecuteQuery("SELECT * FROM TV_TrangThaiSach WHERE MaTT=" + Ma);
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
                string str = " SELECT Row_number() OVER( ORDER BY MaTT DESC) STT, MaTT= 'TrT00' + convert( nvarchar(200),MaTT), TenTT, GhiChu, TrangThai FROM TV_TrangThaiSach ";
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
                string str = " SELECT Row_number() OVER( ORDER BY MaTT DESC) STT, MaTT= 'TrT00' + convert( nvarchar(200),MaTT), TenTT, GhiChu, TrangThai FROM TV_TrangThaiSach  WHERE TrangThai='True'";
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
                string str = "SELECT Count(MaTT) As Tong FROM TV_TrangThaiSach ";
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
        public clTrangThai LayDS_Ma(Decimal Ma)
        {
            DataTable tb = new DataTable();
            clTrangThai obj = new clTrangThai();
            try
            {
                tb = conn.ExecuteQuery("SELECT * FROM TV_TrangThaiSach WHERE MaTT=" + Ma);
                if (tb.Rows.Count > 0)
                {
                    obj.MaTT = Decimal.Parse(tb.Rows[0]["MaTT"].ToString());
                    obj.TenTT = tb.Rows[0]["TenTT"].ToString();
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
