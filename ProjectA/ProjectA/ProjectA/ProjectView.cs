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
    public partial class ProjectView : Form
    {
        String cmd = "Data Source=DESKTOP-T3GNBBF\\SQLEXPRESS;Initial Catalog=ProjectA;Integrated Security=True";
        private static DataTable DataSoure;
        public ProjectView()
        {
            InitializeComponent();
        }
        String con = "Data Source=DESKTOP-T3GNBBF\\SQLEXPRESS;Initial Catalog=ProjectA;Integrated Security=True";
        string query;
        int res;
        int userid;
        private void ProjectView_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(con);

            try
            {
                conn.Open();
                //create a query for retrieving data in the database.
                string query = "SELECT * FROM  Project";
                //initialize new Sql commands
                SqlCommand cmd = new SqlCommand();
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
                    gvproject.DataSource = dt;
                }
                //clearing the columns first
                //gvproject.Columns.Clear();
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                btn.Text = "Edit";
                btn.Name = "Action";
                btn.UseColumnTextForButtonValue = true;
                gvproject.DataSource = dt;
                //add the button in the datagridview
                gvproject.Columns.Add(btn);
                userid = 0;
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

            /////rida code
            //SqlConnection conn = new SqlConnection(con);
            //conn.Open();
            //String str = "SELECT * FROM  Project";
            //SqlCommand command = new SqlCommand(str, conn);
            //// Add the parameters if required
            ////SqlDataReader reader = command.ExecuteReader();

            //DataTable table = new DataTable();
            //SqlDataAdapter adapt = new SqlDataAdapter();
            //adapt.SelectCommand = command;
            //adapt.Fill(table);

            //if (table.Rows.Count > 0)

            //{
            //    gvproject.DataSource = table;
            //}
            //conn.Close();

        }


        private void DataView_Load(object sender, EventArgs e)
        {

        }


        private void gvproject_MouseClick(object sender, MouseEventArgs e)
        {

        }
        private void gvproject_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (gvproject.CurrentCell.Value == "Edit")
            {
                userid = (Int32)(gvproject.CurrentRow.Cells[0].Value);
                txtTitle.Text = gvproject.CurrentRow.Cells[1].Value.ToString();
                txtDes.Text = gvproject.CurrentRow.Cells[2].Value.ToString();

            }


        }

        private void btnSave_Click(object sender, EventArgs e)

        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(cmd);
            conn.Open();
            SqlCommand command = new SqlCommand(cmd, conn);
            // Add the parameters if required

            string query = "INSERT INTO Project(Title, Description ) VALUES(@Title, @Description)";
            SqlCommand str = new SqlCommand(query, conn);
            // Add the parameters if required

            str.Parameters.Add(new SqlParameter("@Title", txtTitle.Text));
            str.Parameters.Add(new SqlParameter("@Description", txtDes.Text));

            int i = str.ExecuteNonQuery();
            if (MessageBox.Show("Do You want to save it", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MessageBox.Show("Student is Saved");
            }
            else
            {
                MessageBox.Show("Student not saved", "Save Again", MessageBoxButtons.OK, MessageBoxIcon.Information);

                conn.Close();
            } 
            if (i != 0)
            {
                MessageBox.Show(i + "Project Details Saved");
            }


            ProjectView query1 = new ProjectView();
            query1.ShowDialog();
            this.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection(con);
            try
            {

                conn.Open();
                int selectrowindex = gvproject.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = gvproject.Rows[selectrowindex];
                string id = Convert.ToString(selectedRow.Cells["Id"].Value);
                //create a query for updating data in the database.
                query = "Update Project SET Description='" + txtDes.Text + "', Title='" + txtTitle.Text +
                "' WHERE ID=" + id;

                //initialize new Sql commands
                SqlCommand cmd = new SqlCommand();
                //hold the data to be executed.
                cmd.Connection = conn;
                cmd.CommandText = query;
                //execute the data
                res = cmd.ExecuteNonQuery();
                //checking the result of an executed command

                MessageBox.Show("User has been updated in the database.");


                // SqlConnection conn = new SqlConnection(con);

                try
                {
                    //     conn.Open();
                    //create a query for retrieving data in the database.
                    string query = "SELECT * FROM  Project";
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
                        gvproject.DataSource = dt;
                    }
                   
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

        private void button3_Click(object sender, EventArgs e)
        {
            {

                String con = "Data Source=DESKTOP-T3GNBBF\\SQLEXPRESS;Initial Catalog=ProjectA;Integrated Security=True";
                SqlConnection conn = new SqlConnection(con);
                conn.Open();
                string sql = "DELETE FROM Project WHERE Id = @ID";
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.Add(new SqlParameter("@Id", textBox1.Text));
                command.ExecuteNonQuery();
                gvproject.DataSource = null;
                DataView_Load(sender, e);
                this.Hide();
                ProjectView abc = new ProjectView();
                abc.ShowDialog();
                this.Show();

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Fyp abc = new Fyp();
            abc.ShowDialog();
            this.Show();
        }

        private void gvproject_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
    
}