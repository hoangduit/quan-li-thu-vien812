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
    public partial class fmNhaCungCap : UserControl
    {
        Int16 TrangThai = 0;
        Decimal Ma = 0;
        Decimal MaNV = Ham.MaNV;
        clNhaCungCap clNCC = new clNhaCungCap();
        clNhaCungCap obj = new clNhaCungCap();

        public fmNhaCungCap()
        {
            InitializeComponent();
        }

        private void fmNhaCungCap_Load(object sender, EventArgs e)
        {
            Ham.ThemLuocSu(MaNV, "fmNhaCungCap", "Xem", "");
            Ham.LoadBnt(TrangThai, pnKhungThem, btnThem, btnLuu, btnXoa, btnSua, btnTaiLai, pnThongBao, lbThongBao);
            this.LoadGV();
            this.LoadQuyen();
        }

        private void LoadGV()
        {
            gridControl1.DataSource = clNCC.LayDS();
            gridView1.GroupPanelText = "Tổng số dòng là: " + clNCC.Dem();
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
            obj = clNCC.LayDS_MaNCC(Ma);
            txtTenNCC.Text = obj.TenNCC;
            txtDiaChi.Text = obj.DiaChiNCC;
            txtDienThoai.Text = obj.DienThoaiNCC;
            txtFax.Text = obj.FaxNCC;
            txtTrangThai.Text = Convert.ToString(obj.TrangThai);
            txtGhiChu.Text = obj.GhiChu;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            TrangThai = 2;
            this.LoadTxt();
            Ham.LoadBnt(TrangThai, pnKhungThem, btnThem, btnLuu, btnXoa, btnSua, btnTaiLai, pnThongBao, lbThongBao);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTenNCC.Text == "")
            {
                Ham.KhungTB(3, "Tên không được rỗng!", pnThongBao, lbThongBao);
                txtTenNCC.Focus();
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
            clNCC.TenNCC = txtTenNCC.Text;
            clNCC.DiaChiNCC = txtDiaChi.Text;
            clNCC.DienThoaiNCC = txtDienThoai.Text;
            clNCC.FaxNCC = txtFax.Text;
            clNCC.TrangThai = int.Parse(txtTrangThai.Text);
            clNCC.GhiChu = txtGhiChu.Text;

            if (clNCC.Them(clNCC) > 0)
            {
                Ham.KhungTB(1, "Thêm thành công!", pnThongBao, lbThongBao);
                Ham.ThemLuocSu(MaNV, "Thêm nhà cung cấp: " + txtTenNCC.Text, "Thêm", "");
            }
            else
                Ham.KhungTB(2, "Thêm thất bại!", pnThongBao, lbThongBao);
        }

        private void Sua()
        {
            clNCC.TenNCC = txtTenNCC.Text;
            clNCC.DiaChiNCC = txtDiaChi.Text;
            clNCC.DienThoaiNCC = txtDienThoai.Text;
            clNCC.FaxNCC = txtFax.Text;
            clNCC.TrangThai = int.Parse(txtTrangThai.Text);
            clNCC.GhiChu = txtGhiChu.Text;
            clNCC.MaNCC = Ma;

            if (clNCC.Sua(clNCC) == true)
            {
                Ham.KhungTB(1, "Thay đổi thành công!", pnThongBao, lbThongBao);
                Ham.ThemLuocSu(MaNV, "Thay đổi nhà cung cấp thành: " + txtTenNCC.Text, "Thay đổi", "");
            }
            else
                Ham.KhungTB(2, "Thay đổi thất bại!", pnThongBao, lbThongBao);
        }

        private void XoaTxt()
        {
            txtTenNCC.Text = "";
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";
            txtFax.Text = "";
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
            Kq = clNCC.Xoa(Ma);

            if (Kq == 0)
                Ham.KhungTB(2, "Xóa thất bại!", pnThongBao, lbThongBao);

            if (Kq == 1)
            {
                Ham.KhungTB(1, "Xóa thành công!", pnThongBao, lbThongBao);
                Ham.ThemLuocSu(MaNV, "Xóa nhà cung cấp: " + obj.TenNCC, "Xóa", "");
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
