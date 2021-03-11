using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMSProject
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void returNBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReturnBook returnbook = new ReturnBook();
            returnbook.Show();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void completeBookDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompleteBookDetail bookdetail = new CompleteBookDetail();
            bookdetail.Show();
        }

        private void circularPicture1_Click(object sender, EventArgs e)
        {
            //
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HomePage home = new HomePage();
            home.Show();
        }

        private void addNewBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddBook addbook = new AddBook();
            addbook.Show();
        }

        private void viewBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewBook viewbook = new ViewBook();
            viewbook.Show();
        }

        private void viewStudentInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewStudent viewstudent = new ViewStudent();
            viewstudent.Show();
        }

        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addNewStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStudent addStudent = new AddStudent();
            addStudent.Show();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void issueBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IssueBook issuebook = new IssueBook();
            issuebook.Show();
        }

        private void circularProgressBar4_Click(object sender, EventArgs e)
        {

        }
    }
}
