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
    public partial class Media : Form
    {
        public Media()
        {
            InitializeComponent();
            rbMedia_1.Checked = true;
            label1.Text = "Essa treliça tem 4 nós e 5 barras";
        }

        private void Media_Load(object sender, EventArgs e)
        {

        }

        private void bt_Comecar_Medio_Click(object sender, EventArgs e)
        {
            if (rbMedia_1.Checked)
            {
                label1.Text = "Essa treliça tem 4 nós e 5 barras";
                FTrel_4Nos1 JanelaMedia1 = new FTrel_4Nos1();
                JanelaMedia1.ShowDialog();


            }

            else //Só pode ser rbMedia_2.Enabled
            {
                FTrel_5Nos JanelaMedia2 = new FTrel_5Nos();
                JanelaMedia2.ShowDialog();
            }
        }

        private void rbMedia_1_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "Essa treliça tem 4 nós e 5 barras";
        }

        private void rbMedia_2_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "Essa treliça tem 5 nós e 7 barras";
        }
    }
}
