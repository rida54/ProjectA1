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
    public partial class View : Form
    {
        String cmd = "Data Source=DESKTOP-T3GNBBF\\SQLEXPRESS;Initial Catalog=ProjectA;Integrated Security=True";
        public View()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(cmd);
            conn.Open();
            SqlCommand command = new SqlCommand(cmd, conn);
            //Add the parameters if required

             //string query = "INSERT into GroupStudent(StudentId) values((Select Id from[Student] WHERE Id = '" + textBox1.Text + "'))";
            string query = "INSERT into GroupStudent(GroupId,StudentId,Status,AssignmentDate) values((Select Id from [Group] Where Id= '" + textBox2.Text+ "'),(Select Id from[Student] WHERE RegistrationNo=@RegistrationNo),(Select Status From [GroupStudent] where GroupId='" + textBox2.Text + "'), (Select AssignmentDate From [GroupStudent] where GroupId='" + textBox2.Text + "'))";

            SqlCommand str = new SqlCommand(query, conn);
            str.Parameters.Add(new SqlParameter("@RegistrationNo", textBox1.Text));

            int l = str.ExecuteNonQuery();

        }

        private void View_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(cmd);
            conn.Open();
            //String str = "select Group.Id, Group.Created_On , GroupStudent.Status , GroupStudent.AssignmentDate , Student.RegistrationNo  from Group join GroupStudent ON Group.Id = GroupStudent.GroupId join Student ON GroupStudent.StudentId = Student.Id";
            String str = "select GroupId, RegistrationNo from GroupStudent Join [Student] ON [Student].Id=GroupStudent.StudentId;";
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
    }
}
