namespace DEAN_SQL
{
    partial class frmNhapHangPreview
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
            this.pictureBoxInvoicePreview = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInvoicePreview)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxInvoicePreview
            // 
            this.pictureBoxInvoicePreview.Location = new System.Drawing.Point(-2, 2);
            this.pictureBoxInvoicePreview.Name = "pictureBoxInvoicePreview";
            this.pictureBoxInvoicePreview.Size = new System.Drawing.Size(831, 709);
            this.pictureBoxInvoicePreview.TabIndex = 0;
            this.pictureBoxInvoicePreview.TabStop = false;
            // 
            // frmNhapHangPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 709);
            this.Controls.Add(this.pictureBoxInvoicePreview);
            this.Name = "frmNhapHangPreview";
            this.Text = "frmNhapHangPreview";
            this.Load += new System.EventHandler(this.frmNhapHangPreview_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInvoicePreview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxInvoicePreview;
    }
}