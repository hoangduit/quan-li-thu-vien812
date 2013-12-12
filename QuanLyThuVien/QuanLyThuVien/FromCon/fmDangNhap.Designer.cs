namespace QuanLyThuVien.ChuongTrinh
{
    partial class fmDangNhap
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.bntDN = new DevExpress.XtraEditors.SimpleButton();
            this.bntThoat = new DevExpress.XtraEditors.SimpleButton();
            this.txtMK = new DevExpress.XtraEditors.TextEdit();
            this.txtTK = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.lbThongBao = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMK.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTK.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.bntDN);
            this.groupControl1.Controls.Add(this.bntThoat);
            this.groupControl1.Controls.Add(this.txtMK);
            this.groupControl1.Controls.Add(this.txtTK);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.lbThongBao);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.pictureEdit1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(363, 183);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Đăng Nhập";
            // 
            // bntDN
            // 
            this.bntDN.Location = new System.Drawing.Point(182, 149);
            this.bntDN.Name = "bntDN";
            this.bntDN.Size = new System.Drawing.Size(75, 23);
            this.bntDN.TabIndex = 6;
            this.bntDN.Text = "Đăng Nhập";
            this.bntDN.Click += new System.EventHandler(this.bntDN_Click);
            // 
            // bntThoat
            // 
            this.bntThoat.Location = new System.Drawing.Point(276, 149);
            this.bntThoat.Name = "bntThoat";
            this.bntThoat.Size = new System.Drawing.Size(75, 23);
            this.bntThoat.TabIndex = 5;
            this.bntThoat.Text = "Thoát";
            this.bntThoat.Click += new System.EventHandler(this.bntThoat_Click);
            // 
            // txtMK
            // 
            this.txtMK.Location = new System.Drawing.Point(182, 120);
            this.txtMK.Name = "txtMK";
            this.txtMK.Properties.PasswordChar = '*';
            this.txtMK.Size = new System.Drawing.Size(169, 20);
            this.txtMK.TabIndex = 4;
            // 
            // txtTK
            // 
            this.txtTK.Location = new System.Drawing.Point(182, 68);
            this.txtTK.Name = "txtTK";
            this.txtTK.Size = new System.Drawing.Size(169, 20);
            this.txtTK.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(155, 100);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(53, 16);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Mật Khẩu";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(155, 46);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(57, 16);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Tài Khoản";
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = global::QuanLyThuVien.Properties.Resources.dangnhap;
            this.pictureEdit1.Location = new System.Drawing.Point(12, 24);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.pictureEdit1.Size = new System.Drawing.Size(120, 148);
            this.pictureEdit1.TabIndex = 0;
            // 
            // lbThongBao
            // 
            this.lbThongBao.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lbThongBao.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbThongBao.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lbThongBao.Location = new System.Drawing.Point(155, 27);
            this.lbThongBao.Name = "lbThongBao";
            this.lbThongBao.Size = new System.Drawing.Size(57, 16);
            this.lbThongBao.TabIndex = 1;
            this.lbThongBao.Text = "Tài Khoản";
            // 
            // fmDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 183);
            this.Controls.Add(this.groupControl1);
            this.Name = "fmDangNhap";
            this.Text = "fmDangNhap";
            this.Load += new System.EventHandler(this.fmDangNhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMK.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTK.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton bntDN;
        private DevExpress.XtraEditors.SimpleButton bntThoat;
        private DevExpress.XtraEditors.TextEdit txtMK;
        private DevExpress.XtraEditors.TextEdit txtTK;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.LabelControl lbThongBao;
    }
}