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
    public partial class frmThaoTac : Form
    {
        public frmThaoTac()
        {
            InitializeComponent();
        }
        Int16 TrangThai = 0;
        Decimal Ma = 0;
        clThaoTac clThaoTac = new clThaoTac();
        clThaoTac ojp = new clThaoTac();
        private void frmThaoTac_Load(object sender, EventArgs e)
        {
            clCanBo clCanBo = new clCanBo();
            clCanBo = clCanBo.LayDS_MaCB(Ham.MaCB);
            txtMaNV.Text = clCanBo.MaSoCB;
            txtTenNV.Text = clCanBo.TenCB;
            Ham.ThemLuocSu(Ham.MaNV, "Thao Tác", "Xem", "");
            Ham.LoadBnt(TrangThai, pnKhungThem, bntThem, bntLuu, bntXoa, bntSua, bntTaiLai, pnThongBao, lbThongBao);
            this.LoadGV();
            this.LoadFrom();
            this.LoadQuyen();
        }
        private void bntThem_Click(object sender, EventArgs e)
        {
            TrangThai = 1;
            this.XoaTxt();
            Ham.LoadBnt(TrangThai, pnKhungThem, bntThem, bntLuu, bntXoa, bntSua, bntTaiLai, pnThongBao, lbThongBao);
        }
        private void bntSua_Click(object sender, EventArgs e)
        {
            TrangThai = 2;
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
            try
            {
                string a = gridView1.GetFocusedRowCellValue(clMa).ToString();
                bntXoa.Enabled = true;
                Ma = Convert.ToDecimal(a.Replace("MTT00", ""));
                if (TrangThai == 2)
                    this.LoadTxt();
            }
            catch (Exception)
            {
                Ham.KhungTB(3, "Không tồn tại!", pnThongBao, lbThongBao);
            }
        }
        private void LoadGV()
        {
            gridControl1.DataSource = clThaoTac.LayDS(Ham.MaCB);
            gridView1.GroupPanelText = "Tổng số dòng là: " + clThaoTac.Dem();
        }
        private void LoadFrom()
        {
            clThaoTac objF = new clThaoTac();
            cbbFrom.Properties.DataSource = objF.LayDS_From();
            cbbFrom.Properties.ValueMember = "MaFrm";
            cbbFrom.Properties.DisplayMember = "TenGoi";
        }
        private void LoadTxt()
        {
            ojp = clThaoTac.LayDS_Ma(Ma);
            cbIn.Checked = ojp.InTT;
            cbKhoa.Checked = ojp.Khoa;
            cbSua.Checked = ojp.SuaTT;
            cbThem.Checked = ojp.ThemTT;
            cbTim.Checked = ojp.ThemTT;
            cbToanQuyen.Checked = ojp.ToanQuyen;
            cbXoa.Checked = ojp.XoaTT;
            cbXem.Checked = ojp.XemTT;
            cbbFrom.EditValue = "MF00" + ojp.MaFrm;
        }
        private void XoaTxt()
        {
            cbIn.Checked = false;
            cbKhoa.Checked = false;
            cbSua.Checked = false;
            cbThem.Checked = false;
            cbTim.Checked = false;
            cbToanQuyen.Checked = false;
            cbXoa.Checked = false;
            cbXem.Checked = false;
            this.LoadFrom();
        }
        private void Them()
        {
            try
            {
                clThaoTac.MaCB = Ham.MaCB;
                String MaSo = "";
                MaSo = cbbFrom.EditValue.ToString();
                clThaoTac.MaFrm = Convert.ToDecimal(MaSo.Replace("MF00", ""));
                clThaoTac.SuaTT = cbSua.Checked;
                clThaoTac.ThemTT = cbThem.Checked;
                clThaoTac.TimTT = cbTim.Checked;
                clThaoTac.ToanQuyen = cbToanQuyen.Checked;
                clThaoTac.XemTT = cbXem.Checked;
                clThaoTac.XoaTT = cbXoa.Checked;
                clThaoTac.InTT = cbIn.Checked;
                clThaoTac.Khoa = cbKhoa.Checked;
                DataTable tb = clThaoTac.KiemTraFrom(clThaoTac.MaFrm, Ham.MaCB);
                if (tb.Rows.Count > 0)
                {
                    Ham.KhungTB(3, "From đã tồn tại", pnThongBao, lbThongBao);
                    return;
                }
                if (clThaoTac.Them(clThaoTac) > 0)
                {
                    Ham.KhungTB(1, "Thêm thành công", pnThongBao, lbThongBao);
                    Ham.ThemLuocSu(Ham.MaNV, "Thêm from: " + cbbFrom.Text, "Thêm", "");
                }
                else
                    Ham.KhungTB(2, "Thêm thất bại", pnThongBao, lbThongBao);
            }
            catch (Exception)
            { Ham.KhungTB(3, "Vui lòng nhập thông tin đầy đủ", pnThongBao, lbThongBao); }

        }
        private void Sua()
        {
            try
            {
                clThaoTac.MaTT = Ma;
                clThaoTac.MaCB = Ham.MaCB;
                String MaSo = "";
                MaSo = cbbFrom.EditValue.ToString();
                clThaoTac.MaFrm = Convert.ToDecimal(MaSo.Replace("MF00", ""));
                clThaoTac.SuaTT = cbSua.Checked;
                clThaoTac.ThemTT = cbThem.Checked;
                clThaoTac.TimTT = cbTim.Checked;
                clThaoTac.ToanQuyen = cbToanQuyen.Checked;
                clThaoTac.XemTT = cbXem.Checked;
                clThaoTac.XoaTT = cbXoa.Checked;
                clThaoTac.InTT = cbIn.Checked;
                clThaoTac.Khoa = cbKhoa.Checked;
                DataTable tb = clThaoTac.KiemTraFrom(clThaoTac.MaFrm, Ham.MaCB);
                if (tb.Rows.Count > 0)
                {
                    if (tb.Rows[0]["MaTT"].ToString() != Ma.ToString())
                    {
                        Ham.KhungTB(3, "From đã tồn tại", pnThongBao, lbThongBao);
                        return;
                    }
                }
                if (clThaoTac.Sua(clThaoTac) == true)
                {
                    Ham.KhungTB(1, "Thay đổi thành công", pnThongBao, lbThongBao);
                    Ham.ThemLuocSu(Ham.MaNV, "Thay đổi ở from: " + cbbFrom.Text, "Thay đổi", "");
                }
                else
                    Ham.KhungTB(2, "Thay đổi thất bại", pnThongBao, lbThongBao);
            }
            catch (Exception)
            { Ham.KhungTB(3, "Vui lòng nhập thông tin đầy đủ", pnThongBao, lbThongBao); }
        }
        private void Xoa()
        {
            int Kq = 0;
            Kq = clThaoTac.Xoa(Ma);
            if (Kq == 0)
                Ham.KhungTB(2, "Xóa thất bại", pnThongBao, lbThongBao);
            if (Kq == 1)
            {
                Ham.KhungTB(1, "Xóa thành công", pnThongBao, lbThongBao);
                Ham.ThemLuocSu(Ham.MaNV, "Xóa from: " + cbbFrom.Text, "Xóa", "");
            }
            if (Kq == 3)
                Ham.KhungTB(3, "Đang được sử dụng không thể xóa", pnThongBao, lbThongBao);
        }
        private void cbKhoa_CheckedChanged(object sender, EventArgs e)
        {
            if (cbKhoa.Checked == true)
            {
                cbIn.Checked = false;
                cbSua.Checked = false;
                cbThem.Checked = false;
                cbTim.Checked = false;
                cbToanQuyen.Checked = false;
                cbXoa.Checked = false;
                cbXem.Checked = false;

                cbIn.Enabled = false;
                cbSua.Enabled = false;
                cbThem.Enabled = false;
                cbTim.Enabled = false;
                cbXoa.Enabled = false;
                cbXem.Enabled = false;
            }
            else
            {
                cbIn.Enabled = false;
                cbSua.Enabled = false;
                cbThem.Enabled = false;
                cbTim.Enabled = false;
                cbToanQuyen.Enabled = false;

                cbXoa.Enabled = true;
                cbXem.Enabled = true;
                cbIn.Enabled = true;
                cbSua.Enabled = true;
                cbThem.Enabled = true;
                cbTim.Enabled = true;
                cbToanQuyen.Enabled = true;
                cbXoa.Enabled = true;
                cbXem.Enabled = true;
            }
        }
        private void cbToanQuyen_CheckedChanged(object sender, EventArgs e)
        {
            if (cbToanQuyen.Checked == true)
            {
                cbIn.Checked = true;
                cbSua.Checked = true;
                cbThem.Checked = true;
                cbTim.Checked = true;
                cbXoa.Checked = true;
                cbXem.Checked = true;
                cbIn.Checked = true;
                cbKhoa.Checked = false;

                cbIn.Enabled = false;
                cbSua.Enabled = false;
                cbThem.Enabled = false;
                cbTim.Enabled = false;
                cbXoa.Enabled = false;
                cbXem.Enabled = false;
            }
            else
            {
                cbIn.Checked = false;
                cbSua.Checked = false;
                cbThem.Checked = false;
                cbTim.Checked = false;
                cbXoa.Checked = false;
                cbXem.Checked = false;

                cbXoa.Enabled = true;
                cbXem.Enabled = true;
                cbIn.Enabled = true;
                cbSua.Enabled = true;
                cbThem.Enabled = true;
                cbTim.Enabled = true;
                cbXoa.Enabled = true;
                cbXem.Enabled = true;
            }
        }
        private void LoadQuyen()
        { 
            clThaoTac PQ = new clThaoTac();
            try
            {
                PQ = PQ.Lay_From(7, Ham.MaNV);
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
