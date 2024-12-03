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
using DAL;
using DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DEAN_SQL
{
    public partial class TinhLuong : Form
    {
        TinhLuong_BLL BLL = new TinhLuong_BLL();

        public string user, pass, server, data, connectionString;

        private void btntracuu_Click(object sender, EventArgs e)
        {
            lst_dl.Items.Clear();
            display();
        }

        public TinhLuong(string username, string password, string servername, string database)
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
                foreach (TinhLuong_DTO tl in BLL.display(cbongay.Text, cbothang.Text, cbonam.Text))
                {
                    ListViewItem item = new ListViewItem(tl.MaNV_P);
                    item.SubItems.Add(tl.TenNV_P);
                    item.SubItems.Add(tl.SoGioLam_P);
                    item.SubItems.Add(tl.TongLuong_P);
                    lst_dl.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi-->" + ex.Message + "", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void TinhLuong_Load(object sender, EventArgs e)
        {
            cbongay.Text=DateTime.Today.Day.ToString();
            cbothang.Text = DateTime.Today.Month.ToString();
            cbonam.Text = DateTime.Today.Year.ToString();
            display();
        }
    }
}
