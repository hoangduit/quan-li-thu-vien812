using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyThuVien.BAL;

namespace QuanLyThuVien.ChuongTrinh
{
    public partial class fmChiTietPN : UserControl
    {
        Int16 TrangThai = 0;
        Decimal Ma = 0;
        Decimal MaNV = Ham.MaNV;
        clPhieuNhapCT clchitietPN = new clPhieuNhapCT();
        clPhieuNhapCT obj = new clPhieuNhapCT();

        ClConn truyVan = new ClConn();

        public fmChiTietPN()
        {
            InitializeComponent();
        }

        private void fmChiTietPN_Load(object sender, EventArgs e)
        {
            Ham.ThemLuocSu(MaNV, "fmChiTietPN", "Xem", "");
            Ham.LoadBnt(TrangThai, pnKhungThem, btnThem, btnSua, btnLuu, btnXoa, btnTaiLai, pnThongBao, lbThongBao);
            this.LoadCmbMaPN();
            this.LoadCmbTenS();
            this.LoadGV();
            this.LoadQuyen();
        }

        private void LoadGV()
        {
            gridControl1.DataSource = clchitietPN.LayDS();
            gridView1.GroupPanelText = "Tổng số dòng là: " + clchitietPN.Dem();
        }
    }
}
