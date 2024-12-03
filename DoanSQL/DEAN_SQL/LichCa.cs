using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Office2013.Excel;
using DTO;

namespace DEAN_SQL
{
    public partial class LichCa : Form
    {
        LichCa_BLL BLL = new LichCa_BLL();
        public string user, pass, server, data, connectionString;

        private void lst_dl_Click(object sender, EventArgs e)
        {
            txtmaca.Text = lst_dl.SelectedItems[0].SubItems[0].Text;
            txttenca.Text = lst_dl.SelectedItems[0].SubItems[1].Text;
            txttgbd.Text = lst_dl.SelectedItems[0].SubItems[2].Text;
            txttgkt.Text = lst_dl.SelectedItems[0].SubItems[3].Text;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if (txtmaca.Text != "")
            {
                try
                {
                    LichCa_DTO lc = new LichCa_DTO(txtmaca.Text, txttenca.Text, txttgbd.Text, txttgkt.Text);
                    string kq = BLL.them(lc);
                    if (kq == "true")
                    {
                        lst_dl.Items.Clear();
                        display();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi-->" + kq + "", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Mã hóa đơn không được đễ trống", "Thông báo");
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            try
            {
                LichCa_DTO lc = new LichCa_DTO(txtmaca.Text, txttenca.Text, txttgbd.Text, txttgkt.Text);
                bool kq = BLL.xoa(lc);
                if (kq == true)
                {
                    lst_dl.Items.Clear();
                    BLL.xoa(lc);
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
                LichCa_DTO lc = new LichCa_DTO(txtmaca.Text, txttenca.Text, txttgbd.Text, txttgkt.Text);
                string kq = BLL.sua(lc);
                if (kq == "true")
                {
                    lst_dl.Items.Clear();
                    display();
                }
                else
                {
                    MessageBox.Show("Lỗi-->" + kq + "", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtmaca.Clear();
            txttenca.Clear();
            txttgbd.Clear();
            txttgkt.Clear();
        }

        private void lst_dl_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public LichCa(string username, string password, string servername, string database)
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
            try
            {
                foreach (LichCa_DTO lc in BLL.display())
                {
                    ListViewItem item = new ListViewItem(lc.MaCA_P);
                    item.SubItems.Add(lc.TenCA_P);
                    item.SubItems.Add(lc.TGBD_P.ToString());
                    item.SubItems.Add(lc.TGKT_P.ToString());
                    lst_dl.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi-->" + ex.Message + "", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }
        private void LichCa_Load(object sender, EventArgs e)
        {
            display();
        }
    }
}
