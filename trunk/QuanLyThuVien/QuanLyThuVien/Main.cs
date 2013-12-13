using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using QuanLyThuVien.ChuongTrinh;
using QuanLyThuVien.BAL;
using QuanLyThuVien.FromCon;
using System.IO;
namespace QuanLyThuVien
{
    public partial class Main : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        TapControl Tap = new TapControl();
        public Main()
        {
            InitializeComponent();

        }
        public void layUser(Decimal MaSo)
        {
            clCanBo clCanBo = new clCanBo();
            DataTable tb = clCanBo.LayCB(MaSo);
            txtHoTen.Caption = tb.Rows[0]["TenCB"].ToString();
            txtThoiGian.Caption = DateTime.Now.ToString();
            txtQuyen.Caption = tb.Rows[0]["Admin"].ToString();
            Ham.ThemLuocSu(MaSo, txtHoTen.Caption + " đã đăng nhập", "Đăng nhập", "");
            Ham.MaNV = MaSo;
            Ham.qAdmin = Convert.ToDecimal( tb.Rows[0]["qAdmin"].ToString());
        }
        private void Main_Load(object sender, EventArgs e)
        {

        }
        private void bntDN_ItemClick(object sender, ItemClickEventArgs e)
        {
            fmDangNhap frm = new fmDangNhap();
            frm.layUser = new fmDangNhap.GetString(layUser);
            frm.ShowDialog();
        }
        private void bntDX_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        private void bntThoat_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        private void bntTaiKhoan_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.CheckTap(bntTaiKhoan.Caption.ToString(), new fmTaiKhoan());
        }
        private void bntPhanQuyen_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.CheckTap(bntPhanQuyen.Caption.ToString(), new fmQuyen());
        }
        private void bntLuuDL_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.CheckTap(bntLuuDL.Caption.ToString(), new fmLuuDuLieu());
        }
        private void bntPhucHoiDL_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.CheckTap(bntPhucHoiDL.Caption.ToString(), new fmPhucHoi());
        }

        //==================================================================================================
        #region 
        public void CheckTap(String Ten, UserControl UserControl)
        {
            int t = 0;
            foreach (DevExpress.XtraTab.XtraTabPage tab in xtraTabControl1.TabPages)
            {
                if (tab.Text == Ten)
                {
                    xtraTabControl1.SelectedTabPage = tab;
                    t = 1;
                }
            }
            if (t != 1)
            {// Nếu chưa có TAb này thì gọi hàm Addtab xây dựng ở trên để Add Tab con vào
                Tap.AddTab(xtraTabControl1, " ", Ten, UserControl);
            }
        }
        // để xóa táp ta chọn
        private void xtraTabControl1_CloseButtonClick(object sender, EventArgs e)
        {
            DevExpress.XtraTab.XtraTabControl tabControl = sender as DevExpress.XtraTab.XtraTabControl;
            DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs arg = e as DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs;
            (arg.Page as DevExpress.XtraTab.XtraTabPage).Dispose();
        }
        //chuyển đến tap khi ta chọn hoăc add
        private void xtraTabControl1_ControlAdded(object sender, ControlEventArgs e)
        {
            xtraTabControl1.SelectedTabPageIndex = xtraTabControl1.TabPages.Count - 1;
        }
        //Phân quyền

        private void PhanQuyen()
        {


        }
        #endregion
        //==================================================================================================
         private void bntChucDanh_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.CheckTap(bntChucDanh.Caption.ToString(), new fmChucDanh());
        } 
        private void bntDoiMatKhau_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDoiMatKhau frm = new frmDoiMatKhau();
            frm.ShowDialog();
        }

        private void bntDonViTinh_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.CheckTap(bntDonViTinh.Caption.ToString(), new fmDonViTinh());
        }

        private void bntNhaXuatBan_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.CheckTap(bntNhaXuatBan.Caption.ToString(), new fmNhaXuatBan());
        }

        private void bntNgonNgu_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.CheckTap(bntNgonNgu.Caption.ToString(), new fmNgonNgu());
        }

        private void bntLoaiSach_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.CheckTap(bntLoaiSach.Caption.ToString(), new fmLoaiSach());
        }

        private void bntNhomSach_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.CheckTap(bntNhomSach.Caption.ToString(), new fmNhomSach());
        }

        private void bntLinhVuc_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.CheckTap(bntLinhVuc.Caption.ToString(), new fmLinhVuc());
        }

        private void bntTinhTrang_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.CheckTap(bntTinhTrang.Caption.ToString(), new fmTinhTrang());
        }

        private void bntTrangThai_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.CheckTap(bntTrangThai.Caption.ToString(), new fmTrangThai());
        }

    }
}