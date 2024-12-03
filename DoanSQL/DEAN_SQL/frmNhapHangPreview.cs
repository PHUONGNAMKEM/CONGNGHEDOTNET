using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace DEAN_SQL
{
    public partial class frmNhapHangPreview : Form
    {
        private Bitmap invoiceBitmap;
        public frmNhapHangPreview(Bitmap bitmap)
        {
            InitializeComponent();
            pictureBoxInvoicePreview.Image = invoiceBitmap;  // Đặt hình ảnh vào PictureBox
            pictureBoxInvoicePreview.SizeMode = PictureBoxSizeMode.Zoom;
            invoiceBitmap = bitmap;// Điều chỉnh kích thước hiển thị
        }

        private void frmNhapHangPreview_Load(object sender, EventArgs e)
        {
            // Hiển thị hình ảnh hóa đơn trong PictureBox
            pictureBoxInvoicePreview.Image = invoiceBitmap;
        }
    }
}
