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
    public partial class Simples : Form
    {
        public Simples()
        {
            InitializeComponent();
            rbSimples_1.Checked = Enabled;
        }

        private void Simples_Load(object sender, EventArgs e)
        {

        }
       
        private void bt_Comecar_Simples_Click(object sender, EventArgs e)
        {
            if (rbSimples_1.Checked)
            {
                FTrel_4Nos2 JanelaSimples1 = new FTrel_4Nos2();
                JanelaSimples1.ShowDialog();

            }

            else //Só pode ser rbSimples_2.Enabled
            {
                FTrel_3Nos JanelaSimples2 = new FTrel_3Nos();
                JanelaSimples2.ShowDialog();
            }
        }

        private void rbSimples_1_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "Essa treliça tem 4 Nós com 5 barras";
        }

        private void rbSimples_2_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "Essa treliça tem 3 Nós com 3 barras";
        }
    }
}
