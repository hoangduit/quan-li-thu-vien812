using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace QuanLyThuVien.BAL
{
    class clChucDanh
    {
        public decimal MaCD { get; set; }
        public string TenCD { get; set; } 
        ClConn conn = new ClConn();
        public Decimal Them(clChucDanh obj)// tra ve ma tu tang
        {
            bool completed = false;//True - Thanh cong, False - Khong thuc hien duoc
            Decimal Ma = 0;// Lay ma vua moi them
            DataTable tb;
            try
            {
                string Str = "INSERT INTO TV_ChucDanh   (TenCD) VALUES (@TenCD)";
                conn.AddParameter("@TenCD", obj.TenCD);
                completed = conn.ExecuteUpdate(Str, false);
                if (completed == true)
                {
                    try
                    {
                        string str = " SELECT Top(1) * FROM TV_ChucDanh ORDER BY  MaCD DESC";
                        tb = conn.ExecuteQuery(str);
                        Ma = Decimal.Parse(tb.Rows[0]["MaCD"].ToString());
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
        public bool Sua(clChucDanh obj)
        {
            bool completed = false;
            //True - Thanh cong, False - Khong thuc hien duoc
            try
            {
                string Str = "UPDATE TV_ChucDanh SET   TenCD = @TenCD  WHERE MaCD = @MaCD ";
                conn.AddParameter("@MaCD", obj.MaCD);
                conn.AddParameter("@TenCD", obj.TenCD);
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
                string Str = " DELETE  TV_ChucDanh WHERE MaCD =" + Ma.ToString();
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
                tb = conn.ExecuteQuery("SELECT * FROM TV_ChucDanh WHERE MaCD=" + Ma);
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
                string str = " SELECT Row_number() OVER( ORDER BY MaCD DESC) STT, MaCD= 'MCD00' + convert( nvarchar(200),MaCD),TenCD FROM TV_ChucDanh ";
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
                string str = "SELECT Count(MaCD) As Tong FROM TV_ChucDanh ";
                if (!conn.runSQLReturnValuseSo(str,out Tong))
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
        public clChucDanh LayDS_MaCD(Decimal Ma)
        {
            DataTable tb = new DataTable();
            clChucDanh obj = new clChucDanh();
            try
            {
                tb = conn.ExecuteQuery("SELECT * FROM TV_ChucDanh WHERE MaCD=" + Ma);
                if (tb.Rows.Count > 0)
                {
                    obj.MaCD = Decimal.Parse(tb.Rows[0]["MaCD"].ToString());
                    obj.TenCD = tb.Rows[0]["TenCD"].ToString();
                }
            }
            catch (Exception )
            {
                //throw new Exception(ex.Message);
            }
            return obj;
        } 
    }
}
