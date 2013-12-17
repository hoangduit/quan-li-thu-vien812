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
    public partial class frmPhieuNhap : UserControl
    {
        Int16 TrangThai = 0;
        Decimal Ma = 0;
        Decimal MaNV = Ham.MaNV;
        clPhieuNhap clphieunhap = new clPhieuNhap();
        clPhieuNhap obj = new clPhieuNhap();

        ClConn truyVan = new ClConn();

        public frmPhieuNhap()
        {
            InitializeComponent();
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {
        }

        private void labelControl4_Click(object sender, EventArgs e)
        {
        }

        private void frmPhieuNhap_Load(object sender, EventArgs e)
        {
            Ham.ThemLuocSu(MaNV, "frmPhieuNhap", "Xem", "");
            Ham.LoadBnt(TrangThai, pnKhungThem, btnThem, btnSua, btnLuu, btnXoa, btnTaiLai, pnThongBao, lbThongBao);
            this.LoadCmbTCNguonNhap();
            this.LoadCmbNCC();
            this.LoadCmbCanBo();
            this.LoadCmbKhoSach();
            this.LoadGV();
            this.LoadQuyen();
        }

        private void LoadGV()
        {
            gvPhieuNhap.DataSource = clphieunhap.LayDS();
            gridView1.GroupPanelText = "Tổng số dòng là: " + clphieunhap.Dem();
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
                    if (PQ.XemTT == false) pnThaoTac.Visible = false;
                    if (PQ.ThemTT == false && PQ.SuaTT == false) btnLuu.Visible = false;
                }
            }
            catch (Exception) { }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void lbThongBao_Click(object sender, EventArgs e)
        {
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            TrangThai = 1;
            this.LoadKhungThem();
            Ham.LoadBnt(TrangThai, pnKhungThem, btnThem, btnSua, btnLuu, btnXoa, btnTaiLai, pnThongBao, lbThongBao);
        }

        private void LoadKhungThem()
        {
            obj = clphieunhap.LayDS_MaPN(Ma);

            txtMaPhieuNhap.Text = obj.MaPhieuNhap;
            LoadCmbTCNguonNhap();
            //dtpickNgayNhap.Value = DateTime.Parse((obj.NgayNhap).ToString());
            dtpickNgayNhap.Value = DateTime.Now;
            LoadCmbCanBo();
            LoadCmbNCC();
            LoadCmbKhoSach();
            datePickNgayTao.Value = DateTime.Now;
            txtGhiChu.Text = obj.GhiChu;
        }

        private void LoadCmbTCNguonNhap()
        {
            cmbTCNguonNhap.DataSource = truyVan.ExecuteQuery("SELECT * FROM TV_TinhChatNguonNhap"); ;
            cmbTCNguonNhap.ValueMember = "MaTCNN";
            cmbTCNguonNhap.DisplayMember = "TenTCNN";
        }

        private void LoadCmbCanBo()
        {
            cmbTCNguonNhap.DataSource = truyVan.ExecuteQuery("SELECT * FROM TV_CanBo");
            cmbTCNguonNhap.ValueMember = "MaCB";
            cmbTCNguonNhap.DisplayMember = "TenCB";
        }

        private void LoadCmbNCC()
        {
            cmbTCNguonNhap.DataSource = truyVan.ExecuteQuery("SELECT * FROM TV_NhaCungCap");
            cmbTCNguonNhap.ValueMember = "MaNCC";
            cmbTCNguonNhap.DisplayMember = "TenNCC";
        }

        private void LoadCmbKhoSach()
        {
            cmbTCNguonNhap.DataSource = truyVan.ExecuteQuery("SELECT * FROM TV_KhoSach");
            cmbTCNguonNhap.ValueMember = "MaK";
            cmbTCNguonNhap.DisplayMember = "TenK";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            TrangThai = 2;
            this.LoadKhungThem();
            Ham.LoadBnt(TrangThai, pnKhungThem, btnThem, btnSua, btnLuu, btnXoa, btnTaiLai, pnThongBao, lbThongBao);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            this.Xoa();
            this.LoadGV();
        }

        private void Xoa()
        {
            int Kq = 0;
            Kq = clphieunhap.Xoa(Ma);

            if (Kq == 0)
                Ham.KhungTB(2, "Xóa thất bại!", pnThongBao, lbThongBao);

            if (Kq == 1)
            {
                Ham.KhungTB(1, "Xóa thành công!", pnThongBao, lbThongBao);
                Ham.ThemLuocSu(MaNV, "Xóa phiếu nhập: " + obj.MaPhieuNhap, "Xóa", "");
            }

            if (Kq == 3)
                Ham.KhungTB(3, "Đang được sử dụng, không thể xóa!", pnThongBao, lbThongBao);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaPhieuNhap.Text == "")
            {
                Ham.KhungTB(3, "Mã phiếu nhập không được rỗng!", pnThongBao, lbThongBao);
                txtMaPhieuNhap.Focus();
                return;
            }

            if (TrangThai == 1)
                this.Them();

            if (TrangThai == 2)
                this.Sua();

            this.LoadGV();
            this.XoaKhungThem();
        }

        private void Them()
        {
            clphieunhap.MaPhieuNhap = txtMaPhieuNhap.Text;
            clphieunhap.MaTinhChatNguonNhap = Decimal.Parse(cmbTCNguonNhap.SelectedValue.ToString());
            clphieunhap.NgayNhap = dtpickNgayNhap.Value; //Convert.ToDateTime(dtpickNgayNhap.Value.Month + "/" + dtpickNgayNhap.Value.Day + "/" + dtpickNgayNhap.Value.Year);
            clphieunhap.MaNhanVien = Decimal.Parse(cmbCanBo.SelectedValue.ToString());
            clphieunhap.MaNhaCungCap = Decimal.Parse(cmbNCC.SelectedValue.ToString());
            clphieunhap.MaKho = Decimal.Parse(cmbKhoS.SelectedValue.ToString());
            clphieunhap.NgayTao = datePickNgayTao.Value;
            clphieunhap.GhiChu = txtGhiChu.Text;

            if (clphieunhap.Them(clphieunhap) > 0)
            {
                Ham.KhungTB(1, "Thêm thành công!", pnThongBao, lbThongBao);
                Ham.ThemLuocSu(MaNV, "Thêm phiếu nhập: " + txtMaPhieuNhap.Text, "Thêm", "");
            }
            else
                Ham.KhungTB(2, "Thêm thất bại!", pnThongBao, lbThongBao);
        }

        private void Sua()
        {
            clphieunhap.MaPN = Ma;
            clphieunhap.MaPhieuNhap = txtMaPhieuNhap.Text;
            clphieunhap.MaTinhChatNguonNhap = Decimal.Parse(cmbTCNguonNhap.SelectedIndex.ToString());
            clphieunhap.NgayNhap = dtpickNgayNhap.Value;
            clphieunhap.MaNhanVien = Decimal.Parse(cmbCanBo.SelectedIndex.ToString());
            clphieunhap.MaNhaCungCap = Decimal.Parse(cmbNCC.SelectedIndex.ToString());
            clphieunhap.MaKho = Decimal.Parse(cmbKhoS.SelectedIndex.ToString());
            clphieunhap.NgayTao = datePickNgayTao.Value;
            clphieunhap.GhiChu = txtGhiChu.Text;
            
            if (clphieunhap.Sua(clphieunhap) == true)
            {
                Ham.KhungTB(1, "Thay đổi thành công!", pnThongBao, lbThongBao);
                Ham.ThemLuocSu(MaNV, "Thay đổi phiếu nhập thành: " + txtMaPhieuNhap.Text, "Thay đổi", "");
            }
            else
                Ham.KhungTB(2, "Thay đổi thất bại!", pnThongBao, lbThongBao);
        }

        private void XoaKhungThem()
        {
            txtMaPhieuNhap.Text = "";
            this.LoadCmbTCNguonNhap();
            dtpickNgayNhap.Value = DateTime.Now;
            this.LoadCmbCanBo();
            this.LoadCmbNCC();
            this.LoadCmbKhoSach();
            datePickNgayTao.Value = DateTime.Now;
            txtGhiChu.Text = "";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            TrangThai = 0;
            Ham.LoadBnt(TrangThai, pnKhungThem, btnThem, btnSua, btnLuu, btnXoa, btnTaiLai, pnThongBao, lbThongBao);
            this.LoadGV();
            this.XoaKhungThem();
            this.LoadQuyen();
            Ma = 0;
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            string a = gridView1.GetFocusedRowCellValue(clMaPN).ToString();
            btnXoa.Enabled = true;
            Ma = Convert.ToDecimal(a);
            if (TrangThai == 2)
                this.LoadKhungThem();
        }

        private void pnKhungThem_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
