using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project6_JwtToken
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection = new SqlConnection("Server=EMIRHAN\\SQLEXPRESS;initial catalog=Db6Project8;integrated security=true");
        private void btnLogin_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("Select * From TblUser Where Username=@username and Password=@password", sqlConnection);
            command.Parameters.AddWithValue("@username", txtUsername.Text);
            command.Parameters.AddWithValue("@password", txtPassword.Text);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            if (sqlDataReader.Read())
            {
                FrmEmployee frm = new FrmEmployee();
                frm.Show();

            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı ya da Şifre");
                txtUsername.Clear();
                txtPassword.Clear();
                txtUsername.Focus();
            }
            sqlConnection.Close();
        }
    }
}
