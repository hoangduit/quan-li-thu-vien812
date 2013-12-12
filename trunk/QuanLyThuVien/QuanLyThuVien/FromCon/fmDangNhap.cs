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
namespace QuanLyThuVien.ChuongTrinh
{
    public partial class fmDangNhap : Form
    {
        public fmDangNhap()
        {
            InitializeComponent();
        }
        public delegate void GetString(Decimal Maso);
        public GetString layUser;
        clCanBo ojp = new clCanBo();
        private void bntDN_Click(object sender, EventArgs e)
        {
            DataTable tb = ojp.DangNhap(txtTK.Text, txtMK.Text);
            if (  txtTK.Text == "")
            {
                lbThongBao.Text = "Tài khoản không được rổng";
                txtTK.Focus();
                return;
            }
            if (  txtMK.Text == "")
            {
                lbThongBao.Text = "Mật khẩu không được rổng";
                txtMK.Focus();
                return;
            }
            if (tb.Rows.Count > 0)
            {
                layUser(Convert.ToDecimal ( tb.Rows[0]["MaCB"].ToString()));
                this.Close();
            }
            else { lbThongBao.Text = "Không đúng vui lòng nhập lại"; txtTK.Focus(); }
        } 
        private void bntThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void fmDangNhap_Load(object sender, EventArgs e)
        {
            lbThongBao.Text = "";
        } 
    }
}
