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
    public partial class fmTrangThai : UserControl
    {
        public fmTrangThai()
        {
            InitializeComponent();
        }
        Int16 TrangThai = 0;
        Decimal Ma = 0;
        clTrangThai clTrangThai = new clTrangThai();
        clTrangThai ojp = new clTrangThai();
        private void fmTrangThai_Load(object sender, EventArgs e)
        {
            Ham.ThemLuocSu(Ham.MaNV, "Trạng Thái Sách", "Xem", "");
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
            if (txtTen.Text == "")
            {
                Ham.KhungTB(3, "Tên trạng thái không được rổng", pnThongBao, lbThongBao);//
                txtTen.Focus();
                return;
            }
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
            Ma = Convert.ToDecimal(a.Replace("TrT00", ""));
            if (TrangThai == 2)
                this.LoadTxt();
        }
        private void LoadGV()
        {
            gridControl1.DataSource = clTrangThai.LayDS();
            gridView1.GroupPanelText = "Tổng số dòng là: " + clTrangThai.Dem();

        }
        private void LoadTxt()
        {
            ojp = clTrangThai.LayDS_Ma(Ma);
            txtTen.Text = ojp.TenTT;
            txtGhiChu.Text = ojp.GhiChu;
            cbTrangThai.Checked = ojp.TrangThai;

        }
        private void XoaTxt()
        {
            txtTen.Text = "";
            txtGhiChu.Text = "";
            cbTrangThai.Checked = false;
        }
        private void Them()
        {

            clTrangThai.TenTT = txtTen.Text;
            clTrangThai.GhiChu = txtGhiChu.Text;
            clTrangThai.TrangThai = cbTrangThai.Checked;
            if (clTrangThai.Them(clTrangThai) > 0)
            {
                Ham.KhungTB(1, "Thêm thành công", pnThongBao, lbThongBao);//
                Ham.ThemLuocSu(Ham.MaNV, "Thêm trạng thái: " + txtTen.Text, "Thêm", "");
            }
            else
                Ham.KhungTB(2, "Thêm thất bại", pnThongBao, lbThongBao);
        }
        private void Sua()
        {

            clTrangThai.TenTT = txtTen.Text;
            clTrangThai.MaTT = Ma;
            clTrangThai.GhiChu = txtGhiChu.Text;
            clTrangThai.TrangThai = cbTrangThai.Checked;
            if (clTrangThai.Sua(clTrangThai) == true)
            {
                Ham.KhungTB(1, "Thay đổi thành công", pnThongBao, lbThongBao);//
                Ham.ThemLuocSu(Ham.MaNV, "Thay đổi trạng thái " + Ma + " thành: " + txtTen.Text, "Thay đổi", "");
            }
            else
                Ham.KhungTB(2, "Thay đổi thất bại", pnThongBao, lbThongBao);
        }
        private void Xoa()
        {
            int Kq = 0;
            Kq = clTrangThai.Xoa(Ma);
            if (Kq == 0)
                Ham.KhungTB(2, "Xóa thất bại", pnThongBao, lbThongBao);
            if (Kq == 1)
            {
                Ham.KhungTB(1, "Xóa thành công", pnThongBao, lbThongBao);
                Ham.ThemLuocSu(Ham.MaNV, "Xóa trạng thái: " + ojp.TenTT, "Xóa", "");//
            }
            if (Kq == 2)
                Ham.KhungTB(3, "Đang được sử dụng không thể xóa", pnThongBao, lbThongBao);
        }
        private void LoadQuyen()
        {

            clThaoTac PQ = new clThaoTac();
            try
            {
                PQ = PQ.Lay_From(1, Ham.MaNV);
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
