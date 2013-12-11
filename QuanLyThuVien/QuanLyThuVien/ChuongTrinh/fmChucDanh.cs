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
    public partial class fmChucDanh : UserControl
    {

        public fmChucDanh()
        {
            InitializeComponent();
        } 
        private void fmChucDanh_Load(object sender, EventArgs e)
        {
            Ham.ThemLuocSu(1, "Chúc Danh", "Xem", "");  
        }
        private void bntThem_Click(object sender, EventArgs e)
        {

        }
        private void bntSua_Click(object sender, EventArgs e)
        {

        }
        private void bntLuu_Click(object sender, EventArgs e)
        {

        }
        private void bntXoa_Click(object sender, EventArgs e)
        {

        }
        private void bntTaiLai_Click(object sender, EventArgs e)
        {

        }
        
        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {

        }

    }
}
