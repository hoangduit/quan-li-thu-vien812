using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace QuanLyThuVien.BAL
{
    class clQuyen
    {
        public Decimal MaQ { get; set; }
        public String TenQ { get; set; }
        public Int32 Admin { get; set; }
        ClConn conn = new ClConn();
        public Decimal Them(clQuyen obj)// tra ve ma tu tang
        {
            bool completed = false;//True - Thanh cong, False - Khong thuc hien duoc
            Decimal Ma = 0;// Lay ma vua moi them
            DataTable tb;
            try
            {
                string Str = "INSERT INTO TV_Quyen   (TenQ, Admin) VALUES (@TenQ, @Admin)";
                conn.AddParameter("@TenQ", obj.TenQ);
                conn.AddParameter("@Admin", obj.Admin);
                completed = conn.ExecuteUpdate(Str, false);
                if (completed == true)
                {
                    try
                    {
                        string str = " SELECT Top(1) * FROM TV_Quyen ORDER BY  MaQ DESC";
                        tb = conn.ExecuteQuery(str);
                        Ma = Decimal.Parse(tb.Rows[0]["MaQ"].ToString());
                    }
                    catch (Exception)
                    {
                        Ma = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                completed = false;
                throw new Exception(ex.Message);
            }
            return Ma;
        }
        public bool Sua(clQuyen obj)
        {
            bool completed = false;
            //True - Thanh cong, False - Khong thuc hien duoc
            try
            {
                string Str = "UPDATE TV_Quyen SET   TenQ = @TenQ , Admin=@Admin  WHERE MaQ = @MaQ ";
                conn.AddParameter("@MaQ", obj.MaQ);
                conn.AddParameter("@TenQ", obj.TenQ);
                conn.AddParameter("@Admin", obj.Admin);
                completed = conn.ExecuteUpdate(Str, false);
            }
            catch (Exception ex)
            {
                completed = false;
                throw new Exception(ex.Message);
            }
            return completed;
        }
        public Int32 Xoa(Decimal Ma)
        {
            int completed = 0;
            //2: Error; 0: Exist; 1: Success 
            try
            {
                string Str = " DELETE  TV_Quyen WHERE MaQ =" + Ma.ToString();
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
            catch (Exception ex)
            {
                completed = 2;
                throw new Exception(ex.Message);
            }
            return completed;
        }
        public bool IsExist(Decimal Ma)
        {
            DataTable tb = new DataTable();
            try
            {
                tb = conn.ExecuteQuery("SELECT * FROM TV_Quyen WHERE MaQ=" + Ma);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return (tb.Rows.Count > 0);
        }
        public DataTable LayDS()
        {
            DataTable tb = new DataTable();
            try
            {
                string str = " SELECT Row_number() OVER( ORDER BY MaQ DESC) STT, MaQ= 'MQ00' + convert( nvarchar(200),MaQ), TenQ, CASE TV_Quyen.Admin when '1' Then N'Quản Trị' ELSE N'Người Dùng' END AS  QuyenHan    FROM TV_Quyen ";
                tb = conn.ExecuteQuery(str);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return tb;
        }
        public Decimal Dem()
        {
            Decimal Tong = 0;
            try
            {
                string str = "SELECT Count(MaQ) As Tong FROM TV_Quyen ";
                if (!conn.runSQLReturnValuseSo(str, out Tong))
                {
                    Tong = 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Tong;
        }
        public clQuyen LayDS_Ma(Decimal Ma)
        {
            DataTable tb = new DataTable();
            clQuyen obj = new clQuyen();
            try
            {
                tb = conn.ExecuteQuery("SELECT * FROM TV_Quyen WHERE MaQ=" + Ma);
                if (tb.Rows.Count > 0)
                {
                    obj.MaQ = Decimal.Parse(tb.Rows[0]["MaQ"].ToString());
                    obj.TenQ = tb.Rows[0]["TenQ"].ToString();
                    obj.Admin = Int32.Parse(tb.Rows[0]["Admin"].ToString());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return obj;
        } 

    }
}
