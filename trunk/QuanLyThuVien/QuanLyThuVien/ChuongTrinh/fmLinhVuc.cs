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
    public partial class fmLinhVuc : UserControl
    {
        public fmLinhVuc()
        {
            InitializeComponent();
        }  
        Int16 TrangThai = 0;
        Decimal Ma = 0;
        clLinhVuc clLinhVuc = new clLinhVuc();
        clLinhVuc ojp = new clLinhVuc(); 
        private void fmLinhVuc_Load(object sender, EventArgs e)
        {
            Ham.ThemLuocSu(Ham.MaNV, "Lĩnh Vực", "Xem", "");
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
                Ham.KhungTB(3, "Tên đơn vị tính không được rổng", pnThongBao, lbThongBao);
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
            Ma = Convert.ToDecimal(a.Replace("LV00", ""));
            if (TrangThai == 2)
                this.LoadTxt();
        }
        private void LoadGV()
        {
            gridControl1.DataSource = clLinhVuc.LayDS();
            gridView1.GroupPanelText = "Tổng số dòng là: " + clLinhVuc.Dem();

        }
        private void LoadTxt()
        {
            ojp = clLinhVuc.LayDS_Ma(Ma);
            txtTen.Text = ojp.TenLV;
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
             
            clLinhVuc.TenLV = txtTen.Text;
            clLinhVuc.GhiChu = txtGhiChu.Text;
            clLinhVuc.TrangThai = cbTrangThai.Checked;
            if (clLinhVuc.Them(clLinhVuc) > 0)
            {
                Ham.KhungTB(1, "Thêm thành công", pnThongBao, lbThongBao);
                Ham.ThemLuocSu(Ham.MaNV, "Thêm lĩnh vực: " + txtTen.Text, "Thêm", "");
            }
            else
                Ham.KhungTB(2, "Thêm thất bại", pnThongBao, lbThongBao);
        }
        private void Sua()
        {   
            clLinhVuc.TenLV = txtTen.Text;
            clLinhVuc.MaLV = Ma;
            clLinhVuc.GhiChu = txtGhiChu.Text;
            clLinhVuc.TrangThai = cbTrangThai.Checked;
            if (clLinhVuc.Sua(clLinhVuc) == true)
            {
                Ham.KhungTB(1, "Thay đổi thành công", pnThongBao, lbThongBao);
                Ham.ThemLuocSu(Ham.MaNV, "Thay đổi lĩnh vực " + Ma + " thành: " + txtTen.Text, "Thay đổi", "");
            }
            else
                Ham.KhungTB(2, "Thay đổi thất bại", pnThongBao, lbThongBao);
        }
        private void Xoa()
        {
            int Kq = 0;
            Kq = clLinhVuc.Xoa(Ma);
            if (Kq == 0)
                Ham.KhungTB(2, "Xóa thất bại", pnThongBao, lbThongBao);
            if (Kq == 1)
            {
                Ham.KhungTB(1, "Xóa thành công", pnThongBao, lbThongBao);
                Ham.ThemLuocSu(Ham.MaNV, "Xóa lĩnh vực: " + ojp.TenLV, "Xóa", "");
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
