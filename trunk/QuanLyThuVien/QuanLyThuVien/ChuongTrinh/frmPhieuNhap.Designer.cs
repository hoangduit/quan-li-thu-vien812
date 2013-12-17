namespace QuanLyThuVien.ChuongTrinh
{
    partial class frmPhieuNhap
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gvPhieuNhap = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clMaPN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clMaPhieuNhap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clTCNguonNhap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clNgayNhap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clNhanVien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clNCC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clKhoS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clNgayTao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clGhiChu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutView1 = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            this.layoutViewCard1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewCard();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.dtpickNgayNhap = new System.Windows.Forms.DateTimePicker();
            this.txtGhiChu = new DevExpress.XtraEditors.TextEdit();
            this.txtMaPhieuNhap = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.pnKhungThem = new DevExpress.XtraEditors.PanelControl();
            this.cmbKhoS = new System.Windows.Forms.ComboBox();
            this.cmbNCC = new System.Windows.Forms.ComboBox();
            this.cmbCanBo = new System.Windows.Forms.ComboBox();
            this.cmbTCNguonNhap = new System.Windows.Forms.ComboBox();
            this.datePickNgayTao = new System.Windows.Forms.DateTimePicker();
            this.pnThaoTac = new DevExpress.XtraEditors.PanelControl();
            this.btnTaiLai = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.btnSua = new DevExpress.XtraEditors.SimpleButton();
            this.btnThem = new DevExpress.XtraEditors.SimpleButton();
            this.pnThongBao = new System.Windows.Forms.Panel();
            this.lbThongBao = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gvPhieuNhap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaPhieuNhap.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnKhungThem)).BeginInit();
            this.pnKhungThem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnThaoTac)).BeginInit();
            this.pnThaoTac.SuspendLayout();
            this.pnThongBao.SuspendLayout();
            this.SuspendLayout();
            // 
            // gvPhieuNhap
            // 
            this.gvPhieuNhap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gvPhieuNhap.Location = new System.Drawing.Point(0, 182);
            this.gvPhieuNhap.MainView = this.gridView1;
            this.gvPhieuNhap.Name = "gvPhieuNhap";
            this.gvPhieuNhap.Size = new System.Drawing.Size(998, 256);
            this.gvPhieuNhap.TabIndex = 3;
            this.gvPhieuNhap.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.layoutView1,
            this.gridView2});
            this.gvPhieuNhap.Click += new System.EventHandler(this.gridControl1_Click);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clMaPN,
            this.clMaPhieuNhap,
            this.clTCNguonNhap,
            this.clNgayNhap,
            this.clNhanVien,
            this.clNCC,
            this.clKhoS,
            this.clNgayTao,
            this.clGhiChu});
            this.gridView1.CustomizationFormBounds = new System.Drawing.Rectangle(775, 419, 216, 183);
            this.gridView1.GridControl = this.gvPhieuNhap;
            this.gridView1.Name = "gridView1";
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            // 
            // clMaPN
            // 
            this.clMaPN.Caption = "STT";
            this.clMaPN.FieldName = "MaPN";
            this.clMaPN.Name = "clMaPN";
            this.clMaPN.OptionsColumn.AllowEdit = false;
            this.clMaPN.OptionsColumn.ReadOnly = true;
            this.clMaPN.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.clMaPN.Visible = true;
            this.clMaPN.VisibleIndex = 0;
            this.clMaPN.Width = 31;
            // 
            // clMaPhieuNhap
            // 
            this.clMaPhieuNhap.Caption = "Mã phiếu nhập";
            this.clMaPhieuNhap.FieldName = "MaPhieuNhap";
            this.clMaPhieuNhap.Name = "clMaPhieuNhap";
            this.clMaPhieuNhap.OptionsColumn.AllowEdit = false;
            this.clMaPhieuNhap.OptionsColumn.ReadOnly = true;
            this.clMaPhieuNhap.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.clMaPhieuNhap.Visible = true;
            this.clMaPhieuNhap.VisibleIndex = 1;
            this.clMaPhieuNhap.Width = 76;
            // 
            // clTCNguonNhap
            // 
            this.clTCNguonNhap.Caption = "Tính chất nguồn nhập";
            this.clTCNguonNhap.FieldName = "MaTinhChatNguonNhap";
            this.clTCNguonNhap.Name = "clTCNguonNhap";
            this.clTCNguonNhap.OptionsColumn.AllowEdit = false;
            this.clTCNguonNhap.OptionsColumn.ReadOnly = true;
            this.clTCNguonNhap.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.clTCNguonNhap.Visible = true;
            this.clTCNguonNhap.VisibleIndex = 2;
            this.clTCNguonNhap.Width = 143;
            // 
            // clNgayNhap
            // 
            this.clNgayNhap.Caption = "Ngày nhập";
            this.clNgayNhap.Name = "clNgayNhap";
            this.clNgayNhap.OptionsColumn.AllowEdit = false;
            this.clNgayNhap.OptionsColumn.ReadOnly = true;
            this.clNgayNhap.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.clNgayNhap.Visible = true;
            this.clNgayNhap.VisibleIndex = 3;
            this.clNgayNhap.Width = 86;
            // 
            // clNhanVien
            // 
            this.clNhanVien.Caption = "Nhân viên";
            this.clNhanVien.Name = "clNhanVien";
            this.clNhanVien.OptionsColumn.AllowEdit = false;
            this.clNhanVien.OptionsColumn.ReadOnly = true;
            this.clNhanVien.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.clNhanVien.Visible = true;
            this.clNhanVien.VisibleIndex = 4;
            this.clNhanVien.Width = 86;
            // 
            // clNCC
            // 
            this.clNCC.Caption = "Nhà cung cấp";
            this.clNCC.FieldName = "MaNhaCungCap";
            this.clNCC.Name = "clNCC";
            this.clNCC.OptionsColumn.AllowEdit = false;
            this.clNCC.OptionsColumn.ReadOnly = true;
            this.clNCC.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.clNCC.Visible = true;
            this.clNCC.VisibleIndex = 5;
            this.clNCC.Width = 143;
            // 
            // clKhoS
            // 
            this.clKhoS.Caption = "Kho sách";
            this.clKhoS.FieldName = "MaKho";
            this.clKhoS.Name = "clKhoS";
            this.clKhoS.OptionsColumn.AllowEdit = false;
            this.clKhoS.OptionsColumn.ReadOnly = true;
            this.clKhoS.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.clKhoS.Visible = true;
            this.clKhoS.VisibleIndex = 6;
            this.clKhoS.Width = 47;
            // 
            // clNgayTao
            // 
            this.clNgayTao.Caption = "Ngày tạo";
            this.clNgayTao.FieldName = "NgayTao";
            this.clNgayTao.Name = "clNgayTao";
            this.clNgayTao.OptionsColumn.AllowEdit = false;
            this.clNgayTao.OptionsColumn.ReadOnly = true;
            this.clNgayTao.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.clNgayTao.Visible = true;
            this.clNgayTao.VisibleIndex = 7;
            this.clNgayTao.Width = 86;
            // 
            // clGhiChu
            // 
            this.clGhiChu.Caption = "Ghi chú";
            this.clGhiChu.FieldName = "GhiChu";
            this.clGhiChu.Name = "clGhiChu";
            this.clGhiChu.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.clGhiChu.Visible = true;
            this.clGhiChu.VisibleIndex = 8;
            this.clGhiChu.Width = 100;
            // 
            // layoutView1
            // 
            this.layoutView1.GridControl = this.gvPhieuNhap;
            this.layoutView1.Name = "layoutView1";
            this.layoutView1.TemplateCard = this.layoutViewCard1;
            // 
            // layoutViewCard1
            // 
            this.layoutViewCard1.ExpandButtonLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.layoutViewCard1.Name = "layoutViewTemplateCard";
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gvPhieuNhap;
            this.gridView2.Name = "gridView2";
            // 
            // dtpickNgayNhap
            // 
            this.dtpickNgayNhap.CustomFormat = "dd/mm/yyyy";
            this.dtpickNgayNhap.Location = new System.Drawing.Point(224, 81);
            this.dtpickNgayNhap.Name = "dtpickNgayNhap";
            this.dtpickNgayNhap.Size = new System.Drawing.Size(169, 20);
            this.dtpickNgayNhap.TabIndex = 35;
            this.dtpickNgayNhap.Value = new System.DateTime(2013, 9, 17, 9, 45, 28, 0);
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(651, 123);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(169, 20);
            this.txtGhiChu.TabIndex = 30;
            // 
            // txtMaPhieuNhap
            // 
            this.txtMaPhieuNhap.Location = new System.Drawing.Point(224, 7);
            this.txtMaPhieuNhap.Name = "txtMaPhieuNhap";
            this.txtMaPhieuNhap.Size = new System.Drawing.Size(169, 20);
            this.txtMaPhieuNhap.TabIndex = 29;
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl8.Location = new System.Drawing.Point(502, 124);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(47, 16);
            this.labelControl8.TabIndex = 28;
            this.labelControl8.Text = "Ghi chú:";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl7.Location = new System.Drawing.Point(75, 46);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(129, 16);
            this.labelControl7.TabIndex = 27;
            this.labelControl7.Text = "Tính chất nguồn nhập:";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Location = new System.Drawing.Point(75, 86);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(65, 16);
            this.labelControl6.TabIndex = 26;
            this.labelControl6.Text = "Ngày nhập:";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Location = new System.Drawing.Point(75, 124);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(45, 16);
            this.labelControl5.TabIndex = 25;
            this.labelControl5.Text = "Cán bộ:";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Location = new System.Drawing.Point(502, 8);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(82, 16);
            this.labelControl4.TabIndex = 24;
            this.labelControl4.Text = "Nhà cung cấp:";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Location = new System.Drawing.Point(502, 46);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(56, 16);
            this.labelControl3.TabIndex = 23;
            this.labelControl3.Text = "Kho sách:";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(502, 86);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(55, 16);
            this.labelControl2.TabIndex = 22;
            this.labelControl2.Text = "Ngày tạo:";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(75, 8);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(89, 16);
            this.labelControl1.TabIndex = 21;
            this.labelControl1.Text = "Mã phiếu nhập:";
            // 
            // pnKhungThem
            // 
            this.pnKhungThem.Controls.Add(this.cmbKhoS);
            this.pnKhungThem.Controls.Add(this.cmbNCC);
            this.pnKhungThem.Controls.Add(this.cmbCanBo);
            this.pnKhungThem.Controls.Add(this.cmbTCNguonNhap);
            this.pnKhungThem.Controls.Add(this.datePickNgayTao);
            this.pnKhungThem.Controls.Add(this.labelControl1);
            this.pnKhungThem.Controls.Add(this.labelControl2);
            this.pnKhungThem.Controls.Add(this.dtpickNgayNhap);
            this.pnKhungThem.Controls.Add(this.labelControl3);
            this.pnKhungThem.Controls.Add(this.labelControl4);
            this.pnKhungThem.Controls.Add(this.labelControl5);
            this.pnKhungThem.Controls.Add(this.labelControl6);
            this.pnKhungThem.Controls.Add(this.labelControl7);
            this.pnKhungThem.Controls.Add(this.txtGhiChu);
            this.pnKhungThem.Controls.Add(this.labelControl8);
            this.pnKhungThem.Controls.Add(this.txtMaPhieuNhap);
            this.pnKhungThem.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnKhungThem.Location = new System.Drawing.Point(0, 0);
            this.pnKhungThem.Name = "pnKhungThem";
            this.pnKhungThem.Size = new System.Drawing.Size(995, 150);
            this.pnKhungThem.TabIndex = 37;
            this.pnKhungThem.Paint += new System.Windows.Forms.PaintEventHandler(this.pnKhungThem_Paint);
            // 
            // cmbKhoS
            // 
            this.cmbKhoS.FormattingEnabled = true;
            this.cmbKhoS.Location = new System.Drawing.Point(652, 45);
            this.cmbKhoS.Name = "cmbKhoS";
            this.cmbKhoS.Size = new System.Drawing.Size(168, 21);
            this.cmbKhoS.TabIndex = 45;
            // 
            // cmbNCC
            // 
            this.cmbNCC.FormattingEnabled = true;
            this.cmbNCC.Location = new System.Drawing.Point(652, 7);
            this.cmbNCC.Name = "cmbNCC";
            this.cmbNCC.Size = new System.Drawing.Size(168, 21);
            this.cmbNCC.TabIndex = 44;
            // 
            // cmbCanBo
            // 
            this.cmbCanBo.FormattingEnabled = true;
            this.cmbCanBo.Location = new System.Drawing.Point(224, 119);
            this.cmbCanBo.Name = "cmbCanBo";
            this.cmbCanBo.Size = new System.Drawing.Size(168, 21);
            this.cmbCanBo.TabIndex = 43;
            // 
            // cmbTCNguonNhap
            // 
            this.cmbTCNguonNhap.FormattingEnabled = true;
            this.cmbTCNguonNhap.Location = new System.Drawing.Point(225, 40);
            this.cmbTCNguonNhap.Name = "cmbTCNguonNhap";
            this.cmbTCNguonNhap.Size = new System.Drawing.Size(168, 21);
            this.cmbTCNguonNhap.TabIndex = 42;
            this.cmbTCNguonNhap.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // datePickNgayTao
            // 
            this.datePickNgayTao.CustomFormat = "dd/mm/yyyy";
            this.datePickNgayTao.Location = new System.Drawing.Point(651, 82);
            this.datePickNgayTao.Name = "datePickNgayTao";
            this.datePickNgayTao.Size = new System.Drawing.Size(169, 20);
            this.datePickNgayTao.TabIndex = 41;
            this.datePickNgayTao.Value = new System.DateTime(2013, 9, 17, 9, 45, 28, 0);
            // 
            // pnThaoTac
            // 
            this.pnThaoTac.Controls.Add(this.btnTaiLai);
            this.pnThaoTac.Controls.Add(this.btnXoa);
            this.pnThaoTac.Controls.Add(this.btnLuu);
            this.pnThaoTac.Controls.Add(this.btnSua);
            this.pnThaoTac.Controls.Add(this.btnThem);
            this.pnThaoTac.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnThaoTac.Location = new System.Drawing.Point(0, 150);
            this.pnThaoTac.Name = "pnThaoTac";
            this.pnThaoTac.Size = new System.Drawing.Size(995, 29);
            this.pnThaoTac.TabIndex = 38;
            this.pnThaoTac.Paint += new System.Windows.Forms.PaintEventHandler(this.panelControl1_Paint);
            // 
            // btnTaiLai
            // 
            this.btnTaiLai.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaiLai.Appearance.Options.UseFont = true;
            this.btnTaiLai.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnTaiLai.Location = new System.Drawing.Point(300, 2);
            this.btnTaiLai.Name = "btnTaiLai";
            this.btnTaiLai.Size = new System.Drawing.Size(75, 25);
            this.btnTaiLai.TabIndex = 12;
            this.btnTaiLai.Text = "Tải Lại";
            this.btnTaiLai.Click += new System.EventHandler(this.btnTaiLai_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Appearance.Options.UseFont = true;
            this.btnXoa.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnXoa.Location = new System.Drawing.Point(225, 2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 25);
            this.btnXoa.TabIndex = 11;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Appearance.Options.UseFont = true;
            this.btnLuu.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnLuu.Location = new System.Drawing.Point(150, 2);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 25);
            this.btnLuu.TabIndex = 10;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnSua
            // 
            this.btnSua.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Appearance.Options.UseFont = true;
            this.btnSua.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSua.Location = new System.Drawing.Point(75, 2);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 25);
            this.btnSua.TabIndex = 9;
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Appearance.Options.UseFont = true;
            this.btnThem.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnThem.Location = new System.Drawing.Point(2, 2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(73, 25);
            this.btnThem.TabIndex = 8;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // pnThongBao
            // 
            this.pnThongBao.BackColor = System.Drawing.Color.Blue;
            this.pnThongBao.Controls.Add(this.lbThongBao);
            this.pnThongBao.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.pnThongBao.Location = new System.Drawing.Point(0, 440);
            this.pnThongBao.Name = "pnThongBao";
            this.pnThongBao.Size = new System.Drawing.Size(998, 22);
            this.pnThongBao.TabIndex = 39;
            this.pnThongBao.Visible = false;
            // 
            // lbThongBao
            // 
            this.lbThongBao.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbThongBao.Appearance.ForeColor = System.Drawing.Color.White;
            this.lbThongBao.Location = new System.Drawing.Point(20, 3);
            this.lbThongBao.Name = "lbThongBao";
            this.lbThongBao.Size = new System.Drawing.Size(64, 16);
            this.lbThongBao.TabIndex = 5;
            this.lbThongBao.Text = "Phiếu Nhập";
            this.lbThongBao.Click += new System.EventHandler(this.lbThongBao_Click);
            // 
            // frmPhieuNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnThongBao);
            this.Controls.Add(this.pnThaoTac);
            this.Controls.Add(this.pnKhungThem);
            this.Controls.Add(this.gvPhieuNhap);
            this.Name = "frmPhieuNhap";
            this.Size = new System.Drawing.Size(995, 466);
            this.Load += new System.EventHandler(this.frmPhieuNhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvPhieuNhap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaPhieuNhap.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnKhungThem)).EndInit();
            this.pnKhungThem.ResumeLayout(false);
            this.pnKhungThem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnThaoTac)).EndInit();
            this.pnThaoTac.ResumeLayout(false);
            this.pnThongBao.ResumeLayout(false);
            this.pnThongBao.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gvPhieuNhap;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn clMaPN;
        private DevExpress.XtraGrid.Columns.GridColumn clMaPhieuNhap;
        private DevExpress.XtraGrid.Columns.GridColumn clTCNguonNhap;
        private DevExpress.XtraGrid.Views.Layout.LayoutView layoutView1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewCard layoutViewCard1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn clNgayNhap;
        private DevExpress.XtraGrid.Columns.GridColumn clNhanVien;
        private DevExpress.XtraGrid.Columns.GridColumn clNCC;
        private DevExpress.XtraGrid.Columns.GridColumn clKhoS;
        private DevExpress.XtraGrid.Columns.GridColumn clNgayTao;
        private DevExpress.XtraGrid.Columns.GridColumn clGhiChu;
        private System.Windows.Forms.DateTimePicker dtpickNgayNhap;
        private DevExpress.XtraEditors.TextEdit txtGhiChu;
        private DevExpress.XtraEditors.TextEdit txtMaPhieuNhap;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl pnKhungThem;
        private DevExpress.XtraEditors.PanelControl pnThaoTac;
        private DevExpress.XtraEditors.SimpleButton btnTaiLai;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private DevExpress.XtraEditors.SimpleButton btnSua;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private System.Windows.Forms.Panel pnThongBao;
        private DevExpress.XtraEditors.LabelControl lbThongBao;
        private System.Windows.Forms.DateTimePicker datePickNgayTao;
        private System.Windows.Forms.ComboBox cmbTCNguonNhap;
        private System.Windows.Forms.ComboBox cmbKhoS;
        private System.Windows.Forms.ComboBox cmbNCC;
        private System.Windows.Forms.ComboBox cmbCanBo;
    }
}
