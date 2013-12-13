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
    public partial class fmQuyen : UserControl
    {
        public fmQuyen()
        {
            InitializeComponent();
        }
        Int16 TrangThai = 0;
        Decimal Ma = 0;
        Decimal MaNV = Ham.MaNV;
        clQuyen clQuyen = new clQuyen();
        clQuyen obj = new clQuyen();
        private void fmQuyen_Load(object sender, EventArgs e)
        {
            Ham.ThemLuocSu(MaNV, "Quyền", "Xem", "");
            Ham.LoadBnt(TrangThai, pnKhungThem, bntThem, bntLuu, bntXoa, bntSua, bntTaiLai, pnThongBao, lbThongBao);
            this.LoadGV();
            this.LoadQuyen();
        }
        private void bntThem_Click(object sender, EventArgs e)
        {
            TrangThai = 1;
            this.LoadTxt();
            Ham.LoadBnt(TrangThai, pnKhungThem, bntThem, bntLuu, bntXoa, bntSua, bntTaiLai, pnThongBao, lbThongBao);

        }
        private void bntSua_Click(object sender, EventArgs e)
        {
            TrangThai = 2;
            this.LoadTxt();
            Ham.LoadBnt(TrangThai, pnKhungThem, bntThem, bntLuu, bntXoa, bntSua, bntTaiLai, pnThongBao, lbThongBao);

        }
        private void bntLuu_Click(object sender, EventArgs e)
        {
            if (txtTenQ.Text == "")
            {
                Ham.KhungTB(3, "Tên quyền không được rổng", pnThongBao, lbThongBao);
                txtTenQ.Focus();
                return;
            }
            if (TrangThai == 1)
                this.Them();
            if (TrangThai == 2)
                this.Sua();
            this.LoadGV();
            this.LoadTxt();

        }
        private void bntXoa_Click(object sender, EventArgs e)
        {
            this.Xoa();
            this.LoadGV();

        }
        private void bntTaiLai_Click(object sender, EventArgs e)
        {
            TrangThai = 0;
            Ham.LoadBnt(TrangThai, pnKhungThem, bntThem, bntLuu, bntXoa, bntSua, bntTaiLai, pnThongBao, lbThongBao);
            this.LoadGV();
            this.XoaTxt();
            this.LoadQuyen();
            Ma = 0;
        }
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            string a = gridView1.GetFocusedRowCellValue(clMa).ToString();
            bntXoa.Enabled = true;
            Ma = Convert.ToDecimal(a.Replace("MQ00", ""));
            if (TrangThai == 2)
                this.LoadTxt();

        }
        private void LoadGV()
        {
            gridControl1.DataSource = clQuyen.LayDS();
            gridView1.GroupPanelText = "Tổng số dòng là: " + clQuyen.Dem();

        }
        private void LoadTxt()
        {
            obj = clQuyen.LayDS_Ma(Ma);
            txtTenQ.Text = obj.TenQ;
            if (obj.Admin == 1) cbAdmin.Checked = true;
            else cbAdmin.Checked = false;
        }
        private void XoaTxt()
        {
            txtTenQ.Text = "";
            cbAdmin.Checked = false;
        }
        private void Them()
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
        private void Sua()
        {

            clQuyen.TenQ = txtTenQ.Text;
            clQuyen.MaQ = Ma;
            if (cbAdmin.Checked == true)
                clQuyen.Admin = 1;
            else clQuyen.Admin = 2;
            if (clQuyen.Sua(clQuyen) == true)
            {
                Ham.KhungTB(1, "Thay đổi thành công", pnThongBao, lbThongBao);
                Ham.ThemLuocSu(MaNV, "Thay đổi quyền thành: " + txtTenQ.Text, "Thay đổi", "");
            }
            else
                Ham.KhungTB(2, "Thay đổi thất bại", pnThongBao, lbThongBao);
        }
        private void Xoa()
        {
            int Kq = 0;
            Kq = clQuyen.Xoa(Ma);
            if (Kq == 0)
                Ham.KhungTB(2, "Xóa thất bại", pnThongBao, lbThongBao);
            if (Kq == 1)
            {
                Ham.KhungTB(1, "Xóa thành công", pnThongBao, lbThongBao);
                Ham.ThemLuocSu(MaNV, "Xóa quyền: " + obj.TenQ, "Xóa", "");
                Ma = 0;
            }
            if (Kq == 3)
                Ham.KhungTB(3, "Đang được sử dụng không thể xóa", pnThongBao, lbThongBao);
        }
        private void LoadQuyen()
        {

            clThaoTac PQ = new clThaoTac();
            try
            {
                PQ = PQ.Lay_From(4, Ham.MaNV);
                if (PQ.ToanQuyen != true && Ham.qAdmin != 1)
                {
                    if (PQ.ThemTT == false) bntThem.Visible = false;
                    if (PQ.SuaTT == false) bntSua.Visible = false;
                    if (PQ.XoaTT == false) bntXoa.Visible = false;
                    if (PQ.XemTT == false) panelControl2.Visible = false;
                    //if (PQ.InTT == false) bntIn.Visible = false;
                    //if (PQ.TimTT == false) bntTim.Visible = false;
                    if (PQ.ThemTT == false && PQ.SuaTT == false) bntLuu.Visible = false;
                }
            }
            catch (Exception) { }
        }
    }
}
