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
    public partial class Group : Form
    {
        String cmd = "Data Source=DESKTOP-T3GNBBF\\SQLEXPRESS;Initial Catalog=ProjectA;Integrated Security=True";

        public Group()
        {
            InitializeComponent();
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(cmd);
            conn.Open();
            SqlCommand command = new SqlCommand(cmd, conn);
            //Add the parameters if required

            string q = "Insert into [Group](Created_On) VALUES(@Created_On)";

            SqlCommand com = new SqlCommand(q, conn);
            com.Parameters.Add(new SqlParameter("@Created_On", DateTime.Parse(textBox1.Text)));
            int i = com.ExecuteNonQuery();


            //string query = "INSERT into GroupStudent(GroupId, StudentId, Status, AssignmentDate) values " +
            //    "((Select Id from [Group] WHERE Created_On = @Created_On)," +
            //    " (Select Id from Student WHERE RegistrationNo = @RegistrationNo)," +
            //    " (Select Id FROM Lookup WHERE Category ='Status' AND Value=@Value), @AssignmentDate)";


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

                Group query1 = new Group();
                query1.ShowDialog();
                this.Show();

            }
        }

        private void GroupStudent_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(cmd);
            conn.Open();
            //String str = "select Group.Id, Group.Created_On , GroupStudent.Status , GroupStudent.AssignmentDate , Student.RegistrationNo  from Group join GroupStudent ON Group.Id = GroupStudent.GroupId join Student ON GroupStudent.StudentId = Student.Id";
            //String str = "select GroupId, Created_On, Status from GroupStudent Join [Group] ON [Group].Id=GroupStudent.GroupId;";
            String str = "select *From [Group]";
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
            //DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            //btn.Text = "Edit";
            //btn.Name = "Action";
            //btn.UseColumnTextForButtonValue = true;
            //gvStudent.DataSource = table;
            ////add the button in the datagridview
            //gvStudent.Columns.Add(btn);
            //int userid;
            //userid = 0;
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.Text = "ClickHereToAddStudent";
            btn.Name = "Action";
            btn.UseColumnTextForButtonValue = true;
            gvStudent.DataSource = table;
            //add the button in the datagridview
            gvStudent.Columns.Add(btn);
            int useriD;
            conn.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Fyp abc = new Fyp();
            abc.ShowDialog();
            this.Show();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        //    SqlConnection conn = new SqlConnection(con);
        //    try
        //    {

        //        conn.Open();
        //        int selectrowindex = gvStudent.SelectedCells[0].RowIndex;
        //        DataGridViewRow selectedRow = gvStudent.Rows[selectrowindex];
        //        string id = Convert.ToString(selectedRow.Cells["Id"].Value);
        //        //create a query for updating data in the database.
        //        //string query = "Update Evaluation set  Name = '" + this.Names.Text + "' ,TotalMarks = '" +
        //        //    this.Marks.Text + "' ,TotalWeightage= '" + this.Weightage.Text + "' where ID = '" +id";";
        //        string query = "Update Person SET FirstName='" + FirstName.Text + "',LastName='" + LastName.Text
        //            + "' , Email='" + Email.Text + "' , Contact='" + Contact.Text + "', DateOfBirth= '" + DOB.Text + "', Gender='" + comboBox1.Text + "' WHERE ID=" + id;

        //        //string query1 = "Update Student SET Id='" + "'(Select Id from Person Where Email=@Email.Text)'" + "' , RegistrationNo='" + RegNo.Text +"' "  ;
        //        //string query1 = "Update Student SET  RegistrationNo=Student.RegistrationNo From Student Join Person ON Person.Id = Student.Id";
        //        string query1 = "Update Student SET RegistrationNo='" + RegNo.Text + "' WHERE ID= " + id;
        //        //initialize new Sql commands
        //        SqlCommand cmd = new SqlCommand();
        //        SqlCommand cmd1 = new SqlCommand();
        //        cmd1.Parameters.Add(new SqlParameter("@Email", Email.Text));

        //        //hold the data to be executed.
        //        cmd.Connection = conn;
        //        cmd.CommandText = query;
        //        cmd1.CommandText = query1;
        //        cmd1.Connection = conn;

        //        //execute the data
        //        int abc = cmd1.ExecuteNonQuery();
        //        int res = cmd.ExecuteNonQuery();
        //        //checking the result of an executed command

        //        MessageBox.Show("User has been updated in the database.");

        //        // SqlConnection conn = new SqlConnection(con);
        //        try
        //        {
        //            //     conn.Open();
        //            //create a query for retrieving data in the database.
        //            query = "SELECT * FROM Person";
        //            //initialize new Sql commands
        //            //SqlCommand cmd = new SqlCommand();
        //            //hold the data to be executed.
        //            cmd.Connection = conn;
        //            cmd.CommandText = query;
        //            //initialize new Sql data adapter
        //            SqlDataAdapter da = new SqlDataAdapter();
        //            //fetching query in the database.
        //            da.SelectCommand = cmd;
        //            //initialize new datatable
        //            DataTable dt = new DataTable();
        //            //refreshes the rows in specified range in the datasource. 
        //            da.Fill(dt);
        //            if (dt.Rows.Count > 0)

        //            {
        //                gvStudent.DataSource = dt;
        //            }

        //            conn.Close();
        //        }
        //        catch (Exception ex)
        //        {
        //            //catching error
        //            MessageBox.Show(ex.Message);
        //        }
        //        finally
        //        {

        //            conn.Close();
        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        //catching error
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        //    da.Dispose();
        //        conn.Close();
        //    }

        
    }

        private void gvStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int userid;
            userid = (Int32)(gvStudent.CurrentRow.Cells[0].Value);
            this.Hide();
            GroupStudent abc = new GroupStudent();
            abc.ShowDialog();
            this.Show();


        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                String con = "Data Source=DESKTOP-T3GNBBF\\SQLEXPRESS;Initial Catalog=ProjectA;Integrated Security=True";
                SqlConnection conn = new SqlConnection(con);
                conn.Open();
                string sql = "DELETE FROM Group WHERE Id = @ID";
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.Add(new SqlParameter("@Id", textBox4.Text));
                command.ExecuteNonQuery();
                gvStudent.DataSource = null;
                GroupStudent_Load(sender, e);
                this.Hide();
                GroupStudent query1 = new GroupStudent();
                query1.ShowDialog();
                this.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show("you cannot delete group from here because of its refrence ");
            }
        }
    }
    }
    
