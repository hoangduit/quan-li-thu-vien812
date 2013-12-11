using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace QuanLyThuVien.BAL
{
    class clLuocSu
    {
        public Decimal MaLS { get; set; }
        public Decimal MaCB { get; set; }
        public String ThaoTac { get; set; }
        public String TomTac { get; set; }
        public DateTime ThoiGian { get; set; }
        public String TenFrom { get; set; }

        ClConn conn = new ClConn();
        public Decimal Them(clLuocSu obj)// tra ve ma tu tang
        {
            bool completed = false;//True - Thanh cong, False - Khong thuc hien duoc
            Decimal Ma = 0;// Lay ma vua moi them
            DataTable tb;
            try
            {
                string Str = "INSERT INTO TV_LuocSu   (MaCB,ThaoTac,TomTac,ThoiGian,TenFrom) VALUES (@MaCB,@ThaoTac,@TomTac,@ThoiGian,@TenFrom)";
                conn.AddParameter("@MaCB", obj.MaCB);
                conn.AddParameter("@ThaoTac", obj.ThaoTac);
                conn.AddParameter("@TomTac", obj.TomTac);
                conn.AddParameter("@ThoiGian", obj.ThoiGian);
                conn.AddParameter("@TenFrom", obj.TenFrom); 
                completed = conn.ExecuteUpdate(Str, false);
                if (completed == true)
                {
                    try
                    {
                        string str = " SELECT * FROM TV_LuocSu ORDER BY  MaLS DESC";
                        tb = conn.ExecuteQuery(str);
                        Ma = Decimal.Parse(tb.Rows[0]["MaLS"].ToString());
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
        public Int32 Xoa(Decimal Ma)
        {
            int completed = 0;
            //-1: Error; 0: Exist; 1: Success 
            try
            {
                string Str = " DELETE  TV_LuocSu WHERE MaLS =" + Ma.ToString();
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
                completed = -1;
                throw new Exception(ex.Message);
            }
            return completed;
        }
        public bool IsExist(Decimal Ma)
        {
            DataTable tb = new DataTable();
            try
            {
                tb = conn.ExecuteQuery("SELECT * FROM TV_LuocSu WHERE MaLS=" + Ma);
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
                string str = " SELECT * FROM TV_LuocSu ";
                tb = conn.ExecuteQuery(str);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return tb;
        } 
    }
}
