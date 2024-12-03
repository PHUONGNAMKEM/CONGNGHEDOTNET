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
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DEAN_SQL
{
    public partial class AppForAdmin : Form
    {
        KhachHangView_BLL BLL_KhachHang = new KhachHangView_BLL();
        Logout_BLL BLL = new Logout_BLL();
        HangHoa_BLL BLL_HH=new HangHoa_BLL();
        private Timer timer_logout;
        public string user, pass, sever, data;
        Logout_DTO logout;
        public AppForAdmin(string phanQuyen, string cachuc, string name, string password, string servername, string database)
        {
           
            InitializeComponent();
            lblPhanQuyen.Text = phanQuyen;
            if(lblPhanQuyen.Text=="&Admin")
            {
                btnPhanQuyen.Visible = true;
            }    
            
            timer_logout = new Timer();
            timer_logout.Interval = 2000; // Kiểm tra mỗi phút
            timer_logout.Tick += timer_logout_Tick;
            timer_logout.Start();
            user = name;
            pass = password;
            sever = servername;
            data = database;
            logout = new Logout_DTO(name, password, servername, database);
            Login_DTO login = new Login_DTO(name, password, servername, database);
            BLL_HH.login(login);
            Login_DTO login_nv = new Login_DTO(name, password, servername, database);
            BLL_NV.login(login_nv);
            Login_DTO login_kh = new Login_DTO(name, password, servername, database);
            BLL_KhachHang.login(login_kh);

            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;

            lblUserName.Text = name;
            lblcachuc.Text = cachuc;
        }


        private void App_Load(object sender, EventArgs e)
        {

            btnWorkWithData.Visible = false;

            if (lblPhanQuyen.Text.Equals("&Admin"))
            {
                btnWorkWithData.Visible = true;
            }
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void App_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    

        private void btnWorkWithData_Click(object sender, EventArgs e)
        {
            //WorkWithData workWithData = new WorkWithData(lblPhanQuyen.Text, user, pass, sever, data);
            //workWithData.Show();
            OpenChildForm(new WorkWithData(lblPhanQuyen.Text, user, pass, sever, data));
            //this.Close();
        }

        private void timer_logout_Tick(object sender, EventArgs e)
        {
            try
            {

                bool kq = BLL.timer_logout_Tick(logout);
                if (kq == true)
                {
                    timer_logout.Stop();
                    // Hiển thị form đăng nhập và đóng form chính
                    Form1 login = new Form1();
                    login.Location = this.Location; // Đặt form login ở vị trí của form hiện tại
                    login.Show();
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error-------> " + ex.Message);
            }
        }
        private void btnlogout_Click(object sender, EventArgs e)
        {

            //DatabaseConnection.InitializeConnection(connString);
            try
            {
                // Đăng xuất và đóng tất cả các form khác
                timer_logout.Stop();
                // Xóa phiên đăng nhập

                BLL.Xoa_phiendangnhap(logout);



                // Hiển thị form đăng nhập và đóng form hiện tại
                Form1 login = new Form1();
                login.Location = this.Location; // Đặt form login ở vị trí của form hiện tại
                login.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error-------> " + ex.Message);
            }
        }
        private void btnnew_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
        }
        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            //KhachHang kh = new KhachHang(user, pass, sever, data);
            //kh.Show();
            OpenChildForm(new KhachHangView(user, pass, sever, data));
        }
        private void btnhoadon_Click(object sender, EventArgs e)
        {
            panelcontainer.Controls.Clear();
            //HoaDon hd = new HoaDon(user, pass, sever, data);

            OpenChildForm(new HoaDon(user, pass, sever, data));

            //hd.TopLevel = false; // Đặt formCon là form con không có thanh tiêu đề riêng.
            //hd.FormBorderStyle = FormBorderStyle.None; // Bỏ viền của form con.
            //hd.Dock = DockStyle.Fill; // Form con sẽ chiếm toàn bộ khu vực chứa.
            //// Giả sử bạn có một Panel tên là panelContainer trong FormCha
            //hd.Parent = panelcontainer;
            //hd.Dock = DockStyle.Fill; // Tùy chọn: Hoặc điều chỉnh vị trí theo nhu cầu.

            //hd.Show();
        }
        private void btnchitiethoadon_Click(object sender, EventArgs e)
        {
            //CHITIETHOADON ct = new CHITIETHOADON(user, pass, sever, data);
            //ct.Show();
            OpenChildForm(new CHITIETHOADON(user, pass, sever, data));
        }

        private void btnhanghoa_Click(object sender, EventArgs e)
        {

            OpenChildForm(new HangHoa(user, pass, sever, data));
            //panelcontainer.Controls.Clear(); -- dòng này command lại
            //HangHoa hh = new HangHoa(user, pass, sever, data); -- dòng này command lại

            //hh.TopLevel = false; // Đặt formCon là form con không có thanh tiêu đề riêng.
            //hh.FormBorderStyle = FormBorderStyle.None; // Bỏ viền của form con.
            //hh.Dock = DockStyle.Fill; // Form con sẽ chiếm toàn bộ khu vực chứa.
            //// Giả sử bạn có một Panel tên là panelContainer trong FormCha
            //hh.Parent = panelcontainer;
            //hh.Dock = DockStyle.Fill; // Tùy chọn: Hoặc điều chỉnh vị trí theo nhu cầu.

            //hh.Show();  -- dòng này command lại
        }
        private void btnkhuyenmai_Click(object sender, EventArgs e)
        {
            //KhuyenMai km = new KhuyenMai(user, pass, sever, data);
            //km.Show();
            OpenChildForm(new KhuyenMai(user, pass, sever, data));

        }

        private void btnloaihang_Click(object sender, EventArgs e)
        {
            //LoaiHang lh = new LoaiHang(user, pass, sever, data);
            //lh.Show();
            OpenChildForm(new LoaiHang(user, pass, sever, data));
        }

        private void btnchitietpn_Click(object sender, EventArgs e)
        {
            //CHITIETPN ctpn = new CHITIETPN( user, pass, sever, data);
            //ctpn.Show();
            OpenChildForm(new CHITIETPN(user, pass, sever, data));
        }

        private void btnphieunhap_Click(object sender, EventArgs e)
        {
            //PHIEUNHAP pn = new PHIEUNHAP(user, pass, sever, data);
            //pn.Show();
            OpenChildForm(new PHIEUNHAP(user, pass, sever, data));
        }

        private void btnnhacc_Click(object sender, EventArgs e)
        {
            //NHACC ncc = new NHACC(user, pass, sever, data);
            //ncc.Show();
            OpenChildForm(new NHACC(user, pass, sever, data));
        }

        private void btnnhanvien_Click(object sender, EventArgs e)
        {
            //NhanVien nv = new NhanVien(user, pass, sever, data);
            //nv.Show();
            OpenChildForm(new NhanVienView(user, pass, sever, data));
        }
        private void btnnhaphang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmNhapHang(user, pass, sever, data));
        }
        private void btnlichca_Click(object sender, EventArgs e)
        {
            OpenChildForm(new LichCa(user, pass, sever, data));
        }
        private void btnlichtruc_Click(object sender, EventArgs e)
        {
            OpenChildForm(new LichTruc(user, pass, sever, data));
        }
        private void btntinhluong_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TinhLuong(user, pass, sever, data));
        }
        private void btnnguyenlieu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new NguyenLieu(user, pass, sever, data));
        }
        private void btnthongke_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmThongKe());
        }
        private void btnbanhang_Click(object sender, EventArgs e)
        {
            //panelkhachhang.Visible = true;
            //panelboloc.Visible = true;
            //panelbanhang.Visible = true;
            //lstbanhang.Visible = true;
            //LoadProducts();

            panelButtonBanHang.BringToFront();
            panelkhachhang.Visible = true;
            panelboloc.Visible = true;
            panelbanhang.Visible = true;
            lstbanhang.Visible = true;
            flowLayoutPanelProducts.Visible = true;
            panelcontainer.Visible = true;

            panelMainDesktop.BringToFront();

            panelbanhang.BringToFront();
            lstbanhang.BringToFront();
            flowLayoutPanelProducts.BringToFront();
            panelcontainer.BringToFront();

            LoadProducts();
        }
        private void btnchitietkhuyenmai_Click(object sender, EventArgs e)
        {
            //ChiTietKhuyenMai ctkm = new ChiTietKhuyenMai(user, pass, sever, data);
            //ctkm.Show();
            OpenChildForm(new ChiTietKhuyenMai(user, pass, sever, data));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //ThongTinNhanVien ttnv = new ThongTinNhanVien(user, pass, sever, data);
            //ttnv.Show();
            OpenChildForm(new ThongTinNhanVien(user, pass, sever, data));
        }
        private void btnchamcong_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ChamCong(user, pass, sever, data));
        }
        private void txttienkhachtra_TextChanged(object sender, EventArgs e)
        {
            if (!txttienkhachtra.Text.All(char.IsDigit))
            {
                MessageBox.Show("Bạn chỉ có thể nhập số nguyên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txttienkhachtra.Text = new string(txttienkhachtra.Text.Where(char.IsDigit).ToArray());
                txttienkhachtra.SelectionStart = txttienkhachtra.TextLength;
            }
            else
            {
                if (txttienkhachtra.Text.Length == 0)
                {
                    txttienthua.Text = "";
                }
                else if (float.Parse(txttienkhachtra.Text) > float.Parse(txtthanhtoan.Text))
                {
                    txttienthua.Text = $"{(float.Parse(txttienkhachtra.Text) - float.Parse(txtthanhtoan.Text)):000}đ";
                }
                else if (float.Parse(txttienkhachtra.Text) < float.Parse(txtthanhtoan.Text))
                {
                    txttienthua.Text = "Không đủ";
                }
                else txttienthua.Text = "0";
            }  
        
        }


        //private void LoadProducts()
        //{
        //    List<HangHoa_DTO> products;
        //    flowLayoutPanelProducts.Controls.Clear();
        //    // Giả sử có danh sách các sản phẩm
        //    try
        //    {
        //        products = BLL_HH.display(); // Phương thức lấy danh sách sản phẩm.
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Lỗi-->" + ex.Message + "", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }

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

        //        // Kiểm tra nếu sản phẩm có sẵn và không thể thêm vào giỏ
        //        bool isOutOfStock = BLL_HH.sl_ton(int.Parse(product.MaHang_P)) == 0;

        //        // Lớp phủ mờ khi hết hàng
        //        if (isOutOfStock) // Nếu sản phẩm hết hàng
        //        {
        //            pictureBox.Enabled = false; // Tắt khả năng bấm vào ảnh
        //            pictureBox.BackColor = System.Drawing.Color.Gray; // Đổi màu mờ cho ảnh

        //            // Tạo lớp phủ mờ trên ảnh
        //            Panel overlay = new Panel
        //            {
        //                Size = pictureBox.Size,
        //                BackColor = System.Drawing.Color.FromArgb(128, System.Drawing.Color.Gray), // Màu xám với độ trong suốt (128) để tạo hiệu ứng mờ
        //                Location = new Point(0, 0)
        //            };
        //            pictureBox.Controls.Add(overlay); // Thêm lớp phủ vào ảnh
        //            pictureBox.Click += (sender, e) => MessageBox.Show("Sản phẩm này đã hết hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); // Hiển thị thông báo khi bấm vào
        //        }
        //        else
        //        {
        //            pictureBox.Click += (sender, e) => AddToInvoice(product); // Nếu có sẵn, bấm vào ảnh để thêm vào giỏ
        //        }

        //        panel.Controls.Add(pictureBox);

        //        // Thêm tên sản phẩm
        //        Label lblName = new Label
        //        {
        //            Text = product.TenHang_P,
        //            AutoSize = true,
        //            Location = new Point(10, 160)
        //        };

        //        if (isOutOfStock) // Nếu sản phẩm hết hàng
        //        {
        //            lblName.Enabled = false; // Tắt khả năng bấm vào tên sản phẩm
        //            lblName.ForeColor = System.Drawing.Color.Gray; // Đổi màu chữ thành màu xám
        //        }
        //        else
        //        {
        //            lblName.Click += (sender, e) => AddToInvoice(product); // Nếu có sẵn, bấm vào tên để thêm vào giỏ
        //        }

        //        panel.Controls.Add(lblName);

        //        // Thêm giá sản phẩm
        //        Label lblPrice = new Label
        //        {
        //            Text = $"Giá: {product.DonGia_P:N0} đ",
        //            AutoSize = true,
        //            Location = new Point(10, 180)
        //        };

        //        if (isOutOfStock) // Nếu sản phẩm hết hàng
        //        {
        //            lblPrice.Enabled = false; // Tắt khả năng bấm vào giá
        //            lblPrice.ForeColor = System.Drawing.Color.Gray; // Đổi màu chữ thành màu xám
        //        }
        //        else
        //        {
        //            lblPrice.Click += (sender, e) => AddToInvoice(product); // Nếu có sẵn, bấm vào giá để thêm vào giỏ
        //        }

        //        panel.Controls.Add(lblPrice);

        //        // Thêm số lượng sản phẩm sẵn có
        //        Label lblStock = new Label
        //        {
        //            Text = $"Sẵn có: {BLL_HH.sl_ton(int.Parse(product.MaHang_P)):N0}",
        //            AutoSize = true,
        //            ForeColor = isOutOfStock ? System.Drawing.Color.Gray : System.Drawing.Color.Green, // Đổi màu chữ thành xám nếu hết hàng
        //            Location = new Point(80, 210),
        //            Font = new System.Drawing.Font("Arial", 8, FontStyle.Regular), // Đặt kích thước chữ nhỏ hơn
        //            Size = new Size(30, 10) // Kích thước nhỏ hơn
        //        };

        //        panel.Controls.Add(lblStock);

        //        // Thêm sự kiện khi click vào panel (cũng cần phải vô hiệu hóa khi sản phẩm hết hàng)
        //        panel.Click += (sender, e) =>
        //        {
        //            if (isOutOfStock)
        //            {
        //                MessageBox.Show("Sản phẩm này đã hết hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            }
        //            else
        //            {
        //                AddToInvoice(product); // Nếu có sẵn, bấm vào panel để thêm vào giỏ
        //            }
        //        };

        //        // Thêm panel vào FlowLayoutPanel
        //        flowLayoutPanelProducts.Controls.Add(panel);
        //    }
        //}
        private void LoadProducts()
        {
            List<HangHoa_DTO> products;
            flowLayoutPanelProducts.Controls.Clear();
            // Giả sử có danh sách các sản phẩm
            try
            {
                products = BLL_HH.display(); // Phương thức lấy danh sách sản phẩm.
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi-->" + ex.Message + "", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
                // Kiểm tra nếu sản phẩm có sẵn và không thể thêm vào giỏ
                bool isOutOfStock = BLL_HH.sl_ton(int.Parse(product.MaHang_P)) == 0;

                // Lớp phủ mờ khi hết hàng
                if (isOutOfStock) // Nếu sản phẩm hết hàng
                {
                    pictureBox.Enabled = false; // Tắt khả năng bấm vào ảnh
                    pictureBox.BackColor = System.Drawing.Color.Gray; // Đổi màu mờ cho ảnh

                    // Tạo lớp phủ mờ trên ảnh
                    Panel overlay = new Panel
                    {
                        Size = pictureBox.Size,
                        BackColor = System.Drawing.Color.FromArgb(128, System.Drawing.Color.Gray), // Màu xám với độ trong suốt (128) để tạo hiệu ứng mờ
                        Location = new Point(0, 0)
                    };
                    pictureBox.Controls.Add(overlay); // Thêm lớp phủ vào ảnh
                    pictureBox.Click += (sender, e) => MessageBox.Show("Sản phẩm này đã hết hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); // Hiển thị thông báo khi bấm vào
                }
                else
                {
                    pictureBox.Click += (sender, e) => AddToInvoice(product); // Nếu có sẵn, bấm vào ảnh để thêm vào giỏ
                }

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

                if (isOutOfStock) // Nếu sản phẩm hết hàng
                {
                    lblName.Enabled = false; // Tắt khả năng bấm vào tên sản phẩm
                    lblName.ForeColor = System.Drawing.Color.Gray; // Đổi màu chữ thành màu xám
                }
                else
                {
                    lblName.Click += (sender, e) => AddToInvoice(product); // Nếu có sẵn, bấm vào tên để thêm vào giỏ
                }

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
                if (isOutOfStock) // Nếu sản phẩm hết hàng
                {
                    lblPrice.Enabled = false; // Tắt khả năng bấm vào giá
                    lblPrice.ForeColor = System.Drawing.Color.Gray; // Đổi màu chữ thành màu xám
                }
                else
                {
                    lblPrice.Click += (sender, e) => AddToInvoice(product); // Nếu có sẵn, bấm vào giá để thêm vào giỏ
                }

                panel.Controls.Add(lblPrice);

                // Thêm số lượng sản phẩm sẵn có
                //Label lblStock = new Label
                //{
                //    Text = $"Sẵn có: {BLL_HH.sl_ton(int.Parse(product.MaHang_P)):N0}",
                //    AutoSize = true,
                //    ForeColor = isOutOfStock ? System.Drawing.Color.Gray : System.Drawing.Color.Green, // Đổi màu chữ thành xám nếu hết hàng
                //    Location = new Point(80, 210),
                //    Font = new System.Drawing.Font("Arial", 8, FontStyle.Regular), // Đặt kích thước chữ nhỏ hơn
                //    Size = new Size(30, 10) // Kích thước nhỏ hơn
                //};

                Guna.UI2.WinForms.Guna2HtmlLabel lblStock = new Guna.UI2.WinForms.Guna2HtmlLabel
                {
                    Text = $"Sẵn có: {BLL_HH.sl_ton(int.Parse(product.MaHang_P)):N0}",
                    AutoSize = true,
                    ForeColor = System.Drawing.Color.Green, // Đổi màu chữ để dễ nhìn  
                    Location = new Point(10, 190),
                    Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Bold) // Đặt kích thước chữ nhỏ hơn  
                };

                panel.Controls.Add(lblStock);

                // Thêm sự kiện khi click vào panel (cũng cần phải vô hiệu hóa khi sản phẩm hết hàng)
                panel.Click += (sender, e) =>
                {
                    if (isOutOfStock)
                    {
                        MessageBox.Show("Sản phẩm này đã hết hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        AddToInvoice(product); // Nếu có sẵn, bấm vào panel để thêm vào giỏ
                    }
                };

                // Thêm panel vào FlowLayoutPanel
                flowLayoutPanelProducts.Controls.Add(panel);
            }
        }



        private void AddToInvoice(HangHoa_DTO product)
        {
            // Kiểm tra xem sản phẩm đã có trong hóa đơn chưa
            foreach (ListViewItem item in lstbanhang.Items)
            {
                // Nếu sản phẩm đã có trong giỏ hàng (dựa vào tên sản phẩm)
                if (item.SubItems[1].Text == product.TenHang_P)
                {
                    // Lấy số lượng hiện tại trong giỏ
                    int currentQuantity = int.Parse(item.SubItems[4].Text);

                    // Lấy số lượng sản phẩm còn lại trong kho
                    int availableStock = BLL_HH.sl_ton(int.Parse(product.MaHang_P));

                    // Kiểm tra nếu số lượng hiện tại cộng thêm 1 vượt quá số lượng sẵn có
                    if (currentQuantity + 1 > availableStock)
                    {
                        MessageBox.Show("Không đủ sản phẩm để thêm vào giỏ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;  // Không thêm sản phẩm vào giỏ hàng
                    }

                    // Nếu đủ, tăng số lượng sản phẩm lên
                    item.SubItems[4].Text = (currentQuantity + 1).ToString();
                    item.SubItems[5].Text = (int.Parse(item.SubItems[4].Text) * product.DonGia_P).ToString();
                    UpdateTotal();
                    return;
                }
            }

            // Nếu sản phẩm chưa có trong giỏ, thêm mới
            ListViewItem newItem = new ListViewItem(product.MaHang_P);  // Cột 0: Mã sản phẩm
            newItem.SubItems.Add(product.TenHang_P);         // Cột 1: Tên sản phẩm
            newItem.SubItems.Add(product.DonGia_P.ToString());         // Cột 2: Giá sản phẩm
            newItem.SubItems.Add("0");         // Cột 3: Khuyến mãi
            newItem.SubItems.Add("1");                              // Cột 4: Số lượng (Mặc định 1)
            newItem.SubItems.Add(product.DonGia_P.ToString());         // Cột 5: Thành tiền

            // Lấy số lượng sản phẩm trong kho
            int availableStockNew = BLL_HH.sl_ton(int.Parse(product.MaHang_P));

            // Kiểm tra nếu số lượng sản phẩm ban đầu lớn hơn số lượng sẵn có
            if (1 > availableStockNew)
            {
                MessageBox.Show("Sản phẩm này hết hàng, không thể thêm vào giỏ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            lstbanhang.Items.Add(newItem);
            UpdateTotal();  // Cập nhật tổng tiền hóa đơn
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
            foreach(ListViewItem item in lstbanhang.Items)
            {
                total += float.Parse(item.SubItems[5].Text);
            }    
            lbltongtien.Text = $"{total:N0} đ";
            if(txtsdt.TextLength!=0)
            {
                txtkhuyenmai.Text = BLL_KhachHang.giamgia(total).ToString();
            }    
            else
            {
                txtkhuyenmai.Text = "0";
            }
            txtthanhtoan.Text = (total - float.Parse(txtkhuyenmai.Text)).ToString();
        }
        
        private void ThanhToanHoaDon()
        {
            HoaDon hd_ma = new HoaDon(user, pass, sever, data);
            if (txttienthua.Text == "Không đủ")
            {
                MessageBox.Show("Không đủ để thanh toán hóa đơn");
            }
            else
            {
                try
                {
                    // 1. Tạo mã hóa đơn mới
                    string maHoaDon ="HD"+ DateTime.Today.ToString("ddMMyy") + string.Format("{0:000}", hd_ma.GenerateMaHoaDon());
                    string ngayLap = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");


                    // Lưu thông tin khách hàng nếu có
                    if(txtsdt.TextLength!=0)
                    {
                        KhachHang_DTO kh = new KhachHang_DTO(txttenkh.Text, txtdiachi.Text, txtsdt.Text);
                        try
                        {
                            if(BLL_KhachHang.kiemtra_tontai(txtsdt.Text)==false)
                            {
                                BLL_KhachHang.them(kh);
                            }                           

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi--> " + ex.Message);
                            return;
                        }
                    }    
                    //// 2. Lưu thông tin hóa đơn vào cơ sở dữ liệu
                    BanHang_BLL BLL_BanHang =new BanHang_BLL();
                    HoaDon_DTO hd = new HoaDon_DTO(maHoaDon,ngayLap, user);
                    string kq = BLL_BanHang.luu_hd(hd);
                    if(kq=="true")
                    {
                        //MessageBox.Show("Lưu hóa đơn thành công");
                    }
                    else
                    {
                        MessageBox.Show("Lỗi--> "+kq);
                        return;
                    }

                    // Lưu chi tiết hóa đơn vào bảng ChiTietHoaDon
                    try
                    {
                        foreach (ListViewItem item in lstbanhang.Items)
                        {
                            string masp = item.SubItems[0].Text;
                            string donGia = item.SubItems[2].Text;
                            string soLuong = item.SubItems[4].Text;

                            ChiTietHoaDon_DTO cthd = new ChiTietHoaDon_DTO(masp, soLuong, donGia);
                            BLL_BanHang.luu_cthd(cthd);
                           

                        }
                        //MessageBox.Show("Lưu chi tiết hóa đơn thành công");
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Lỗi--> "+ex.Message);
                        return;
                    }
                    // 3. Thông báo thanh toán thành công
                    MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 4. Gọi chức năng in hóa đơn
                    ShowInvoicePreview(maHoaDon, ngayLap);
                    InHoaDon(maHoaDon, ngayLap);




                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra khi thanh toán: " + ex.Message);
                    return;
                }
            }

        }
        private void btnthanhtoan_Click(object sender, EventArgs e)
        {
            ThanhToanHoaDon();
            LoadProducts();
            btnhuy_Click(sender, e);

        }
        private Bitmap GenerateInvoicePreview(string maHoaDon, string ngayLap)
        {
            // Kích thước của Bitmap (tùy chỉnh theo kích thước hóa đơn)
            int width = 900;
            int height = 1000;

            // Tạo Bitmap
            Bitmap invoiceBitmap = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(invoiceBitmap))
            {
                g.Clear(System.Drawing.Color.White);

                // Vẽ nội dung hóa đơn lên Bitmap
                System.Drawing.Font titleFont = new System.Drawing.Font("Arial", 26, FontStyle.Bold);
                System.Drawing.Font subTitleFont = new System.Drawing.Font("Arial", 18, FontStyle.Regular);
                System.Drawing.Font contentFont = new System.Drawing.Font("Arial", 15);

                // Thêm tiêu đề
                string storeTitle = "CỬA HÀNG MẮT KÍNH";
                string invoiceTitle = "HÓA ĐƠN THANH TOÁN";

                SizeF storeTitleSize = g.MeasureString(storeTitle, subTitleFont);
                SizeF invoiceTitleSize = g.MeasureString(invoiceTitle, titleFont);

                float centerXStore = (width - storeTitleSize.Width) / 2;
                float centerXInvoice = (width - invoiceTitleSize.Width) / 2;

                g.DrawString(storeTitle, subTitleFont, Brushes.Black, new PointF(centerXStore, 20));
                g.DrawString(invoiceTitle, titleFont, Brushes.Black, new PointF(centerXInvoice, 50));

                // Thêm thông tin mã hóa đơn và ngày lập
                g.DrawString($"Mã hóa đơn: {maHoaDon}", contentFont, Brushes.Black, new PointF(50, 100));
                g.DrawString($"Ngày lập: {ngayLap}", contentFont, Brushes.Black, new PointF(width - 400, 100));

                // Thêm bảng chi tiết sản phẩm
                Pen blackPen = new Pen(System.Drawing.Color.Black, 1);
                float startX = 50;
                float startY = 150;
                float columnWidth1 = 50;  // Chiều rộng cột STT
                float columnWidth2 = 220; // Chiều rộng cột Tên Sản Phẩm
                float columnWidth3 = 120; // Chiều rộng cột Đơn Giá
                float columnWidth4 = 100; // Chiều rộng cột Số Lượng
                float columnWidth5 = 120; // Chiều rộng cột Khuyến Mãi
                float columnWidth6 = 140; // Chiều rộng cột Thành Tiền

                // Vẽ tiêu đề các cột
                g.DrawRectangle(blackPen, startX, startY, columnWidth1 + columnWidth2 + columnWidth3 + columnWidth4 + columnWidth5 + columnWidth6, 30);
                g.DrawString("STT", contentFont, Brushes.Black, new PointF(startX + 5, startY + 5));
                g.DrawString("Tên Sản Phẩm", contentFont, Brushes.Black, new PointF(startX + columnWidth1 + 5, startY + 5));
                g.DrawString("Đơn Giá", contentFont, Brushes.Black, new PointF(startX + columnWidth1 + columnWidth2 + 5, startY + 5));
                g.DrawString("Số Lượng", contentFont, Brushes.Black, new PointF(startX + columnWidth1 + columnWidth2 + columnWidth3 + 5, startY + 5));
                g.DrawString("Khuyến Mãi", contentFont, Brushes.Black, new PointF(startX + columnWidth1 + columnWidth2 + columnWidth3 + columnWidth4 + 5, startY + 5));
                g.DrawString("Thành Tiền", contentFont, Brushes.Black, new PointF(startX + columnWidth1 + columnWidth2 + columnWidth3 + columnWidth4 + columnWidth5 + 5, startY + 5));

                int stt = 1;
                float yPos = startY + 30;

                // Giả sử bạn có một danh sách sản phẩm trong lstbanhang (ListView)
                foreach (ListViewItem item in lstbanhang.Items)
                {
                    string tenSanPham = item.SubItems[1].Text;
                    string donGia = item.SubItems[2].Text;
                    string soLuong = item.SubItems[4].Text;
                    string khuyenMai = item.SubItems[3].Text;
                    string thanhTien = item.SubItems[5].Text;

                    // Vẽ đường viền cho từng dòng chi tiết
                    g.DrawRectangle(blackPen, startX, yPos, columnWidth1 + columnWidth2 + columnWidth3 + columnWidth4 + columnWidth5 + columnWidth6, 30);
                    g.DrawString(stt.ToString(), contentFont, Brushes.Black, new PointF(startX + 5, yPos + 5));
                    g.DrawString(tenSanPham, contentFont, Brushes.Black, new PointF(startX + columnWidth1 + 5, yPos + 5));
                    g.DrawString(donGia, contentFont, Brushes.Black, new PointF(startX + columnWidth1 + columnWidth2 + 5, yPos + 5));
                    g.DrawString(soLuong, contentFont, Brushes.Black, new PointF(startX + columnWidth1 + columnWidth2 + columnWidth3 + 5, yPos + 5));
                    g.DrawString(khuyenMai, contentFont, Brushes.Black, new PointF(startX + columnWidth1 + columnWidth2 + columnWidth3 + columnWidth4 + 5, yPos + 5));
                    g.DrawString(thanhTien, contentFont, Brushes.Black, new PointF(startX + columnWidth1 + columnWidth2 + columnWidth3 + columnWidth4 + columnWidth5 + 5, yPos + 5));

                    yPos += 30;
                    stt++;
                }

                // Tổng kết hóa đơn
                yPos += 20;
                string totalString = $"Tổng Tiền: {total:000}đ";
                g.DrawString(totalString, contentFont, Brushes.Black, new PointF(width - 350, yPos));

                string discount = $"Tiền khuyến mãi: {float.Parse(txtkhuyenmai.Text):000}đ";
                g.DrawString(discount, contentFont, Brushes.Black, new PointF(width - 350, yPos+30));

                string pay = $"Thanh toán: {float.Parse(txtthanhtoan.Text):000}đ";
                g.DrawString(pay, contentFont, Brushes.Black, new PointF(width - 350, yPos+60));

                string tienKhachTraString = $"Tiền Khách Trả: {txttienkhachtra.Text}đ";
                g.DrawString(tienKhachTraString, contentFont, Brushes.Black, new PointF(width - 350, yPos + 90));

                string tienThuaString = $"Tiền Thừa: {txttienthua.Text}đ";
                g.DrawString(tienThuaString, contentFont, Brushes.Black, new PointF(width - 350, yPos + 120));

                // Thêm lời cảm ơn
                string thankYouText = "Cảm ơn quý khách đã mua sắm tại cửa hàng!";
                SizeF textSize = g.MeasureString(thankYouText, contentFont);
                float centerX = (width - textSize.Width) / 2;
                g.DrawString(thankYouText, contentFont, Brushes.Black, new PointF(centerX, yPos + 160));
            }

            return invoiceBitmap;
        }
        private void ShowInvoicePreview(string maHoaDon, string ngayLap)
        {
            Bitmap invoiceBitmap = GenerateInvoicePreview(maHoaDon, ngayLap);
            frmPrintPreview previewForm = new frmPrintPreview(invoiceBitmap);
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

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            txttentimkiem.Clear();
            LoadProducts();
        }
        public void timkiemsp_theoten()
        {
            flowLayoutPanelProducts.Controls.Clear();
            // Giả sử có danh sách các sản phẩm
            List<HangHoa_DTO> products = BLL_HH.search(txttentimkiem.Text, cbogiadau.Text, cbogiacuoi.Text); // Phương thức lấy danh sách sản phẩm.

            // Thêm từng sản phẩm vào FlowLayoutPanel
            foreach (var product in products)
            {
                Panel panel = new Panel
                {
                    Size = new Size(150, 200), // Kích thước mỗi sản phẩm
                    BorderStyle = BorderStyle.FixedSingle
                };

                // Thêm ảnh sản phẩm
                string fileName = product.Hinh_P;
                //Lấy đường dẫn tới thư mục hiện tại của ứng dụng (thường là Debug hoặc Release khi chạy từ Visual Studio).
                string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
                //Lùi về một cấp để thoát khỏi thư mục Debug hoặc Release, lấy thư mục gốc của dự án.
                projectDirectory = System.IO.Directory.GetParent(projectDirectory).Parent.Parent.FullName;

                // Kết hợp đường dẫn với thư mục Images
                string imagePath = System.IO.Path.Combine(projectDirectory, "Images", fileName);
                if (!string.IsNullOrEmpty(imagePath) && System.IO.File.Exists(imagePath))
                {
                    pictureBox1.Image = Image.FromFile(imagePath);
                }
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

                // Thêm sự kiện khi click vào panel
                panel.Click += (sender, e) => AddToInvoice(product);

                // Thêm panel vào FlowLayoutPanel
                flowLayoutPanelProducts.Controls.Add(panel);
            }
        }
        private void btnapdung_Click(object sender, EventArgs e)
        {
            timkiemsp_theoten();

        }

        private void cbogiadau_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbogiacuoi.Text!="" && float.Parse(cbogiadau.Text)>float.Parse(cbogiacuoi.Text))
            {
                MessageBox.Show("Giá đầu không được lớn hơn giá cuối");
                cbogiadau.SelectedIndex = 0;
            }
        }

        private void cbogiacuoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbogiadau.Text != "" && float.Parse(cbogiadau.Text) > float.Parse(cbogiacuoi.Text))
            {
                MessageBox.Show("Giá cuối không được nhỏ hơn giá giá đầu");
                cbogiacuoi.SelectedIndex = 0;
            }
        }
        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int Msg, int wParam, int lParam);
        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void InHoaDon(string maHoaDon, string ngayLap)
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += (sender, e) => printDocument_PrintPage(sender, e, maHoaDon, ngayLap);

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }
        NhanVien_BLL BLL_NV = new NhanVien_BLL();



        private void btnPhanQuyen_Click(object sender, EventArgs e)
        {
            //frmPhanQuyen frm = new frmPhanQuyen();
            //frm.ShowDialog();
            OpenChildForm(new frmPhanQuyen(user, pass, sever, data));
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            total = 0;
            lstbanhang.Items.Clear();
            txttienkhachtra.Clear();
            txttienthua.Clear();
            lbltongtien.Text = "";
            txtthanhtoan.Clear();
            txtkhuyenmai.Clear();
        }

        private void panelButtonBanHang_Paint(object sender, PaintEventArgs e)
        {

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

        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lstbanhang.Items)
            {
                if (item.SubItems[0].Text == txtmasp.Text)
                {
                    if (int.Parse(txtsl.Text)> BLL_HH.sl_ton(int.Parse(txtmasp.Text)))
                    {
                        MessageBox.Show("Số lượng không đủ để đáp ứng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    item.SubItems[4].Text = txtsl.Text;
                    item.SubItems[5].Text = (float.Parse(item.SubItems[2].Text) * int.Parse(txtsl.Text)).ToString();
                }
            }
            UpdateTotal();
        }

        private void AppForAdmin_Click(object sender, EventArgs e)
        {

        }

        private void lstbanhang_Click(object sender, EventArgs e)
        {
            txtmasp.Text = lstbanhang.SelectedItems[0].SubItems[0].Text;
            txtsl.Text = lstbanhang.SelectedItems[0].SubItems[4].Text;
        }

        private void AppForAdmin_Load(object sender, EventArgs e)
        {
            txtkhuyenmai.Text = "0";
            lstbanhang.ContextMenuStrip = contextMenuStrip1;
        }



        private Form currentChildForm;
        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelMainDesktop.Controls.Add(childForm);
            panelMainDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

    }
}
