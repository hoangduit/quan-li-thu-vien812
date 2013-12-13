using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace QuanLyThuVien.BAL
{
    class clDonViTinh
    {
        public Decimal MaDVT { get; set; }
        public String TenDVT { get; set; }
        public String GhiChu { get; set; }
        public Boolean TrangThai { get; set; } 
        ClConn conn = new ClConn();
        public Decimal Them(clDonViTinh obj)// tra ve ma tu tang
        {
            bool completed = false;//True - Thanh cong, False - Khong thuc hien duoc
            Decimal Ma = 0;// Lay ma vua moi them
            DataTable tb;
            try
            {
                string Str = "INSERT INTO TV_DonViTinh   (TenDVT, GhiChu, TrangThai) VALUES (@TenDVT, @GhiChu, @TrangThai)";
                conn.AddParameter("@TenDVT", obj.TenDVT);
                conn.AddParameter("@GhiChu", obj.GhiChu);
                conn.AddParameter("@TrangThai", obj.TrangThai);
                completed = conn.ExecuteUpdate(Str, false);
                if (completed == true)
                {
                    try
                    {
                        string str = " SELECT Top(1) * FROM TV_DonViTinh ORDER BY  MaDVT DESC";
                        tb = conn.ExecuteQuery(str);
                        Ma = Decimal.Parse(tb.Rows[0]["MaDVT"].ToString());
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
        public bool Sua(clDonViTinh obj)
        {
            bool completed = false;
            //True - Thanh cong, False - Khong thuc hien duoc
            try
            {
                string Str = "UPDATE TV_DonViTinh SET   TenDVT=@TenDVT, GhiChu=@GhiChu, TrangThai=@TrangThai  WHERE MaDVT = @MaDVT ";
                conn.AddParameter("@MaDVT", obj.MaDVT);
                conn.AddParameter("@TenDVT", obj.TenDVT);
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
                string Str = " DELETE  TV_DonViTinh WHERE MaDVT =" + Ma.ToString();
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
                tb = conn.ExecuteQuery("SELECT * FROM TV_DonViTinh WHERE MaDVT=" + Ma);
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
                string str = " SELECT Row_number() OVER( ORDER BY MaDVT DESC) STT, MaDVT= 'DVT00' + convert( nvarchar(200),MaDVT), TenDVT, GhiChu, TrangThai FROM TV_DonViTinh ";
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
                string str = " SELECT Row_number() OVER( ORDER BY MaDVT DESC) STT, MaDVT= 'DVT00' + convert( nvarchar(200),MaDVT), TenDVT, GhiChu, TrangThai FROM TV_DonViTinh WHERE TrangThai='True'";
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
                string str = "SELECT Count(MaDVT) As Tong FROM TV_DonViTinh ";
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
        public clDonViTinh LayDS_Ma(Decimal Ma)
        {
            DataTable tb = new DataTable();
            clDonViTinh obj = new clDonViTinh();
            try
            {
                tb = conn.ExecuteQuery("SELECT * FROM TV_DonViTinh WHERE MaDVT=" + Ma);
                if (tb.Rows.Count > 0)
                {
                    obj.MaDVT = Decimal.Parse(tb.Rows[0]["MaDVT"].ToString());
                    obj.TenDVT = tb.Rows[0]["TenDVT"].ToString();
                    obj.GhiChu = tb.Rows[0]["GhiChu"].ToString();
                    obj.TrangThai =Boolean.Parse( tb.Rows[0]["TrangThai"].ToString());
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
