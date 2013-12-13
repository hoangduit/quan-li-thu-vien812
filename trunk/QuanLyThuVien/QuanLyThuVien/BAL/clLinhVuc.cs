using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace QuanLyThuVien.BAL
{
    class clLinhVuc
    {
        public Decimal MaLV { get; set; }
        public String TenLV { get; set; }
        public String GhiChu { get; set; }
        public Boolean TrangThai { get; set; }
        ClConn conn = new ClConn();
        public Decimal Them(clLinhVuc obj)// tra ve ma tu tang
        {
            bool completed = false;//True - Thanh cong, False - Khong thuc hien duoc
            Decimal Ma = 0;// Lay ma vua moi them
            DataTable tb;
            try
            {
                string Str = "INSERT INTO TV_LinhVuc   (TenLV, GhiChu, TrangThai) VALUES (@TenLV, @GhiChu, @TrangThai)";
                conn.AddParameter("@TenLV", obj.TenLV);
                conn.AddParameter("@GhiChu", obj.GhiChu);
                conn.AddParameter("@TrangThai", obj.TrangThai);
                completed = conn.ExecuteUpdate(Str, false);
                if (completed == true)
                {
                    try
                    {
                        string str = " SELECT Top(1) * FROM TV_LinhVuc ORDER BY  MaLV DESC";
                        tb = conn.ExecuteQuery(str);
                        Ma = Decimal.Parse(tb.Rows[0]["MaLV"].ToString());
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
        public bool Sua(clLinhVuc obj)
        {
            bool completed = false;
            //True - Thanh cong, False - Khong thuc hien duoc
            try
            {
                string Str = "UPDATE TV_LinhVuc SET   TenLV=@TenLV, GhiChu=@GhiChu, TrangThai=@TrangThai  WHERE MaLV = @MaLV ";
                conn.AddParameter("@MaLV", obj.MaLV);
                conn.AddParameter("@TenLV", obj.TenLV);
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
                string Str = " DELETE  TV_LinhVuc WHERE MaLV =" + Ma.ToString();
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
                tb = conn.ExecuteQuery("SELECT * FROM TV_LinhVuc WHERE MaLV=" + Ma);
            }
            catch (Exception   )
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
                string str = " SELECT Row_number() OVER( ORDER BY MaLV DESC) STT, MaLV= 'LV00' + convert( nvarchar(200),MaLV), TenLV, GhiChu, TrangThai FROM TV_LinhVuc ";
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
                string str = " SELECT Row_number() OVER( ORDER BY MaLV DESC) STT, MaLV= 'LV00' + convert( nvarchar(200),MaLV), TenLV, GhiChu, TrangThai FROM TV_LinhVuc  WHERE TrangThai='True'";
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
                string str = "SELECT Count(MaLV) As Tong FROM TV_LinhVuc ";
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
        public clLinhVuc LayDS_Ma(Decimal Ma)
        {
            DataTable tb = new DataTable();
            clLinhVuc obj = new clLinhVuc();
            try
            {
                tb = conn.ExecuteQuery("SELECT * FROM TV_LinhVuc WHERE MaLV=" + Ma);
                if (tb.Rows.Count > 0)
                {
                    obj.MaLV = Decimal.Parse(tb.Rows[0]["MaLV"].ToString());
                    obj.TenLV = tb.Rows[0]["TenLV"].ToString();
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
