using BLL;
using DocumentFormat.OpenXml.Wordprocessing;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DEAN_SQL
{
    public partial class frmNhapHang : Form
    {
        public string user, pass, sever, data;
        HangHoa_BLL BLL_HH = new HangHoa_BLL();
        NhaCungCap_BLL BLL_NCC=new NhaCungCap_BLL();
        public frmNhapHang(string name, string password, string servername, string database)
        {
            InitializeComponent();
            user = name;
            pass = password;
            sever = servername;
            data = database;
            Login_DTO login = new Login_DTO(name, password, servername, database);
            Login_DTO login_nv = new Login_DTO(name, password, servername, database);
            BLL_NV.login(login_nv);
            BLL_HH.login(login);
            BLL_NCC.login(login);
        }
        private void panelButtonBanHang_Paint(object sender, PaintEventArgs e)
        {
            LoadProducts();
            cboncc.DataSource = BLL_NCC.display();
            cboncc.DisplayMember = "TenNCC_P";
            cboncc.ValueMember = "MaNCC_P";
        }
        //private void LoadProducts()
        //{
        //    flowLayoutPanelProducts.Controls.Clear();
        //    // Giả sử có danh sách các sản phẩm
        //    List<HangHoa_DTO> products = BLL_HH.display(); // Phương thức lấy danh sách sản phẩm.

        //    // Thêm từng sản phẩm vào FlowLayoutPanel
        //    foreach (var product in products)
        //    {
        //        Panel panel = new Panel
        //        {
        //            Size = new Size(150, 230), // Tăng chiều cao để chứa thêm thông tin số lượng
        //            BorderStyle = BorderStyle.FixedSingle
        //        };

        //        // Thêm ảnh sản phẩm
        //        string fileName = product.Hinh_P;
        //        string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
        //        projectDirectory = System.IO.Directory.GetParent(projectDirectory).Parent.Parent.FullName;
        //        string imagePath = System.IO.Path.Combine(projectDirectory, "Images", fileName);

        //        PictureBox pictureBox = new PictureBox
        //        {
        //            Size = new Size(150, 150),
        //            Image = Image.FromFile(imagePath), // Đường dẫn ảnh sản phẩm
        //            SizeMode = PictureBoxSizeMode.StretchImage
        //        };
        //        pictureBox.Click += (sender, e) => AddToInvoice(product);
        //        panel.Controls.Add(pictureBox);

        //        // Thêm tên sản phẩm
        //        Label lblName = new Label
        //        {
        //            Text = product.TenHang_P,
        //            AutoSize = true,
        //            Location = new Point(10, 160)
        //        };
        //        lblName.Click += (sender, e) => AddToInvoice(product);
        //        panel.Controls.Add(lblName);

        //        // Thêm giá sản phẩm
        //        Label lblPrice = new Label
        //        {
        //            Text = $"Giá: {product.DonGia_P:N0} đ",
        //            AutoSize = true,
        //            Location = new Point(10, 180)
        //        };
        //        lblPrice.Click += (sender, e) => AddToInvoice(product);
        //        panel.Controls.Add(lblPrice);

        //        // Thêm số lượng sản phẩm sẵn có
        //        Label lblStock = new Label
        //        {
        //            Text = $"Sẵn có: {BLL_HH.sl_ton(int.Parse(product.MaHang_P)):N0}",
        //            AutoSize = true,
        //            ForeColor = System.Drawing.Color.Green, // Đổi màu chữ để dễ nhìn
        //            Location = new Point(80, 210),
        //            Font = new System.Drawing.Font("Arial", 8, FontStyle.Regular), // Đặt kích thước chữ nhỏ hơn
        //            Size = new Size(30, 10), // Kích thước nhỏ hơn

        //        };
        //        lblStock.Click += (sender, e) => AddToInvoice(product);
        //        panel.Controls.Add(lblStock);

        //        // Thêm sự kiện khi click vào panel
        //        panel.Click += (sender, e) => AddToInvoice(product);

        //        // Thêm panel vào FlowLayoutPanel
        //        flowLayoutPanelProducts.Controls.Add(panel);
        //    }

        //}
        private void LoadProducts()
        {
            flowLayoutPanelProducts.Controls.Clear();
            // Giả sử có danh sách các sản phẩm
            List<HangHoa_DTO> products = BLL_HH.display(); // Phương thức lấy danh sách sản phẩm.

            // Thêm từng sản phẩm vào FlowLayoutPanel
            foreach (var product in products)
            {
                //Panel panel = new Panel
                //{
                //    Size = new Size(150, 230), // Tăng chiều cao để chứa thêm thông tin số lượng
                //    BorderStyle = BorderStyle.FixedSingle
                //};

                // Tạo Guna2Panel  
                Guna.UI2.WinForms.Guna2Panel panel = new Guna.UI2.WinForms.Guna2Panel
                {
                    Size = new Size(150, 220), // Kích thước panel  
                    FillColor = System.Drawing.Color.White, // Màu nền  
                    BorderColor = System.Drawing.Color.FromArgb(204, 204, 204), // Màu viền  
                    BorderRadius = 8,
                    BorderThickness = 1, // Độ dày viền  
                    Padding = new Padding(2), // Khoảng cách giữa nội dung và viền  
                    Margin = new Padding(10), // Khoảng cách giữa các panel
                                              //ShadowDecoration = { Enabled = true, Shadow = new System.Windows.Forms.Padding(5) } // Hiệu ứng bóng  
                };

                // Thêm ảnh sản phẩm
                //string fileName = product.Hinh_P;
                //string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
                //projectDirectory = System.IO.Directory.GetParent(projectDirectory).Parent.Parent.FullName;
                //string imagePath = System.IO.Path.Combine(projectDirectory, "Images", fileName);

                // Thêm ảnh sản phẩm  
                string fileName = product.Hinh_P;
                string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
                projectDirectory = System.IO.Directory.GetParent(projectDirectory).Parent.Parent.FullName;
                string imagePath = System.IO.Path.Combine(projectDirectory, "Images", fileName);


                //PictureBox pictureBox = new PictureBox
                //{
                //    Size = new Size(150, 150),
                //    Image = Image.FromFile(imagePath), // Đường dẫn ảnh sản phẩm
                //    SizeMode = PictureBoxSizeMode.StretchImage
                //};

                Guna.UI2.WinForms.Guna2PictureBox pictureBox = new Guna.UI2.WinForms.Guna2PictureBox
                {
                    Size = new Size(140, 140),
                    Image = Image.FromFile(imagePath), // Đường dẫn ảnh sản phẩm  
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    BorderRadius = 8,
                    Location = new Point(5, 5), // Đặt vị trí của ảnh  
                    BackColor = System.Drawing.Color.Transparent // Đặt nền trong suốt  
                };
                pictureBox.Click += (sender, e) => AddToInvoice(product);
                panel.Controls.Add(pictureBox);

                // Thêm tên sản phẩm
                //Label lblName = new Label
                //{
                //    Text = product.TenHang_P,
                //    AutoSize = true,
                //    Location = new Point(10, 160)
                //};
                Guna.UI2.WinForms.Guna2HtmlLabel lblName = new Guna.UI2.WinForms.Guna2HtmlLabel
                {
                    Text = product.TenHang_P,
                    AutoSize = true,
                    Location = new Point(10, 150),
                    Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold) // Đặt font chữ  
                };

                lblName.Click += (sender, e) => AddToInvoice(product);
                panel.Controls.Add(lblName);

                // Thêm giá sản phẩm
                //Label lblPrice = new Label
                //{
                //    Text = $"Giá: {product.DonGia_P:N0} đ",
                //    AutoSize = true,
                //    Location = new Point(10, 180)
                //};

                Guna.UI2.WinForms.Guna2HtmlLabel lblPrice = new Guna.UI2.WinForms.Guna2HtmlLabel
                {
                    Text = $"Giá: {product.DonGia_P:N0} đ",
                    AutoSize = true,
                    Location = new Point(10, 170),
                    Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Regular) // Đặt kích thước chữ  
                };

                lblPrice.Click += (sender, e) => AddToInvoice(product);
                panel.Controls.Add(lblPrice);

                // Thêm số lượng sản phẩm sẵn có
                //Label lblStock = new Label
                //{
                //    Text = $"Sẵn có: {BLL_HH.sl_ton(int.Parse(product.MaHang_P)):N0}",
                //    AutoSize = true,
                //    ForeColor = System.Drawing.Color.Green, // Đổi màu chữ để dễ nhìn
                //    Location = new Point(80, 210),
                //    Font = new System.Drawing.Font("Arial", 8, FontStyle.Regular), // Đặt kích thước chữ nhỏ hơn
                //    Size = new Size(30, 10), // Kích thước nhỏ hơn

                //};
                Guna.UI2.WinForms.Guna2HtmlLabel lblStock = new Guna.UI2.WinForms.Guna2HtmlLabel
                {
                    Text = $"Sẵn có: {BLL_HH.sl_ton(int.Parse(product.MaHang_P)):N0}",
                    AutoSize = true,
                    ForeColor = System.Drawing.Color.Green, // Đổi màu chữ để dễ nhìn  
                    Location = new Point(10, 190),
                    Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Bold) // Đặt kích thước chữ nhỏ hơn  
                };

                lblStock.Click += (sender, e) => AddToInvoice(product);
                panel.Controls.Add(lblStock);

                // Thêm sự kiện khi click vào panel
                panel.Click += (sender, e) => AddToInvoice(product);

                // Thêm panel vào FlowLayoutPanel
                flowLayoutPanelProducts.Controls.Add(panel);
            }

        }


        private void AddToInvoice(HangHoa_DTO product)
        {
            // Kiểm tra xem sản phẩm đã có trong hóa đơn chưa
            foreach (ListViewItem item in lstbanhang.Items)
            {
                if (item.SubItems[1].Text == product.TenHang_P)
                {
                    // Tăng số lượng sản phẩm nếu đã tồn tại trong hóa đơn
                    item.SubItems[3].Text = (int.Parse(item.SubItems[3].Text) + 1).ToString();
                    item.SubItems[4].Text = (int.Parse(item.SubItems[3].Text) * product.DonGia_P).ToString();
                    UpdateTotal();
                    return;
                }
            }

            // Nếu sản phẩm chưa có trong hóa đơn, thêm mới
            ListViewItem newItem = new ListViewItem(product.MaHang_P);  // Cột 0: Mã sản phẩm
            newItem.SubItems.Add(product.TenHang_P);         // Cột 1: Tên sản phẩm
            newItem.SubItems.Add(product.DonGia_P.ToString());         // Cột 2: Giá sản phẩm
            newItem.SubItems.Add("1");                              // Cột 3: Số lượng (Mặc định 1)
            newItem.SubItems.Add(product.DonGia_P.ToString());         // Cột 4: Thành tiền

            lstbanhang.Items.Add(newItem);
            UpdateTotal();  // Cập nhật tổng hóa đơn
        }
        private void ShowInvoicePreview(string mapn, string ngayLap)
        {
            Bitmap invoiceBitmap = GenerateInvoicePreview(mapn, ngayLap);
            frmNhapHangPreview previewForm = new frmNhapHangPreview(invoiceBitmap);
            previewForm.ShowDialog();
        }
        private void InPhieuNhap(string mapn, string ngayLap)
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += (sender, e) => printDocument_PrintPage(sender, e, mapn, ngayLap);

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }
        private void printDocument_PrintPage(object sender, PrintPageEventArgs e, string mapn, string ngayLap)
        {
            // Tạo hóa đơn dưới dạng Bitmap
            Bitmap invoiceBitmap = GenerateInvoicePreview(mapn, ngayLap);

            // Vẽ Bitmap lên giấy in
            e.Graphics.DrawImage(invoiceBitmap, e.MarginBounds);

            // Nếu nội dung vượt quá một trang, bạn có thể thiết lập giá trị e.HasMorePages = true
            // để tiếp tục in trên trang kế tiếp
            // Ví dụ:
            // e.HasMorePages = false; // Đặt false nếu chỉ in một trang
        }
        private void btnluuhoadon_Click(object sender, EventArgs e)
        {

            LuuPhieNnhap();
            LoadProducts();
            btnhuy_Click(sender, e);
        }

        private void btntaohoadon_Click(object sender, EventArgs e)
        {
            PHIEUNHAP pn_ma = new PHIEUNHAP(user, pass, sever, data);
            // 1. Tạo mã hóa đơn mới
            txtmapn.Text = "PN" + DateTime.Today.ToString("ddMMyy") + string.Format("{0:000}", pn_ma.GenerateMaPhieuNhap());
            txtngaynhap.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void panelkhachhang_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            lbltongtien.Text = "0";
            lstbanhang.Items.Clear();
            txtmapn.Clear();
            txtngaynhap.Clear();
        }

        private void lstbanhang_Click(object sender, EventArgs e)
        {
            txtmasp.Text = lstbanhang.SelectedItems[0].SubItems[0].Text;
            txtsl.Text = lstbanhang.SelectedItems[0].SubItems[3].Text;
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lstbanhang.Items)
            {
                if (item.SubItems[0].Text == txtmasp.Text)
                {
                    lstbanhang.Items.Remove(item);
                }
            }
            UpdateTotal();
        }

        private void sữaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lstbanhang.Items)
            {
                if (item.SubItems[0].Text == txtmasp.Text)
                {
                    item.SubItems[3].Text = txtsl.Text;
                    item.SubItems[4].Text = (float.Parse(item.SubItems[2].Text) * float.Parse(txtsl.Text)).ToString();
                }
            }
            UpdateTotal();
        }

        private void frmNhapHang_Load(object sender, EventArgs e)
        {
            lstbanhang.ContextMenuStrip = contextMenuStrip1;
        }
        NhanVien_BLL BLL_NV = new NhanVien_BLL();
        private Bitmap GenerateInvoicePreview(string mapn, string ngayLap)
        {
            NhanVien_DTO nv = new NhanVien_DTO(user);
            // Kích thước của Bitmap (tùy chỉnh theo kích thước hóa đơn)
            int width = 900;
            int height = 1000;

            // Tạo Bitmap
            Bitmap invoiceBitmap = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(invoiceBitmap))
            {
                g.Clear(System.Drawing.Color.White);

                // Định nghĩa phông chữ
                System.Drawing.Font titleFont = new System.Drawing.Font("Arial", 26, FontStyle.Bold);
                System.Drawing.Font subTitleFont = new System.Drawing.Font("Arial", 18, FontStyle.Regular);
                System.Drawing.Font contentFont = new System.Drawing.Font("Arial", 15);
                System.Drawing.Font headerFont = new System.Drawing.Font("Arial", 15, FontStyle.Bold); // Font in đậm cho hàng tiêu đề

                // Thêm tiêu đề
                string storeTitle = "CỬA HÀNG MẮT KÍNH";
                string invoiceTitle = "PHIẾU NHẬP ĐÃ THANH TOÁN";

                SizeF storeTitleSize = g.MeasureString(storeTitle, subTitleFont);
                SizeF invoiceTitleSize = g.MeasureString(invoiceTitle, titleFont);

                float centerXStore = (width - storeTitleSize.Width) / 2;
                float centerXInvoice = (width - invoiceTitleSize.Width) / 2;

                g.DrawString(storeTitle, subTitleFont, Brushes.Black, new PointF(centerXStore, 20));
                g.DrawString(invoiceTitle, titleFont, Brushes.Black, new PointF(centerXInvoice, 50));

                // Thêm thông tin mã hóa đơn và ngày lập
                g.DrawString($"Mã phiếu nhập: {mapn}", contentFont, Brushes.Black, new PointF(50, 150));
                g.DrawString($"Nhà cung cấp: {cboncc.Text}", contentFont, Brushes.Black, new PointF(50, 200));
                g.DrawString($"Nhân viên lập: {BLL_NV.ten_nv(nv)}", contentFont, Brushes.Black, new PointF(width - 270, 200));
                g.DrawString($"Ngày lập: {ngayLap}", contentFont, Brushes.Black, new PointF(width - 270, 150));

                // Thiết lập vị trí bảng và chiều rộng các cột
                Pen blackPen = new Pen(System.Drawing.Color.Black, 1);
                Brush grayBrush = new SolidBrush(System.Drawing.Color.LightGray); // Nền xám nhạt cho tiêu đề
                float startX = 50;
                float startY = 250;

                // Chiều rộng các cột
                float columnWidth1 = 50;  // Cột STT
                float columnWidth2 = 300; // Cột Tên Sản Phẩm
                float columnWidth3 = 150; // Cột Đơn Giá
                float columnWidth4 = 120; // Cột Số Lượng
                float columnWidth5 = 150; // Cột Thành tiền

                // Tổng chiều rộng của bảng
                float tableWidth = columnWidth1 + columnWidth2 + columnWidth3 + columnWidth4 + columnWidth5;

                // Vẽ nền cho tiêu đề
                g.FillRectangle(grayBrush, startX, startY, tableWidth, 30);

                // Vẽ tiêu đề bảng
                float currentX = startX;
                g.DrawRectangle(blackPen, startX, startY, tableWidth, 30);

                // Vẽ từng cột trong tiêu đề
                g.DrawLine(blackPen, currentX, startY, currentX, startY + 30); // Cột đầu tiên
                g.DrawString("STT", headerFont, Brushes.Black, new PointF(currentX + 5, startY + 5));
                currentX += columnWidth1;

                g.DrawLine(blackPen, currentX, startY, currentX, startY + 30);
                g.DrawString("Tên Sản Phẩm", headerFont, Brushes.Black, new PointF(currentX + 5, startY + 5));
                currentX += columnWidth2;

                g.DrawLine(blackPen, currentX, startY, currentX, startY + 30);
                g.DrawString("Đơn Giá", headerFont, Brushes.Black, new PointF(currentX + 5, startY + 5));
                currentX += columnWidth3;

                g.DrawLine(blackPen, currentX, startY, currentX, startY + 30);
                g.DrawString("Số Lượng", headerFont, Brushes.Black, new PointF(currentX + 5, startY + 5));
                currentX += columnWidth4;

                g.DrawLine(blackPen, currentX, startY, currentX, startY + 30);
                g.DrawString("Thành Tiền", headerFont, Brushes.Black, new PointF(currentX + 5, startY + 5));

                // Vẽ nội dung bảng
                int stt = 1;
                float yPos = startY + 30;

                foreach (ListViewItem item in lstbanhang.Items)
                {
                    string tenSanPham = item.SubItems[1].Text;
                    string donGia = item.SubItems[2].Text;
                    string soLuong = item.SubItems[3].Text;
                    string thanhTien = item.SubItems[4].Text;

                    // Vẽ đường viền cho từng dòng
                    currentX = startX;
                    g.DrawRectangle(blackPen, startX, yPos, tableWidth, 30);

                    // Vẽ từng cột trong dòng
                    g.DrawLine(blackPen, currentX, yPos, currentX, yPos + 30);
                    g.DrawString(stt.ToString(), contentFont, Brushes.Black, new PointF(currentX + 5, yPos + 5));
                    currentX += columnWidth1;

                    g.DrawLine(blackPen, currentX, yPos, currentX, yPos + 30);
                    g.DrawString(tenSanPham, contentFont, Brushes.Black, new PointF(currentX + 5, yPos + 5));
                    currentX += columnWidth2;

                    g.DrawLine(blackPen, currentX, yPos, currentX, yPos + 30);
                    g.DrawString(donGia, contentFont, Brushes.Black, new PointF(currentX + 5, yPos + 5));
                    currentX += columnWidth3;

                    g.DrawLine(blackPen, currentX, yPos, currentX, yPos + 30);
                    g.DrawString(soLuong, contentFont, Brushes.Black, new PointF(currentX + 5, yPos + 5));
                    currentX += columnWidth4;

                    g.DrawLine(blackPen, currentX, yPos, currentX, yPos + 30);
                    g.DrawString(thanhTien, contentFont, Brushes.Black, new PointF(currentX + 5, yPos + 5));

                    yPos += 30;
                    stt++;
                }

                // Tổng kết hóa đơn
                yPos += 20;
                string totalString = $"Tổng Tiền: {total:#,##0}đ";
                g.DrawString(totalString, contentFont, Brushes.Black, new PointF(width - 270, yPos));

                // Vẽ đường thẳng trên lời cảm ơn
                float lineStartX = 50;
                float lineEndX = width - 50;
                float lineY = yPos + 40; // Vị trí ngay trên lời cảm ơn
                g.DrawLine(blackPen, lineStartX, lineY, lineEndX, lineY);

                // Thêm lời cảm ơn
                string thankYouText = "Cảm ơn quý khách đã mua sắm tại cửa hàng!";
                SizeF textSize = g.MeasureString(thankYouText, contentFont);
                float centerX = (width - textSize.Width) / 2;
                g.DrawString(thankYouText, contentFont, Brushes.Black, new PointF(centerX, yPos + 50));
            }

            return invoiceBitmap;

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        // Tính tổng tiền hóa đơn
        float total;
        private void UpdateTotal()
        {
            total = 0;
            //foreach (DataGridViewRow row in dataGridViewInvoice.Rows)
            //{
            //    total += Convert.ToInt32(row.Cells["ThanhTien"].Value);
            //}
            foreach (ListViewItem item in lstbanhang.Items)
            {
                total += float.Parse(item.SubItems[4].Text);
            }
            lbltongtien.Text = $"{total:N0} đ";
        }

        private void LuuPhieNnhap()
        {
           
            try
            {

                ShowInvoicePreview(txtmapn.Text, txtngaynhap.Text);
                // Lưu thông tin hóa đơn vào bảng HoaDon
                NhapHang_BLL BLL_NhapHang = new NhapHang_BLL();
                //PhieuNhap_DTO pn = new PhieuNhap_DTO(txtmapn.Text, txtngaynhap.Text,cboncc.SelectedValue.ToString(), user);

                PhieuNhap_DTO pn = new PhieuNhap_DTO(txtmapn.Text, DateTime.ParseExact(txtngaynhap.Text,"dd/MM/yyyy", CultureInfo.CurrentCulture).ToString(), cboncc.SelectedValue.ToString(), user);
                string kq = BLL_NhapHang.luu_pn(pn);
                if (kq == "true")
                {
                    MessageBox.Show("Lưu phiếu nhập thành công");
                }
                else
                {
                    MessageBox.Show("Lỗi--> " + kq);
                }

                // Lưu chi tiết hóa đơn vào bảng ChiTietHoaDon
                try
                {
                    foreach (ListViewItem item in lstbanhang.Items)
                    {
                        string masp = item.SubItems[0].Text;
                        string donGia = item.SubItems[2].Text;
                        string soLuong = item.SubItems[3].Text;

                        ChiTietPN_DTO ctpn = new ChiTietPN_DTO(txtmapn.Text, masp, soLuong,donGia);
                        BLL_NhapHang.luu_ctpn(ctpn);


                    }
                    MessageBox.Show("Lưu chi tiết phiếu nhập thành công");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi--> " + ex.Message);
                }
                InPhieuNhap(txtmapn.Text, txtngaynhap.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi lưu phiếu nhập: " + ex.Message);
            }

        }
    }
}
