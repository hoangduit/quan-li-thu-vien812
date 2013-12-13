using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
namespace QuanLyThuVien.BAL
{
    static class Ham
    {
        static public Decimal MaNV { get; set; }
        static public Decimal MaCB { get; set; }
        static public Decimal qAdmin { get; set; } 
        static public void ThemLuocSu(Decimal MaCB, String TenFrom, String ThaoTac, String TomTac)
        {
            try
            {
                clLuocSu ojpLS = new clLuocSu();
                Decimal LuocSu = 0;
                ojpLS.MaCB = MaCB;
                ojpLS.TenFrom = TenFrom;
                ojpLS.ThaoTac = ThaoTac;
                ojpLS.ThoiGian = DateTime.Now;
                ojpLS.TomTac = TomTac;
                LuocSu = ojpLS.Them(ojpLS);
            }
            catch (Exception )
            {
                //throw new Exception(ex.Message);
            }

        }
        static public void LoadBnt(Int16 TrangThai, PanelControl KhungThem, SimpleButton bntThem, SimpleButton bntLuu, SimpleButton bntXoa, SimpleButton bntSua, SimpleButton bntLamlai, Panel pnThongBao, LabelControl lbThongBao)
        {

            pnThongBao.BackColor = System.Drawing.Color.DodgerBlue;
            if (TrangThai == 0)
            {
                pnThongBao.Visible = false;
                KhungThem.Visible = false;
                bntSua.Enabled = true;
                bntThem.Enabled = true;
                bntXoa.Enabled = false;
                bntLuu.Enabled = false;
            }
            if (TrangThai == 1)
            {
                pnThongBao.Visible = true;
                lbThongBao.Text = "Bạn đang thêm";
                KhungThem.Visible = true;
                bntSua.Enabled = true;
                bntThem.Enabled = false;
                bntXoa.Enabled = false;
                bntLuu.Enabled = true;
            }
            if (TrangThai == 2)
            {
                pnThongBao.Visible = true;
                lbThongBao.Text = "Bạn đang sửa";
                KhungThem.Visible = true;
                bntSua.Enabled = false;
                bntThem.Enabled = true;
                bntXoa.Enabled = false;
                bntLuu.Enabled = true;
            }

        }
        static public void KhungTB(int TrangThai, String str, Panel pnThongBao, LabelControl lbThongBao)
        {
            pnThongBao.Visible = true;
            if (TrangThai == 1)// Thành Công
                pnThongBao.BackColor = System.Drawing.Color.Blue;
            if (TrangThai == 2)// Thất Bại
                pnThongBao.BackColor = System.Drawing.Color.IndianRed;
            if (TrangThai == 3)// Cảnh Báo 
                pnThongBao.BackColor = System.Drawing.Color.DarkOrange;
            if (TrangThai == 4)// Khác màu đất
                pnThongBao.BackColor = System.Drawing.Color.DarkGray;
            
            lbThongBao.Appearance.ForeColor = System.Drawing.Color.White;
            lbThongBao.Text = str;
        }
    }
}
