using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectA
{
    public partial class ProjectList : Form
    {
        String cmd = "Data Source=DESKTOP-T3GNBBF\\SQLEXPRESS;Initial Catalog=ProjectA;Integrated Security=True";
        private iTextSharp.text.Font headerfont;
        private readonly int k;

        public ProjectList()
        {
            InitializeComponent();
        }

        private void ProjectList_Load(object sender, EventArgs e)
        {
            object con = null;
            SqlConnection conn = new SqlConnection(cmd);
            conn.Open();
            String str = "SELECT Evaluation.Id, Evaluation.TotalMarks, Evaluation.Name, Evaluation.TotalWeightage from Evaluation";
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
                        for (int k = 0; k < cell2; k++)
                        if (dataGridView1.Rows[1].Cells[k].Value == null)
                        {
                            dataGridView1.Rows[i].Cells[k].Value = "null";
                        }
                    pdfTable.AddCell(dataGridView1.Rows[i].Cells[k].Value.ToString());
                    this.dataGridView1.Columns[1].Width = 150;

                }

              

                //Adding DataRow
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
                using (FileStream stream = new FileStream(folderPath + "DataGridViewExport.pdf", FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                    PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    pdfDoc.Add(pdfTable);
                    pdfDoc.Close();
                    stream.Close();
                }
            }
        }
    }
}
