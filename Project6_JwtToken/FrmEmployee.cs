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
    public partial class FrmEmployee : Form
    {
        public FrmEmployee()
        {
            InitializeComponent();
        }//

        SqlConnection sqlConnection = new SqlConnection("Server=EMIRHAN\\SQLEXPRESS;initial catalog=Db6Project8;integrated security=true");
        private void FrmEmployee_Load(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("Select * From  TblEmployee", sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            sqlConnection.Close();
        }
    }
}
