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
    public partial class IssueBook : Form
    {
        public IssueBook()
        {
            InitializeComponent();
        }

        private void IssueBook_Load(object sender, EventArgs e)
        {
            String CS = "data source=.; database = LMSDB; integrated security=SSPI";
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand(" select bkName from tblBookInfos", con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    for(int i=0; i<reader.FieldCount; i++)
                    {
                        comboBoxBK.Items.Add(reader.GetString(i));
                    }
                }
                reader.Close();
                
            }
        }

        private void circularPicture1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void jFlatButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnStRefresh_Click(object sender, EventArgs e)
        {
            //txtStName.Clear();
            txtStNumber.Clear();
            //txtStDepartment.Clear();
            //txtStSemester.Clear();
            //txtStContact.Clear();
            //txtStEmail.Clear();
            //comboBoxBK.Text = "";
        }
        int counting;
        string stNumber;
        private void btnSearchSt_Click(object sender, EventArgs e)
        {
            if (txtStNumber.Text != "")
            {
                String CS = "data source=.; database = LMSDB; integrated security=SSPI";
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandText = " select *from tblStudentInfos where stNumber='" + txtStNumber.Text + "'";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataSet dataSet = new DataSet();
                    dataAdapter.Fill(dataSet);
                    /*Only 3 books will be taken start*/
                    cmd.CommandText = " select count(stNumber) from tblIssueBooks where stNumber='" + txtStNumber.Text + "' and bkReturnDate is null";
                    SqlDataAdapter dataAdapter1 = new SqlDataAdapter(cmd);
                    DataSet dataSet1 = new DataSet();
                    dataAdapter1.Fill(dataSet1);
                    counting = int.Parse(dataSet1.Tables[0].Rows[0][0].ToString());
                    /*Only 3 books will be taken end*/
                    if (dataSet.Tables[0].Rows.Count != 0)
                    {
                        stNumber = dataSet.Tables[0].Rows[0][2].ToString();
                        txtStName.Text = dataSet.Tables[0].Rows[0][1].ToString();
                        txtStDepartment.Text = dataSet.Tables[0].Rows[0][3].ToString();
                        txtStSemester.Text = dataSet.Tables[0].Rows[0][4].ToString();
                        txtStContact.Text = dataSet.Tables[0].Rows[0][5].ToString();
                        txtStEmail.Text = dataSet.Tables[0].Rows[0][6].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Student Number is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnIssueBk_Click(object sender, EventArgs e)
        {
            if (txtStName.Text != "" && txtStDepartment.Text != "" && txtStSemester.Text != "" && txtStContact.Text != "" && txtStEmail.Text != "")
            {
                if(comboBoxBK.SelectedIndex!=-1 && counting <= 2)
                {
                    String CS = "data source=.; database = LMSDB; integrated security=SSPI";
                    using (SqlConnection con = new SqlConnection(CS))
                    {   //Int64 contact = Int64.Parse(txtstContact.Text);
                            SqlCommand cmd = new SqlCommand("insert into tblIssueBooks(stName,stNumber,stDepartment,stSemester,stContact,stEmail,bkName,bkIssueDate) values('" + txtStName.Text + "', '" + txtStNumber.Text + "'," +
                           "'" + txtStDepartment.Text + "', '" + txtStSemester.Text + "', " + Int64.Parse(txtStContact.Text) + ", '" + txtStEmail.Text + "', '"+ comboBoxBK.Text +"' ,'"+ dateTimePicker.Text +"') ", con);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Book Issued successfully. ", " Success" , MessageBoxButtons.OK , MessageBoxIcon.Information);
                            txtStName.Clear();
                            txtStNumber.Clear();
                            txtStDepartment.Clear();
                            txtStSemester.Clear();
                            txtStContact.Clear();
                            txtStEmail.Clear();
                            comboBoxBK.Text = " ";


                    }
                }
                else
                {
                    MessageBox.Show("No Selected book or"+ " Student who has StudentNumber= "+stNumber+" has reached the maximum book number should be taken. ", "  Error or Max book number" ,MessageBoxButtons.OK , MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("There is no Student Number which is entered. Please enter student number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtStNumber_TextChanged(object sender, EventArgs e)
        {
            if (txtStNumber.Text == "")
            {
                txtStName.Clear();
                txtStDepartment.Clear();
                txtStSemester.Clear();
                txtStContact.Clear();
                txtStEmail.Clear();
                comboBoxBK.Text = "";
            }
        }
    }
}
