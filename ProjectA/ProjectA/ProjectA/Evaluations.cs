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
    public partial class Evaluations : Form
    {
        String cmd = "Data Source=DESKTOP-T3GNBBF\\SQLEXPRESS;Initial Catalog=ProjectA;Integrated Security=True";

        public Evaluations()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Fyp abc = new Fyp();
            abc.ShowDialog();
            this.Show();
        }

        private void Evaluations_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(cmd);
            conn.Open();
            //String str = "select Group.Id, Group.Created_On , GroupProject.GroupId, GroupProject.ProjectId , GroupProject.AssignmentDate ,   from Group join GroupProject ON Group.Id = GroupProject.GroupId join Project ON GroupProject.ProjectId = Project.Id";
            String str = "select GroupId, EvaluationId, ObtainedMarks, EvaluationDate from [GroupEvaluation] Join [Group] ON [Group].Id= [GroupEvaluation].GroupId;";
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

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(cmd);
            conn.Open();
            SqlCommand command = new SqlCommand(cmd, conn);
            //Add the parameters if required

            string q = "Insert into [GroupEvaluation](GroupId, EvaluationId, ObtainedMarks, EvaluationDate) VALUES((Select Id from [Group] WHERE Id = '" + textBox1.Text + "'),(Select Id from [Evaluation] WHERE Id = '" + textBox2.Text + "'), @ObtainedMarks, @EvaluationDate) ";

            SqlCommand com = new SqlCommand(q, conn);
            com.Parameters.Add(new SqlParameter("@ObtainedMarks", textBox4.Text));
            com.Parameters.Add(new SqlParameter("@EvaluationDate", textBox5.Text));

            int i = com.ExecuteNonQuery();

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

                if (i != 0)
                {
                    MessageBox.Show(i + " Student Details Saved");
                }

                Evaluations query1 = new Evaluations();
                query1.ShowDialog();
                this.Show();

            }
        
    }
    }
}
