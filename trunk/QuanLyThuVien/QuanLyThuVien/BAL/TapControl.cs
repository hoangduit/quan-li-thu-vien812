using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
namespace QuanLyThuVien.BAL
{
    class TapControl
    { 
        public void AddTab(DevExpress.XtraTab.XtraTabControl XtraTabCha, string icon, string TabNameAdd, System.Windows.Forms.UserControl UserControl)
        {
            // Khởi tạo 1 Tab Con (XtraTabPage) 
            DevExpress.XtraTab.XtraTabPage TAbAdd = new DevExpress.XtraTab.XtraTabPage(); 
            TAbAdd.Text = TabNameAdd; 
            TAbAdd.Controls.Add(UserControl); 
            UserControl.Dock = DockStyle.Fill; 
            XtraTabCha.TabPages.Add(TAbAdd);
        }
    }
}
