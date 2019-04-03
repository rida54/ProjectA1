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
    public partial class Advisor : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-T3GNBBF\\SQLEXPRESS;Initial Catalog=ProjectA;Integrated Security=True");

        public Advisor()
        {
            InitializeComponent();
            Designation.Items.Add("Professor");
            Designation.Items.Add("Associate Professor");
            Designation.Items.Add("Assisstant Professor");
            Designation.Items.Add("Lecturer");
            Designation.Items.Add("Industry Professional");
            comboBox1.Items.Add("Male");
            comboBox1.Items.Add("Female");

        }
        private void Advisor_Load(object sender, EventArgs e)
        {
            String cmd = "Data Source=DESKTOP-T3GNBBF\\SQLEXPRESS;Initial Catalog=ProjectA;Integrated Security=True";

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
                gvAdvisor.DataSource = table;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void gvAdvisor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Fyp abc = new Fyp();
            abc.ShowDialog();
            this.Show();
        }

        private void Advisor_Load_1(object sender, EventArgs e)
        {

        }

        private void Save_Click(object sender, EventArgs e)
        {


            String cmd = "Data Source=DESKTOP-T3GNBBF\\SQLEXPRESS;Initial Catalog=ProjectA;Integrated Security=True";

            SqlConnection conn = new SqlConnection(cmd);
            conn.Open();
            SqlCommand command = new SqlCommand(cmd, conn);
            // Add the parameters if required

            // string query = "INSERT INTO (Id, FirstName, LastName, Contact, Email, DateOfBirth, Gender) VALUES(@Id, @FirstName, @LastName, @Contact, @Email, @DateOfBirth, @Gender)";
            string query = "INSERT into Person(FirstName , LastName , Contact , Email , DateOfBirth , Gender) values (@FirstName ,@LastName, @Contact , @Email, @DateOfBirth, (Select Id FROM Lookup WHERE Category = 'Gender' AND Value=@Value))";
            SqlCommand str = new SqlCommand(query, conn);
            //// Add the parameters if required

            str.Parameters.Add(new SqlParameter("@FirstName", FirstName.Text));
            str.Parameters.Add(new SqlParameter("@LastName", LastName.Text));
            str.Parameters.Add(new SqlParameter("@Contact", Contact.Text));
            str.Parameters.Add(new SqlParameter("@Email ", Em.Text));
            str.Parameters.Add(new SqlParameter("@DateOfBirth", DOB.Text));
            str.Parameters.Add(new SqlParameter("@Gender", comboBox1.Text));
            str.Parameters.Add(new SqlParameter("@Value", comboBox1.Text));




            string abc = "INSERT into Advisor(Designation, Salary) values (@Designation, @Salary, (Select Id FROM Lookup WHERE Category = 'Gender' AND Value=@Value))";
            //// Add the parameters if required
            SqlCommand stri = new SqlCommand(abc, conn);
            stri.Parameters.Add(new SqlParameter("@Designation", Designation.Text));
            stri.Parameters.Add(new SqlParameter("@Salary", Salary.Text));
            Advisor query1 = new Advisor();
            query1.ShowDialog();
            this.Show();
            int i = str.ExecuteNonQuery();
            string fName = FirstName.Text;
            if (string.IsNullOrWhiteSpace(fName) || fName.Any(Char.IsDigit))
            {
                MessageBox.Show("Please enter your First Name without digits");
                FirstName.Select();
            }
            string lName = LastName.Text;

            if (string.IsNullOrWhiteSpace(fName) || lName.Any(Char.IsDigit))
            {
                MessageBox.Show("Please enter your Last Name without digits");
                LastName.Select();
            }

            else
            {
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
                
            }
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            String con = "Data Source=DESKTOP-T3GNBBF\\SQLEXPRESS;Initial Catalog=ProjectA;Integrated Security=True";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            string sql = "DELETE FROM Advisor WHERE Id = @ID";
            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.Add(new SqlParameter("@Id", textBox3.Text));
            command.ExecuteNonQuery();
            gvAdvisor.DataSource = null;
            Advisor_Load(sender, e);
            this.Hide();
            Advisor query1 = new Advisor();
            query1.ShowDialog();
            this.Show();
        }

        private void Update_Click(object sender, EventArgs e)
        {
            String con = "Data Source=DESKTOP-T3GNBBF\\SQLEXPRESS;Initial Catalog=ProjectA;Integrated Security=True";

            SqlConnection conn = new SqlConnection(con);
            try
            {

                conn.Open();
                int selectrowindex = gvAdvisor.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = gvAdvisor.Rows[selectrowindex];
                string id = Convert.ToString(selectedRow.Cells["Id"].Value);
                //create a query for updating data in the database.
                //string query = "Update Evaluation set  Name = '" + this.Names.Text + "' ,TotalMarks = '" +
                //    this.Marks.Text + "' ,TotalWeightage= '" + this.Weightage.Text + "' where ID = '" +id";";
                string query = "Update Person SET FirstName='" + FirstName.Text + "',LastName='" + LastName.Text
                    + "' , Email='" + Em.Text + "' , Contact='" + Contact.Text + "', DateOfBirth= '" + DOB.Text + "', Gender='" + comboBox1.Text + "' WHERE ID=" + id;

                string up = "Update Advisor SET Designation='" + Designation.Text + "', Salary='" + Salary.Text
                       + "' , Email='" + Em.Text + "' , Contact='" + Contact.Text + "', DateOfBirth= '" + DOB.Text + "', Gender='" + comboBox1.Text + "' WHERE ID=" + id;


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
                    query = "SELECT * FROM Advisor";
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
                        gvAdvisor.DataSource = dt;
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

        private void button6_Click(object sender, EventArgs e)
        {
            Fyp query1 = new Fyp();
            query1.ShowDialog();
            this.Show();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorPositionItem_Click(object sender, EventArgs e)
        {

        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Fyp abc = new Fyp();
            abc.ShowDialog();
            this.Show();
        }
    }
}
    

