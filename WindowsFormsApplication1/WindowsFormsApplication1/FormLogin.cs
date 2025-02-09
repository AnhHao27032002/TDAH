﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btn_dangnhap_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=ANHHAO\SQLSEVER2012;Initial Catalog=QUANLYKHACHSAN;Integrated Security=True");
            string username = txt_username.Text;
            string password = txt_password.Text;
            if (username == null || username.Equals(""))
            {
                MessageBox.Show("Tài khoản không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (password == null || password.Equals(""))
            {
                MessageBox.Show("Mật khẩu không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            con.Open();
            string sql = "SELECT * FROM NHANVIEN WHERE USERNAME = '" + username + "' AND PASS = '" + password + "'";
            SqlCommand perform = new SqlCommand(sql, con);
            SqlDataReader doc = perform.ExecuteReader();
            if (doc.Read())
            {
                MessageBox.Show("Đăng nhập thành công!\nXin chào " + username, "Đăng nhập thành công!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FormMAIN frmMAIN = new FormMAIN();
                frmMAIN.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác", "Đăng nhập thất bại!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r; r = MessageBox.Show(
                "Bạn có muốn thoát?",
                "Thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
                e.Cancel = true;
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

    }
}
