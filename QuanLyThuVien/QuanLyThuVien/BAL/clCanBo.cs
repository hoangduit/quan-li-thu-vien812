using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QuanLyThuVien.BAL
{
    class clCanBo
    {
        public Decimal MaCB { get; set; }
        public String MaSoCB { get; set; }
        public String TenCB { get; set; }
        public String DiaChi { get; set; }
        public String SDT { get; set; }
        public String Mail { get; set; }
        public Decimal MaCD { get; set; }
        public String TaiKhoan { get; set; }
        public String MatKhau { get; set; }
        public Decimal MaQuyen { get; set; }
        public Boolean TrangThai { get; set; }
        public Boolean GioiTinh { get; set; }
        ClConn conn = new ClConn();
        public Decimal Them(clCanBo obj)// tra ve ma tu tang
        {
            bool completed = false;//True - Thanh cong, False - Khong thuc hien duoc
            Decimal Ma = 0;// Lay ma vua moi them
            DataTable tb;
            try
            {
                string Str = "INSERT INTO TV_CanBo   (MaSoCB, TenCB, DiaChi, SDT, Mail, MaCD, TaiKhoan, MatKhau, MaQuyen, TrangThai, GioiTinh) VALUES (@MaSoCB, @TenCB, @DiaChi, @SDT, @Mail, @MaCD, @TaiKhoan, @MatKhau, @MaQuyen, @TrangThai, @GioiTinh)";
                conn.AddParameter("@MaSoCB", obj.MaSoCB);
                conn.AddParameter("@TenCB", obj.TenCB);
                conn.AddParameter("@DiaChi", obj.DiaChi);
                conn.AddParameter("@SDT", obj.SDT);
                conn.AddParameter("@Mail", obj.Mail);
                conn.AddParameter("@MaCD", obj.MaCD);
                conn.AddParameter("@TaiKhoan", obj.TaiKhoan);
                conn.AddParameter("@MatKhau", obj.MatKhau);
                conn.AddParameter("@MaQuyen", obj.MaQuyen);
                conn.AddParameter("@TrangThai", obj.TrangThai);
                conn.AddParameter("@GioiTinh", obj.GioiTinh);
                completed = conn.ExecuteUpdate(Str, false);
                if (completed == true)
                {
                    try
                    {
                        string str = " SELECT Top(1) * FROM TV_CanBo ORDER BY  MaCB DESC";
                        tb = conn.ExecuteQuery(str);
                        Ma = Decimal.Parse(tb.Rows[0]["MaCD"].ToString());
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
        public Boolean Sua(clCanBo obj)
        {
            bool completed = false;
            //True - Thanh cong, False - Khong thuc hien duoc
            try
            {
                string Str = "UPDATE TV_CanBo SET    TenCB=@TenCB, DiaChi=@DiaChi, SDT=@SDT, Mail=@Mail, MaCD=@MaCD, MaQuyen=@MaQuyen, TrangThai=@TrangThai, GioiTinh=@GioiTinh WHERE MaCB = @MaCB ";
                conn.AddParameter("@MaCB", obj.MaCB);
                conn.AddParameter("@TenCB", obj.TenCB);
                conn.AddParameter("@DiaChi", obj.DiaChi);
                conn.AddParameter("@SDT", obj.SDT);
                conn.AddParameter("@Mail", obj.Mail);
                conn.AddParameter("@MaCD", obj.MaCD);
                conn.AddParameter("@MaQuyen", obj.MaQuyen);
                conn.AddParameter("@TrangThai", obj.TrangThai);
                conn.AddParameter("@GioiTinh", obj.GioiTinh);
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
                string Str = " DELETE  TV_CanBo WHERE MaCB =" + Ma.ToString();
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
        public Boolean IsExist(Decimal Ma)
        {
            DataTable tb = new DataTable();
            try
            {
                tb = conn.ExecuteQuery("SELECT * FROM TV_CanBo WHERE MaCB=" + Ma);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return (tb.Rows.Count > 0);
        }
        public Boolean KT_MaSoCB(String MaSoCB)
        {
            DataTable tb = new DataTable();
            try
            {
                tb = conn.ExecuteQuery("SELECT * FROM TV_CanBo WHERE MaSoCB='" + MaSoCB + "'");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return (tb.Rows.Count > 0);
        }
        public Boolean KT_MatKhau(Decimal MaNV, String MK)
        {
            DataTable tb = new DataTable();
            try
            {
                tb = conn.ExecuteQuery("SELECT * FROM TV_CanBo WHERE MaCB='" + MaNV + "' AND MatKhau='" + MK + "'");

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
                string str = " SELECT        Row_number() OVER( ORDER BY MaCB DESC) STT, MaCB= 'MCB00' + convert( nvarchar(200),MaCB), TV_CanBo.MaSoCB, TV_CanBo.TenCB, TV_ChucDanh.TenCD, TV_CanBo.MaSoCB, TV_CanBo.DiaChi, TV_CanBo.SDT, TV_CanBo.Mail, " +
                                           " TV_CanBo.TaiKhoan, TV_CanBo.MatKhau, TV_Quyen.TenQ,     " +
                                           " CASE TV_Quyen.Admin when '1' Then N'Quản Trị' ELSE N'Người Dùng' END AS  Admin , " +
                                           " CASE TV_CanBo.GioiTinh when 'True' Then N'Nam' ELSE N'Nữ' END AS  GioiTinh , " +
                                           " CASE    TV_CanBo.TrangThai when '1' Then N'Đang dùng' ELSE N'Đã khóa' END AS  TrangThai  " +
                             " FROM          TV_CanBo LEFT OUTER JOIN   TV_Quyen ON TV_CanBo.MaQuyen = TV_Quyen.MaQ LEFT OUTER JOIN  TV_ChucDanh ON TV_CanBo.MaCD = TV_ChucDanh.MaCD ";
                tb = conn.ExecuteQuery(str);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return tb;
        }
        public DataTable DangNhap(String TK, String MK)
        {
            DataTable tb = new DataTable();
            try
            {
                string str = String.Format(" SELECT * FROM TV_CanBo WHERE TaiKhoan='{0}' AND MatKhau='{1}' ", TK, MK);
                tb = conn.ExecuteQuery(str);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return tb;
        }
        public Boolean DoiMatKhau(Decimal MaNV, String MK, String MKM)
        {
            if (KT_MatKhau(MaNV, MK) == false) { return false; }
            bool completed = false;
            //True - Thanh cong, False - Khong thuc hien duoc
            try
            {
                string Str = "UPDATE TV_CanBo SET  MatKhau=@MatKhau WHERE MaCB = @MaCB ";
                conn.AddParameter("@MatKhau", MKM);
                conn.AddParameter("@MaCB", MaNV);
                completed = conn.ExecuteUpdate(Str, false);
            }
            catch (Exception ex)
            {
                completed = false;
                throw new Exception(ex.Message);
            }
            return completed;
        }
        public Decimal Dem()
        {
            Decimal Tong = 0;
            try
            {
                string str = "SELECT Count(MaCD) As Tong FROM TV_ChucDanh ";
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
        public clCanBo LayDS_MaCB(Decimal Ma)
        {
            DataTable tb = new DataTable();
            clCanBo obj = new clCanBo();
            try
            {
                tb = conn.ExecuteQuery("SELECT * FROM TV_CanBo WHERE MaCB=" + Ma);
                if (tb.Rows.Count > 0)
                {
                    obj.MaCB = Decimal.Parse(tb.Rows[0]["MaCB"].ToString());
                    obj.MaSoCB = tb.Rows[0]["MaSoCB"].ToString();
                    obj.TenCB = tb.Rows[0]["TenCB"].ToString();
                    obj.DiaChi = tb.Rows[0]["DiaChi"].ToString();
                    obj.SDT = tb.Rows[0]["SDT"].ToString();
                    obj.Mail = tb.Rows[0]["Mail"].ToString();
                    obj.MaCD = Decimal.Parse(tb.Rows[0]["MaCD"].ToString());
                    obj.TaiKhoan = tb.Rows[0]["TaiKhoan"].ToString();
                    obj.MatKhau = tb.Rows[0]["MatKhau"].ToString();
                    obj.MaQuyen = Decimal.Parse(tb.Rows[0]["MaQuyen"].ToString());
                    obj.TrangThai = Boolean.Parse(tb.Rows[0]["TrangThai"].ToString());
                    obj.GioiTinh = Boolean.Parse(tb.Rows[0]["GioiTinh"].ToString());

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return obj;
        }
        public DataTable LayCB(Decimal Ma)
        {
            DataTable tb = new DataTable();
            try
            {
                string str = " SELECT        Row_number() OVER( ORDER BY MaCB DESC) STT, MaCB= 'MCB00' + convert( nvarchar(200),MaCB), TV_CanBo.MaSoCB, TV_CanBo.TenCB, TV_ChucDanh.TenCD, TV_CanBo.MaSoCB, TV_CanBo.DiaChi, TV_CanBo.SDT, TV_CanBo.Mail, " +
                                           " TV_CanBo.TaiKhoan, TV_CanBo.MatKhau, TV_Quyen.TenQ, Admin AS qAdmin ,   " +
                                           " CASE TV_Quyen.Admin when '1' Then N'Quản Trị' ELSE N'Người Dùng' END AS  Admin , " +
                                           " CASE TV_CanBo.GioiTinh when 'True' Then N'Nam' ELSE N'Nữ' END AS  GioiTinh , " +
                                           " CASE    TV_CanBo.TrangThai when '1' Then N'Đang dùng' ELSE N'Đã khóa' END AS  TrangThai  " +
                             " FROM          TV_CanBo LEFT OUTER JOIN   TV_Quyen ON TV_CanBo.MaQuyen = TV_Quyen.MaQ LEFT OUTER JOIN  TV_ChucDanh ON TV_CanBo.MaCD = TV_ChucDanh.MaCD WHERE MaCB=" + Ma;
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
