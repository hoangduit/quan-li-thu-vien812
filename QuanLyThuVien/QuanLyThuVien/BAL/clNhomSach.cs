using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace QuanLyThuVien.BAL
{
    class clNhomSach
    {
        public Decimal MaNS { get; set; }
        public String TenNS { get; set; }
        public String GhiChu { get; set; }
        public Boolean TrangThai { get; set; }
        ClConn conn = new ClConn();
        public Decimal Them(clNhomSach obj)// tra ve ma tu tang
        {
            bool completed = false;//True - Thanh cong, False - Khong thuc hien duoc
            Decimal Ma = 0;// Lay ma vua moi them
            DataTable tb;
            try
            {
                string Str = "INSERT INTO TV_NhomSach   (TenNS, GhiChu, TrangThai) VALUES (@TenNS, @GhiChu, @TrangThai)";
                conn.AddParameter("@TenNS", obj.TenNS);
                conn.AddParameter("@GhiChu", obj.GhiChu);
                conn.AddParameter("@TrangThai", obj.TrangThai);
                completed = conn.ExecuteUpdate(Str, false);
                if (completed == true)
                {
                    try
                    {
                        string str = " SELECT Top(1) * FROM TV_NhomSach ORDER BY  MaNS DESC";
                        tb = conn.ExecuteQuery(str);
                        Ma = Decimal.Parse(tb.Rows[0]["MaNS"].ToString());
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
        public bool Sua(clNhomSach obj)
        {
            bool completed = false;
            //True - Thanh cong, False - Khong thuc hien duoc
            try
            {
                string Str = "UPDATE TV_NhomSach SET   TenNS=@TenNS, GhiChu=@GhiChu, TrangThai=@TrangThai  WHERE MaNS = @MaNS ";
                conn.AddParameter("@MaNS", obj.MaNS);
                conn.AddParameter("@TenNS", obj.TenNS);
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
                string Str = " DELETE  TV_NhomSach WHERE MaNS =" + Ma.ToString();
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
                tb = conn.ExecuteQuery("SELECT * FROM TV_NhomSach WHERE MaNS=" + Ma);
            }
            catch (Exception  )
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
                string str = " SELECT Row_number() OVER( ORDER BY MaNS DESC) STT, MaNS= 'NS00' + convert( nvarchar(200),MaNS), TenNS, GhiChu, TrangThai FROM TV_NhomSach ";
                tb = conn.ExecuteQuery(str);
            }
            catch (Exception  )
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
                string str = " SELECT Row_number() OVER( ORDER BY MaNS DESC) STT, MaNS= 'NS00' + convert( nvarchar(200),MaNS), TenNS, GhiChu, TrangThai FROM TV_NhomSach  WHERE TrangThai='True'";
                tb = conn.ExecuteQuery(str);
            }
            catch (Exception  )
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
                string str = "SELECT Count(MaNS) As Tong FROM TV_NhomSach ";
                if (!conn.runSQLReturnValuseSo(str, out Tong))
                {
                    Tong = 0;
                }
            }
            catch (Exception  )
            {
               // throw new Exception(ex.Message);
            }
            return Tong;
        }
        public clNhomSach LayDS_Ma(Decimal Ma)
        {
            DataTable tb = new DataTable();
            clNhomSach obj = new clNhomSach();
            try
            {
                tb = conn.ExecuteQuery("SELECT * FROM TV_NhomSach WHERE MaNS=" + Ma);
                if (tb.Rows.Count > 0)
                {
                    obj.MaNS = Decimal.Parse(tb.Rows[0]["MaNS"].ToString());
                    obj.TenNS = tb.Rows[0]["TenNS"].ToString();
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
