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
using System.Xml.Linq;

namespace ProjectA
{
    public partial class DataView : Form
    {
        int userid;
        String cmd = "Data Source=DESKTOP-T3GNBBF\\SQLEXPRESS;Initial Catalog=ProjectA;Integrated Security=True";
        private static DataTable DataSoure;
        String con = "Data Source=DESKTOP-T3GNBBF\\SQLEXPRESS;Initial Catalog=ProjectA;Integrated Security=True";
        public DataView()
        {
            InitializeComponent();
        }

        private void DataView_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            String str = "SELECT * FROM Evaluation";
            SqlCommand command = new SqlCommand(str, conn);
            // Add the parameters if required
            //SqlDataReader reader = command.ExecuteReader();

            DataTable table = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = command;
            adapt.Fill(table);

            if (table.Rows.Count > 0)

            {
                Grid.DataSource = table;
            }
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.Text = "Edit";
            btn.Name = "Action";
            btn.UseColumnTextForButtonValue = true;
            Grid.DataSource = table;
            //add the button in the datagridview
            Grid.Columns.Add(btn);
            conn.Close();
           




        }



        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        { }



        private void Grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (Grid.CurrentCell.Value == "Edit")
            {
                userid = (Int32)(Grid.CurrentRow.Cells[0].Value);
                Names.Text = Grid.CurrentRow.Cells[1].Value.ToString();
                Marks.Text = Grid.CurrentRow.Cells[2].Value.ToString();
                Weightage.Text = Grid.CurrentRow.Cells[3].Value.ToString();

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String con = "Data Source=DESKTOP-T3GNBBF\\SQLEXPRESS;Initial Catalog=ProjectA;Integrated Security=True";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            //string query = "UPDATE Evaluation SET Name=@Name , TotalMarks=@TotalMarks";
            //SqlCommand str = new SqlCommand(query, conn);
            //str.Parameters.AddWithValue("@Name", Names.Text);
            //str.Parameters.AddWithValue("@TotalMarks", decimal.Parse(Marks.Text));
            //str.Parameters.AddWithValue("@TotalWightage", decimal.Parse(Wieghtage.Text));



            // Add the parameters if required
            //str.ExecuteNonQuery();



        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            if (ID.Text == "")
            {
                MessageBox.Show("Please enter Id you want to delete");
                ID.Focus();
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {

            String con = "Data Source=DESKTOP-T3GNBBF\\SQLEXPRESS;Initial Catalog=ProjectA;Integrated Security=True";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            string sql = "DELETE FROM Evaluation WHERE Id = @ID";
            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.Add(new SqlParameter("@Id", ID.Text));
            command.ExecuteNonQuery();
            Grid.DataSource = null;
            DataView_Load(sender, e);
            this.Hide();
            DataView query1 = new DataView();
            query1.ShowDialog();
            this.Show();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection(cmd);
            conn.Open();
            SqlCommand command = new SqlCommand(cmd, conn);
            // Add the parameters if required

            string query = "INSERT INTO Evaluation(Name, TotalMarks, TotalWeightage) VALUES(@Name, @TotalMarks, @TotalWeightage)";
            SqlCommand str = new SqlCommand(query, conn);
            // Add the parameters if required

            str.Parameters.Add(new SqlParameter("@Name", Names.Text));
            str.Parameters.Add(new SqlParameter("@TotalMarks", Marks.Text));
            str.Parameters.Add(new SqlParameter("@TotalWeightage", Weightage.Text));

            int i = str.ExecuteNonQuery();


            string fName = Names.Text;
            if (string.IsNullOrWhiteSpace(fName) || fName.Any(Char.IsDigit))
            {
                MessageBox.Show("Please enter your First Name without digits");
                Names.Select();
            }
  
            else
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
                    MessageBox.Show(i + "Student Data Saved");
                }


                DataView query1 = new DataView();
                query1.ShowDialog();
                this.Show();

            }
        }
        

    private void button4_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            if (Weightage.Text == "")
            {
                MessageBox.Show("Please enter total weightage");
                Weightage.Focus();
            }
        }

        private void Marks_TextChanged(object sender, EventArgs e)
        {
            if (Marks.Text == "")
            {
                MessageBox.Show("Please enter Total Marks");
                Marks.Focus();
            }
        }

        private void Names_TextChanged(object sender, EventArgs e)
        {
            
                if (Names.Text == "")
                {
                    MessageBox.Show("Please enter your First Name");
                    Names.Focus();
                }
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Weightage_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            if (!Marks.Text.All(c => Char.IsNumber(c)))

            {
                MessageBox.Show("Please enter your Integer Value");

            }
            //Display error
            else { }
   }

        private void button2_Click_1(object sender, EventArgs e)
        {
            {

                SqlConnection conn = new SqlConnection(con);
                try
                {

                    conn.Open();
                    int selectrowindex = Grid.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = Grid.Rows[selectrowindex];
                    string id = Convert.ToString(selectedRow.Cells["Id"].Value);
                    //create a query for updating data in the database.
                    //string query = "Update Evaluation set  Name = '" + this.Names.Text + "' ,TotalMarks = '" +
                    //    this.Marks.Text + "' ,TotalWeightage= '" + this.Weightage.Text + "' where ID = '" +id";";
                    string query = "Update Evaluation SET Name='" + Names.Text + "',TotalMarks='" + Marks.Text
                        + "' , TotalWeightage='" +  Weightage.Text +"' WHERE ID=" + id;


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
                        query = "SELECT * FROM  Evaluation";
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
                            Grid.DataSource = dt;
                        }
                        //clearing the columns first
                        ////gvproject.Columns.Clear();
                        //DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                        //btn.Text = "Edit";
                        //btn.Name = "Action";
                        //btn.UseColumnTextForButtonValue = true;
                        //Grid.DataSource = dt;
                        ////add the button in the datagridview
                        //Grid.Columns.Add(btn);
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

        private void button4_Click_2(object sender, EventArgs e)
        {
            this.Hide();
            Fyp abc = new Fyp();
            abc.ShowDialog();
            this.Show();
        }
    }
    
}