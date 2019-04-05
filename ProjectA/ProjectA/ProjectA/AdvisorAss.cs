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
    public partial class AdvisorAss : Form
    {
        String cmd = "Data Source=DESKTOP-T3GNBBF\\SQLEXPRESS;Initial Catalog=ProjectA;Integrated Security=True";

        public AdvisorAss()
        {
            InitializeComponent();
           
            comboBox1.Items.Add("Main Advisor");
            comboBox1.Items.Add("Co - Advisror");
            comboBox1.Items.Add("Industry Advisor");

        }

        private void AdvisorAss_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(cmd);
            conn.Open();
            //String str = "select Group.Id, Group.Created_On , GroupProject.GroupId, GroupProject.ProjectId , GroupProject.AssignmentDate ,   from Group join GroupProject ON Group.Id = GroupProject.GroupId join Project ON GroupProject.ProjectId = Project.Id";
            String str = "select AdvisorId, ProjectId, AdvisorRole, AssignmentDate from ProjectAdvisor Join [Project] ON [Project].Id= ProjectAdvisor.ProjectId;";
            SqlCommand command = new SqlCommand(str, conn);
            // Add the parameters if required
            //SqlDataReader reader = command.ExecuteReader();

            DataTable table = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = command;
            adapt.Fill(table);
           

            if (table.Rows.Count > 0)

            {
                dataGridView1.DataSource = table;
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

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Fyp abc = new Fyp();
            abc.ShowDialog();
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(cmd);
            conn.Open();
            SqlCommand command = new SqlCommand(cmd, conn);

            string query1 = "INSERT INTO ProjectAdvisor(ProjectId, AdvisorId, AdvisorRole, AssignmentDate) VALUES((Select Id from [Project] WHERE Title = '" + textBox4.Text + "'), (Select Id from [Advisor] WHERE Id = '" + textBox1.Text + "'), (Select Id FROM Lookup WHERE Category ='ADVISOR_ROLE' AND Value=@Value), @AssignmentDate)";
            SqlCommand com1 = new SqlCommand(query1, conn);
            com1.Parameters.Add(new SqlParameter("@AssignmentDate", DateTime.Parse( textBox3.Text)));
            com1.Parameters.Add(new SqlParameter("@Value", comboBox1.Text));


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

                AdvisorAss query2 = new AdvisorAss();
                query2.ShowDialog();
                this.Show();

            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    String con = "Data Source=DESKTOP-T3GNBBF\\SQLEXPRESS;Initial Catalog=ProjectA;Integrated Security=True";
                    SqlConnection conn = new SqlConnection(con);
                    conn.Open();
                    string sql = "DELETE FROM ProjectAdvisor WHERE AdvisorId = @AdvisorID";
                    SqlCommand command = new SqlCommand(sql, conn);
                    command.Parameters.Add(new SqlParameter("@Id", textBox1.Text));
                    command.ExecuteNonQuery();
                    dataGridView1.DataSource = null;
                    AdvisorAss_Load(sender, e);

                    this.Hide();
                    AdvisorAss query2 = new AdvisorAss();
                    query2.ShowDialog();
                    this.Show();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("you cannot delete group from here because of its refrence ");
                }
            }
        }
    }
}
