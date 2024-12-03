namespace DEAN_SQL
{
    partial class frmPhanQuyen
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btncaptk = new System.Windows.Forms.Button();
            this.cbomanv = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnphanquyen = new System.Windows.Forms.Button();
            this.chkSelect = new System.Windows.Forms.CheckBox();
            this.chkUpdate = new System.Windows.Forms.CheckBox();
            this.chkDelete = new System.Windows.Forms.CheckBox();
            this.chkInsert = new System.Windows.Forms.CheckBox();
            this.cbotable = new System.Windows.Forms.ComboBox();
            this.cbousername = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnthuhoiquyen = new System.Windows.Forms.Button();
            this.btnxemquyen = new System.Windows.Forms.Button();
            this.dgvtatcaquyencua_user = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.cbotatcaquyen = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvtatcaquyencua_user)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(363, 167);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(331, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "PHÂN QUYỀN NGƯỜI DÙNG";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbotatcaquyen);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.dgvtatcaquyencua_user);
            this.panel1.Controls.Add(this.btnxemquyen);
            this.panel1.Controls.Add(this.btnthuhoiquyen);
            this.panel1.Controls.Add(this.btncaptk);
            this.panel1.Controls.Add(this.cbomanv);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btnphanquyen);
            this.panel1.Controls.Add(this.chkSelect);
            this.panel1.Controls.Add(this.chkUpdate);
            this.panel1.Controls.Add(this.chkDelete);
            this.panel1.Controls.Add(this.chkInsert);
            this.panel1.Controls.Add(this.cbotable);
            this.panel1.Controls.Add(this.cbousername);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1386, 1055);
            this.panel1.TabIndex = 4;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btncaptk
            // 
            this.btncaptk.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncaptk.Location = new System.Drawing.Point(983, 249);
            this.btncaptk.Margin = new System.Windows.Forms.Padding(2);
            this.btncaptk.Name = "btncaptk";
            this.btncaptk.Size = new System.Drawing.Size(204, 64);
            this.btncaptk.TabIndex = 18;
            this.btncaptk.Text = "Cấp tài khoản";
            this.btncaptk.UseVisualStyleBackColor = true;
            this.btncaptk.Click += new System.EventHandler(this.btncaptk_Click);
            // 
            // cbomanv
            // 
            this.cbomanv.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbomanv.FormattingEnabled = true;
            this.cbomanv.Location = new System.Drawing.Point(668, 249);
            this.cbomanv.Margin = new System.Windows.Forms.Padding(2);
            this.cbomanv.Name = "cbomanv";
            this.cbomanv.Size = new System.Drawing.Size(287, 37);
            this.cbomanv.TabIndex = 17;
            this.cbomanv.SelectedIndexChanged += new System.EventHandler(this.cbomanv_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(363, 249);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(179, 29);
            this.label5.TabIndex = 16;
            this.label5.Text = "Choose Staff ID";
            // 
            // btnphanquyen
            // 
            this.btnphanquyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnphanquyen.Location = new System.Drawing.Point(983, 329);
            this.btnphanquyen.Margin = new System.Windows.Forms.Padding(2);
            this.btnphanquyen.Name = "btnphanquyen";
            this.btnphanquyen.Size = new System.Drawing.Size(204, 64);
            this.btnphanquyen.TabIndex = 15;
            this.btnphanquyen.Text = "Phân quyền";
            this.btnphanquyen.UseVisualStyleBackColor = true;
            this.btnphanquyen.Click += new System.EventHandler(this.btnphanquyen_Click);
            // 
            // chkSelect
            // 
            this.chkSelect.AutoSize = true;
            this.chkSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSelect.Location = new System.Drawing.Point(367, 414);
            this.chkSelect.Margin = new System.Windows.Forms.Padding(2);
            this.chkSelect.Name = "chkSelect";
            this.chkSelect.Size = new System.Drawing.Size(129, 33);
            this.chkSelect.TabIndex = 14;
            this.chkSelect.Text = "SELECT";
            this.chkSelect.UseVisualStyleBackColor = true;
            this.chkSelect.CheckedChanged += new System.EventHandler(this.btnselect_CheckedChanged);
            // 
            // chkUpdate
            // 
            this.chkUpdate.AutoSize = true;
            this.chkUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUpdate.Location = new System.Drawing.Point(939, 414);
            this.chkUpdate.Margin = new System.Windows.Forms.Padding(2);
            this.chkUpdate.Name = "chkUpdate";
            this.chkUpdate.Size = new System.Drawing.Size(132, 33);
            this.chkUpdate.TabIndex = 13;
            this.chkUpdate.Text = "UPDATE";
            this.chkUpdate.UseVisualStyleBackColor = true;
            this.chkUpdate.CheckedChanged += new System.EventHandler(this.btnupdate_CheckedChanged);
            // 
            // chkDelete
            // 
            this.chkDelete.AutoSize = true;
            this.chkDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDelete.Location = new System.Drawing.Point(746, 414);
            this.chkDelete.Margin = new System.Windows.Forms.Padding(2);
            this.chkDelete.Name = "chkDelete";
            this.chkDelete.Size = new System.Drawing.Size(129, 33);
            this.chkDelete.TabIndex = 12;
            this.chkDelete.Text = "DELETE";
            this.chkDelete.UseVisualStyleBackColor = true;
            this.chkDelete.CheckedChanged += new System.EventHandler(this.btndelete_CheckedChanged);
            // 
            // chkInsert
            // 
            this.chkInsert.AutoSize = true;
            this.chkInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkInsert.Location = new System.Drawing.Point(560, 414);
            this.chkInsert.Margin = new System.Windows.Forms.Padding(2);
            this.chkInsert.Name = "chkInsert";
            this.chkInsert.Size = new System.Drawing.Size(124, 33);
            this.chkInsert.TabIndex = 11;
            this.chkInsert.Text = "INSERT";
            this.chkInsert.UseVisualStyleBackColor = true;
            this.chkInsert.CheckedChanged += new System.EventHandler(this.btninsert_CheckedChanged);
            // 
            // cbotable
            // 
            this.cbotable.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbotable.FormattingEnabled = true;
            this.cbotable.Location = new System.Drawing.Point(668, 356);
            this.cbotable.Margin = new System.Windows.Forms.Padding(2);
            this.cbotable.Name = "cbotable";
            this.cbotable.Size = new System.Drawing.Size(287, 37);
            this.cbotable.TabIndex = 10;
            // 
            // cbousername
            // 
            this.cbousername.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbousername.FormattingEnabled = true;
            this.cbousername.Location = new System.Drawing.Point(668, 302);
            this.cbousername.Margin = new System.Windows.Forms.Padding(2);
            this.cbousername.Name = "cbousername";
            this.cbousername.Size = new System.Drawing.Size(287, 37);
            this.cbousername.TabIndex = 9;
            this.cbousername.SelectedIndexChanged += new System.EventHandler(this.cbousername_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DEAN_SQL.Properties.Resources.administrator;
            this.pictureBox1.Location = new System.Drawing.Point(959, 60);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(67, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(607, 55);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(309, 42);
            this.label4.TabIndex = 6;
            this.label4.Text = "&Admin quyền lực";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(363, 361);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 29);
            this.label3.TabIndex = 5;
            this.label3.Text = "Choose Table";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(363, 302);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(214, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "Choose Username";
            // 
            // btnthuhoiquyen
            // 
            this.btnthuhoiquyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnthuhoiquyen.Location = new System.Drawing.Point(983, 167);
            this.btnthuhoiquyen.Margin = new System.Windows.Forms.Padding(2);
            this.btnthuhoiquyen.Name = "btnthuhoiquyen";
            this.btnthuhoiquyen.Size = new System.Drawing.Size(204, 64);
            this.btnthuhoiquyen.TabIndex = 19;
            this.btnthuhoiquyen.Text = "Thu hồi quyền";
            this.btnthuhoiquyen.UseVisualStyleBackColor = true;
            this.btnthuhoiquyen.Click += new System.EventHandler(this.btnthuhoiquyen_Click);
            // 
            // btnxemquyen
            // 
            this.btnxemquyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnxemquyen.Location = new System.Drawing.Point(983, 478);
            this.btnxemquyen.Margin = new System.Windows.Forms.Padding(2);
            this.btnxemquyen.Name = "btnxemquyen";
            this.btnxemquyen.Size = new System.Drawing.Size(204, 64);
            this.btnxemquyen.TabIndex = 20;
            this.btnxemquyen.Text = "Xem quyền";
            this.btnxemquyen.UseVisualStyleBackColor = true;
            this.btnxemquyen.Click += new System.EventHandler(this.btnxemquyen_Click);
            // 
            // dgvtatcaquyencua_user
            // 
            this.dgvtatcaquyencua_user.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvtatcaquyencua_user.Location = new System.Drawing.Point(91, 547);
            this.dgvtatcaquyencua_user.Name = "dgvtatcaquyencua_user";
            this.dgvtatcaquyencua_user.RowHeadersWidth = 51;
            this.dgvtatcaquyencua_user.RowTemplate.Height = 24;
            this.dgvtatcaquyencua_user.Size = new System.Drawing.Size(1222, 305);
            this.dgvtatcaquyencua_user.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(363, 496);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 29);
            this.label6.TabIndex = 22;
            this.label6.Text = "Chọn quyền";
            // 
            // cbotatcaquyen
            // 
            this.cbotatcaquyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbotatcaquyen.FormattingEnabled = true;
            this.cbotatcaquyen.Location = new System.Drawing.Point(542, 496);
            this.cbotatcaquyen.Margin = new System.Windows.Forms.Padding(2);
            this.cbotatcaquyen.Name = "cbotatcaquyen";
            this.cbotatcaquyen.Size = new System.Drawing.Size(413, 37);
            this.cbotatcaquyen.TabIndex = 23;
            // 
            // frmPhanQuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1386, 1055);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmPhanQuyen";
            this.Text = "frmPhanQuyen";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPhanQuyen_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvtatcaquyencua_user)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkSelect;
        private System.Windows.Forms.CheckBox chkUpdate;
        private System.Windows.Forms.CheckBox chkDelete;
        private System.Windows.Forms.CheckBox chkInsert;
        private System.Windows.Forms.ComboBox cbotable;
        private System.Windows.Forms.ComboBox cbousername;
        private System.Windows.Forms.Button btnphanquyen;
        private System.Windows.Forms.ComboBox cbomanv;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btncaptk;
        private System.Windows.Forms.DataGridView dgvtatcaquyencua_user;
        private System.Windows.Forms.Button btnxemquyen;
        private System.Windows.Forms.Button btnthuhoiquyen;
        private System.Windows.Forms.ComboBox cbotatcaquyen;
        private System.Windows.Forms.Label label6;
    }
}