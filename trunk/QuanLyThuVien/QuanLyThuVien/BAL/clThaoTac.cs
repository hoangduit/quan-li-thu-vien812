using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace QuanLyThuVien.BAL
{
    class clThaoTac
    {
        public Decimal MaTT { get; set; }
        public Decimal MaFrm { get; set; }
        public Decimal MaCB { get; set; }
        public Boolean ToanQuyen { get; set; }
        public Boolean TimTT { get; set; }
        public Boolean ThemTT { get; set; }
        public Boolean SuaTT { get; set; }
        public Boolean XoaTT { get; set; }
        public Boolean XemTT { get; set; }
        public Boolean InTT { get; set; }
        public Boolean Khoa { get; set; }
        ClConn conn = new ClConn();
        public Decimal Them(clThaoTac obj)// tra ve ma tu tang
        {
            bool completed = false;//True - Thanh cong, False - Khong thuc hien duoc
            Decimal Ma = 0;// Lay ma vua moi them
            DataTable tb;
            try
            {
                string Str = "INSERT INTO TV_ThaoTac  (MaFrm, MaCB, ToanQuyen, ThemTT, SuaTT, XoaTT, XemTT, TimTT, InTT, Khoa) VALUES (@MaFrm, @MaCB, @ToanQuyen, @ThemTT, @SuaTT, @XoaTT, @XemTT, @TimTT, @InTT, @Khoa)";
                conn.AddParameter("@MaFrm", obj.MaFrm);
                conn.AddParameter("@MaCB", obj.MaCB);
                conn.AddParameter("@ToanQuyen", obj.ToanQuyen);
                conn.AddParameter("@ThemTT", obj.ThemTT);
                conn.AddParameter("@SuaTT", obj.SuaTT);
                conn.AddParameter("@XoaTT", obj.XoaTT);
                conn.AddParameter("@XemTT", obj.XemTT);
                conn.AddParameter("@TimTT", obj.TimTT);
                conn.AddParameter("@InTT", obj.InTT);
                conn.AddParameter("@Khoa", obj.Khoa);
                completed = conn.ExecuteUpdate(Str, false);
                if (completed == true)
                {
                    try
                    {
                        string str = " SELECT Top(1) * FROM TV_ThaoTac ORDER BY  MaTT DESC";
                        tb = conn.ExecuteQuery(str);
                        Ma = Decimal.Parse(tb.Rows[0]["MaTT"].ToString());
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
        public Boolean Sua(clThaoTac obj)
        {
            bool completed = false;
            //True - Thanh cong, False - Khong thuc hien duoc
            try
            {
                string Str = "UPDATE TV_ThaoTac SET  MaFrm =@MaFrm, MaCB=@MaCB, ToanQuyen=@ToanQuyen, ThemTT=@ThemTT, SuaTT=@SuaTT, XoaTT=@XoaTT, XemTT=@XemTT, TimTT=@TimTT, InTT=@InTT, Khoa=@Khoa  WHERE MaTT = @MaTT ";
                conn.AddParameter("@MaTT", obj.MaTT);
                conn.AddParameter("@MaFrm", obj.MaFrm);
                conn.AddParameter("@MaCB", obj.MaCB);
                conn.AddParameter("@ToanQuyen", obj.ToanQuyen);
                conn.AddParameter("@ThemTT", obj.ThemTT);
                conn.AddParameter("@SuaTT", obj.SuaTT);
                conn.AddParameter("@XoaTT", obj.XoaTT);
                conn.AddParameter("@XemTT", obj.XemTT);
                conn.AddParameter("@TimTT", obj.TimTT);
                conn.AddParameter("@InTT", obj.InTT);
                conn.AddParameter("@Khoa", obj.Khoa);
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
                string Str = " DELETE  TV_ThaoTac WHERE MaTT =" + Ma.ToString();
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
                tb = conn.ExecuteQuery("SELECT * FROM TV_ThaoTac WHERE MaTT=" + Ma);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return (tb.Rows.Count > 0);
        }
        public Decimal Dem()
        {
            Decimal Tong = 0;
            try
            {
                string str = "SELECT Count(MaTT) As Tong FROM TV_ThaoTac ";
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
        public DataTable  KiemTraFrom(Decimal From, Decimal MaNV)
        {
            DataTable tb = new DataTable();
            try
            {
                tb = conn.ExecuteQuery("SELECT * FROM TV_ThaoTac WHERE MaFrm=" + From + " AND MaCB=" + MaNV);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return tb;
        }

        public DataTable LayDS(Decimal MaCB)
        {
            DataTable tb = new DataTable();
            try
            {
                string str = " SELECT        Row_number() OVER( ORDER BY MaTT DESC) STT, MaTT= 'MTT00' + convert( nvarchar(200),MaTT),   TV_ThaoTac.ToanQuyen, TV_ThaoTac.ThemTT, TV_ThaoTac.SuaTT, TV_ThaoTac.XoaTT, TV_ThaoTac.XemTT, TV_ThaoTac.TimTT, TV_ThaoTac.InTT, " +
                                           " TV_ThaoTac.Khoa, TV_CanBo.TenCB, TV_From.TenGoi, TV_ThaoTac.MaTT " +
                             " FROM          TV_CanBo RIGHT OUTER JOIN " +
                                           " TV_ThaoTac LEFT OUTER JOIN   TV_From ON TV_ThaoTac.MaFrm = TV_From.MaFrm ON TV_CanBo.MaCB = TV_ThaoTac.MaCB WHERE TV_ThaoTac.MaCB=" + MaCB;
                tb = conn.ExecuteQuery(str);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return tb;
        }
        public clThaoTac LayDS_Ma(Decimal Ma)
        {
            DataTable tb = new DataTable();
            clThaoTac obj = new clThaoTac();
            try
            {
                tb = conn.ExecuteQuery("SELECT * FROM TV_ThaoTac WHERE MaTT=" + Ma);
                if (tb.Rows.Count > 0)
                {
                    obj.MaTT = Decimal.Parse(tb.Rows[0]["MaTT"].ToString());
                    obj.MaFrm = Decimal.Parse(tb.Rows[0]["MaFrm"].ToString());
                    obj.ToanQuyen = Boolean.Parse(tb.Rows[0]["ToanQuyen"].ToString());
                    obj.ThemTT = Boolean.Parse(tb.Rows[0]["ThemTT"].ToString());
                    obj.SuaTT = Boolean.Parse(tb.Rows[0]["SuaTT"].ToString());
                    obj.XoaTT = Boolean.Parse(tb.Rows[0]["XoaTT"].ToString());
                    obj.XemTT = Boolean.Parse(tb.Rows[0]["XemTT"].ToString());
                    obj.TimTT = Boolean.Parse(tb.Rows[0]["TimTT"].ToString());
                    obj.InTT = Boolean.Parse(tb.Rows[0]["InTT"].ToString());
                    obj.Khoa = Boolean.Parse(tb.Rows[0]["Khoa"].ToString());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return obj;
        }
        public DataTable LayDS_From()
        {
            DataTable tb = new DataTable();
            try
            {
                string str = " SELECT  Row_number() OVER( ORDER BY MaFrm DESC) STT, MaFrm= 'MF00' + convert( nvarchar(200),MaFrm), TenGoi FROM TV_From ";
                tb = conn.ExecuteQuery(str);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return tb;
        }
        public clThaoTac Lay_From(Decimal From, Decimal MaNV)
        {
            DataTable tb = new DataTable();
            clThaoTac obj = new clThaoTac();
            try
            {
                tb = conn.ExecuteQuery("SELECT * FROM TV_ThaoTac WHERE MaFrm=" + From + " AND MaCB=" + MaNV);
                if (tb.Rows.Count > 0)
                {
                    obj.MaTT = Decimal.Parse(tb.Rows[0]["MaTT"].ToString());
                    obj.MaFrm = Decimal.Parse(tb.Rows[0]["MaFrm"].ToString());
                    obj.ToanQuyen = Boolean.Parse(tb.Rows[0]["ToanQuyen"].ToString());
                    obj.ThemTT = Boolean.Parse(tb.Rows[0]["ThemTT"].ToString());
                    obj.SuaTT = Boolean.Parse(tb.Rows[0]["SuaTT"].ToString());
                    obj.XoaTT = Boolean.Parse(tb.Rows[0]["XoaTT"].ToString());
                    obj.XemTT = Boolean.Parse(tb.Rows[0]["XemTT"].ToString());
                    obj.TimTT = Boolean.Parse(tb.Rows[0]["TimTT"].ToString());
                    obj.InTT = Boolean.Parse(tb.Rows[0]["InTT"].ToString());
                    obj.Khoa = Boolean.Parse(tb.Rows[0]["Khoa"].ToString());
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
