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

namespace LMSProject
{
    public partial class CompleteBookDetail : Form
    {
        public CompleteBookDetail()
        {
            InitializeComponent();
        }

        private void circularPicture1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void CompleteBookDetail_Load(object sender, EventArgs e)
        {
            String CS = "data source=.; database = LMSDB; integrated security=SSPI";
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = " select *from tblIssueBooks where bkReturnDate is null";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                da.Fill(dataSet);
                dataGridView1.DataSource = dataSet.Tables[0];
                /* 2nd gridview reurn book part*/
                cmd.CommandText = " select *from tblIssueBooks where bkReturnDate is not null";
                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                DataSet dataSet1 = new DataSet();
                da1.Fill(dataSet1);
                dataGridView2.DataSource = dataSet1.Tables[0];

            }
        }
    }
}
