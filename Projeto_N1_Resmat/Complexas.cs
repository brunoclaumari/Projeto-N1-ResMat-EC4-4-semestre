using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_N1_Resmat
{
    public partial class Complexas : Form
    {
        public Complexas()
        {
            InitializeComponent();
            rbComplexas_1.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (rbComplexas_1.Checked)
            {
                FTrel_8Nos JanelaComplex1 = new FTrel_8Nos();
                JanelaComplex1.ShowDialog();
            }

            else 
            {
                FTrel_7Nos JanelaComplex2 = new FTrel_7Nos();
                JanelaComplex2.ShowDialog();
            }
        }

        private void rbComplexas_1_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "Essa treliça tem 8 Nós com 13 barras";
        }

        private void rbComplexas_2_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "Essa treliça tem 7 Nós com 11 barras";
        }
    }
}
