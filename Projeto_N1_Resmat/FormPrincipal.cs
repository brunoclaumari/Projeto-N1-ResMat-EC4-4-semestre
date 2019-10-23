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
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void btnEscolhaModelo_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                Simples TelaSimples = new Simples();
                TelaSimples.Top = this.Top;
                TelaSimples.Left = this.Left;
                TelaSimples.ShowDialog();
            }

            else if (comboBox1.SelectedIndex == 1)
            {
                Media TelaMedia = new Media();
                TelaMedia.Top = this.Top;
                TelaMedia.Left = this.Left;
                TelaMedia.ShowDialog();
               
            }

            else if (comboBox1.SelectedIndex == 2)  
            {
                Complexas TelaComplexas = new Complexas();
                TelaComplexas.Top = this.Top;
                TelaComplexas.Left = this.Left;
                TelaComplexas.ShowDialog();
            }

            else
            {
                MessageBox.Show("Selecione uma das opções para começar");
                return;
          
            }




        }
    }
}
