using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyThuVien.BAL;
using QuanLyThuVien.FromCon;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Windows.Forms.DataVisualization.Charting;
namespace QuanLyThuVien.ChuongTrinh
{
    public partial class fmTaiKhoan : UserControl
    {
        public fmTaiKhoan()
        {
            InitializeComponent();
        }
        Int16 TrangThai = 0;
        Decimal Ma = 0;
        Decimal MaNV = 1;
        clCanBo clCanBo = new clCanBo();
        clCanBo ojp = new clCanBo();
        private void fmTaiKhoan_Load(object sender, EventArgs e)
        {
            Ham.ThemLuocSu(MaNV, "Người dùng", "Xem", "");
            Ham.LoadBnt(TrangThai, pnKhungThem, bntThem, bntLuu, bntXoa, bntSua, bntTaiLai, pnThongBao, lbThongBao);
            this.LoadGV();
            this.LoadCD();
            this.LoadQ();
            Ham.MaNV = MaNV;
            bntPhanQuyen.Enabled = false;
        }
        private void bntChucDanh_Click(object sender, EventArgs e)
        {
            frmChucDanh frm = new frmChucDanh();
            frm.ShowDialog();
        }
        private void bntQuyen_Click(object sender, EventArgs e)
        {
            frmQuyen frm = new frmQuyen();
            frm.ShowDialog();
        }
        private void bntThem_Click(object sender, EventArgs e)
        {
            TrangThai = 1;
            txtMaSo.Enabled = true;
            this.XoaTxt();
            Ham.LoadBnt(TrangThai, pnKhungThem, bntThem, bntLuu, bntXoa, bntSua, bntTaiLai, pnThongBao, lbThongBao);
        }
        private void bntSua_Click(object sender, EventArgs e)
        {
            TrangThai = 2;
            txtMaSo.Enabled = false;
            this.XoaTxt();
            Ham.LoadBnt(TrangThai, pnKhungThem, bntThem, bntLuu, bntXoa, bntSua, bntTaiLai, pnThongBao, lbThongBao);

        }
        private void bntLuu_Click(object sender, EventArgs e)
        {
            if (TrangThai == 1)
                this.Them();
            if (TrangThai == 2)
                this.Sua();
            this.LoadGV();
            this.XoaTxt();
        }
        private void bntXoa_Click(object sender, EventArgs e)
        {
            this.Xoa();
            this.LoadGV();
        }
        private void bntPhanQuyen_Click(object sender, EventArgs e)
        {
            if (Ma > 0)
            {
                Ham.MaCB = Ma;
                frmThaoTac frm = new frmThaoTac();
                frm.ShowDialog(); 
            }
        }
        private void bntTaiLai_Click(object sender, EventArgs e)
        {
            TrangThai = 0;
            Ham.LoadBnt(TrangThai, pnKhungThem, bntThem, bntLuu, bntXoa, bntSua, bntTaiLai, pnThongBao, lbThongBao);
            this.LoadGV();
            this.XoaTxt();
        }
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                string a = gridView1.GetFocusedRowCellValue(clMa).ToString();
                bntXoa.Enabled = true;
                Ma = Convert.ToDecimal(a.Replace("MCB00", ""));
                if (TrangThai == 2)
                    this.LoadTxt();
                bntPhanQuyen.Enabled = true;
            }
            catch (Exception)
            {
                Ham.KhungTB(3, "Không tồn tại!", pnThongBao, lbThongBao);
            }

        }
        private void LoadGV()
        {
            gridControl1.DataSource = clCanBo.LayDS();
            gridView1.GroupPanelText = "Tổng số dòng là: " + clCanBo.Dem();

        }
        private void LoadTxt()
        {
            ojp = clCanBo.LayDS_MaCB(Ma);
            String GT = "";
            txtMaSo.Text = ojp.MaSoCB;
            txtHoTen.Text = ojp.TenCB;
            txtDiaChi.Text = ojp.DiaChi;
            txtSDT.Text = ojp.SDT;
            txtMail.Text = ojp.Mail;
            cbbChucDan.EditValue = "MCD00"+ojp.MaCD;
            cbbQuyen.EditValue = "MQ00"+ojp.MaQuyen;
            txtMaSo.Text = ojp.TaiKhoan;
            txtMaSo.Text = ojp.MatKhau;
            cbTrangThai.Checked = ojp.TrangThai;
            if (clCanBo.GioiTinh == true) GT = "Nam";
            else GT = "Nữ";
            cbbGioiTinh.SelectedText = "";
            cbbGioiTinh.SelectedText = GT;

        }
        private void LoadCD()
        {
            clChucDanh obj = new clChucDanh();
            cbbChucDan.Properties.DataSource = obj.LayDS();
            cbbChucDan.Properties.ValueMember = "MaCD";
            cbbChucDan.Properties.DisplayMember = "TenCD";
        }
        private void LoadQ()
        {
            clQuyen obj = new clQuyen();
            cbbQuyen.Properties.DataSource = obj.LayDS();
            cbbQuyen.Properties.ValueMember = "MaQ";
            cbbQuyen.Properties.DisplayMember = "TenQ";
        }
        private void XoaTxt()
        {
            txtMaSo.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            txtMail.Text = "";
            this.LoadCD();
            this.LoadQ();
            txtMaSo.Text = "";
            txtMaSo.Text = "";
            cbTrangThai.Checked = false;
            cbbGioiTinh.SelectedText = "";
        }
        private void Them()
        {
            Boolean GT = false;
            clCanBo.MaSoCB = txtMaSo.Text.Trim() ;
            clCanBo.TenCB = txtHoTen.Text;
            clCanBo.DiaChi = txtDiaChi.Text;
            clCanBo.SDT = txtSDT.Text;
            clCanBo.Mail = txtMail.Text;
            String MaSo = "";
            MaSo = cbbChucDan.EditValue.ToString () ;
            clCanBo.MaCD = Convert.ToDecimal(MaSo .Replace ("MCD00",""));
            MaSo = cbbQuyen.EditValue.ToString();
            clCanBo.MaQuyen = Convert.ToDecimal(MaSo.Replace("MQ00", ""));

            clCanBo.TaiKhoan = txtMaSo.Text;
            clCanBo.MatKhau = txtMaSo.Text;
            clCanBo.TrangThai = cbTrangThai.Checked;
            if (cbbGioiTinh.SelectedText == "Nam") GT = true;
            else GT = false;
            clCanBo.GioiTinh = GT;
            if (clCanBo.KT_MaSoCB(clCanBo.MaSoCB.ToString ().Trim ()))
                Ham.KhungTB(3, "Mã số đã tồn tại! ", pnThongBao, lbThongBao);
            if (clCanBo.Them(clCanBo) > 0)
            {
                Ham.KhungTB(1, "Thêm thành công", pnThongBao, lbThongBao);
                Ham.ThemLuocSu(MaNV, "Thêm nhân viên: " + txtHoTen.Text, "Thêm", "");
            }
            else
                Ham.KhungTB(2, "Thêm thất bại", pnThongBao, lbThongBao);
        }
        private void Sua()
        {
            Boolean GT = false;
            clCanBo.MaCB = Ma;
            clCanBo.MaSoCB = txtMaSo.Text;
            clCanBo.TenCB = txtHoTen.Text;
            clCanBo.DiaChi = txtDiaChi.Text;
            clCanBo.SDT = txtSDT.Text;
            clCanBo.Mail = txtMail.Text;
            String MaSo = "";
            MaSo = cbbChucDan.EditValue.ToString();
            clCanBo.MaCD = Convert.ToDecimal(MaSo.Replace("MCD00", ""));
            MaSo = cbbQuyen.EditValue.ToString();
            clCanBo.MaQuyen = Convert.ToDecimal(MaSo.Replace("MQ00", ""));
            clCanBo.TaiKhoan = txtMaSo.Text;
            clCanBo.MatKhau = txtMaSo.Text;
            clCanBo.TrangThai = cbTrangThai.Checked;
            if (cbbGioiTinh.SelectedText == "Nam") GT = true;
            else GT = false;
            clCanBo.GioiTinh = GT;
            if (clCanBo.Sua(clCanBo) == true)
            {
                Ham.KhungTB(1, "Thay đổi thành công", pnThongBao, lbThongBao);
                Ham.ThemLuocSu(MaNV, "Thay đổi nhân viên với mã: " + txtMaSo.Text, "Thay đổi", "");
            }
            else
                Ham.KhungTB(2, "Thay đổi thất bại", pnThongBao, lbThongBao);
        }
        private void Xoa()
        {
            int Kq = 0;
            Kq = clCanBo.Xoa(Ma);
            if (Kq == 0)
                Ham.KhungTB(2, "Xóa thất bại", pnThongBao, lbThongBao);
            if (Kq == 1)
            {
                Ham.KhungTB(1, "Xóa thành công", pnThongBao, lbThongBao);
                Ham.ThemLuocSu(MaNV, "Xóa nhân viên với mã: " + ojp.MaSoCB, "Xóa", "");
                Ma = 0;
                bntPhanQuyen.Enabled = false;
            }
            if (Kq == 3)
                Ham.KhungTB(3, "Đang được sử dụng không thể xóa", pnThongBao, lbThongBao);
        } 
    }
}
