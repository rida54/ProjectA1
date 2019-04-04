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
    public partial class Student : Form
    {
        String cmd = "Data Source=DESKTOP-T3GNBBF\\SQLEXPRESS;Initial Catalog=ProjectA;Integrated Security=True";
        public Student()
        {
            InitializeComponent();
            comboBox1.Items.Add("Male");
            comboBox1.Items.Add("Female");

        }

        private void Save_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(cmd);
            conn.Open();
            SqlCommand command = new SqlCommand(cmd, conn);
            // Add the parameters if required

            string query = "INSERT into Person(FirstName , LastName , Contact , Email , DateOfBirth , Gender) values (@FirstName ,@LastName, @Contact , @Email, @DateOfBirth, (Select Id FROM Lookup WHERE Category = 'Gender' AND Value=@Value))";
            SqlCommand str = new SqlCommand(query, conn);
            // Add the parameters if required

            str.Parameters.Add(new SqlParameter("@FirstName", FirstName.Text));
            str.Parameters.Add(new SqlParameter("@LastName", LastName.Text));
            str.Parameters.Add(new SqlParameter("@Contact", Contact.Text));
            str.Parameters.Add(new SqlParameter("@Email", Email.Text));
            str.Parameters.Add(new SqlParameter("@DateOfBirth", DOB.Text));
            str.Parameters.Add(new SqlParameter("@Gender", comboBox1.Text));
            str.Parameters.Add(new SqlParameter("@Value", comboBox1.Text));
            string q = "insert into Student(Id, RegistrationNo) VALUES((Select Id from Person WHERE Email = @Email ),@RegistrationNo)";

            SqlCommand com = new SqlCommand(q, conn);
            com.Parameters.Add(new SqlParameter("@RegistrationNo", RegNo.Text));
            com.Parameters.Add(new SqlParameter("@Email", Email.Text));
            int i = str.ExecuteNonQuery();
            int l = com.ExecuteNonQuery();
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

                Student query1 = new Student();
                query1.ShowDialog();
                this.Show();

            }
        }

        private void Student_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(cmd);
            conn.Open();
            String str = "select Person.Id,Person.FirstName, Person.LastName, Person.Contact , Person.Email ,Person.DateOfBirth , Person.Gender , Student.RegistrationNo  from Person join Student ON Person.Id = Student.Id ";
            SqlCommand command = new SqlCommand(str, conn);
            // Add the parameters if required
            //SqlDataReader reader = command.ExecuteReader();

            DataTable table = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = command;
            adapt.Fill(table);

            if (table.Rows.Count > 0)

            {
                gvStudent.DataSource = table;
            }
        
        
            
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.Text = "Edit";
            btn.Name = "Action";
            btn.UseColumnTextForButtonValue = true;
            gvStudent.DataSource = table;
            //add the button in the datagridview
            gvStudent.Columns.Add(btn);
            int userid ;
            userid = 0;
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            String con = "Data Source=DESKTOP-T3GNBBF\\SQLEXPRESS;Initial Catalog=ProjectA;Integrated Security=True";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            string sql = "DELETE FROM Person WHERE Id = @ID";
            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.Add(new SqlParameter("@Id", ID.Text));
            command.ExecuteNonQuery();
            string sql1 = "DELETE FROM Student WHERE Id = @ID";
            SqlCommand command1 = new SqlCommand(sql1, conn);
            command1.Parameters.Add(new SqlParameter("@Id", ID.Text));
            command1.ExecuteNonQuery();
            gvStudent.DataSource = null;
            Student_Load(sender, e);

        }

        private void FirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void ID_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void DOB_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Fyp abc = new Fyp();
            abc.ShowDialog();
            this.Show();
        }

        private void Update_Click(object sender, EventArgs e)
        {
            {
                String con = "Data Source=DESKTOP-T3GNBBF\\SQLEXPRESS;Initial Catalog=ProjectA;Integrated Security=True";

                SqlConnection conn = new SqlConnection(con);
                try
                {

                    conn.Open();
                    int selectrowindex = gvStudent.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = gvStudent.Rows[selectrowindex];
                    string id = Convert.ToString(selectedRow.Cells["Id"].Value);
                    //create a query for updating data in the database.
                    //string query = "Update Evaluation set  Name = '" + this.Names.Text + "' ,TotalMarks = '" +
                    //    this.Marks.Text + "' ,TotalWeightage= '" + this.Weightage.Text + "' where ID = '" +id";";
                    string query = "Update Person SET FirstName='" + FirstName.Text + "',LastName='" + LastName.Text
                        + "' , Email='" + Email.Text + "' , Contact='" + Contact.Text + "', DateOfBirth= '" + DOB.Text + "', Gender='" + comboBox1.Text + "' WHERE ID=" + id;

                    //string query1 = "Update Student SET Id='" + "'(Select Id from Person Where Email=@Email.Text)'" + "' , RegistrationNo='" + RegNo.Text +"' "  ;
                    //string query1 = "Update Student SET  RegistrationNo=Student.RegistrationNo From Student Join Person ON Person.Id = Student.Id";
                    string query1 = "Update Student SET RegistrationNo='" + RegNo.Text + "' WHERE ID= "+ id;
                    //initialize new Sql commands
                    SqlCommand cmd = new SqlCommand();
                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.Parameters.Add(new SqlParameter("@Email", Email.Text));

                    //hold the data to be executed.
                    cmd.Connection = conn;
                    cmd.CommandText = query;
                    cmd1.CommandText = query1;
                    cmd1.Connection = conn;

                    //execute the data
                    int abc = cmd1.ExecuteNonQuery();
                    int res = cmd.ExecuteNonQuery();
                    //checking the result of an executed command

                    MessageBox.Show("User has been updated in the database.");

                    // SqlConnection conn = new SqlConnection(con);
                    try
                    {
                        //     conn.Open();
                        //create a query for retrieving data in the database.
                        query ="select Person.Id,Person.FirstName, Person.LastName, Person.Contact , Person.Email ,Person.DateOfBirth , Person.Gender , Student.RegistrationNo  from Person join Student ON Person.Id = Student.Id ";

                        //initialize new Sql commands
                        //SqlCommand cmd = new SqlCommand();
                        //hold the data to be executed.
                        cmd.Connection = conn;
                        cmd.CommandText = query;
                        //initialize new Sql data adapter
                        SqlDataAdapter da = new SqlDataAdapter();
                        //fetching query in the database.
                        da.SelectCommand = cmd;
                        //initialize new datatable
                        DataTable dt = new DataTable();
                        //refreshes the rows in specified range in the datasource. 
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)

                        {
                            gvStudent.DataSource = dt;
                        }

                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        //catching error
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {

                        conn.Close();
                    }
                }

                catch (Exception ex)
                {
                    //catching error
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    //    da.Dispose();
                    conn.Close();
                }

            }
        }

        private void gvStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (gvStudent.CurrentCell.Value == "Edit")
            {
                int userid;
                userid = (Int32)(gvStudent.CurrentRow.Cells[0].Value);
                FirstName.Text = gvStudent.CurrentRow.Cells[1].Value.ToString();
                LastName.Text = gvStudent.CurrentRow.Cells[2].Value.ToString();
                Contact.Text = gvStudent.CurrentRow.Cells[3].Value.ToString();
                Email.Text = gvStudent.CurrentRow.Cells[4].Value.ToString();
                DOB.Text = gvStudent.CurrentRow.Cells[5].Value.ToString();
                comboBox1.Text = gvStudent.CurrentRow.Cells[6].Value.ToString();
                RegNo.Text = gvStudent.CurrentRow.Cells[7].Value.ToString();

            }

        }
    }
}
