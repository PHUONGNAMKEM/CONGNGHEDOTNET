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
using DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DEAN_SQL
{
    public partial class ChamCong : Form
    {
        ChamCong_BLL BLL = new ChamCong_BLL();
        public string user, pass, server, data, connectionString;

        private void lst_dl_Click(object sender, EventArgs e)
        {
            cbomanv.SelectedValue = lst_dl.SelectedItems[0].SubItems[0].Text;
            cbomaca.SelectedValue = lst_dl.SelectedItems[0].SubItems[1].Text;
            txtngaylam.Text = lst_dl.SelectedItems[0].SubItems[2].Text;
            txttgvao.Text = lst_dl.SelectedItems[0].SubItems[3].Text;
            txttgra.Text = lst_dl.SelectedItems[0].SubItems[4].Text;
            txtghichu.Text = lst_dl.SelectedItems[0].SubItems[5].Text;
        }

        public ChamCong(string username, string password, string servername, string database)
        {
            InitializeComponent();
            user = username;
            pass = password;
            server = servername;
            data = database;
            Login_DTO login = new Login_DTO(username, password, servername, database);
            BLL.login(login);
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if (cbomanv.Text != "")
            {
                try
                {
                    ChamCong_DTO cc = new ChamCong_DTO(cbomanv.SelectedValue.ToString(), cbomaca.SelectedValue.ToString(), txtngaylam.Text, txttgvao.Text, txttgra.Text, txtghichu.Text);
                    string kq = BLL.them(cc);
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
                ChamCong_DTO cc = new ChamCong_DTO(cbomanv.SelectedValue.ToString(), cbomaca.SelectedValue.ToString(), txtngaylam.Text, txttgvao.Text, txttgra.Text, txtghichu.Text);
                bool kq = BLL.xoa(cc);
                if (kq == true)
                {
                    lst_dl.Items.Clear();
                    BLL.xoa(cc);
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
                ChamCong_DTO cc = new ChamCong_DTO(cbomanv.SelectedValue.ToString(), cbomaca.SelectedValue.ToString(), txtngaylam.Text, txttgvao.Text, txttgra.Text, txtghichu.Text,item.SubItems[0].Text, item.SubItems[1].Text, item.SubItems[2].Text);
                string kq = BLL.sua(cc);
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
            txtghichu.Clear();
            txtngaylam.Clear();
            txttgra.Clear();
            txttgvao.Clear();
        }

        public void load_manv()
        {
            try
            {
                cbomanv.DataSource = BLL.getall_manv();
                cbomanv.DisplayMember = "TenNV_P";
                cbomanv.ValueMember = "MaNV_P";
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi-->" + ex.Message + "", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        public void load_malichca()
        {
            try
            {
                cbomaca.DataSource = BLL.getall_lichca();
                cbomaca.DisplayMember = "TenCA_P";
                cbomaca.ValueMember = "MaCA_P";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi-->" + ex.Message + "", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
        public void display()
        {
            try
            {
                foreach (ChamCong_DTO cc in BLL.display())
                {
                    ListViewItem item = new ListViewItem(cc.MaNV_P);
                    item.SubItems.Add(cc.MaCA_P);
                    item.SubItems.Add(cc.NgayLam_P);
                    item.SubItems.Add(cc.TGVAO_P);
                    item.SubItems.Add(cc.TGRA_P);
                    item.SubItems.Add(cc.GhiChu_P);
                    lst_dl.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi-->" + ex.Message + "", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
        private void ChamCong_Load(object sender, EventArgs e)
        {
            load_manv();
            load_malichca();
            display();
        }
    }
}
