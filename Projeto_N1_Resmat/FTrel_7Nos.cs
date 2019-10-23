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
    public partial class FTrel_7Nos : Form
    {
        private void LimpaContainer(Control objeto)
        {
            if (objeto is TextBox)
                objeto.Text = "";

            for (int n = 0; n < objeto.Controls.Count; n++)
            {

                if (!(objeto.Name is "groupBox3" || objeto.Name is "groupBox2"))
                    LimpaContainer(objeto.Controls[n]);

                else
                    ZeraContainer((objeto.Controls[n]));
            }
        }


        private void ZeraContainer(Control objeto)
        {
            if (objeto is TextBox)
            {
                objeto.Text = "0";
            }

            if (objeto is GroupBox)
                for (int n = 0; n < objeto.Controls.Count; n++)
                {
                    (objeto.Controls[n] as CheckBox).Checked = false;
                }
        }

        private void DesabilitaCheckBox(Control objeto)
        {
            if (objeto is CheckBox)
            {
                objeto.Enabled = false;
            }
        }
        public FTrel_7Nos()
        {
            InitializeComponent();
            txtFAV.Text = "0";
            txtFAH.Text = "0";
            txtFBV.Text = "0";
            txtFBH.Text = "0";
            txtFCV.Text = "0";
            txtFCH.Text = "0";
            txtFDV.Text = "0";
            txtFDH.Text = "0";
            txtFEV.Text = "0";
            txtFEH.Text = "0";
            txtFFV.Text = "0";
            txtFFH.Text = "0";
            txtFGV.Text = "0";
            txtFGH.Text = "0";

            // chamanda da funcao
            DesabilitaGroupBox(groupBox4);
        }
        // funcao para desabilitar txtbox no groupbox
        private void DesabilitaGroupBox(GroupBox gb)
        {
            foreach (Control ctrl in gb.Controls)
            {
                if (ctrl is TextBox)
                {
                    //TextBox t = ctrl as TextBox;
                    ctrl.Enabled = false;
                }
            }
        }

        const int MAX = 14;

        //metodo que muda o sinal do sentido da força
        public string MudaSinalTexto(string texto, CheckBox cBoxEnv)
        {
            if (texto.Substring(0, 1) == "-" && cBoxEnv.Checked)
                return texto;

            if ((cBoxEnv.Checked && texto != "0"))
                texto = "-" + texto;
            else
                texto = texto.Replace("-", "");
            return texto;
        }
        //valida valores double
        private double ValidaDouble(TextBox textoForcas)
        {
            if (!double.TryParse(textoForcas.Text, out double valorConvert))
            {
                eProvMarcaErro.SetError(textoForcas, "Digite apenas números!!!!");
                textoForcas.Focus();
                temErro = true;
            }
            return valorConvert;
        }
        //metodo que define tração ou compressão
        private void TracaoOuCompressao(double valor, TextBox txtBOX)
        {
            valor = Math.Round(valor, 2);
            if (valor < 0)
            {
                valor = valor * -1;
                txtBOX.Text = valor.ToString() + " Tr.";
            }
            else if (valor > 0)
                txtBOX.Text = valor.ToString() + " Com.";
            else
                txtBOX.Text = valor.ToString();
        }

        //metodo que define sentido da forca de apoio
        private string ApoioPCimaOuPBaixo(double valor, string fApoio, string tipoReacao)
        {
            valor = Math.Round(valor, 2);
            if (tipoReacao[0].ToString().ToUpper() == "V")
            {
                if (valor < 0)
                {
                    valor = valor * -1;
                    fApoio = valor.ToString() + " P/ Baixo";
                }
                else
                    fApoio = valor.ToString() + " P/ Cima";
            }
            else
            {
                if (valor < 0)
                {
                    valor = valor * -1;
                    fApoio = valor.ToString() + " P/ Esquerda";
                }
                else
                    fApoio = valor.ToString() + " P/ Direita";
            }
            if (valor == 0)
                fApoio = valor.ToString();

            return fApoio;
        }

        public double[,] matPri;
        public double[,] matId;
        public double[,] matrizF;
        public string[,] matrizDes;
        public double[,] MatrizIn;
        public double[] vetorGrandao;

        //metodo para guardar coordenadas e angulos das barras
        private void InstanciaBarras(string barra, List<Nos> TestListNo)
        {
            //InstanciaBarras vai receber o nome da barra e a lista com todos os Nós e suas coordenadas
            Barras adicBarras = new Barras();
            adicBarras.DescBarra = barra;
            //Exemplo se barra = AB ptIni = A e ptFim = B
            string ptIni = adicBarras.DescBarra.Substring(0, 1);
            string ptFim = adicBarras.DescBarra.Substring(1, 1);
            foreach (Nos bNo in TestListNo)
            {//Para cada Nó na lista de Nós verifica se a barra pertece ao Nó
                if (bNo.OrdemDoNo.ToString() == ptIni)
                {//Exemplo se o nó A for igual a ptIni (no caso se a barra for AB vai ser positivo)
                 //Caso positivo para o exemplo adicionar as coordenadas do nó A para a barra AB
                    adicBarras.Xinic = bNo.coordX;
                    adicBarras.Yinic = bNo.coordY;
                    bNo.ListaDeBarras.Add(adicBarras);
                }
                if (bNo.OrdemDoNo.ToString() == ptFim)
                {//Exemplo se o nó A for igual a ptFim (no caso se a barra for AB vai ser positivo)
                 //Caso positivo para o exemplo adicionar as coordenadas do nó B para a barra AB
                    adicBarras.Xfinal = bNo.coordX;
                    adicBarras.Yfinal = bNo.coordY;
                    bNo.ListaDeBarras.Add(adicBarras);
                }
            }//No final do foreach vamos ter todas as barras com seus pontos suas coordenadas
        }
        //metodo para ordenar soma das forcas horizontais
        private void OrdenaSomasHoriz(Calculo calcu, int noAtualDaVez,
            string[] vNomeDasForcas, double[] vetorSomandoF, string nomeNo)
        {
            double angBr;
            for (int j = 3; j < MAX; j++)
            {
                // vNomeDasForcas = Recebe o vetor com o nome dos pontos para serem colocados na Matriz
                string forcaAtual = vNomeDasForcas[j];
                //Se Barra = AB ptoIni = A e proFinal = B
                string ptoIni = forcaAtual[0].ToString();
                string ptoFinal = forcaAtual[1].ToString();
                foreach (Barras barr in listaDeNos[noAtualDaVez].ListaDeBarras)
                {//Para cada Barra da lista de Barras do Nó atual vai comparar se existe no Nó
                    if (barr.DescBarra == forcaAtual)
                    {
                        angBr = barr.AngInclin();
                        vetorSomandoF[j] = calcu.Cosseno(angBr);
                        if (ptoFinal == nomeNo)//ponto final igual ao no
                        {
                            vetorSomandoF[j] = -vetorSomandoF[j];
                        }
                        noContemBarra = true;
                        break;
                    }
                    else
                    {
                        noContemBarra = false;//se a barra não existir no nó o valor será "0".
                        vetorSomandoF[j] = 0;
                    }
                }

            }
        }
        //metodo para ordenar soma das forcas verticais
        private void OrdenaSomasVert(Calculo calcu, int noAtualDaVez,
            string[] vNomeDasForcas, double[] vetorSomandoF, string nomeNo)
        {
            for (int j = 3; j < MAX; j++)
            {
                string forcaAtual = vNomeDasForcas[j];
                string ptoIni = forcaAtual[0].ToString();
                string ptoFinal = forcaAtual[1].ToString();
                foreach (Barras barr in listaDeNos[noAtualDaVez].ListaDeBarras)
                {
                    if (barr.DescBarra == forcaAtual)
                    {
                        double angBr = barr.AngInclin();
                        vetorSomandoF[j] = calcu.Seno(angBr);
                        if (ptoFinal == nomeNo)//ponto final igual ao no
                        {
                            vetorSomandoF[j] = -vetorSomandoF[j];
                        }
                        noContemBarra = true;
                        break;
                    }
                    else
                    {
                        noContemBarra = false;
                        vetorSomandoF[j] = 0;
                    }
                }
            }
        }

        public List<Nos> listaDeNos;

        string noAtual = "";
        public bool noContemBarra = false;
        public bool temErro = false;

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            eProvMarcaErro.Clear();
            txtResultado.Clear();
            listaDeNos = new List<Nos>();
            List<double[]> listaSomaDeForcas = new List<double[]>();
            double[] forcaNosPontos = new double[MAX];


            matPri = new double[MAX, MAX];
            matId = new double[MAX, MAX];
            matrizF = new double[MAX, 1];
            matrizDes = new string[MAX, 1];
            MatrizIn = new double[MAX, MAX];
            vetorGrandao = new double[MAX * MAX];
            Calculo c = new Calculo();

            try
            {
                //MATRIZES PASSADAS PARA A CLASSE               
                c.matPrincipal = matPri;
                c.matIdent = matId;
                c.matrizForcas = matrizF;
                c.matrizDescForca = matrizDes;
                c.MatrizInversa = MatrizIn;

                //Ponto A                               

                forcaNosPontos[0] = ValidaDouble(txtFAH);
                forcaNosPontos[1] = ValidaDouble(txtFAV);

                //Ponto B                
                forcaNosPontos[2] = ValidaDouble(txtFBH);
                forcaNosPontos[3] = ValidaDouble(txtFBV);

                //Ponto C
                forcaNosPontos[4] = ValidaDouble(txtFCH);
                forcaNosPontos[5] = ValidaDouble(txtFCV);

                //Ponto D                
                forcaNosPontos[6] = ValidaDouble(txtFDH);
                forcaNosPontos[7] = ValidaDouble(txtFDV);

                //Ponto E                
                forcaNosPontos[8] = ValidaDouble(txtFEH);
                forcaNosPontos[9] = ValidaDouble(txtFEV);

                //Ponto F              
                forcaNosPontos[10] = ValidaDouble(txtFFH);
                forcaNosPontos[11] = ValidaDouble(txtFFV);

                //Ponto G            
                forcaNosPontos[12] = ValidaDouble(txtFGH);
                forcaNosPontos[13] = ValidaDouble(txtFGV);

                c.vetForcas = forcaNosPontos;

                double ang1 = 0;
                //double ang2 = 0;

                double bMaior = 0;
                double bMenor = 0;
                double pontaFora = 0;
                double altura = 0;
                double cosAng1 = 0;
                double senAng1 = 0;
                double bTri = 0;
                //double senAng2 = 0;
                int noVez = 0;


                string[] vetorNomeForcas = { "HA", "VA", "VC", "AB", "AE", "EB", "EF", "BF",
                                             "BC", "FC", "FG","CG","CD","GD"};

                //double pontas = 0;
                if (double.Parse(txtAltura.Text) <= 0 || double.Parse(txtAD.Text) <= 0)
                {
                    MessageBox.Show("A distância AD e a altura devem ser maior que 0");
                    return;
                }

                //else if (double.Parse(txtAltura.Text) < double.Parse(txtAD.Text))
                else
                {
                    //double COposto = double.Parse(txtAltura.Text);
                    //double CAdjacente = (double.Parse(txtAB.Text) - double.Parse(txtCD.Text)) / 2;
                    //distAB = Convert.ToDouble(txtAB.Text);
                    bMaior = ValidaDouble(txtAD);
                    bMenor = (bMaior / 3) * 2;
                    bTri = bMaior / 3;
                    pontaFora = (bMaior - bMenor) / 2;
                    altura = ValidaDouble(txtAltura);

                    //angulo ang1 é o angulo DÂB e BCE
                    ang1 = c.CalculaAngulo(altura, pontaFora);
                    //angulo ang2 é o angulo DBA e EBC

                    if (ang1 >= 90)
                    {
                        MessageBox.Show("Não é possível calcular com angulo maior ou igual que 90");
                        return;
                    }
                    //ang2 = c.CalculaAngulo(altura, pontaDentro);


                    cosAng1 = c.Cosseno(ang1);
                    senAng1 = c.Seno(ang1);

                    Nos no = new Nos();
                    no.OrdemDoNo = 'A';
                    no.coordX = 0;
                    no.coordY = 0;
                    listaDeNos.Add(no);

                    no = new Nos();
                    no.OrdemDoNo = 'B';
                    no.coordX = bTri; ;
                    no.coordY = 0;
                    listaDeNos.Add(no);

                    no = new Nos();
                    no.OrdemDoNo = 'C';
                    no.coordX = bTri * 2;
                    no.coordY = 0;
                    listaDeNos.Add(no);

                    no = new Nos();
                    no.OrdemDoNo = 'D';
                    no.coordX = bMaior;
                    no.coordY = 0;
                    listaDeNos.Add(no);

                    no = new Nos();
                    no.OrdemDoNo = 'E';
                    no.coordX = pontaFora;
                    no.coordY = altura;
                    listaDeNos.Add(no);

                    no = new Nos();
                    no.OrdemDoNo = 'F';
                    no.coordX = pontaFora + bTri;
                    no.coordY = altura;
                    listaDeNos.Add(no);

                    no = new Nos();
                    no.OrdemDoNo = 'G';
                    no.coordX = bMaior - pontaFora;
                    no.coordY = altura;
                    listaDeNos.Add(no);

                    InstanciaBarras("AB", listaDeNos);
                    InstanciaBarras("AE", listaDeNos);
                    InstanciaBarras("EB", listaDeNos);
                    InstanciaBarras("EF", listaDeNos);
                    InstanciaBarras("BF", listaDeNos);
                    InstanciaBarras("BC", listaDeNos);
                    InstanciaBarras("FC", listaDeNos);
                    InstanciaBarras("FG", listaDeNos);
                    InstanciaBarras("CG", listaDeNos);
                    InstanciaBarras("CD", listaDeNos);
                    InstanciaBarras("GD", listaDeNos);


                    #region ORDENA OS VALORES DO SENTIDO DAS FORÇAS
                    for (int i = 0; i < MAX; i++)
                    {

                        double[] vetorSomaTeste = new double[MAX];
                        if (i == 0 || i == 1)
                        {
                            noAtual = "A";
                            noVez = 0;
                            if ((i % 2) == 0)
                            {
                                vetorSomaTeste[0] = -1;
                                vetorSomaTeste[1] = 0;
                                vetorSomaTeste[2] = 0;
                                OrdenaSomasHoriz(c, noVez, vetorNomeForcas, vetorSomaTeste, noAtual);
                            }
                            else
                            {
                                vetorSomaTeste[0] = 0;
                                vetorSomaTeste[1] = -1;
                                vetorSomaTeste[2] = 0;
                                OrdenaSomasVert(c, noVez, vetorNomeForcas, vetorSomaTeste, noAtual);
                            }
                        }

                        if (i == 2 || i == 3)
                        {
                            noAtual = "B";
                            noVez = 1;
                            if ((i % 2) == 0)
                            {
                                vetorSomaTeste[0] = 0;
                                vetorSomaTeste[1] = 0;
                                vetorSomaTeste[2] = 0;
                                OrdenaSomasHoriz(c, noVez, vetorNomeForcas, vetorSomaTeste, noAtual);

                            }
                            else
                            {
                                vetorSomaTeste[0] = 0;
                                vetorSomaTeste[1] = 0;
                                vetorSomaTeste[2] = 0;
                                OrdenaSomasVert(c, noVez, vetorNomeForcas, vetorSomaTeste, noAtual);
                            }
                        }
                        if (i == 4 || i == 5)
                        {
                            noAtual = "C";
                            noVez = 2;
                            if ((i % 2) == 0)
                            {
                                vetorSomaTeste[0] = 0;
                                vetorSomaTeste[1] = 0;
                                vetorSomaTeste[2] = 0;
                                OrdenaSomasHoriz(c, noVez, vetorNomeForcas, vetorSomaTeste, noAtual);

                            }
                            else
                            {
                                vetorSomaTeste[0] = 0;
                                vetorSomaTeste[1] = 0;
                                vetorSomaTeste[2] = 0;
                                OrdenaSomasVert(c, noVez, vetorNomeForcas, vetorSomaTeste, noAtual);

                            }
                        }
                        if (i == 6 || i == 7)
                        {
                            noAtual = "D";
                            noVez = 3;
                            if ((i % 2) == 0)
                            {
                                vetorSomaTeste[0] = 0;
                                vetorSomaTeste[1] = 0;
                                vetorSomaTeste[2] = 0;
                                OrdenaSomasHoriz(c, noVez, vetorNomeForcas, vetorSomaTeste, noAtual);

                            }
                            else
                            {
                                vetorSomaTeste[0] = 0;
                                vetorSomaTeste[1] = 0;
                                vetorSomaTeste[2] = -1;
                                OrdenaSomasVert(c, noVez, vetorNomeForcas, vetorSomaTeste, noAtual);

                            }
                        }
                        if (i == 8 || i == 9)
                        {
                            noAtual = "E";
                            noVez = 4;
                            if ((i % 2) == 0)
                            {
                                vetorSomaTeste[0] = 0;
                                vetorSomaTeste[1] = 0;
                                vetorSomaTeste[2] = 0;
                                OrdenaSomasHoriz(c, noVez, vetorNomeForcas, vetorSomaTeste, noAtual);

                            }
                            else
                            {
                                vetorSomaTeste[0] = 0;
                                vetorSomaTeste[1] = 0;
                                vetorSomaTeste[2] = 0;
                                OrdenaSomasVert(c, noVez, vetorNomeForcas, vetorSomaTeste, noAtual);

                            }
                        }

                        if (i == 10 || i == 11)
                        {
                            noAtual = "F";
                            noVez = 5;
                            if ((i % 2) == 0)
                            {
                                vetorSomaTeste[0] = 0;
                                vetorSomaTeste[1] = 0;
                                vetorSomaTeste[2] = 0;
                                OrdenaSomasHoriz(c, noVez, vetorNomeForcas, vetorSomaTeste, noAtual);

                            }
                            else
                            {
                                vetorSomaTeste[0] = 0;
                                vetorSomaTeste[1] = 0;
                                vetorSomaTeste[2] = 0;
                                OrdenaSomasVert(c, noVez, vetorNomeForcas, vetorSomaTeste, noAtual);

                            }
                        }

                        if (i == 12 || i == 13)
                        {
                            noAtual = "G";
                            noVez = 6;
                            if ((i % 2) == 0)
                            {
                                vetorSomaTeste[0] = 0;
                                vetorSomaTeste[1] = 0;
                                vetorSomaTeste[2] = 0;
                                OrdenaSomasHoriz(c, noVez, vetorNomeForcas, vetorSomaTeste, noAtual);

                            }
                            else
                            {
                                vetorSomaTeste[0] = 0;
                                vetorSomaTeste[1] = 0;
                                vetorSomaTeste[2] = 0;
                                OrdenaSomasVert(c, noVez, vetorNomeForcas, vetorSomaTeste, noAtual);

                            }
                        }
                        listaSomaDeForcas.Add(vetorSomaTeste);
                        //DEPOIS DE PASSAR EM TODAS AS CONDIÇÕES 
                        //AQUI JÁ TEREMOS TODOS OS VALORES PRONTOS PARA SEREM PROCESSADOS NA MATRIZ
                    }
                    lblAng1.Text = lblAng1B.Text = ang1.ToString("F3") + "°";

                }
                #endregion
                //else if (double.Parse(txtAltura.Text) > double.Parse(txtAD.Text))
                //{
                //    MessageBox.Show("A altura deve ser menor que a Distância AC");
                //    return;
                //}
               

                int posV = 0;//marca posição do vetor 

                foreach (double[] vetor in listaSomaDeForcas)//for para vetor receber valores da lista
                {
                    int colAtual = 0;
                    while (colAtual < vetor.Length)
                    {
                        vetorGrandao[posV] = vetor[colAtual];
                        colAtual++;
                        posV++;
                    }
                }


                c.Ordem = MAX;//ordem da matriz
                c.vetForcas = forcaNosPontos;// vetor representa matriz coluna de forças externas da força da treliça
                c.vetDescForcas = vetorNomeForcas;//vetor do nome das Forças
                c.vetor = vetorGrandao;//vetor com todos os valores a ser preenchido na matriz

                //\//\//\//\//\//\//\//\//\//\//\//\//\//\/\/\/\/\/\///\///\/\///\///\///\///\///\//\/\/\///\

                ///////////////////////////////////////////////////////////////////////////////////////////////////////

                c.CriaMatriz2(c.vetForcas, c.vetor, c.matPrincipal,
                  c.matIdent, c.matrizForcas//, c.matrizDescForca
                  );

                int ordemM = Convert.ToInt32(Math.Sqrt(c.vetor.Length)) - 1;
                c.MatrizInversa = c.CriaInversa(c.matPrincipal, c.matIdent, c.matrizForcas, c.matrizDescForca);


                #region IMPRIME O RESULTADO NO FORM
                for (int linha = 0; linha < 3; linha++)
                {
                    string textoApoio = "";
                    //txtResultado.Text += c.vetDescForcas[linha] + ": " + Math.Round(c.matrizForcas[linha, 0], 3);
                    txtResultado.Text += c.vetDescForcas[linha] + " : " + ApoioPCimaOuPBaixo(c.matrizForcas[linha, 0], textoApoio, c.vetDescForcas[linha]);

                    txtResultado.Text += Environment.NewLine;
                }
                TracaoOuCompressao(c.matrizForcas[3, 0], txtForcaAB);
                TracaoOuCompressao(c.matrizForcas[4, 0], txtForcaAE);
                TracaoOuCompressao(c.matrizForcas[5, 0], txtForcaBE);
                TracaoOuCompressao(c.matrizForcas[6, 0], txtForcaEF);
                TracaoOuCompressao(c.matrizForcas[7, 0], txtForcaBF);
                TracaoOuCompressao(c.matrizForcas[8, 0], txtForcaBC);
                TracaoOuCompressao(c.matrizForcas[9, 0], txtForcaCF);
                TracaoOuCompressao(c.matrizForcas[10, 0], txtForcaFG);
                TracaoOuCompressao(c.matrizForcas[11, 0], txtForcaCG);
                TracaoOuCompressao(c.matrizForcas[12, 0], txtForcaCD);
                TracaoOuCompressao(c.matrizForcas[13, 0], txtForcaDG);

                if (temErro)
                    return;

            }
            #endregion

            catch (FormatException)
            {
                //MessageBox.Show("Não foi possivel converter!!Digite Novamente");
                MessageBox.Show("Não foi possivel calcular!" + Environment.NewLine +
                   "Todos os campos devem ser preenchidos.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
                return;
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimpaContainer(this);
        }

        private void cbAV_CheckedChanged(object sender, EventArgs e)
        {
            txtFAV.Text = MudaSinalTexto(txtFAV.Text, cbAV);
        }

        private void cbBV_CheckedChanged(object sender, EventArgs e)
        {
            txtFBV.Text = MudaSinalTexto(txtFBV.Text, cbBV);
        }

        private void cbCV_CheckedChanged(object sender, EventArgs e)
        {
            txtFCV.Text = MudaSinalTexto(txtFCV.Text, cbCV);
        }

        private void cbDV_CheckedChanged(object sender, EventArgs e)
        {
            txtFDV.Text = MudaSinalTexto(txtFDV.Text, cbDV);
        }

        private void cbEV_CheckedChanged(object sender, EventArgs e)
        {
            txtFEV.Text = MudaSinalTexto(txtFEV.Text, cbEV);
        }

        private void cbFV_CheckedChanged(object sender, EventArgs e)
        {
            txtFFV.Text = MudaSinalTexto(txtFFV.Text, cbFV);
        }

        private void cbGV_CheckedChanged(object sender, EventArgs e)
        {
            txtFGV.Text = MudaSinalTexto(txtFGV.Text, cbGV);
        }

        private void cbAH_CheckedChanged(object sender, EventArgs e)
        {
            txtFAH.Text = MudaSinalTexto(txtFAH.Text, cbAH);
        }

        private void cbBH_CheckedChanged(object sender, EventArgs e)
        {
            txtFBH.Text = MudaSinalTexto(txtFBH.Text, cbBH);
        }

        private void cbCH_CheckedChanged(object sender, EventArgs e)
        {
            txtFCH.Text = MudaSinalTexto(txtFCH.Text, cbCH);
        }

        private void cbDH_CheckedChanged(object sender, EventArgs e)
        {
            txtFDH.Text = MudaSinalTexto(txtFDH.Text, cbDH);
        }

        private void cbEH_CheckedChanged(object sender, EventArgs e)
        {
            txtFEH.Text = MudaSinalTexto(txtFEH.Text, cbEH);
        }

        private void cbFH_CheckedChanged(object sender, EventArgs e)
        {
            txtFFH.Text = MudaSinalTexto(txtFFH.Text, cbFH);
        }

        private void cbGH_CheckedChanged(object sender, EventArgs e)
        {
            txtFGH.Text = MudaSinalTexto(txtFGH.Text, cbGH);
        }



















    }
}
