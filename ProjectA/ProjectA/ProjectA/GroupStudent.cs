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
    public partial class GroupStudent : Form

    {
        String cmd = "Data Source=DESKTOP-T3GNBBF\\SQLEXPRESS;Initial Catalog=ProjectA;Integrated Security=True";
        public GroupStudent()
        {
            InitializeComponent();
            comboBox1.Items.Add("Active");
            comboBox1.Items.Add("InActive");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(cmd);
            conn.Open();
            SqlCommand command = new SqlCommand(cmd, conn);
           
            string query = "INSERT into GroupStudent(GroupId, StudentId, Status, AssignmentDate) values ((Select Id from [Group] WHERE Id = '" + textBox5.Text + "'),(Select Id from [Student] WHERE Id = '" + textBox6.Text + "'),(Select Id FROM Lookup WHERE Category ='Status' AND Value=@Value), @AssignmentDate)";
            SqlCommand str = new SqlCommand(query, conn);
            // Add the parameters if required

            str.Parameters.Add(new SqlParameter("@Status", comboBox1.Text));
            str.Parameters.Add(new SqlParameter("@AssignmentDate", DateTime.Parse(textBox3.Text)));
            str.Parameters.Add(new SqlParameter("@Value", comboBox1.Text));
            str.Parameters.Add(new SqlParameter("@Created_On", DateTime.Parse(textBox1.Text)));
            int i = str.ExecuteNonQuery();
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

                GroupStudent query1 = new GroupStudent();
                query1.ShowDialog();
                this.Show();

            }
        }

            private void View_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(cmd);
            conn.Open();
            //String str = "select Group.Id, Group.Created_On , GroupStudent.Status , GroupStudent.AssignmentDate , Student.RegistrationNo  from Group join GroupStudent ON Group.Id = GroupStudent.GroupId join Student ON GroupStudent.StudentId = Student.Id";
            //String str = "select GroupId, RegistrationNo from GroupStudent Join [Student] ON [Student].Id=GroupStudent.StudentId;";
            String str = "select GroupId, Created_On, Status, StudentId from GroupStudent Join [Group] ON [Group].Id=GroupStudent.GroupId;";
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Group abc = new Group();
            abc.ShowDialog();
            this.Show();
        }
    }
}
