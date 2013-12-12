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
    public partial class frmChucDanh : Form
    {
        public frmChucDanh()
        {
            InitializeComponent();
        }
        clChucDanh clChucDanh = new clChucDanh();
        public Decimal MaNV = Ham.MaNV;
        private void bntThem_Click(object sender, EventArgs e)
        {
            clChucDanh.TenCD = txtTenCD.Text;
            if (clChucDanh.Them(clChucDanh) > 0)
            {
                Ham.KhungTB(1, "Thêm thành công", pnThongBao, lbThongBao);
                Ham.ThemLuocSu(MaNV, "Thêm chúc danh: " + txtTenCD.Text, "Thêm", "");
            }
            else
                Ham.KhungTB(2, "Thêm thất bại", pnThongBao, lbThongBao); 
        } 
        private void bntTaiLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmChucDanh_Load(object sender, EventArgs e)
        {
            Ham.KhungTB(4, "Thao tác thêm ", pnThongBao, lbThongBao); 
        }
    }
}
