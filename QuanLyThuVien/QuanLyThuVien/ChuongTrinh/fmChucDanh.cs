﻿using System;
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
    public partial class fmChucDanh : UserControl
    {
        public fmChucDanh()
        {
            InitializeComponent();

        }
        Int16 TrangThai = 0;
        Decimal Ma = 0;
        Decimal MaNV = Ham.MaNV;
        clChucDanh clChucDanh = new clChucDanh();
        clChucDanh ojp = new clChucDanh();
        private void fmChucDanh_Load(object sender, EventArgs e)
        {
            Ham.ThemLuocSu(MaNV, "Chúc Danh", "Xem", "");
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
            if (txtTenCD.Text == "")
            {
                Ham.KhungTB(3, "Chúc danh không được rổng", pnThongBao, lbThongBao);
                txtTenCD.Focus();
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
            Ma = Convert.ToDecimal(a.Replace("MCD00", ""));
            if (TrangThai == 2)
                this.LoadTxt();
        }
        private void LoadGV()
        {
            gridControl1.DataSource = clChucDanh.LayDS();
            gridView1.GroupPanelText = "Tổng số dòng là: " + clChucDanh.Dem();

        }
        private void LoadTxt()
        {
            ojp = clChucDanh.LayDS_MaCD(Ma);
            txtTenCD.Text = ojp.TenCD;
        }
        private void XoaTxt()
        {
            txtTenCD.Text = "";
        }
        private void Them()
        {
             
            clChucDanh.TenCD = txtTenCD.Text;
            if (clChucDanh.Them(clChucDanh) > 0)
            {
                Ham.KhungTB(1, "Thêm thành công", pnThongBao, lbThongBao);
                Ham.ThemLuocSu(MaNV, "Thêm chúc danh: " + txtTenCD.Text, "Thêm", "");
            }
            else
                Ham.KhungTB(2, "Thêm thất bại", pnThongBao, lbThongBao);
        }
        private void Sua()
        {
          
            clChucDanh.TenCD = txtTenCD.Text;
            clChucDanh.MaCD = Ma;
            if (clChucDanh.Sua(clChucDanh) == true)
            {
                Ham.KhungTB(1, "Thay đổi thành công", pnThongBao, lbThongBao);
                Ham.ThemLuocSu(MaNV, "Thay đổi chúc danh thành: " + txtTenCD.Text, "Thay đổi", "");
            }
            else
                Ham.KhungTB(2, "Thay đổi thất bại", pnThongBao, lbThongBao);
        } 
        private void Xoa()
        {
            int Kq = 0;
            Kq = clChucDanh.Xoa(Ma);
            if (Kq == 0)
                Ham.KhungTB(2, "Xóa thất bại", pnThongBao, lbThongBao);
            if (Kq == 1)
            {
                Ham.KhungTB(1, "Xóa thành công", pnThongBao, lbThongBao);
                Ham.ThemLuocSu(MaNV, "Xóa chúc danh: " + ojp.TenCD, "Xóa", "");
            }
            if (Kq == 3)
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
            catch (Exception) {  }
        }

        private void pnKhungThem_Paint(object sender, PaintEventArgs e)
        {
        }

        private void pnThongBao_Paint(object sender, PaintEventArgs e)
        {
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
        }
    }
}
