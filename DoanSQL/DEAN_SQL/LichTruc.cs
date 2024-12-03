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
    public partial class LichTruc : Form
    {
        LichTruc_BLL BLL = new LichTruc_BLL();

        public string user, pass, server, data, connectionString;
        public LichTruc(string username, string password, string servername, string database)
        {
            InitializeComponent();
            user = username;
            pass = password;
            server = servername;
            data = database;
            Login_DTO login = new Login_DTO(username, password, servername, database);
            BLL.login(login);
        }

        private void lst_dl_Click(object sender, EventArgs e)
        {
            cbomanv.SelectedValue = lst_dl.SelectedItems[0].SubItems[0].Text;
            cbomaca.SelectedValue = lst_dl.SelectedItems[0].SubItems[1].Text;
            txtngaytruc.Text = lst_dl.SelectedItems[0].SubItems[2].Text;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if (cbomanv.Text != "")
            {
                try
                {
                    LichTruc_DTO lt = new LichTruc_DTO(cbomanv.SelectedValue.ToString(), cbomaca.SelectedValue.ToString(), txtngaytruc.Text);
                    string kq = BLL.them(lt);
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
                LichTruc_DTO lt = new LichTruc_DTO(cbomanv.SelectedValue.ToString(), cbomaca.SelectedValue.ToString(), txtngaytruc.Text);
                bool kq = BLL.xoa(lt);
                if (kq == true)
                {
                    lst_dl.Items.Clear();
                    BLL.xoa(lt);
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
                LichTruc_DTO lt = new LichTruc_DTO(cbomanv.SelectedValue.ToString(), cbomaca.SelectedValue.ToString(), txtngaytruc.Text, item.SubItems[0].Text, item.SubItems[1].Text, item.SubItems[2].Text);
                string kq = BLL.sua(lt);
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
            txtngaytruc.Clear();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void grpnhapthongtinlichtruc_Enter(object sender, EventArgs e)
        {

        }

        private void grpthongtinlichtruc_Enter(object sender, EventArgs e)
        {

        }

        public void load_manv()
        {
            try
            {
                cbomanv.DataSource = BLL.getall_manv();
                cbomanv.DisplayMember = "TenNV_P";
                cbomanv.ValueMember = "MaNV_P";
            }
            catch (Exception ex)
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
                foreach (LichTruc_DTO lt in BLL.display())
                {
                    ListViewItem item = new ListViewItem(lt.MaNV_P);
                    item.SubItems.Add(lt.MaCA_P);
                    item.SubItems.Add(lt.NgayTruc_P);
                    lst_dl.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi-->" + ex.Message + "", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }
        private void LichTruc_Load(object sender, EventArgs e)
        {
            load_manv();
            load_malichca();
            display();
        }

    }
}
