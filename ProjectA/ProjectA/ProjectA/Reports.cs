using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Globalization;
using System.IO;
using System.Data.SqlClient;

namespace ProjectA
{
    public partial class Reports : Form
    {
        private readonly int j;
        String cmd = "Data Source=DESKTOP-T3GNBBF\\SQLEXPRESS;Initial Catalog=ProjectA;Integrated Security=True";
        public Reports()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                //Creating iTextSharp Table from the DataTable data
                PdfPTable pdfTable = new PdfPTable(dataGridView1.ColumnCount);
                pdfTable.DefaultCell.Padding = 3;
                pdfTable.WidthPercentage = 30;
                pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfTable.DefaultCell.BorderWidth = 1;

                pdfTable.WidthPercentage = 90f;

                int[] firstTablecellWidth = { 20, 25, 25, 30 };
                pdfTable.SetWidths(firstTablecellWidth);

                //Adding Header row
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                    cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                    pdfTable.AddCell(cell);
                }

                //Adding DataRow
                int row = dataGridView1.Rows.Count;
                int cell2 = dataGridView1.Rows[1].Cells.Count;
                for (int i = 0; i < row - 1; i++)

                {

                    for (int j = 0; j < cell2; j++)
                    {
                        if (dataGridView1.Rows[i].Cells[j].Value == null)
                        {
                            dataGridView1.Rows[i].Cells[j].Value = "null";
                        }
                        pdfTable.AddCell(dataGridView1.Rows[i].Cells[j].Value.ToString());
                        this.dataGridView1.Columns[1].Width = 150;
                    }

                }
                
                //foreach (DataGridViewRow row in dataGridView1.Rows)
                //{
                //    foreach (DataGridViewCell cell in row.Cells)
                //    {
                //        pdfTable.AddCell(cell.Value.ToString());
                //    }
                //}


                //Exporting to PDF
                string folderPath = @"e:\";
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                using (FileStream stream = new FileStream(folderPath + "DataGridViewExport1.pdf", FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                    PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    pdfDoc.Add(pdfTable);
                    pdfDoc.Close();
                    stream.Close();
                }
                MessageBox.Show("Report is generated succesfully!!");

            }

            }

        private void Reports_Load(object sender, EventArgs e)
        {
            object con = null;
            SqlConnection conn = new SqlConnection(cmd);
            conn.Open();
            //String str = "SELECT StudentId, TotalMarks, ProjectId from GroupStudent join person ON person.Id = GroupStudent.StudentId join GroupEvaluation ON GroupEvaluation.GroupId = GroupStudent.GroupId Join Evaluation ON Evaluation.Id = GroupEvaluation.EvaluationId JOIN GroupProject ON GroupProject.ProjectId = GroupEvaluation.GroupId";
            String str = "SELECT *From Evaluation";
            // String str = "SELECT Title AS 'Project Title', FirstName + ' ' + LastName AS 'Student Name' , RegistrationNo AS 'Registration No', Evaluation.Name AS 'Evaluation Name', Evaluation.TotalMarks AS 'Total Marks', GroupEvaluation.ObtainedMarks AS 'Obtained Marks', TotalWeightage AS 'Total Weightage'  FROM (((((GroupEvaluation JOIN Evaluation ON EvaluationId = Id) JOIN GroupStudent ON GroupStudent.GroupId = GroupEvaluation.GroupId) JOIN Student ON StudentId = Student.Id ) JOIN Person ON Person.Id = Student.Id) JOIN GroupProject ON GroupProject.GroupId = GroupStudent.GroupId) JOIN Project ON Project.Id = GroupProject.ProjectId where EvaluationDate > GroupStudent.AssignmentDate";
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
        }
    }
}
