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
    public partial class fmKhoSach : UserControl
    {
        Int16 TrangThai = 0;
        Decimal Ma = 0;
        Decimal MaNV = Ham.MaNV;
        clKhoSach clkho = new clKhoSach();
        clKhoSach obj = new clKhoSach();

        public fmKhoSach()
        {
            InitializeComponent();
        }

        private void fmKhoSach_Load(object sender, EventArgs e)
        {
            Ham.ThemLuocSu(MaNV, "fmKhoSach", "Xem", "");
            Ham.LoadBnt(TrangThai, pnKhungThem, btnThem, btnLuu, btnXoa, btnSua, btnTaiLai, pnThongBao, lbThongBao);
            this.LoadGV();
            this.LoadQuyen();
        }

        private void LoadGV()
        {
            gridControl1.DataSource = clkho.LayDS();
            gridView1.GroupPanelText = "Tổng số dòng là: " + clkho.Dem();
        }

        private void LoadQuyen()
        {
            clThaoTac PQ = new clThaoTac();
            try
            {
                PQ = PQ.Lay_From(1, Ham.MaNV);
                if (PQ.ToanQuyen != true && Ham.qAdmin != 1)
                {
                    if (PQ.ThemTT == false) btnThem.Visible = false;
                    if (PQ.SuaTT == false) btnSua.Visible = false;
                    if (PQ.XoaTT == false) btnXoa.Visible = false;
                    if (PQ.XemTT == false) panelControl2.Visible = false;
                    if (PQ.ThemTT == false && PQ.SuaTT == false) btnLuu.Visible = false;
                }
            }
            catch (Exception) { }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            TrangThai = 1;
            this.LoadTxt();
            Ham.LoadBnt(TrangThai, pnKhungThem, btnThem, btnLuu, btnXoa, btnSua, btnTaiLai, pnThongBao, lbThongBao);
        }

        private void LoadTxt()
        {
            obj = clkho.LayDS_MaK(Ma);
            txtTenK.Text = obj.TenK;
            txtDiaChi.Text = obj.DiaChi;
            txtDienThoai.Text = obj.SoDienThoai;
            txtGhiChu.Text = obj.GhiChu;
            txtTrangThai.Text = Convert.ToString(obj.TrangThai);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            TrangThai = 2;
            this.LoadTxt();
            Ham.LoadBnt(TrangThai, pnKhungThem, btnThem, btnLuu, btnXoa, btnSua, btnTaiLai, pnThongBao, lbThongBao);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTenK.Text == "")
            {
                Ham.KhungTB(3, "Tên không được rỗng!", pnThongBao, lbThongBao);
                txtTenK.Focus();
                return;
            }

            if (TrangThai == 1)
                this.Them();

            if (TrangThai == 2)
                this.Sua();

            this.LoadGV();
            this.XoaTxt();
        }

        private void Them()
        {
            clkho.TenK = txtTenK.Text;
            clkho.DiaChi = txtDiaChi.Text;
            clkho.SoDienThoai = txtDienThoai.Text;
            clkho.GhiChu = txtGhiChu.Text;
            clkho.TrangThai = int.Parse(txtTrangThai.Text);

            if (clkho.Them(clkho) > 0)
            {
                Ham.KhungTB(1, "Thêm thành công!", pnThongBao, lbThongBao);
                Ham.ThemLuocSu(MaNV, "Thêm kho sách: " + txtTenK.Text, "Thêm", "");
            }
            else
                Ham.KhungTB(2, "Thêm thất bại!", pnThongBao, lbThongBao);
        }

        private void Sua()
        {
            clkho.TenK = txtTenK.Text;
            clkho.DiaChi = txtDiaChi.Text;
            clkho.SoDienThoai = txtDienThoai.Text;
            clkho.GhiChu = txtGhiChu.Text;
            clkho.TrangThai = int.Parse(txtTrangThai.Text);
            clkho.MaK = Ma;

            if (clkho.Sua(clkho) == true)
            {
                Ham.KhungTB(1, "Thay đổi thành công!", pnThongBao, lbThongBao);
                Ham.ThemLuocSu(MaNV, "Thay đổi kho thành: " + txtTenK.Text, "Thay đổi", "");
            }
            else
                Ham.KhungTB(2, "Thay đổi thất bại!", pnThongBao, lbThongBao);
        }

        private void XoaTxt()
        {
            txtTenK.Text = "";
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";
            txtTrangThai.Text = "";
            txtGhiChu.Text = "";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            this.Xoa();
            this.LoadGV();
        }

        private void Xoa()
        {
            int Kq = 0;
            Kq = clkho.Xoa(Ma);

            if (Kq == 0)
                Ham.KhungTB(2, "Xóa thất bại!", pnThongBao, lbThongBao);

            if (Kq == 1)
            {
                Ham.KhungTB(1, "Xóa thành công!", pnThongBao, lbThongBao);
                Ham.ThemLuocSu(MaNV, "Xóa kho sách: " + obj.TenK, "Xóa", "");
            }

            if (Kq == 3)
                Ham.KhungTB(3, "Đang được sử dụng, không thể xóa!", pnThongBao, lbThongBao);
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            TrangThai = 0;
            Ham.LoadBnt(TrangThai, pnKhungThem, btnThem, btnLuu, btnXoa, btnSua, btnTaiLai, pnThongBao, lbThongBao);
            this.LoadGV();
            this.XoaTxt();
            this.LoadQuyen();
            Ma = 0;
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            string a = gridView1.GetFocusedRowCellValue(clMa).ToString();
            btnXoa.Enabled = true;
            Ma = Convert.ToDecimal(a);
            if (TrangThai == 2)
                this.LoadTxt();
        }
    }
}
