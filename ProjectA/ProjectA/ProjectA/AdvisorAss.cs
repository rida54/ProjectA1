using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectA
{
    public partial class AdvisorAss : Form
    {
        public AdvisorAss()
        {
            InitializeComponent();
            Designation.Items.Add("Professor");
            Designation.Items.Add("Associate Professor");
            Designation.Items.Add("Assisstant Professor");
            Designation.Items.Add("Lecturer");
            Designation.Items.Add("Industry Professional");
            comboBox1.Items.Add("Main Advisor");
            comboBox1.Items.Add("Co - Advisror");
            comboBox1.Items.Add("Industry Advisor");

        }

        private void AdvisorAss_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Fyp abc = new Fyp();
            abc.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Fyp abc = new Fyp();
            abc.ShowDialog();
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
