namespace DEAN_SQL
{
    partial class LichTruc
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
            this.grpnhapthongtinlichtruc = new System.Windows.Forms.GroupBox();
            this.cbomaca = new System.Windows.Forms.ComboBox();
            this.cbomanv = new System.Windows.Forms.ComboBox();
            this.txtngaytruc = new System.Windows.Forms.TextBox();
            this.lblmaca = new System.Windows.Forms.Label();
            this.lblsoluong = new System.Windows.Forms.Label();
            this.lblmanv = new System.Windows.Forms.Label();
            this.grpthongtinlichtruc = new System.Windows.Forms.GroupBox();
            this.lst_dl = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpnhapthongtinlichtruc.SuspendLayout();
            this.grpthongtinlichtruc.SuspendLayout();
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
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // grpnhapthongtinlichtruc
            // 
            this.grpnhapthongtinlichtruc.Controls.Add(this.cbomaca);
            this.grpnhapthongtinlichtruc.Controls.Add(this.cbomanv);
            this.grpnhapthongtinlichtruc.Controls.Add(this.txtngaytruc);
            this.grpnhapthongtinlichtruc.Controls.Add(this.lblmaca);
            this.grpnhapthongtinlichtruc.Controls.Add(this.lblsoluong);
            this.grpnhapthongtinlichtruc.Controls.Add(this.lblmanv);
            this.grpnhapthongtinlichtruc.Location = new System.Drawing.Point(89, 66);
            this.grpnhapthongtinlichtruc.Name = "grpnhapthongtinlichtruc";
            this.grpnhapthongtinlichtruc.Size = new System.Drawing.Size(756, 201);
            this.grpnhapthongtinlichtruc.TabIndex = 23;
            this.grpnhapthongtinlichtruc.TabStop = false;
            this.grpnhapthongtinlichtruc.Text = "Nhập thông tin lịch trực";
            this.grpnhapthongtinlichtruc.Enter += new System.EventHandler(this.grpnhapthongtinlichtruc_Enter);
            // 
            // cbomaca
            // 
            this.cbomaca.FormattingEnabled = true;
            this.cbomaca.Location = new System.Drawing.Point(467, 43);
            this.cbomaca.Name = "cbomaca";
            this.cbomaca.Size = new System.Drawing.Size(230, 24);
            this.cbomaca.TabIndex = 9;
            // 
            // cbomanv
            // 
            this.cbomanv.FormattingEnabled = true;
            this.cbomanv.Location = new System.Drawing.Point(133, 43);
            this.cbomanv.Name = "cbomanv";
            this.cbomanv.Size = new System.Drawing.Size(215, 24);
            this.cbomanv.TabIndex = 8;
            // 
            // txtngaytruc
            // 
            this.txtngaytruc.Location = new System.Drawing.Point(133, 125);
            this.txtngaytruc.Name = "txtngaytruc";
            this.txtngaytruc.Size = new System.Drawing.Size(215, 22);
            this.txtngaytruc.TabIndex = 5;
            // 
            // lblmaca
            // 
            this.lblmaca.AutoSize = true;
            this.lblmaca.Location = new System.Drawing.Point(397, 46);
            this.lblmaca.Name = "lblmaca";
            this.lblmaca.Size = new System.Drawing.Size(47, 16);
            this.lblmaca.TabIndex = 2;
            this.lblmaca.Text = "MaCA:";
            this.lblmaca.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblsoluong
            // 
            this.lblsoluong.AutoSize = true;
            this.lblsoluong.Location = new System.Drawing.Point(58, 128);
            this.lblsoluong.Name = "lblsoluong";
            this.lblsoluong.Size = new System.Drawing.Size(70, 16);
            this.lblsoluong.TabIndex = 1;
            this.lblsoluong.Text = "NgayTruc:";
            // 
            // lblmanv
            // 
            this.lblmanv.AutoSize = true;
            this.lblmanv.Location = new System.Drawing.Point(58, 46);
            this.lblmanv.Name = "lblmanv";
            this.lblmanv.Size = new System.Drawing.Size(48, 16);
            this.lblmanv.TabIndex = 0;
            this.lblmanv.Text = "MaNV:";
            // 
            // grpthongtinlichtruc
            // 
            this.grpthongtinlichtruc.Controls.Add(this.lst_dl);
            this.grpthongtinlichtruc.Location = new System.Drawing.Point(89, 333);
            this.grpthongtinlichtruc.Name = "grpthongtinlichtruc";
            this.grpthongtinlichtruc.Size = new System.Drawing.Size(756, 212);
            this.grpthongtinlichtruc.TabIndex = 22;
            this.grpthongtinlichtruc.TabStop = false;
            this.grpthongtinlichtruc.Text = "Thông tin lịch trực";
            this.grpthongtinlichtruc.Enter += new System.EventHandler(this.grpthongtinlichtruc_Enter);
            // 
            // lst_dl
            // 
            this.lst_dl.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lst_dl.FullRowSelect = true;
            this.lst_dl.GridLines = true;
            this.lst_dl.HideSelection = false;
            this.lst_dl.Location = new System.Drawing.Point(61, 39);
            this.lst_dl.Name = "lst_dl";
            this.lst_dl.Size = new System.Drawing.Size(636, 148);
            this.lst_dl.TabIndex = 0;
            this.lst_dl.UseCompatibleStateImageBehavior = false;
            this.lst_dl.View = System.Windows.Forms.View.Details;
            this.lst_dl.Click += new System.EventHandler(this.lst_dl_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "MANV";
            this.columnHeader1.Width = 90;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "MACA";
            this.columnHeader2.Width = 90;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "NGAYTRUC";
            this.columnHeader3.Width = 90;
            // 
            // LichTruc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 562);
            this.Controls.Add(this.btnclear);
            this.Controls.Add(this.btnsua);
            this.Controls.Add(this.btnxoa);
            this.Controls.Add(this.btnthem);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.grpnhapthongtinlichtruc);
            this.Controls.Add(this.grpthongtinlichtruc);
            this.Name = "LichTruc";
            this.Text = "LichTruc";
            this.Load += new System.EventHandler(this.LichTruc_Load);
            this.grpnhapthongtinlichtruc.ResumeLayout(false);
            this.grpnhapthongtinlichtruc.PerformLayout();
            this.grpthongtinlichtruc.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnclear;
        private System.Windows.Forms.Button btnsua;
        private System.Windows.Forms.Button btnxoa;
        private System.Windows.Forms.Button btnthem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox grpnhapthongtinlichtruc;
        private System.Windows.Forms.ComboBox cbomaca;
        private System.Windows.Forms.ComboBox cbomanv;
        private System.Windows.Forms.TextBox txtngaytruc;
        private System.Windows.Forms.Label lblmaca;
        private System.Windows.Forms.Label lblsoluong;
        private System.Windows.Forms.Label lblmanv;
        private System.Windows.Forms.GroupBox grpthongtinlichtruc;
        private System.Windows.Forms.ListView lst_dl;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}