using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.BAL
{
    class clTinhChatNguonNhap
    {
        public decimal MaTCNN { get; set; }
        public string TenTCNN { get; set; }
        public int TrangThai { get; set; }
        public string GhiChu { get; set; }

        ClConn conn = new ClConn();

        public DataTable LayDS()
        {
            DataTable tb = new DataTable();
            try
            {
                string str = @"SELECT Row_number() OVER( ORDER BY MaTCNN DESC) STT,MaTCNN,
                                TenTCNN,TrangThai,GhiChu FROM TV_TinhChatNguonNhap";

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
                string str = "SELECT Count(MaTCNN) As Tong FROM TV_TinhChatNguonNhap ";
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

        public clTinhChatNguonNhap LayDS_MaTCNN(Decimal Ma)
        {
            DataTable tb = new DataTable();
            clTinhChatNguonNhap obj = new clTinhChatNguonNhap();
            try
            {
                tb = conn.ExecuteQuery("SELECT * FROM TV_TinhChatNguonNhap WHERE MaTCNN = " + Ma);
                if (tb.Rows.Count > 0)
                {
                    obj.MaTCNN = Decimal.Parse(tb.Rows[0]["MaTCNN"].ToString());
                    obj.TenTCNN = tb.Rows[0]["TenTCNN"].ToString();
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

        public Decimal Them(clTinhChatNguonNhap obj)// tra ve ma tu tang
        {
            bool completed = false;//True - Thanh cong, False - Khong thuc hien duoc
            Decimal Ma = 0;// Lay ma vua moi them
            DataTable tb;

            try
            {
                string Str = @"INSERT INTO TV_TinhChatNguonNhap (TenTCNN) VALUES (@TenTCNN),
                                (TrangThai) VALUES (@TrangThai), (GhiChu) VALUES (@GhiChu)";

                conn.AddParameter("@TenTCNN", obj.TenTCNN);
                conn.AddParameter("@TrangThai", obj.TrangThai);
                conn.AddParameter("@GhiChu", obj.GhiChu);

                completed = conn.ExecuteUpdate(Str, false);

                if (completed == true)
                {
                    try
                    {
                        string str = " SELECT Top(1) * FROM TV_TinhChatNguonNhap ORDER BY MaTCNN DESC";
                        tb = conn.ExecuteQuery(str);
                        Ma = Decimal.Parse(tb.Rows[0]["MaTCNN"].ToString());
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

        public bool Sua(clTinhChatNguonNhap obj)
        {
            bool completed = false;
            //True - Thanh cong, False - Khong thuc hien duoc

            try
            {
                string Str = @"UPDATE TV_TinhChatNguonNhap SET TenTCNN = @TenTCNN,
                                TrangThai = @TrangThai, GhiChu = @GhiChu
                                WHERE MaTCNN = @MaTCNN";

                conn.AddParameter("@MaTCNN", obj.MaTCNN);
                conn.AddParameter("@TenTCNN", obj.TenTCNN);
                conn.AddParameter("@TrangThai", obj.TrangThai);
                conn.AddParameter("@GhiChu", obj.GhiChu);

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
                string Str = " DELETE TV_TinhChatNguonNhap WHERE MaTCNN = " + Ma.ToString();

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
                tb = conn.ExecuteQuery("SELECT * FROM TV_TinhChatNguonNhap WHERE MaTCNN = " + Ma);
            }
            catch (Exception)
            {
                //throw new Exception(ex.Message);
            }
            return (tb.Rows.Count > 0);
        }
    }
}
