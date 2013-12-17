using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.BAL
{
    class clNhaCungCap
    {
        public decimal MaNCC { get; set; }
        public string TenNCC { get; set; }
        public string DiaChiNCC { get; set; }
        public string DienThoaiNCC { get; set; }
        public string FaxNCC { get; set; }
        public int TrangThai { get; set; }
        public string GhiChu { get; set; }

        ClConn conn = new ClConn();

        public DataTable LayDS()
        {
            DataTable tb = new DataTable();
            try
            {
                string str = @"SELECT Row_number() OVER( ORDER BY MaNCC DESC) STT,MaNCC,
                                TenNCC,DiaChiNCC,DienThoaiNCC,FaxNCC,GhiChu,TrangThai FROM TV_NhaCungCap";

                tb = conn.ExecuteQuery(str);
            }
            catch (Exception)
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
                string str = "SELECT Count(MaNCC) As Tong FROM TV_NhaCungCap ";
                if (!conn.runSQLReturnValuseSo(str, out Tong))
                {
                    Tong = 0;
                }
            }
            catch (Exception)
            {
                //throw new Exception(ex.Message);
            }
            return Tong;
        }

        public clNhaCungCap LayDS_MaNCC(Decimal Ma)
        {
            DataTable tb = new DataTable();
            clNhaCungCap obj = new clNhaCungCap();
            try
            {
                tb = conn.ExecuteQuery("SELECT * FROM TV_NhaCungCap WHERE MaNCC = " + Ma);
                if (tb.Rows.Count > 0)
                {
                    obj.MaNCC = Decimal.Parse(tb.Rows[0]["MaNCC"].ToString());
                    obj.TenNCC = tb.Rows[0]["TenNCC"].ToString();
                    obj.DiaChiNCC = tb.Rows[0]["DiaChiNCC"].ToString();
                    obj.DienThoaiNCC = tb.Rows[0]["DienThoaiNCC"].ToString();
                    obj.FaxNCC = tb.Rows[0]["FaxNCC"].ToString();
                    obj.TrangThai = int.Parse(tb.Rows[0]["TrangThai"].ToString());
                    obj.GhiChu = tb.Rows[0]["GhiChu"].ToString();
                }
            }
            catch (Exception)
            {
                //throw new Exception(ex.Message);
            }
            return obj;
        }

        public Decimal Them(clNhaCungCap obj)// tra ve ma tu tang
        {
            bool completed = false;//True - Thanh cong, False - Khong thuc hien duoc
            Decimal Ma = 0;// Lay ma vua moi them
            DataTable tb;

            try
            {
                string Str = @"INSERT INTO TV_NhaCungCap (TenNCC) VALUES (@TenNCC), (DiaChiNCC) VALUES (@DiaChiNCC),
                                (DienThoaiNCC) VALUES (@DienThoaiNCC), (FaxNCC) VALUES (@FaxNCC),
                                (GhiChu) VALUES (@GhiChu), (TrangThai) VALUES (@TrangThai)";

                conn.AddParameter("@TenNCC", obj.TenNCC);
                conn.AddParameter("@DiaChiNCC", obj.DiaChiNCC);
                conn.AddParameter("@DienThoaiNCC", obj.DienThoaiNCC);
                conn.AddParameter("@FaxNCC", obj.FaxNCC);
                conn.AddParameter("@GhiChu", obj.GhiChu);
                conn.AddParameter("@TrangThai", obj.TrangThai);

                completed = conn.ExecuteUpdate(Str, false);

                if (completed == true)
                {
                    try
                    {
                        string str = " SELECT Top(1) * FROM TV_NhaCungCap ORDER BY MaNCC DESC";
                        tb = conn.ExecuteQuery(str);
                        Ma = Decimal.Parse(tb.Rows[0]["MaNCC"].ToString());
                    }
                    catch (Exception)
                    {
                        Ma = 0;
                    }
                }
            }
            catch (Exception)
            {
                completed = false;
                //throw new Exception(ex.Message);
            }
            return Ma;
        }

        public bool Sua(clNhaCungCap obj)
        {
            bool completed = false;
            //True - Thanh cong, False - Khong thuc hien duoc

            try
            {
                string Str = @"UPDATE TV_NhaCungCap SET TenNCC = @TenNCC, DiaChiNCC = @DiaChiNCC,
                                DienThoaiNCC = @DienThoaiNCC, FaxNCC = @FaxNCC, 
                                GhiChu = @GhiChu, TrangThai = @TrangThai
                                WHERE MaNCC = @MaNCC";

                conn.AddParameter("@MaNCC", obj.MaNCC);
                conn.AddParameter("@TenNCC", obj.TenNCC);
                conn.AddParameter("@DiaChiNCC", obj.DiaChiNCC);
                conn.AddParameter("@DienThoaiNCC", obj.DienThoaiNCC);
                conn.AddParameter("@FaxNCC", obj.FaxNCC);
                conn.AddParameter("@GhiChu", obj.GhiChu);
                conn.AddParameter("@TrangThai", obj.TrangThai);

                completed = conn.ExecuteUpdate(Str, false);
            }
            catch (Exception)
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
                string Str = "DELETE TV_NhaCungCap WHERE MaNCC = " + Ma.ToString();

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
            catch (Exception)
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
                tb = conn.ExecuteQuery("SELECT * FROM TV_NhaCungCap WHERE MaNCC = " + Ma);
            }
            catch (Exception)
            {
                //throw new Exception(ex.Message);
            }
            return (tb.Rows.Count > 0);
        }
    }
}
