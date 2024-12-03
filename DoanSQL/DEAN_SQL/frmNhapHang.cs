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
        private void LoadProducts()
        {
            flowLayoutPanelProducts.Controls.Clear();
            // Giả sử có danh sách các sản phẩm
            List<HangHoa_DTO> products = BLL_HH.display(); // Phương thức lấy danh sách sản phẩm.

            // Thêm từng sản phẩm vào FlowLayoutPanel
            foreach (var product in products)
            {
                Panel panel = new Panel
                {
                    Size = new Size(150, 230), // Tăng chiều cao để chứa thêm thông tin số lượng
                    BorderStyle = BorderStyle.FixedSingle
                };

                // Thêm ảnh sản phẩm
                string fileName = product.Hinh_P;
                string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
                projectDirectory = System.IO.Directory.GetParent(projectDirectory).Parent.Parent.FullName;
                string imagePath = System.IO.Path.Combine(projectDirectory, "Images", fileName);

                PictureBox pictureBox = new PictureBox
                {
                    Size = new Size(150, 150),
                    Image = Image.FromFile(imagePath), // Đường dẫn ảnh sản phẩm
                    SizeMode = PictureBoxSizeMode.StretchImage
                };
                pictureBox.Click += (sender, e) => AddToInvoice(product);
                panel.Controls.Add(pictureBox);

                // Thêm tên sản phẩm
                Label lblName = new Label
                {
                    Text = product.TenHang_P,
                    AutoSize = true,
                    Location = new Point(10, 160)
                };
                lblName.Click += (sender, e) => AddToInvoice(product);
                panel.Controls.Add(lblName);

                // Thêm giá sản phẩm
                Label lblPrice = new Label
                {
                    Text = $"Giá: {product.DonGia_P:N0} đ",
                    AutoSize = true,
                    Location = new Point(10, 180)
                };
                lblPrice.Click += (sender, e) => AddToInvoice(product);
                panel.Controls.Add(lblPrice);

                // Thêm số lượng sản phẩm sẵn có
                Label lblStock = new Label
                {
                    Text = $"Sẵn có: {BLL_HH.sl_ton(int.Parse(product.MaHang_P)):N0}",
                    AutoSize = true,
                    ForeColor = System.Drawing.Color.Green, // Đổi màu chữ để dễ nhìn
                    Location = new Point(80, 210),
                    Font = new System.Drawing.Font("Arial", 8, FontStyle.Regular), // Đặt kích thước chữ nhỏ hơn
                    Size = new Size(30, 10), // Kích thước nhỏ hơn

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

        private void btnluuhoadon_Click(object sender, EventArgs e)
        {
            LuuPhieNnhap();
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
                    MessageBox.Show("Lổi--> " + kq);
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
                    MessageBox.Show("Lổi--> " + ex.Message);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi lưu phiếu nhập: " + ex.Message);
            }

        }
    }
}
