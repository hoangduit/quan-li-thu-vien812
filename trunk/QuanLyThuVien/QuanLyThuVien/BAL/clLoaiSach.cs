using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace QuanLyThuVien.BAL
{
    class clLoaiSach
    {

        public Decimal MaLS { get; set; }
        public String TenLS { get; set; }
        public String GhiChu { get; set; }
        public Boolean TrangThai { get; set; }
        ClConn conn = new ClConn();
        public Decimal Them(clLoaiSach obj)// tra ve ma tu tang
        {
            bool completed = false;//True - Thanh cong, False - Khong thuc hien duoc
            Decimal Ma = 0;// Lay ma vua moi them
            DataTable tb;
            try
            {
                string Str = "INSERT INTO TV_LoaiSach   (TenLS, GhiChu, TrangThai) VALUES (@TenLS, @GhiChu, @TrangThai)";
                conn.AddParameter("@TenLS", obj.TenLS);
                conn.AddParameter("@GhiChu", obj.GhiChu);
                conn.AddParameter("@TrangThai", obj.TrangThai);
                completed = conn.ExecuteUpdate(Str, false);
                if (completed == true)
                {
                    try
                    {
                        string str = " SELECT Top(1) * FROM TV_LoaiSach ORDER BY  MaLS DESC";
                        tb = conn.ExecuteQuery(str);
                        Ma = Decimal.Parse(tb.Rows[0]["MaLS"].ToString());
                    }
                    catch (Exception)
                    {
                        Ma = 0;
                    }
                }
            }
            catch (Exception  )
            {
                completed = false;
                //throw new Exception(ex.Message);
            }
            return Ma;
        }
        public bool Sua(clLoaiSach obj)
        {
            bool completed = false;
            //True - Thanh cong, False - Khong thuc hien duoc
            try
            {
                string Str = "UPDATE TV_LoaiSach SET   TenLS=@TenLS, GhiChu=@GhiChu, TrangThai=@TrangThai  WHERE MaLS = @MaLS ";
                conn.AddParameter("@MaLS", obj.MaLS);
                conn.AddParameter("@TenLS", obj.TenLS);
                conn.AddParameter("@GhiChu", obj.GhiChu);
                conn.AddParameter("@TrangThai", obj.TrangThai);
                completed = conn.ExecuteUpdate(Str, false);
            }
            catch (Exception  )
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
                string Str = " DELETE  TV_LoaiSach WHERE MaLS =" + Ma.ToString();
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
            catch (Exception  )
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
                tb = conn.ExecuteQuery("SELECT * FROM TV_LoaiSach WHERE MaLS=" + Ma);
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
                string str = " SELECT Row_number() OVER( ORDER BY MaLS DESC) STT, MaLS= 'LS00' + convert( nvarchar(200),MaLS), TenLS, GhiChu, TrangThai FROM TV_LoaiSach ";
                tb = conn.ExecuteQuery(str);
            }
            catch (Exception  )
            {
               // throw new Exception(ex.Message);
            }
            return tb;
        }

        public DataTable LoadCbb()
        {
            DataTable tb = new DataTable();
            try
            {
                string str = " SELECT Row_number() OVER( ORDER BY MaLS DESC) STT, MaLS= 'LS00' + convert( nvarchar(200),MaLS), TenLS, GhiChu, TrangThai FROM TV_LoaiSach  WHERE TrangThai='True'";
                tb = conn.ExecuteQuery(str);
            }
            catch (Exception  )
            {
               // throw new Exception(ex.Message);
            }
            return tb;
        }
        public Decimal Dem()
        {
            Decimal Tong = 0;
            try
            {
                string str = "SELECT Count(MaLS) As Tong FROM TV_LoaiSach ";
                if (!conn.runSQLReturnValuseSo(str, out Tong))
                {
                    Tong = 0;
                }
            }
            catch (Exception  )
            {
                //throw new Exception(ex.Message);
            }
            return Tong;
        }
        public clLoaiSach LayDS_Ma(Decimal Ma)
        {
            DataTable tb = new DataTable();
            clLoaiSach obj = new clLoaiSach();
            try
            {
                tb = conn.ExecuteQuery("SELECT * FROM TV_LoaiSach WHERE MaLS=" + Ma);
                if (tb.Rows.Count > 0)
                {
                    obj.MaLS = Decimal.Parse(tb.Rows[0]["MaLS"].ToString());
                    obj.TenLS = tb.Rows[0]["TenLS"].ToString();
                    obj.GhiChu = tb.Rows[0]["GhiChu"].ToString();
                    obj.TrangThai = Boolean.Parse(tb.Rows[0]["TrangThai"].ToString());
                }
            }
            catch (Exception  )
            {
               // throw new Exception(ex.Message);
            }
            return obj;
        } 
    }
}
