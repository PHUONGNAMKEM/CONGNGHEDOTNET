namespace DEAN_SQL
{
    partial class frmNhapHang
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
            this.components = new System.ComponentModel.Container();
            this.panelMainDesktop = new System.Windows.Forms.Panel();
            this.panelButtonBanHang = new System.Windows.Forms.Panel();
            this.lstbanhang = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelbanhang = new System.Windows.Forms.Panel();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lbltonghoadon = new System.Windows.Forms.Label();
            this.lbltongtien = new System.Windows.Forms.Label();
            this.btnhuy = new System.Windows.Forms.Button();
            this.btnluuphieunhap = new System.Windows.Forms.Button();
            this.panelkhachhang = new System.Windows.Forms.Panel();
            this.txtsl = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboncc = new System.Windows.Forms.ComboBox();
            this.txtmasp = new System.Windows.Forms.TextBox();
            this.txtmapn = new System.Windows.Forms.TextBox();
            this.lblmasp = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtngaynhap = new System.Windows.Forms.TextBox();
            this.btntaophieunhap = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.flowLayoutPanelProducts = new System.Windows.Forms.FlowLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xóaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sữaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelMainDesktop.SuspendLayout();
            this.panelButtonBanHang.SuspendLayout();
            this.panelbanhang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panelkhachhang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel5.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMainDesktop
            // 
            this.panelMainDesktop.Controls.Add(this.panelButtonBanHang);
            this.panelMainDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainDesktop.Location = new System.Drawing.Point(0, 0);
            this.panelMainDesktop.Margin = new System.Windows.Forms.Padding(2);
            this.panelMainDesktop.Name = "panelMainDesktop";
            this.panelMainDesktop.Size = new System.Drawing.Size(1924, 1055);
            this.panelMainDesktop.TabIndex = 28;
            // 
            // panelButtonBanHang
            // 
            this.panelButtonBanHang.Controls.Add(this.lstbanhang);
            this.panelButtonBanHang.Controls.Add(this.panelbanhang);
            this.panelButtonBanHang.Controls.Add(this.panelkhachhang);
            this.panelButtonBanHang.Controls.Add(this.flowLayoutPanelProducts);
            this.panelButtonBanHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelButtonBanHang.Location = new System.Drawing.Point(0, 0);
            this.panelButtonBanHang.Margin = new System.Windows.Forms.Padding(2);
            this.panelButtonBanHang.Name = "panelButtonBanHang";
            this.panelButtonBanHang.Size = new System.Drawing.Size(1924, 1055);
            this.panelButtonBanHang.TabIndex = 0;
            this.panelButtonBanHang.Paint += new System.Windows.Forms.PaintEventHandler(this.panelButtonBanHang_Paint);
            // 
            // lstbanhang
            // 
            this.lstbanhang.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader11,
            this.columnHeader12});
            this.lstbanhang.FullRowSelect = true;
            this.lstbanhang.GridLines = true;
            this.lstbanhang.HideSelection = false;
            this.lstbanhang.Location = new System.Drawing.Point(67, 307);
            this.lstbanhang.Name = "lstbanhang";
            this.lstbanhang.Size = new System.Drawing.Size(751, 466);
            this.lstbanhang.TabIndex = 46;
            this.lstbanhang.UseCompatibleStateImageBehavior = false;
            this.lstbanhang.View = System.Windows.Forms.View.Details;
            this.lstbanhang.Click += new System.EventHandler(this.lstbanhang_Click);
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Mã NL";
            this.columnHeader7.Width = 90;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Tên NL";
            this.columnHeader8.Width = 90;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Đơn giá";
            this.columnHeader9.Width = 90;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Số lượng";
            this.columnHeader11.Width = 90;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Tổng";
            this.columnHeader12.Width = 90;
            // 
            // panelbanhang
            // 
            this.panelbanhang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelbanhang.Controls.Add(this.pictureBox6);
            this.panelbanhang.Controls.Add(this.pictureBox3);
            this.panelbanhang.Controls.Add(this.lbltonghoadon);
            this.panelbanhang.Controls.Add(this.lbltongtien);
            this.panelbanhang.Controls.Add(this.btnhuy);
            this.panelbanhang.Controls.Add(this.btnluuphieunhap);
            this.panelbanhang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelbanhang.Location = new System.Drawing.Point(833, 81);
            this.panelbanhang.Name = "panelbanhang";
            this.panelbanhang.Size = new System.Drawing.Size(688, 220);
            this.panelbanhang.TabIndex = 41;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::DEAN_SQL.Properties.Resources.cross;
            this.pictureBox6.Location = new System.Drawing.Point(506, 115);
            this.pictureBox6.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(59, 42);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 40;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DEAN_SQL.Properties.Resources.check__1_;
            this.pictureBox3.Location = new System.Drawing.Point(256, 115);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(59, 42);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 31;
            this.pictureBox3.TabStop = false;
            // 
            // lbltonghoadon
            // 
            this.lbltonghoadon.AutoSize = true;
            this.lbltonghoadon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltonghoadon.Location = new System.Drawing.Point(77, 78);
            this.lbltonghoadon.Name = "lbltonghoadon";
            this.lbltonghoadon.Size = new System.Drawing.Size(153, 25);
            this.lbltonghoadon.TabIndex = 30;
            this.lbltonghoadon.Text = "Tổng hóa đơn:";
            // 
            // lbltongtien
            // 
            this.lbltongtien.AutoSize = true;
            this.lbltongtien.Location = new System.Drawing.Point(261, 78);
            this.lbltongtien.Name = "lbltongtien";
            this.lbltongtien.Size = new System.Drawing.Size(0, 25);
            this.lbltongtien.TabIndex = 39;
            // 
            // btnhuy
            // 
            this.btnhuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(72)))), ((int)(((byte)(80)))));
            this.btnhuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnhuy.ForeColor = System.Drawing.Color.White;
            this.btnhuy.Location = new System.Drawing.Point(340, 115);
            this.btnhuy.Name = "btnhuy";
            this.btnhuy.Size = new System.Drawing.Size(169, 42);
            this.btnhuy.TabIndex = 38;
            this.btnhuy.Text = "Hủy";
            this.btnhuy.UseVisualStyleBackColor = false;
            this.btnhuy.Click += new System.EventHandler(this.btnhuy_Click);
            // 
            // btnluuphieunhap
            // 
            this.btnluuphieunhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(182)))), ((int)(((byte)(120)))));
            this.btnluuphieunhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnluuphieunhap.ForeColor = System.Drawing.Color.White;
            this.btnluuphieunhap.Location = new System.Drawing.Point(78, 115);
            this.btnluuphieunhap.Name = "btnluuphieunhap";
            this.btnluuphieunhap.Size = new System.Drawing.Size(179, 42);
            this.btnluuphieunhap.TabIndex = 37;
            this.btnluuphieunhap.Text = "Lưu phiếu nhập";
            this.btnluuphieunhap.UseVisualStyleBackColor = false;
            this.btnluuphieunhap.Click += new System.EventHandler(this.btnluuhoadon_Click);
            // 
            // panelkhachhang
            // 
            this.panelkhachhang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelkhachhang.Controls.Add(this.txtsl);
            this.panelkhachhang.Controls.Add(this.label2);
            this.panelkhachhang.Controls.Add(this.cboncc);
            this.panelkhachhang.Controls.Add(this.txtmasp);
            this.panelkhachhang.Controls.Add(this.txtmapn);
            this.panelkhachhang.Controls.Add(this.lblmasp);
            this.panelkhachhang.Controls.Add(this.pictureBox1);
            this.panelkhachhang.Controls.Add(this.label1);
            this.panelkhachhang.Controls.Add(this.txtngaynhap);
            this.panelkhachhang.Controls.Add(this.btntaophieunhap);
            this.panelkhachhang.Controls.Add(this.label7);
            this.panelkhachhang.Controls.Add(this.label6);
            this.panelkhachhang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelkhachhang.Location = new System.Drawing.Point(67, 81);
            this.panelkhachhang.Name = "panelkhachhang";
            this.panelkhachhang.Size = new System.Drawing.Size(751, 220);
            this.panelkhachhang.TabIndex = 45;
            this.panelkhachhang.Paint += new System.Windows.Forms.PaintEventHandler(this.panelkhachhang_Paint);
            // 
            // txtsl
            // 
            this.txtsl.Location = new System.Drawing.Point(216, 127);
            this.txtsl.Name = "txtsl";
            this.txtsl.Size = new System.Drawing.Size(59, 30);
            this.txtsl.TabIndex = 55;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 25);
            this.label2.TabIndex = 54;
            this.label2.Text = "Số lượng sản phẩm";
            // 
            // cboncc
            // 
            this.cboncc.FormattingEnabled = true;
            this.cboncc.Location = new System.Drawing.Point(216, 51);
            this.cboncc.Name = "cboncc";
            this.cboncc.Size = new System.Drawing.Size(332, 33);
            this.cboncc.TabIndex = 47;
            // 
            // txtmasp
            // 
            this.txtmasp.Location = new System.Drawing.Point(489, 130);
            this.txtmasp.Name = "txtmasp";
            this.txtmasp.ReadOnly = true;
            this.txtmasp.Size = new System.Drawing.Size(59, 30);
            this.txtmasp.TabIndex = 53;
            // 
            // txtmapn
            // 
            this.txtmapn.Location = new System.Drawing.Point(216, 14);
            this.txtmapn.Name = "txtmapn";
            this.txtmapn.Size = new System.Drawing.Size(332, 30);
            this.txtmapn.TabIndex = 46;
            // 
            // lblmasp
            // 
            this.lblmasp.AutoSize = true;
            this.lblmasp.Location = new System.Drawing.Point(338, 132);
            this.lblmasp.Name = "lblmasp";
            this.lblmasp.Size = new System.Drawing.Size(131, 25);
            this.lblmasp.TabIndex = 52;
            this.lblmasp.Text = "Mã sản phẩm";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DEAN_SQL.Properties.Resources.check__1_;
            this.pictureBox1.Location = new System.Drawing.Point(208, 160);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(67, 42);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 43;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 25);
            this.label1.TabIndex = 45;
            this.label1.Text = "Mã phiếu nhập";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtngaynhap
            // 
            this.txtngaynhap.Location = new System.Drawing.Point(216, 91);
            this.txtngaynhap.Name = "txtngaynhap";
            this.txtngaynhap.Size = new System.Drawing.Size(332, 30);
            this.txtngaynhap.TabIndex = 4;
            // 
            // btntaophieunhap
            // 
            this.btntaophieunhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(182)))), ((int)(((byte)(120)))));
            this.btntaophieunhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btntaophieunhap.ForeColor = System.Drawing.Color.White;
            this.btntaophieunhap.Location = new System.Drawing.Point(25, 160);
            this.btntaophieunhap.Name = "btntaophieunhap";
            this.btntaophieunhap.Size = new System.Drawing.Size(186, 42);
            this.btntaophieunhap.TabIndex = 44;
            this.btntaophieunhap.Text = "Tạo phiếu nhập";
            this.btntaophieunhap.UseVisualStyleBackColor = false;
            this.btntaophieunhap.Click += new System.EventHandler(this.btntaohoadon_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 25);
            this.label7.TabIndex = 1;
            this.label7.Text = "Ngày nhập";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 25);
            this.label6.TabIndex = 0;
            this.label6.Text = "Nhà cung cấp";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // flowLayoutPanelProducts
            // 
            this.flowLayoutPanelProducts.AutoScroll = true;
            this.flowLayoutPanelProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanelProducts.Location = new System.Drawing.Point(833, 307);
            this.flowLayoutPanelProducts.Name = "flowLayoutPanelProducts";
            this.flowLayoutPanelProducts.Size = new System.Drawing.Size(688, 466);
            this.flowLayoutPanelProducts.TabIndex = 29;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panelMainDesktop);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1924, 1055);
            this.panel5.TabIndex = 29;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xóaToolStripMenuItem,
            this.sữaToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(105, 52);
            // 
            // xóaToolStripMenuItem
            // 
            this.xóaToolStripMenuItem.Name = "xóaToolStripMenuItem";
            this.xóaToolStripMenuItem.Size = new System.Drawing.Size(104, 24);
            this.xóaToolStripMenuItem.Text = "Xóa";
            this.xóaToolStripMenuItem.Click += new System.EventHandler(this.xóaToolStripMenuItem_Click);
            // 
            // sữaToolStripMenuItem
            // 
            this.sữaToolStripMenuItem.Name = "sữaToolStripMenuItem";
            this.sữaToolStripMenuItem.Size = new System.Drawing.Size(104, 24);
            this.sữaToolStripMenuItem.Text = "Sữa";
            this.sữaToolStripMenuItem.Click += new System.EventHandler(this.sữaToolStripMenuItem_Click);
            // 
            // frmNhapHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.panel5);
            this.Name = "frmNhapHang";
            this.Text = "frmNhapHang";
            this.Load += new System.EventHandler(this.frmNhapHang_Load);
            this.panelMainDesktop.ResumeLayout(false);
            this.panelButtonBanHang.ResumeLayout(false);
            this.panelbanhang.ResumeLayout(false);
            this.panelbanhang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panelkhachhang.ResumeLayout(false);
            this.panelkhachhang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel5.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMainDesktop;
        private System.Windows.Forms.Panel panelButtonBanHang;
        private System.Windows.Forms.ListView lstbanhang;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.Panel panelkhachhang;
        private System.Windows.Forms.TextBox txtngaynhap;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelProducts;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btntaophieunhap;
        private System.Windows.Forms.TextBox txtmapn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboncc;
        private System.Windows.Forms.Panel panelbanhang;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lbltonghoadon;
        private System.Windows.Forms.Label lbltongtien;
        private System.Windows.Forms.Button btnhuy;
        private System.Windows.Forms.Button btnluuphieunhap;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem xóaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sữaToolStripMenuItem;
        private System.Windows.Forms.TextBox txtsl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtmasp;
        private System.Windows.Forms.Label lblmasp;
    }
}