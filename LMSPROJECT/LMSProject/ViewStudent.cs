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
    public partial class ViewStudent : Form
    {
        public ViewStudent()
        {
            InitializeComponent();
        }

        private void circularPicture1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ViewStudent_Load(object sender, EventArgs e)
        {
            String CS = "data source=.; database = LMSDB; integrated security=SSPI";
            using (SqlConnection con = new SqlConnection(CS))
            {

                SqlCommand cmd = new SqlCommand("select *from tblStudentInfos", con);
                con.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataSet dataset = new DataSet();
                dataAdapter.Fill(dataset);
                dataGridView1.DataSource = dataset.Tables[0];
            }
        }
        int stId;
        Int64 rowId;
        string stNumber;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[0].Value != null)
            {
                stId = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            String CS = "data source=.; database = LMSDB; integrated security=SSPI";
            using (SqlConnection con = new SqlConnection(CS))
            {

                SqlCommand cmd = new SqlCommand("select *from tblStudentInfos where stId ='" + stId + "' ", con);
                con.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataSet dataset = new DataSet();
                dataAdapter.Fill(dataset);
                stNumber = dataset.Tables[0].Rows[0][2].ToString();
                rowId = Int64.Parse(dataset.Tables[0].Rows[0][0].ToString());
                txtStName.Text = dataset.Tables[0].Rows[0][1].ToString();
                txtStNumber.Text = dataset.Tables[0].Rows[0][2].ToString();
                txtStDepartment.Text = dataset.Tables[0].Rows[0][3].ToString();
                txtStSemester.Text = dataset.Tables[0].Rows[0][4].ToString();
                txtStContact.Text = dataset.Tables[0].Rows[0][5].ToString();
                txtStEmail.Text = dataset.Tables[0].Rows[0][6].ToString();
            }
        }

        private void txtStudentname_TextChanged(object sender, EventArgs e)
        {
            if (txtStudentname.Text != "")
            {
                String CS = "data source=.; database = LMSDB; integrated security=SSPI";
                using (SqlConnection con = new SqlConnection(CS))
                {

                    SqlCommand cmd = new SqlCommand("select *from tblStudentInfos where stName like '" + txtStudentname.Text + "%'", con);
                    con.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataSet dataset = new DataSet();
                    dataAdapter.Fill(dataset);
                    dataGridView1.DataSource = dataset.Tables[0];
                }
            }
            else
            {
                String CS = "data source=.; database = LMSDB; integrated security=SSPI";
                using (SqlConnection con = new SqlConnection(CS))
                {

                    SqlCommand cmd = new SqlCommand("select *from tblStudentInfos", con);
                    con.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataSet dataset = new DataSet();
                    dataAdapter.Fill(dataset);
                    dataGridView1.DataSource = dataset.Tables[0];
                }
            }
        }

        private void btnStNameRefresh_Click(object sender, EventArgs e)
        {
            txtStudentname.Clear();
        }

        private void btnStInofRefresh_Click(object sender, EventArgs e)
        {
            txtStName.Clear();
            txtStNumber.Clear();
            txtStDepartment.Clear();
            txtStSemester.Clear();
            txtStContact.Clear();
            txtStEmail.Clear();
        }

        private void btnStUpdate_Click(object sender, EventArgs e)
        {
            String CS = "data source=.; database = LMSDB; integrated security=SSPI";
            using (SqlConnection con = new SqlConnection(CS))
            {
                if (MessageBox.Show("Data will be Updated. Do you Want to Confirm", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    SqlCommand cmd = new SqlCommand("Update tblStudentInfos set stName ='" + txtStName.Text + "', stNumber ='" + txtStNumber.Text + "'" +
                                       ", stDepartment ='" + txtStDepartment.Text + "', stSemester = '" + txtStSemester.Text + "', stContact =" + Int64.Parse(txtStContact.Text) + " " +
                                       ", stEmail ='"+ txtStEmail.Text +"' where stId =" + rowId + " ", con);
                    con.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataSet dataset = new DataSet();
                    dataAdapter.Fill(dataset);
                    MessageBox.Show("Student who has Number =  " + stNumber + "  is Updated.", " Success" + MessageBoxButtons.OK + MessageBoxIcon.Information);
                    txtStName.Clear();
                    txtStNumber.Clear();
                    txtStDepartment.Clear();
                    txtStSemester.Clear();
                    txtStContact.Clear();
                    txtStEmail.Clear();
                }

            }
        }

        private void btnStDelete_Click(object sender, EventArgs e)
        {
            String CS = "data source=.; database = LMSDB; integrated security=SSPI";
            using (SqlConnection con = new SqlConnection(CS))
            {
                if (MessageBox.Show("Data will be deleted. Do you Want to Confirm", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    SqlCommand cmd = new SqlCommand("Delete from tblStudentInfos where stId =" + rowId + " ", con);
                    con.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataSet dataset = new DataSet();
                    dataAdapter.Fill(dataset);
                    MessageBox.Show("Student who has StudentID =  " + stNumber + "  is Deleted.", " Success" + MessageBoxButtons.OK + MessageBoxIcon.Information);
                   
                }

            }
        }
    }
}
