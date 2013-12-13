using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace QuanLyThuVien.BAL
{
    class clNhaXuatBan
    {
        public Decimal MaNXB { get; set; }
        public String TenNXB { get; set; }
        public String DiaChiNXB { get; set; }
        public String SDTNXB { get; set; }
        public String FaxNXB { get; set; }
        public String MailNXB { get; set; }
        public String GhiChu { get; set; }
        public Boolean TrangThai { get; set; }
        ClConn conn = new ClConn();
        public Decimal Them(clNhaXuatBan obj)// tra ve ma tu tang
        {
            bool completed = false;//True - Thanh cong, False - Khong thuc hien duoc
            Decimal Ma = 0;// Lay ma vua moi them
            DataTable tb;
            try
            {
                string Str = "INSERT INTO TV_NhaXuatBan   (TenNXB, DiaChiNXB, SDTNXB, FaxNXB, MailNXB, GhiChu, TrangThai) VALUES (@TenNXB, @DiaChiNXB, @SDTNXB, @FaxNXB, @MailNXB, @GhiChu, @TrangThai)";
                conn.AddParameter("@TenNXB", obj.TenNXB);
                conn.AddParameter("@DiaChiNXB", obj.DiaChiNXB);
                conn.AddParameter("@SDTNXB", obj.SDTNXB);
                conn.AddParameter("@FaxNXB", obj.FaxNXB);
                conn.AddParameter("@MailNXB", obj.MailNXB);
                conn.AddParameter("@GhiChu", obj.GhiChu);
                conn.AddParameter("@TrangThai", obj.TrangThai);
                completed = conn.ExecuteUpdate(Str, false);
                if (completed == true)
                {
                    try
                    {
                        string str = " SELECT Top(1) * FROM TV_NhaXuatBan ORDER BY  MaNXB DESC";
                        tb = conn.ExecuteQuery(str);
                        Ma = Decimal.Parse(tb.Rows[0]["MaNXB"].ToString());
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
        public bool Sua(clNhaXuatBan obj)
        {
            bool completed = false;
            //True - Thanh cong, False - Khong thuc hien duoc
            try
            {
                string Str = "UPDATE TV_NhaXuatBan SET   TenNXB=@TenNXB, DiaChiNXB=@DiaChiNXB, SDTNXB=@SDTNXB, FaxNXB=@FaxNXB, MailNXB=@MailNXB, GhiChu=@GhiChu, TrangThai=@TrangThai  WHERE MaNXB = @MaNXB ";
                conn.AddParameter("@MaNXB", obj.MaNXB);
                conn.AddParameter("@TenNXB", obj.TenNXB);
                conn.AddParameter("@DiaChiNXB", obj.DiaChiNXB);
                conn.AddParameter("@SDTNXB", obj.SDTNXB);
                conn.AddParameter("@FaxNXB", obj.FaxNXB);
                conn.AddParameter("@MailNXB", obj.MailNXB);
                conn.AddParameter("@GhiChu", obj.GhiChu);
                conn.AddParameter("@TrangThai", obj.TrangThai);
                completed = conn.ExecuteUpdate(Str, false);
            }
            catch (Exception  )
            {
                completed = false;
               // throw new Exception(ex.Message);
            }
            return completed;
        }
        public Int32 Xoa(Decimal Ma)
        {
            int completed = 0;
            //2: Error; 0: Exist; 1: Success 
            try
            {
                string Str = " DELETE  TV_NhaXuatBan WHERE MaNXB =" + Ma.ToString();
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
                tb = conn.ExecuteQuery("SELECT * FROM TV_NhaXuatBan WHERE MaNXB=" + Ma);
            }
            catch (Exception  )
            {
               // throw new Exception(ex.Message);
            }
            return (tb.Rows.Count > 0);
        }
        public DataTable LayDS()
        {
            DataTable tb = new DataTable();
            try
            {
                string str = " SELECT Row_number() OVER( ORDER BY MaNXB DESC) STT, MaNXB= 'NXB00' + convert( nvarchar(200),MaNXB), TenNXB, DiaChiNXB, SDTNXB, FaxNXB, MailNXB, GhiChu, TrangThai FROM TV_NhaXuatBan ";
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
                string str = " SELECT Row_number() OVER( ORDER BY MaNXB DESC) STT, MaNXB= 'NXB00' + convert( nvarchar(200),MaNXB), TenNXB, DiaChiNXB, SDTNXB, FaxNXB, MailNXB, GhiChu, TrangThai FROM TV_NhaXuatBan  WHERE TrangThai='True'";
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
                string str = "SELECT Count(MaNXB) As Tong FROM TV_NhaXuatBan ";
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
        public clNhaXuatBan LayDS_Ma(Decimal Ma)
        {
            DataTable tb = new DataTable();
            clNhaXuatBan obj = new clNhaXuatBan();
            try
            {
                tb = conn.ExecuteQuery("SELECT * FROM TV_NhaXuatBan WHERE MaNXB=" + Ma);
                if (tb.Rows.Count > 0)
                {
                    obj.MaNXB = Decimal.Parse(tb.Rows[0]["MaNXB"].ToString());
                    obj.TenNXB = tb.Rows[0]["TenNXB"].ToString();
                    obj.DiaChiNXB = tb.Rows[0]["DiaChiNXB"].ToString();
                    obj.SDTNXB = tb.Rows[0]["SDTNXB"].ToString();
                    obj.FaxNXB = tb.Rows[0]["FaxNXB"].ToString();
                    obj.MailNXB = tb.Rows[0]["MailNXB"].ToString();
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
