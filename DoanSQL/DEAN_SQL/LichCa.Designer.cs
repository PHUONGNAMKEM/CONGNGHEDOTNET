namespace DEAN_SQL
{
    partial class LichCa
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
            this.btnclear = new System.Windows.Forms.Button();
            this.btnsua = new System.Windows.Forms.Button();
            this.btnxoa = new System.Windows.Forms.Button();
            this.btnthem = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.grpnhapthongtinlichca = new System.Windows.Forms.GroupBox();
            this.txttenca = new System.Windows.Forms.TextBox();
            this.txtmaca = new System.Windows.Forms.TextBox();
            this.txttgkt = new System.Windows.Forms.TextBox();
            this.txttgbd = new System.Windows.Forms.TextBox();
            this.lbltgkt = new System.Windows.Forms.Label();
            this.lbltenca = new System.Windows.Forms.Label();
            this.lbltgbd = new System.Windows.Forms.Label();
            this.lblmaca = new System.Windows.Forms.Label();
            this.grpthongtinlichca = new System.Windows.Forms.GroupBox();
            this.lst_dl = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpnhapthongtinlichca.SuspendLayout();
            this.grpthongtinlichca.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnclear
            // 
            this.btnclear.Location = new System.Drawing.Point(699, 281);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(146, 46);
            this.btnclear.TabIndex = 28;
            this.btnclear.Text = "Mới";
            this.btnclear.UseVisualStyleBackColor = true;
            this.btnclear.Click += new System.EventHandler(this.btnclear_Click);
            // 
            // btnsua
            // 
            this.btnsua.Location = new System.Drawing.Point(493, 281);
            this.btnsua.Name = "btnsua";
            this.btnsua.Size = new System.Drawing.Size(146, 46);
            this.btnsua.TabIndex = 27;
            this.btnsua.Text = "Sửa";
            this.btnsua.UseVisualStyleBackColor = true;
            this.btnsua.Click += new System.EventHandler(this.btnsua_Click);
            // 
            // btnxoa
            // 
            this.btnxoa.Location = new System.Drawing.Point(291, 281);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(146, 46);
            this.btnxoa.TabIndex = 26;
            this.btnxoa.Text = "Xóa";
            this.btnxoa.UseVisualStyleBackColor = true;
            this.btnxoa.Click += new System.EventHandler(this.btnxoa_Click);
            // 
            // btnthem
            // 
            this.btnthem.Location = new System.Drawing.Point(89, 281);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(146, 46);
            this.btnthem.TabIndex = 25;
            this.btnthem.Text = "Thêm";
            this.btnthem.UseVisualStyleBackColor = true;
            this.btnthem.Click += new System.EventHandler(this.btnthem_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(436, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 29);
            this.label5.TabIndex = 24;
            this.label5.Text = "APP";
            // 
            // grpnhapthongtinlichca
            // 
            this.grpnhapthongtinlichca.Controls.Add(this.txttenca);
            this.grpnhapthongtinlichca.Controls.Add(this.txtmaca);
            this.grpnhapthongtinlichca.Controls.Add(this.txttgkt);
            this.grpnhapthongtinlichca.Controls.Add(this.txttgbd);
            this.grpnhapthongtinlichca.Controls.Add(this.lbltgkt);
            this.grpnhapthongtinlichca.Controls.Add(this.lbltenca);
            this.grpnhapthongtinlichca.Controls.Add(this.lbltgbd);
            this.grpnhapthongtinlichca.Controls.Add(this.lblmaca);
            this.grpnhapthongtinlichca.Location = new System.Drawing.Point(89, 66);
            this.grpnhapthongtinlichca.Name = "grpnhapthongtinlichca";
            this.grpnhapthongtinlichca.Size = new System.Drawing.Size(756, 201);
            this.grpnhapthongtinlichca.TabIndex = 23;
            this.grpnhapthongtinlichca.TabStop = false;
            this.grpnhapthongtinlichca.Text = "Nhập thông tin lịch ca";
            // 
            // txttenca
            // 
            this.txttenca.Location = new System.Drawing.Point(467, 43);
            this.txttenca.Name = "txttenca";
            this.txttenca.Size = new System.Drawing.Size(230, 22);
            this.txttenca.TabIndex = 11;
            // 
            // txtmaca
            // 
            this.txtmaca.Location = new System.Drawing.Point(133, 43);
            this.txtmaca.Name = "txtmaca";
            this.txtmaca.ReadOnly = true;
            this.txtmaca.Size = new System.Drawing.Size(215, 22);
            this.txtmaca.TabIndex = 10;
            // 
            // txttgkt
            // 
            this.txttgkt.Location = new System.Drawing.Point(467, 119);
            this.txttgkt.Name = "txttgkt";
            this.txttgkt.Size = new System.Drawing.Size(230, 22);
            this.txttgkt.TabIndex = 7;
            // 
            // txttgbd
            // 
            this.txttgbd.Location = new System.Drawing.Point(133, 125);
            this.txttgbd.Name = "txttgbd";
            this.txttgbd.Size = new System.Drawing.Size(215, 22);
            this.txttgbd.TabIndex = 5;
            // 
            // lbltgkt
            // 
            this.lbltgkt.AutoSize = true;
            this.lbltgkt.Location = new System.Drawing.Point(397, 124);
            this.lbltgkt.Name = "lbltgkt";
            this.lbltgkt.Size = new System.Drawing.Size(46, 16);
            this.lbltgkt.TabIndex = 3;
            this.lbltgkt.Text = "TGKT:";
            // 
            // lbltenca
            // 
            this.lbltenca.AutoSize = true;
            this.lbltenca.Location = new System.Drawing.Point(397, 46);
            this.lbltenca.Name = "lbltenca";
            this.lbltenca.Size = new System.Drawing.Size(52, 16);
            this.lbltenca.TabIndex = 2;
            this.lbltenca.Text = "TenCA:";
            this.lbltenca.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbltgbd
            // 
            this.lbltgbd.AutoSize = true;
            this.lbltgbd.Location = new System.Drawing.Point(58, 128);
            this.lbltgbd.Name = "lbltgbd";
            this.lbltgbd.Size = new System.Drawing.Size(48, 16);
            this.lbltgbd.TabIndex = 1;
            this.lbltgbd.Text = "TGBD:";
            // 
            // lblmaca
            // 
            this.lblmaca.AutoSize = true;
            this.lblmaca.Location = new System.Drawing.Point(58, 46);
            this.lblmaca.Name = "lblmaca";
            this.lblmaca.Size = new System.Drawing.Size(47, 16);
            this.lblmaca.TabIndex = 0;
            this.lblmaca.Text = "MaCA:";
            // 
            // grpthongtinlichca
            // 
            this.grpthongtinlichca.Controls.Add(this.lst_dl);
            this.grpthongtinlichca.Location = new System.Drawing.Point(89, 333);
            this.grpthongtinlichca.Name = "grpthongtinlichca";
            this.grpthongtinlichca.Size = new System.Drawing.Size(756, 212);
            this.grpthongtinlichca.TabIndex = 22;
            this.grpthongtinlichca.TabStop = false;
            this.grpthongtinlichca.Text = "Thông tin lịch ca";
            // 
            // lst_dl
            // 
            this.lst_dl.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lst_dl.FullRowSelect = true;
            this.lst_dl.GridLines = true;
            this.lst_dl.HideSelection = false;
            this.lst_dl.Location = new System.Drawing.Point(61, 39);
            this.lst_dl.Name = "lst_dl";
            this.lst_dl.Size = new System.Drawing.Size(636, 148);
            this.lst_dl.TabIndex = 0;
            this.lst_dl.UseCompatibleStateImageBehavior = false;
            this.lst_dl.View = System.Windows.Forms.View.Details;
            this.lst_dl.SelectedIndexChanged += new System.EventHandler(this.lst_dl_SelectedIndexChanged);
            this.lst_dl.Click += new System.EventHandler(this.lst_dl_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "MACA";
            this.columnHeader1.Width = 90;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "TENCA";
            this.columnHeader2.Width = 90;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "TGBD";
            this.columnHeader3.Width = 90;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "TGKT";
            this.columnHeader4.Width = 90;
            // 
            // LichCa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 562);
            this.Controls.Add(this.btnclear);
            this.Controls.Add(this.btnsua);
            this.Controls.Add(this.btnxoa);
            this.Controls.Add(this.btnthem);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.grpnhapthongtinlichca);
            this.Controls.Add(this.grpthongtinlichca);
            this.Name = "LichCa";
            this.Text = "LichCa";
            this.Load += new System.EventHandler(this.LichCa_Load);
            this.grpnhapthongtinlichca.ResumeLayout(false);
            this.grpnhapthongtinlichca.PerformLayout();
            this.grpthongtinlichca.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnclear;
        private System.Windows.Forms.Button btnsua;
        private System.Windows.Forms.Button btnxoa;
        private System.Windows.Forms.Button btnthem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox grpnhapthongtinlichca;
        private System.Windows.Forms.TextBox txttenca;
        private System.Windows.Forms.TextBox txtmaca;
        private System.Windows.Forms.TextBox txttgkt;
        private System.Windows.Forms.TextBox txttgbd;
        private System.Windows.Forms.Label lbltgkt;
        private System.Windows.Forms.Label lbltenca;
        private System.Windows.Forms.Label lbltgbd;
        private System.Windows.Forms.Label lblmaca;
        private System.Windows.Forms.GroupBox grpthongtinlichca;
        private System.Windows.Forms.ListView lst_dl;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}