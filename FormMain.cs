using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void comboBox_MainSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            string getvalue = comboBox_MainSelect.SelectedItem.ToString();
            if(getvalue=="Models")
            {
                FormModel formModel = new FormModel();
                formModel.Show();
            }
            else
                if(getvalue=="OSInterfaces")
            {
                Form1 form1 = new Form1();
                form1.Show();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label_main_Click(object sender, EventArgs e)
        {

        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }
    }
}
