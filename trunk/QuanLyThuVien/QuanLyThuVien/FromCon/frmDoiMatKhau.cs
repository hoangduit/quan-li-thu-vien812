using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 
using QuanLyThuVien.BAL;
namespace QuanLyThuVien.FromCon
{
    public partial class frmDoiMatKhau : Form
    {
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }
        clCanBo clCanBo = new clCanBo();
        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            Ham.KhungTB(4, "Thao tác đổi mật khẩu ", pnThongBao, lbThongBao); 
        }
        private void bntLuu_Click(object sender, EventArgs e)
        {
            if (txtMKCu.Text.Trim() == "")
            {
                txtMKCu.Focus();
                Ham.KhungTB(3, "Chưa nhập mật khẩu củ", pnThongBao, lbThongBao);
                return;
            } 
            if (txtMKMoi.Text.Trim() == "")
            {
                txtMKMoi.Focus();
                Ham.KhungTB(3, "Chưa nhập mật khẩu củ", pnThongBao, lbThongBao);
                return;
            }
            if (txtMKMoi.Text.Trim() != txtNhapLai.Text.Trim())
            {
                txtNhapLai.Focus();
                Ham.KhungTB(3, "Nhập lại chưa đúng", pnThongBao, lbThongBao);
                return;
            }
            if(clCanBo.DoiMatKhau(Ham.MaNV, txtMKCu.Text.Trim(), txtNhapLai.Text.Trim())){
                  Ham.KhungTB(1, "Đổi mật khẩu thành công", pnThongBao, lbThongBao);
                  Ham.ThemLuocSu(Ham.MaNV, "Đổi mật khẩu ", "Thêm", "");
            }else Ham.KhungTB(2, "Đổi mật khẩu thất bại", pnThongBao, lbThongBao); 
        }
        private void bntTaiLai_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
    }
}
