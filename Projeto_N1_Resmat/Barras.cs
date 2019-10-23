using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_N1_Resmat
{
    public class Barras
    {
        public string DescBarra { get; set; }
        public double Xinic { get; set; }
        public double Yinic { get; set; }
        public double Xfinal { get; set; }
        public double Yfinal { get; set; }
        public double AngInclin()
        {
            Calculo calc = new Calculo();
            double ang = 0;
            if ((Xfinal - Xinic) == 0 && (Yfinal - Yinic) > 0)
                ang = 90;
            else if ((Xfinal - Xinic) == 0 && (Yfinal - Yinic) < 0)
                ang = 270;
            else
                ang = calc.CalculaAngulo((Yfinal - Yinic), (Xfinal - Xinic));
            return ang;
        }
    }
}
