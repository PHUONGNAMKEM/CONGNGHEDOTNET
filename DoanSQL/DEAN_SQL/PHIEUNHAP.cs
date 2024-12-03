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
using BLL;
using DTO;
using System.Globalization;

namespace DEAN_SQL
{
    public partial class PHIEUNHAP : Form
    {
        PhieuNhap_BLL BLL = new PhieuNhap_BLL();
        public string user, pass, server, data, connectionString;
        public PHIEUNHAP(string username, string password, string servername, string database)
        {
            InitializeComponent();
            user = username;
            pass = password;
            server = servername;
            data = database;
            Login_DTO login = new Login_DTO(username, password, servername, database);
            BLL.login(login);
        }
        private void PHIEUNHAP_Load(object sender, EventArgs e)
        {
            display();
        }
        public void display()
        {
            try
            {
                foreach (PhieuNhap_DTO pn in BLL.display())
                {
                    ListViewItem item = new ListViewItem(pn.MaPN_P);
                    item.SubItems.Add(pn.NgayNhap_P);
                    item.SubItems.Add(pn.MaNCC_P);
                    item.SubItems.Add(pn.MANV_P);
                    lst_dl.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi-->" + ex.Message + "", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if (txtmapn.TextLength != 0)
            {
                try
                {
                    PhieuNhap_DTO pn = new PhieuNhap_DTO(txtmapn.Text, txtngaynhap.Text, txtmancc.Text, txtmanv.Text);
                    bool kq = BLL.them(pn);
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
                MessageBox.Show("Mã phiếu nhập không được đễ trống", "Thông báo");
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            try
            {
                PhieuNhap_DTO pn = new PhieuNhap_DTO(txtmapn.Text, txtngaynhap.Text, txtmancc.Text, txtmanv.Text);
                bool kq = BLL.xoa(pn);
                if (kq == true)
                {
                    lst_dl.Items.Clear();
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
                PhieuNhap_DTO pn = new PhieuNhap_DTO(txtmapn.Text, txtngaynhap.Text, txtmancc.Text, txtmanv.Text);
                bool kq = BLL.sua(pn);
                if (kq == true)
                {
                    lst_dl.Items.Clear();
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

        private void lst_dl_Click(object sender, EventArgs e)
        {
            txtmapn.Text = lst_dl.SelectedItems[0].SubItems[0].Text;
            txtngaynhap.Text = lst_dl.SelectedItems[0].SubItems[1].Text;
            txtmancc.Text = lst_dl.SelectedItems[0].SubItems[2].Text;
            txtmanv.Text = lst_dl.SelectedItems[0].SubItems[3].Text;
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtmancc.Clear();
            txtmanv.Clear();
            txtmapn.Clear();
            txtngaynhap.Clear();
        }
        public int GenerateMaPhieuNhap()
        {
            display();
            DateTime ngay = DateTime.Today;
            string ma = ngay.ToString("yyyy-MM-dd");
            int count = 0;
          
            foreach (ListViewItem item in lst_dl.Items)
            {
                // Chuyển đổi chuỗi thành DateTime và chỉ lấy phần ngày để so sánh
                if (DateTime.TryParse(item.SubItems[1].Text, out DateTime ngayNhap))
                {
                    if (ngayNhap.Date == ngay.Date) // So sánh chỉ phần ngày
                    {
                        count++;
                    }
                }
            }

            return count + 1;
        }


    }
}
