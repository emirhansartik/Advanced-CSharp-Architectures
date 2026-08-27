using Dapper;
using Project1_DapperNorthwind.Dtos.CategoryDtos;
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

namespace Project1_DapperNorthwind
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
             SqlConnection connection = new SqlConnection("Server=EMIRHAN\\SQLEXPRESS;initial catalog=Db1Project8_Northwind;integrated security=true");

        private async void btnCategoryList_Click(object sender, EventArgs e)
        {
            string query = "Select * From Categories";
            var values = await connection.QueryAsync<ResultCategoryDto>(query);
            dataGridView1.DataSource = values;

        }

        private async void btnCreateCategory_Click(object sender, EventArgs e)
        {
            string query = "insert into Categories (CategoryName,Description) Values (@p1,@p2)";
            var parameteres = new DynamicParameters();
            parameteres.Add("@p1", txtCategoryDescription.Text);
            parameteres.Add("@p2", txtCategoryName.Text);
            await connection.ExecuteAsync(query, parameteres);
        }

        private async void btnCategoryDelete_Click(object sender, EventArgs e)
        {
            string query = "Delete From Categories Where CategoryId=@categoryId";
            var parameteres = new DynamicParameters();
            parameteres.Add("@categoryId", txtCategoryId.Text);
            await connection.ExecuteAsync(query, parameteres);
            MessageBox.Show("Başarıyla silindi");

        }

        private async void btnCategoryUpdate_Click(object sender, EventArgs e)
        {
            string query = "Update Categories Set CategoryName = @categoryName, Description=@description Where CategoryId = @categoryId";
            var parameteres = new DynamicParameters();
            parameteres.Add("@categoryName", txtCategoryName.Text);
            parameteres.Add("@description", txtCategoryDescription.Text);
            parameteres.Add("@categoryId", txtCategoryId.Text);
            await connection.ExecuteAsync(query, parameteres);
            MessageBox.Show("Başarıyla güncellendi");
        }
    }
}
