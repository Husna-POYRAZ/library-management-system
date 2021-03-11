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
    public partial class ViewBook : Form
    {
        public ViewBook()
        {
            InitializeComponent();
        }

        private void ViewBook_Load(object sender, EventArgs e)
        {
            String CS = "data source=.; database = LMSDB; integrated security=SSPI";
            using (SqlConnection con = new SqlConnection(CS))
            {

                SqlCommand cmd = new SqlCommand("select *from tblBookInfos", con);
                con.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataSet dataset = new DataSet();
                dataAdapter.Fill(dataset);
                dataGridView1.DataSource = dataset.Tables[0];
            }
        }

        private void circularPicture3_Click(object sender, EventArgs e)
        {

        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            txtBookName.Clear();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void circularPicture1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        int bkId;
        Int64 rowId;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.Rows[e.RowIndex].Cells[0].Value != null)
            {
                bkId = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            String CS = "data source=.; database = LMSDB; integrated security=SSPI";
            using (SqlConnection con = new SqlConnection(CS))
            {

                SqlCommand cmd = new SqlCommand("select *from tblBookInfos where bkId ='"+ bkId +"' ", con);
                con.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataSet dataset = new DataSet();
                dataAdapter.Fill(dataset);
                rowId = Int64.Parse(dataset.Tables[0].Rows[0][0].ToString());
                txtbkName.Text = dataset.Tables[0].Rows[0][1].ToString();
                txtbkAuthor.Text=dataset.Tables[0].Rows[0][2].ToString();
                txtbkPublication.Text = dataset.Tables[0].Rows[0][3].ToString();
                txtbkDate.Text = dataset.Tables[0].Rows[0][4].ToString();
                txtbkPrice.Text = dataset.Tables[0].Rows[0][5].ToString();
                txtbkQuantity.Text= dataset.Tables[0].Rows[0][6].ToString();
            }
        }

        private void txtBookName_TextChanged(object sender, EventArgs e)
        {
            if (txtBookName.Text != "")
            {
                String CS = "data source=.; database = LMSDB; integrated security=SSPI";
                using (SqlConnection con = new SqlConnection(CS))
                {

                    SqlCommand cmd = new SqlCommand("select *from tblBookInfos where bkName like '"+ txtBookName.Text +"%'", con);
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

                    SqlCommand cmd = new SqlCommand("select *from tblBookInfos", con);
                    con.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataSet dataset = new DataSet();
                    dataAdapter.Fill(dataset);
                    dataGridView1.DataSource = dataset.Tables[0];
                }
            }
        }

        private void btnBkInfosRefresh_Click(object sender, EventArgs e)
        {
            txtbkName.Clear();
            txtbkAuthor.Clear();
            txtbkPublication.Clear();
            txtbkDate.Clear();
            txtbkPrice.Clear();
            txtbkQuantity.Clear();
        }

        private void btnBkInfosUpdate_Click(object sender, EventArgs e)
        {
            String CS = "data source=.; database = LMSDB; integrated security=SSPI";
            using (SqlConnection con = new SqlConnection(CS))
            {
                if (MessageBox.Show("Data will be Updated. Do you Want to Confirm", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    SqlCommand cmd = new SqlCommand("update tblBookInfos set bkName ='" + txtbkName.Text + "', bkAuthor ='" + txtbkAuthor.Text + "'" +
                                       ", bkPublication ='" + txtbkPublication.Text + "', bkDate = '" + txtbkDate.Text + "', bkPrice =" + Int64.Parse(txtbkPrice.Text) + " " +
                                       ", bkQuanity =" + Int64.Parse(txtbkQuantity.Text) + " where bkId =" + rowId + " ", con);
                    con.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataSet dataset = new DataSet();
                    dataAdapter.Fill(dataset);
                    MessageBox.Show("Book which has ID =  "+bkId+ "  is Updated.", " Success" + MessageBoxButtons.OK + MessageBoxIcon.Information);
                    txtbkName.Clear();
                    txtbkAuthor.Clear();
                    txtbkPublication.Clear();
                    txtbkDate.Clear();
                    txtbkPrice.Clear();
                    txtbkQuantity.Clear();
                }
                   
            }
        }

        private void btnBkDelete_Click(object sender, EventArgs e)
        {
            String CS = "data source=.; database = LMSDB; integrated security=SSPI";
            using (SqlConnection con = new SqlConnection(CS))
            {
                if (MessageBox.Show("Data will be deleted. Do you Want to Confirm", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)==DialogResult.OK)
                {
                    SqlCommand cmd = new SqlCommand("Delete from tblBookInfos where bkId =" + rowId + " ", con);
                    con.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataSet dataset = new DataSet();
                    dataAdapter.Fill(dataset);
                    MessageBox.Show("Book which has ID =  " + bkId +  "is Deleted.", " Success" + MessageBoxButtons.OK + MessageBoxIcon.Information);
                    //txtbkName.Clear();
                    //txtbkAuthor.Clear();
                    //txtbkPublication.Clear();
                    //txtbkDate.Clear();
                    //txtbkPrice.Clear();
                    //txtbkQuantity.Clear();
                }

            }
        }
    }
}
