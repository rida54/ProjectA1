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
    public partial class StudentForm : Form
    {
        public StudentForm()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            String cmd = "Data Source=DESKTOP-T3GNBBF\\SQLEXPRESS;Initial Catalog=ProjectA;Integrated Security=True";

            SqlConnection conn = new SqlConnection(cmd);
            conn.Open();
            SqlCommand command = new SqlCommand(cmd, conn);
            // Add the parameters if required

            // string query = "INSERT INTO (Id, FirstName, LastName, Contact, Email, DateOfBirth, Gender) VALUES(@Id, @FirstName, @LastName, @Contact, @Email, @DateOfBirth, @Gender)";
            string query = "INSERT into Person(FirstName , LastName , Contact , Email , DateOfBirth , Gender) values  (@FirstName ,@LastName, @Contact , @Email, @DateOfBirth, (Select Id FROM Lookup WHERE Category = 'Gender' AND Value=@Value))";
            SqlCommand str = new SqlCommand(query, conn);
            //// Add the parameters if required

            str.Parameters.Add(new SqlParameter("@FirstName", FirstName.Text));
            str.Parameters.Add(new SqlParameter("@LastName", LastName.Text));
            str.Parameters.Add(new SqlParameter("@Contact", Contact.Text));
            str.Parameters.Add(new SqlParameter("@Email ", Email.Text));
            str.Parameters.Add(new SqlParameter("@DateOfBirth", DOB.Text));
            str.Parameters.Add(new SqlParameter("@Gender", comboBox1.Text));
            str.Parameters.Add(new SqlParameter("@Value", comboBox1.Text));



            //string q = "insert into Student(Id, RegistrationNo) VALUES((Select Id from Person WHERE Email = @Email ),@RegistrationNo)";

            //SqlCommand com = new SqlCommand(cmd, conn);
            //str.Parameters.Add(new SqlParameter("@RegistrationNo", RegNo.Text));

            int i = str.ExecuteNonQuery();
            string fName = FirstName.Text;
            if (string.IsNullOrWhiteSpace(fName) || fName.Any(Char.IsDigit))
            {
                MessageBox.Show("Please enter your First Name without digits");
                FirstName.Select();
            }
           
            if (MessageBox.Show("Do You want to Register it", "Register", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MessageBox.Show("Student is registered");
            }
            else
            {
                MessageBox.Show("Student not registered", "Register Again", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //Display_Data();
            conn.Close();

            StudentForm query1 = new StudentForm();
            query1.ShowDialog();
            this.Show();
        }
        private void StudentInfo_Load(object sender, EventArgs e)
        {
            {
                String cmd = "Data Source=DESKTOP-T3GNBBF\\SQLEXPRESS;Initial Catalog=ProjectA;Integrated Security=True";

                SqlConnection conn = new SqlConnection(cmd);
                conn.Open();
                //String str = "select Person.Id,Person.FirstName, Person.LastName, Person.Contact , Person.Email ,Person.DateOfBirth , Person.Gender , Student.RegistrationNo  from Person join Student ON Person.Id = Student.Id ";
                String str = "select *From Person";

                SqlCommand command = new SqlCommand(str, conn);
                // Add the parameters if required
                //SqlDataReader reader = command.ExecuteReader();
                command.Connection = conn;
                command.CommandText = str;
                SqlDataAdapter adapt = new SqlDataAdapter();
                adapt.SelectCommand = command;
                DataTable table = new DataTable();
                adapt.Fill(table);

                if (table.Rows.Count > 0)

                {
                    gvStudent.DataSource = table;
                }
               
            }
        }
        private void ID_TextChanged(object sender, EventArgs e)
        {
        }

        private void label11_Click(object sender, EventArgs e)
        {
        }

        private void Update_Click(object sender, EventArgs e)
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


                //initialize new Sql commands
                SqlCommand cmd = new SqlCommand();
                //hold the data to be executed.
                cmd.Connection = conn;
                cmd.CommandText = query;
                //execute the data
                int res = cmd.ExecuteNonQuery();
                //checking the result of an executed command

                MessageBox.Show("User has been updated in the database.");

                // SqlConnection conn = new SqlConnection(con);
                try
                {
                    //     conn.Open();
                    //create a query for retrieving data in the database.
                    query = "SELECT * FROM  Student";
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

        private void button2_Click(object sender, EventArgs e)
        {

            String con = "Data Source=DESKTOP-T3GNBBF\\SQLEXPRESS;Initial Catalog=ProjectA;Integrated Security=True";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            string sql = "DELETE FROM Student WHERE Id = @ID";
            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.Add(new SqlParameter("@Id", ID.Text));
            command.ExecuteNonQuery();
            gvStudent.DataSource = null;
            StudentInfo_Load(sender, e);
            StudentForm query1 = new StudentForm();
            query1.ShowDialog();
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Fyp query1 = new Fyp();
            query1.ShowDialog();
            this.Show();
        }
    } }

    

