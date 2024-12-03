using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DEAN_SQL
{
    public partial class frmPrintPreview : Form
    {
        private Bitmap invoiceBitmap;
        public frmPrintPreview()
        {
            InitializeComponent();
            pictureBoxInvoicePreview.Image = invoiceBitmap;  // Đặt hình ảnh vào PictureBox
            pictureBoxInvoicePreview.SizeMode = PictureBoxSizeMode.Zoom;  // Điều chỉnh kích thước hiển thị

        }

        private void frmPrintPreview_Load(object sender, EventArgs e)
        {
            // Hiển thị hình ảnh hóa đơn trong PictureBox
            pictureBoxInvoicePreview.Image = invoiceBitmap;
        }
        // Hàm khởi tạo mới để nhận Bitmap
        public frmPrintPreview(Bitmap bitmap)
        {
            InitializeComponent();
            invoiceBitmap = bitmap;
        }
    }
}
