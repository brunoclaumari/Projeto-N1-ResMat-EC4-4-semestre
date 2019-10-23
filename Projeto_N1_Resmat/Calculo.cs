using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_N1_Resmat
{
    public class Calculo
    {
        double fatorDeTransf = (Math.PI / 180);
        public double CalculaAngulo(double cOposto, double cAdjacente)
        {
            double angulo;
            //angulo = Math.Atan2(cOposto, cAdjacente) / 0.01745;
            angulo = (Math.Atan2(cOposto, cAdjacente)) / fatorDeTransf;
            return Math.Round(angulo, 6);
        }

        public double Cosseno(double angulo)
        {
            double cos = (Math.Cos(angulo * fatorDeTransf));
            return Math.Round(cos, 5);
        }
        public double Seno(double angulo)
        {
            double sen = (Math.Sin(angulo * fatorDeTransf));
            return Math.Round(sen, 5);
        }


        //  public double[] vetor = { 1,0,0,-0.664,-1,0,0,0,
        //                     0,-1,1,0.747,0,0,0,0,
        //                     0,0,0,0,1,0.8,0,0,
        //                     0,0,0,0,0,0.6,0,-1,
        //                     0,0,0,0.664,0,-0.8,0.8,0,
        //                     0,0,0,-0.747,0,-0.6,0.6,0,
        //                     0,0,0,0,0,0,-0.8,0,
        //                     0,0,-1,0,0,0,-0.6,0,
        //};
        //public double[] vetor { get; set; }
        //public double[] vetForcas { get; set; }

        public int Ordem { get; set; }


        public double[,] matPrincipal { get; set; }
        public double[,] matIdent { get; set; }
        public double[,] matrizForcas { get; set; }
        public string[,] matrizDescForca { get; set; }
        public double[,] MatrizInversa { get; set; }



        public double[] vetor;
        public double[] vetForcas;
        public string[] vetDescForcas;
        //const int MAX = 8;

        //double[,] matPrincipal = new double[MAX, MAX];
        //double[,] matIdent = new double[MAX, MAX];
        //double[,] matrizForcas = new double[MAX, 1];
        //string[,] matrizDescForca = new string[MAX, 1];
        //double[,] MatrizInversa = new double[MAX, MAX];

        public void CriaMatriz2(double[] vetorForcas,
            double[] vetor,
            double[,] principal, double[,] ident, double[,] matForcas
            //,string[,] matDescForca
            )
        {
            int j = 0;
            int ordem = Ordem;


            for (int linha = 0; linha < ordem; linha++)
            {
                for (int coluna = 0; coluna < ordem; coluna++)
                {
                    principal[linha, coluna] = (vetor[j]);
                    j++;
                    if (linha == coluna)
                        ident[linha, coluna] = 1;
                    else
                        ident[linha, coluna] = 0;
                }
                matrizForcas[linha, 0] = vetorForcas[linha];
            }
        }

        public double[,] CopiaMatriz(double[,] principalMat)
        {
            int ordem = Convert.ToInt32(Math.Sqrt(principalMat.Length));
            double[,] Matrix = new double[ordem, ordem];

            for (int linha = 0; linha < ordem; linha++)
            {
                for (int coluna = 0; coluna < ordem; coluna++)
                {
                    Matrix[linha, coluna] = principalMat[linha, coluna];
                }
            }
            return Matrix;
        }
        public void TrocaLinha(double[,] matrizRef, double[,] mIdentRef,
            double[,] matColunaRef, string[,] matrizNomeForca,
            int ordem, int linhaParaTroca, int colunaAtual)
        {
            double[] vetAux = new double[ordem];
            double[] vetIdentAux = new double[ordem];
            double vetColunaResult = 0;

            int posNulo = 0;
            int posNaoNulo = 0;
            for (int r = 0; r < ordem; r++)
            {
                vetAux[r] = matrizRef[linhaParaTroca, r];
                vetIdentAux[r] = mIdentRef[linhaParaTroca, r];
                vetColunaResult = matColunaRef[linhaParaTroca, 0];

                posNulo = linhaParaTroca;
            }
            for (int k = linhaParaTroca + 1; k < ordem; k++)
            {
                if (matrizRef[k, colunaAtual] != 0)
                {
                    posNaoNulo = k;
                    for (int m = 0; m < ordem; m++)
                    {
                        matrizRef[posNulo, m] = matrizRef[posNaoNulo, m];
                        matrizRef[posNaoNulo, m] = vetAux[m];
                        mIdentRef[posNulo, m] = mIdentRef[posNaoNulo, m];
                        mIdentRef[posNaoNulo, m] = vetIdentAux[m];

                    }
                    matColunaRef[posNulo, 0] = matColunaRef[posNaoNulo, 0];
                    matColunaRef[posNaoNulo, 0] = vetColunaResult;
                    break;
                }

            }
        }
        public double[,] CriaInversa(double[,] orig, double[,] ident,
            double[,] matColForcas, string[,] matDescricForca)
        {
            int ordemMat = Convert.ToInt32(Math.Sqrt(orig.Length));
            double[,] OrigTeste = CopiaMatriz(orig);
            double[,] IdentTeste = CopiaMatriz(ident);

            int linha = 0;
            int coluna = 0;

            double pivo;
            int posSubtrac = 0;

            for (coluna = 0; coluna < ordemMat; coluna++)
            {
                posSubtrac = coluna;
                for (linha = posSubtrac; linha < ordemMat; linha++)
                {
                    if (linha == coluna)
                    {

                        if (OrigTeste[linha, coluna] != 0)
                        {
                            int n = 0;
                            pivo = OrigTeste[linha, coluna];
                            do
                            {
                                OrigTeste[linha, n] = OrigTeste[linha, n] * (1 / pivo);
                                IdentTeste[linha, n] = IdentTeste[linha, n] * (1 / pivo);
                                n++;
                            }
                            while (n < ordemMat);
                            matColForcas[linha, 0] = matColForcas[linha, 0] * (1 / pivo);
                        }
                        else
                        {
                            TrocaLinha(OrigTeste, IdentTeste, matrizForcas, matrizDescForca, ordemMat, linha, coluna);

                            posSubtrac = linha--;
                        }
                    }
                    else
                    {
                        pivo = OrigTeste[linha, coluna];
                        for (int n = 0; n < ordemMat; n++)
                        {
                            OrigTeste[linha, n] = OrigTeste[linha, n] - ((OrigTeste[posSubtrac, n]) * pivo);
                            IdentTeste[linha, n] = IdentTeste[linha, n] - ((IdentTeste[posSubtrac, n]) * pivo);
                        }
                        matColForcas[linha, 0] = matColForcas[linha, 0] - ((matColForcas[posSubtrac, 0]) * pivo);
                    }
                }
            }

            for (coluna = ordemMat - 1; coluna > 0; coluna--)
            {
                posSubtrac = coluna;
                linha = coluna - 1;
                do
                {
                    pivo = OrigTeste[linha, posSubtrac];
                    for (int n = ordemMat - 1; n >= 0; n--)
                    {
                        OrigTeste[linha, n] = OrigTeste[linha, n] - ((OrigTeste[posSubtrac, n]) * pivo);
                        IdentTeste[linha, n] = IdentTeste[linha, n] - ((IdentTeste[posSubtrac, n]) * pivo);
                    }
                    matColForcas[linha, 0] = matColForcas[linha, 0] - ((matColForcas[posSubtrac, 0]) * pivo);
                    linha--;
                }
                while (linha >= 0);
            }
            matPrincipal = CopiaMatriz(OrigTeste);
            matIdent = CopiaMatriz(IdentTeste);


            return IdentTeste;
        }



        //public void btnMostrarMatriz_Click_1(object sender, EventArgs e)
        //{
        //    CriaMatriz2(vetForcas, vetDescForcas, vetor, matPrincipal,
        //        matIdent, matrizForcas, matrizDescForca);

        //    int ordemM = Convert.ToInt32(Math.Sqrt(vetor.Length)) - 1;
        //    MatrizInversa = CriaInversa(matPrincipal, matIdent, matrizForcas, matrizDescForca);
        //    for (int linha = 0; linha <= ordemM; linha++)
        //    {
        //        for (int coluna = 0; coluna <= ordemM; coluna++)
        //        {
        //            // txtMatrizNormal.Text += Math.Round(matPrincipal[linha, coluna], 3).ToString() + "  ";
        //            // txtMatrizIdentidade.Text += Math.Round(matIdent[linha, coluna], 3).ToString() + "  ";
        //            // txtMatrizInversa.Text += Math.Round(MatrizInversa[linha, coluna], 3).ToString() + "  ";
        //        }
        //        //txtResultado.Text += matrizDescForca[linha, 0] + ": " + Math.Round(matrizForcas[linha, 0], 3);
        //        //txtMatrizNormal.Text += Environment.NewLine;
        //        //txtMatrizIdentidade.Text += Environment.NewLine;
        //        //txtMatrizInversa.Text += Environment.NewLine;
        //        //txtResultado.Text += Environment.NewLine;
        //    }
        //}
    }


}
