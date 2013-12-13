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
    public partial class frmQuyen : Form
    {
        public frmQuyen()
        {
            InitializeComponent();
        }
        clQuyen clQuyen = new clQuyen();
        public Decimal MaNV = Ham.MaNV;
        private void bntThem_Click(object sender, EventArgs e)
        {
            clQuyen.TenQ = txtTenQ.Text;
            if (cbAdmin.Checked == true)
                clQuyen.Admin = 1;
            else clQuyen.Admin = 2;
            if (clQuyen.Them(clQuyen) > 0)
            {
                Ham.KhungTB(1, "Thêm thành công", pnThongBao, lbThongBao);
                Ham.ThemLuocSu(MaNV, "Thêm quyền: " + txtTenQ.Text, "Thêm", "");
            }
            else
                Ham.KhungTB(2, "Thêm thất bại", pnThongBao, lbThongBao);
        } 
        private void bntTaiLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmQuyen_Load(object sender, EventArgs e)
        {
            Ham.KhungTB(4, "Thao tác thêm ", pnThongBao, lbThongBao); 
        }

        private void panelControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbAdmin_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void txtTenQ_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void pnThongBao_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbThongBao_Click(object sender, EventArgs e)
        {

        }
        
    }
}
