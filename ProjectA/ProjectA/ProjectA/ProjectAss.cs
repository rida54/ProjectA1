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

namespace ProjectA
{

    public partial class ProjectAss : Form
    {
        String cmd = "Data Source=DESKTOP-T3GNBBF\\SQLEXPRESS;Initial Catalog=ProjectA;Integrated Security=True";
        public ProjectAss()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(cmd);
            conn.Open();
            SqlCommand command = new SqlCommand(cmd, conn);
            // Add the parameters if required

            //string query = "INSERT into GroupStudent(GroupId, StudentId, Status, AssignmentDate) values ((Select Id from Group WHERE Created_On = @Created_On), (Select Id from Student WHERE RegistrationNo = @RegistrationNo), (Select Id FROM Lookup WHERE Category ='Status' AND Value=@Value), @AssignmentDate)";
           


            //string q = "insert into Group(Created_On) VALUES(@Created_On)";

            //SqlCommand com = new SqlCommand(q, conn);
            //com.Parameters.Add(new SqlParameter("@Created_On", textBox4.Text));
            string query1 = "INSERT INTO GroupProject(GroupId, ProjectId, AssignmentDate) VALUES((Select Id from [Group] WHERE Id = '" + textBox6.Text + "'),(Select Id from [Project] WHERE Title = '" + textBox4.Text + "'), @AssignmentDate)";
           // string query1 = "INSERT INTO GroupProject(AssignmentDate) VALUES(@AssignmentDate)";
            SqlCommand com1 = new SqlCommand(query1, conn);
            com1.Parameters.Add(new SqlParameter("@AssignmentDate", textBox3.Text));

           // int l = com.ExecuteNonQuery();
            int k = com1.ExecuteNonQuery();

            {
                if (MessageBox.Show("Do You want to save it", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MessageBox.Show("Student is Saved");
                }
                else
                {
                    MessageBox.Show("Student not saved", "Save Again", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                conn.Close();

                if (k != 0)
                {
                    MessageBox.Show(k + " Student Details Saved");
                }

                ProjectAss query2 = new ProjectAss();
                query2.ShowDialog();
                this.Show();

            }
        }

        private void ProjectAss_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(cmd);
            conn.Open();
            //String str = "select Group.Id, Group.Created_On , GroupProject.GroupId, GroupProject.ProjectId , GroupProject.AssignmentDate ,   from Group join GroupProject ON Group.Id = GroupProject.GroupId join Project ON GroupProject.ProjectId = Project.Id";
            String str = "select GroupId, ProjectId, AssignmentDate from GroupProject Join [Group] ON [Group].Id=GroupProject.GroupId;";
            SqlCommand command = new SqlCommand(str, conn);
            // Add the parameters if required
            //SqlDataReader reader = command.ExecuteReader();

            DataTable table = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = command;
            adapt.Fill(table);

            if (table.Rows.Count > 0)

            {
                gvProject.DataSource = table;
            }
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Fyp abc = new Fyp();
            abc.ShowDialog();
            this.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Fyp abc = new Fyp();
            abc.ShowDialog();
            this.Show();
        }

        private void Save_Click_1(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(cmd);
            conn.Open();
            SqlCommand command = new SqlCommand(cmd, conn);
           
            string query1 = "INSERT INTO GroupProject(GroupId, ProjectId, AssignmentDate) VALUES((Select Id from [Group] WHERE Id = '" + textBox6.Text + "'),(Select Id from [Project] WHERE Title = '" + textBox4.Text + "'), @AssignmentDate)";
            SqlCommand com1 = new SqlCommand(query1, conn);
            com1.Parameters.Add(new SqlParameter("@AssignmentDate", textBox3.Text));

            // int l = com.ExecuteNonQuery();
            int k = com1.ExecuteNonQuery();

            {
                if (MessageBox.Show("Do You want to save it", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MessageBox.Show("Student is Saved");
                }
                else
                {
                    MessageBox.Show("Student not saved", "Save Again", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                conn.Close();

                if (k != 0)
                {
                    MessageBox.Show(k + " Student Details Saved");
                }

                ProjectAss query2 = new ProjectAss();
                query2.ShowDialog();
                this.Show();

            }
       
        
    }
    }
}
