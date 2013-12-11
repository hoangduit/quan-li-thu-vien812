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


namespace QuanLyThuVien
{
    public partial class Main : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        TapControl Tap = new TapControl();
        public Main()
        {
            InitializeComponent();

        }
        private void bntDN_ItemClick(object sender, ItemClickEventArgs e)
        {
            fmDangNhap frm = new fmDangNhap();
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
        #endregion
         
        private void bntChucDanh_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.CheckTap(bntChucDanh.Caption.ToString(), new fmChucDanh());
        }
    }
}