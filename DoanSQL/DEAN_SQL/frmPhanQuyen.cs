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
using BLL;
using ClosedXML.Excel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DEAN_SQL
{
    public partial class frmPhanQuyen : Form
    {
        UserBLL userBLL = new UserBLL();
        PhanQuyen_BLL phanquyenBLL = new PhanQuyen_BLL();
        QuyenCuaUser_BLL quyencua_userBLL = new QuyenCuaUser_BLL();
        public string user, pass, server, data;
        string quyenduoccap = "";
        public frmPhanQuyen(string username, string password, string servername, string database)
        {
            InitializeComponent();
            user = username;
            pass = password;
            server = servername;
            data = database;
            Login_DTO login = new Login_DTO(username, password, servername, database);
            phanquyenBLL.login(login);
            quyencua_userBLL.login(login);
        }

        private void btnphanquyen_Click(object sender, EventArgs e)
        {
            // Gọi thủ tục phân quyền
            string username = cbousername.Text;
            string table = cbotable.Text;

            //userBLL.GrantPermissions(username, table, quyenduoccap);


            // Phân quyền mới ở đây
            // Lấy ra câu lệnh phân quyền (grant...) ở đây
            phanquyenBLL.layQuyen_For_PhanQuyen(int.Parse(cbotatcaquyen.SelectedValue.ToString()));

            bool ketQuaPhanQuyen = phanquyenBLL.phanQuyen_For_User(int.Parse(cbotatcaquyen.SelectedValue.ToString()), cbousername.SelectedValue.ToString());
            if (ketQuaPhanQuyen == false)
            {
                MessageBox.Show("Phân quyền thất bại!");
                return;
            }

            else
            {
                MessageBox.Show("Phân quyền thành công!");
            }
        }
        // Phân quyền mới ở đây
        public void loadAllQuyen()
        {
            cbotatcaquyen.DataSource = phanquyenBLL.display();
            cbotatcaquyen.DisplayMember = "MoTa";
            cbotatcaquyen.ValueMember = "MaQuyen";
        }

        public void loadQuyenUser()
        {
            dgvtatcaquyencua_user.DataSource = quyencua_userBLL.display(cbousername.SelectedValue.ToString());
        }

        public void loadUser()
        {
            cbousername.DataSource = userBLL.GetAllUsers();
        }

        public void loadTable()
        {
            cbotable.DataSource = userBLL.GetAllTables();
        }
        public void loadStaff()
        {
            cbomanv.DataSource = userBLL.GetAllStaff();
            cbomanv.DisplayMember= "TenNV_P";
            cbomanv.ValueMember = "MaNV_P";
        }


        private void frmPhanQuyen_Load(object sender, EventArgs e)
        {        
            loadUser();
            loadTable();
            loadStaff();
            loadAllQuyen();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void UpdatePermissions()
        {
            quyenduoccap = "";

            // Kiểm tra trạng thái của các checkbox và cập nhật chuỗi quyền
            if (chkSelect.Checked)
            {
                quyenduoccap += "SELECT";
            }

            if (chkInsert.Checked)
            {
                if (!string.IsNullOrEmpty(quyenduoccap))
                {
                    quyenduoccap += ", ";
                }
                quyenduoccap += "INSERT";
            }

            if (chkUpdate.Checked)
            {
                if (!string.IsNullOrEmpty(quyenduoccap))
                {
                    quyenduoccap += ", ";
                }
                quyenduoccap += "UPDATE";
            }

            if (chkDelete.Checked)
            {
                if (!string.IsNullOrEmpty(quyenduoccap))
                {
                    quyenduoccap += ", ";
                }
                quyenduoccap += "DELETE";
            }
        }

        private void btnselect_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePermissions();
        }

        private void btninsert_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePermissions();
        }

        private void btndelete_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePermissions();
        }

        private void btnupdate_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePermissions();
        }

        private void btnthuhoiquyen_Click(object sender, EventArgs e)
        {
            // Phân quyền mới ở đây
            // Lấy ra câu lệnh phân quyền (grant...) ở đây
            phanquyenBLL.layQuyen_For_ThuHoiQuyen(int.Parse(cbotatcaquyen.SelectedValue.ToString()));

            bool ketQuaPhanQuyen = phanquyenBLL.thuHoiQuyen_For_User(int.Parse(cbotatcaquyen.SelectedValue.ToString()), cbousername.SelectedValue.ToString());
            if (ketQuaPhanQuyen == false)
            {
                MessageBox.Show("Thu hồi quyền thất bại!");
                return;
            }

            else
            {
                MessageBox.Show("Thu hồi quyền thành công!");
            }
        }

        private void btnxemquyen_Click(object sender, EventArgs e)
        {
            loadQuyenUser();
        }

        private void cbousername_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbomanv_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btncaptk_Click(object sender, EventArgs e)
        {
            userBLL.GrantAcc(cbomanv.SelectedValue.ToString(), cbousername.Text);
        }
    }
}
