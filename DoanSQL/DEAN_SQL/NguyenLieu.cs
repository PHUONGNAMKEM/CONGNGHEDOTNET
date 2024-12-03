using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DEAN_SQL
{
    public partial class NguyenLieu : Form
    {
        NguyenLieu_BLL BLL = new NguyenLieu_BLL();
        public string user, pass, server, data;
        public NguyenLieu(string username, string password, string servername, string database)
        {
            InitializeComponent();
            user = username;
            pass = password;
            server = servername;
            data = database;
            Login_DTO login = new Login_DTO(username, password, servername, database);
            BLL.login(login);
        }
        public void display()
        {
            foreach (NguyenLieu_DTO nl in BLL.display())
            {
                ListViewItem item = new ListViewItem(nl.MaNL_P);
                item.SubItems.Add(nl.TenNL_P);
                item.SubItems.Add(nl.SL_Ton_P);
                item.SubItems.Add(nl.DVT_P);
                item.SubItems.Add(nl.DonGia_P);
                item.SubItems.Add(nl.Hinh_P);
                lst_dl.Items.Add(item);
            }
        }

        private void NguyenLieu_Load(object sender, EventArgs e)
        {
            display();
        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            if (txtmanl.TextLength != 0)
            {
                try
                {
                    NguyenLieu_DTO nl = new NguyenLieu_DTO(txtmanl.Text, txttennl.Text,txtslton.Text,txtdvt.Text, txtdongia.Text, txthinh.Text);
                    bool kq = BLL.them(nl);
                    if (kq == true)
                    {
                        lst_dl.Items.Clear();
                        display();
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Mã nguyên liệu không được đễ trống", "Thông báo");
            }
        }

    
        private void btnxoa_Click(object sender, EventArgs e)
        {
            try
            {
                NguyenLieu_DTO nl = new NguyenLieu_DTO(txtmanl.Text, txttennl.Text, txtslton.Text, txtdvt.Text, txtdongia.Text, txthinh.Text);
                bool kq = BLL.xoa(nl);
                if (kq == true)
                {
                    lst_dl.Items.Clear();
                    BLL.xoa(nl);
                    display();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnsua_Click(object sender, EventArgs e)
        {
            ListViewItem item = lst_dl.FocusedItem;
            if (item != null)
            {
                try
                {
                    NguyenLieu_DTO nl = new NguyenLieu_DTO(txtmanl.Text, txttennl.Text, txtslton.Text, txtdvt.Text, txtdongia.Text, txthinh.Text);
                    bool kq = BLL.sua(nl);
                    if (kq == true)
                    {
                        lst_dl.Items.Clear();
                        BLL.sua(nl);
                        display();
                    }
                    else
                    {
                        MessageBox.Show("Sửa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else MessageBox.Show("Bạn hãy chọn một đối tưởng để sửa");
        }


        private void btnclear_Click(object sender, EventArgs e)
        {
            txtdongia.Clear();
            txtmanl.Clear();
            txttennl.Clear();
            txtslton.Clear();
            txtdvt.Clear();
            txthinh.Clear();

        }


        private void lst_dl_Click(object sender, EventArgs e)
        {
            txtmanl.Text = lst_dl.SelectedItems[0].SubItems[0].Text;
            txttennl.Text = lst_dl.SelectedItems[0].SubItems[1].Text;
            txtslton.Text = lst_dl.SelectedItems[0].SubItems[2].Text;
            txtdvt.Text = lst_dl.SelectedItems[0].SubItems[3].Text;
            txtdongia.Text = lst_dl.SelectedItems[0].SubItems[4].Text;
            txthinh.Text = lst_dl.SelectedItems[0].SubItems[5].Text;

            string fileName = lst_dl.SelectedItems[0].SubItems[5].Text;
            //Lấy đường dẫn tới thư mục hiện tại của ứng dụng (thường là Debug hoặc Release khi chạy từ Visual Studio).
            string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
            //Lùi về một cấp để thoát khỏi thư mục Debug hoặc Release, lấy thư mục gốc của dự án.
            projectDirectory = System.IO.Directory.GetParent(projectDirectory).Parent.Parent.FullName;

            // Kết hợp đường dẫn với thư mục Images
            string imagePath = System.IO.Path.Combine(projectDirectory, "Images_NL", fileName);
            if (!string.IsNullOrEmpty(imagePath) && System.IO.File.Exists(imagePath))
            {
                pictureBox1.Image = Image.FromFile(imagePath);
                //txthinh.Text = imagePath; // Hiển thị đường dẫn hình ảnh trong TextBox
            }
        }
        private void btnmo_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            openFileDialog.Title = "Chọn hình ảnh";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string fileName = System.IO.Path.GetFileName(filePath);

                // Thư mục gốc của dự án (không phải Debug/Release)
                string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;

                // Lùi về một cấp thư mục để thoát khỏi Debug hoặc Release
                projectDirectory = System.IO.Directory.GetParent(projectDirectory).Parent.Parent.FullName;

                // Tạo đường dẫn tới thư mục Images
                string targetFolder = System.IO.Path.Combine(projectDirectory, "Images");

                // Kiểm tra và tạo thư mục nếu chưa tồn tại
                if (!System.IO.Directory.Exists(targetFolder))
                {
                    System.IO.Directory.CreateDirectory(targetFolder);
                }

                // Sao chép file vào thư mục Images
                string destPath = System.IO.Path.Combine(targetFolder, fileName);
                if (!System.IO.File.Exists(destPath))
                {
                    try
                    {
                        System.IO.File.Copy(filePath, destPath, true);
                        txthinh.Text = fileName; // Chỉ lưu tên file
                        pictureBox1.Image = Image.FromFile(destPath); // Hiển thị hình ảnh
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi sao chép file: " + ex.Message);
                    }
                }
                else
                {
                    txthinh.Text = fileName; // Chỉ lưu tên file
                    pictureBox1.Image = Image.FromFile(destPath); // Hiển thị hình ảnh
                }

            }
        }

    }
}
