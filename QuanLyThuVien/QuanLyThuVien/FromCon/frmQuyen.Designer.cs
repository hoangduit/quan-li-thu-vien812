﻿namespace QuanLyThuVien.FromCon
{
    partial class frmQuyen
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
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.bntThem = new DevExpress.XtraEditors.SimpleButton();
            this.bntTaiLai = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.cbAdmin = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtTenQ = new DevExpress.XtraEditors.TextEdit();
            this.pnThongBao = new System.Windows.Forms.Panel();
            this.lbThongBao = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbAdmin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenQ.Properties)).BeginInit();
            this.pnThongBao.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.bntThem);
            this.panelControl2.Controls.Add(this.bntTaiLai);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 62);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(329, 29);
            this.panelControl2.TabIndex = 13;
            this.panelControl2.Paint += new System.Windows.Forms.PaintEventHandler(this.panelControl2_Paint);
            // 
            // bntThem
            // 
            this.bntThem.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntThem.Appearance.Options.UseFont = true;
            this.bntThem.Dock = System.Windows.Forms.DockStyle.Right;
            this.bntThem.Location = new System.Drawing.Point(173, 2);
            this.bntThem.Name = "bntThem";
            this.bntThem.Size = new System.Drawing.Size(79, 25);
            this.bntThem.TabIndex = 7;
            this.bntThem.Text = "Thêm";
            this.bntThem.Click += new System.EventHandler(this.bntThem_Click);
            // 
            // bntTaiLai
            // 
            this.bntTaiLai.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntTaiLai.Appearance.Options.UseFont = true;
            this.bntTaiLai.Dock = System.Windows.Forms.DockStyle.Right;
            this.bntTaiLai.Location = new System.Drawing.Point(252, 2);
            this.bntTaiLai.Name = "bntTaiLai";
            this.bntTaiLai.Size = new System.Drawing.Size(75, 25);
            this.bntTaiLai.TabIndex = 1;
            this.bntTaiLai.Text = "Thoát";
            this.bntTaiLai.Click += new System.EventHandler(this.bntTaiLai_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.cbAdmin);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.txtTenQ);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(329, 62);
            this.panelControl1.TabIndex = 12;
            this.panelControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.panelControl1_Paint);
            // 
            // cbAdmin
            // 
            this.cbAdmin.Location = new System.Drawing.Point(258, 26);
            this.cbAdmin.Name = "cbAdmin";
            this.cbAdmin.Properties.Caption = "Admin";
            this.cbAdmin.Size = new System.Drawing.Size(58, 19);
            this.cbAdmin.TabIndex = 15;
            this.cbAdmin.CheckedChanged += new System.EventHandler(this.cbAdmin_CheckedChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(20, 29);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 16);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "Tên quyền";
            this.labelControl1.Click += new System.EventHandler(this.labelControl1_Click);
            // 
            // txtTenQ
            // 
            this.txtTenQ.Location = new System.Drawing.Point(96, 25);
            this.txtTenQ.Name = "txtTenQ";
            this.txtTenQ.Size = new System.Drawing.Size(156, 20);
            this.txtTenQ.TabIndex = 5;
            this.txtTenQ.EditValueChanged += new System.EventHandler(this.txtTenQ_EditValueChanged);
            // 
            // pnThongBao
            // 
            this.pnThongBao.BackColor = System.Drawing.Color.Blue;
            this.pnThongBao.Controls.Add(this.lbThongBao);
            this.pnThongBao.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnThongBao.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.pnThongBao.Location = new System.Drawing.Point(0, 89);
            this.pnThongBao.Name = "pnThongBao";
            this.pnThongBao.Size = new System.Drawing.Size(329, 22);
            this.pnThongBao.TabIndex = 14;
            this.pnThongBao.Visible = false;
            this.pnThongBao.Paint += new System.Windows.Forms.PaintEventHandler(this.pnThongBao_Paint);
            // 
            // lbThongBao
            // 
            this.lbThongBao.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbThongBao.Appearance.ForeColor = System.Drawing.Color.White;
            this.lbThongBao.Location = new System.Drawing.Point(20, 3);
            this.lbThongBao.Name = "lbThongBao";
            this.lbThongBao.Size = new System.Drawing.Size(61, 16);
            this.lbThongBao.TabIndex = 5;
            this.lbThongBao.Text = "Chúc Danh";
            this.lbThongBao.Click += new System.EventHandler(this.lbThongBao_Click);
            // 
            // frmQuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 111);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.pnThongBao);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmQuyen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmQuyen";
            this.Load += new System.EventHandler(this.frmQuyen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbAdmin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenQ.Properties)).EndInit();
            this.pnThongBao.ResumeLayout(false);
            this.pnThongBao.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton bntThem;
        private DevExpress.XtraEditors.SimpleButton bntTaiLai;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtTenQ;
        private System.Windows.Forms.Panel pnThongBao;
        private DevExpress.XtraEditors.LabelControl lbThongBao;
        private DevExpress.XtraEditors.CheckEdit cbAdmin;
    }
}