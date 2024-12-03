using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DTO;
using BLL;
using DocumentFormat.OpenXml.Office2010.Drawing;

namespace DEAN_SQL
{
    public partial class NHACC : Form
    {
        NhaCungCap_BLL BLL = new NhaCungCap_BLL();
        public string user, pass, server, data;
        public NHACC(string username, string password, string servername, string database)
        {
            InitializeComponent();
            user = username;
            pass = password;
            server = servername;
            data = database;
            Login_DTO login = new Login_DTO(username, password, servername, database);
            BLL.login(login);
        }
        private void NHACC_Load(object sender, EventArgs e)
        {
            display();
        }
        public void display()
        {
            try
            {
                foreach (NhaCungCap_DTO ncc in BLL.display())
                {
                    ListViewItem item = new ListViewItem(ncc.MaNCC_P);
                    item.SubItems.Add(ncc.TenNCC_P);
                    item.SubItems.Add(ncc.DiaChi_P);
                    item.SubItems.Add(ncc.SoDT_P);
                    lst_dl.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi -->" + ex.Message + "");
                return;
            }
        }

        private void lst_dl_Click(object sender, EventArgs e)
        {
            txtmancc.Text = lst_dl.SelectedItems[0].SubItems[0].Text;
            txttenncc.Text = lst_dl.SelectedItems[0].SubItems[1].Text;
            txtdiachi.Text = lst_dl.SelectedItems[0].SubItems[2].Text;
            txtsodt.Text = lst_dl.SelectedItems[0].SubItems[3].Text;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if (txtmancc.TextLength != 0)
            {
                try
                {
                    NhaCungCap_DTO ncc = new NhaCungCap_DTO(txtmancc.Text, txttenncc.Text, txtdiachi.Text, txtsodt.Text);
                    bool kq = BLL.them(ncc);
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
                MessageBox.Show("Mã nhà cung cấp không được đễ trống", "Thông báo");
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            try
            {
                NhaCungCap_DTO ncc = new NhaCungCap_DTO(txtmancc.Text, txttenncc.Text, txtdiachi.Text, txtsodt.Text);
                bool kq = BLL.xoa(ncc);
                if (kq == true)
                {
                    lst_dl.Items.Clear();
                    BLL.xoa(ncc);
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
            try
            {
                NhaCungCap_DTO kh = new NhaCungCap_DTO(item.SubItems[0].Text, txttenncc.Text, txtdiachi.Text, txtsodt.Text);
                bool kq = BLL.sua(kh);
                if (kq == true)
                {
                    lst_dl.Items.Clear();
                    BLL.sua(kh);
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

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtdiachi.Clear();
            txtmancc.Clear();
            txtsodt.Clear();
            txttenncc.Clear();
        }

    }
}
