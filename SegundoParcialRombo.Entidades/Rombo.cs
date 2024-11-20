using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoParcialRombo.Entidades
{
    public class Rombo
    {
        public int diagonalmayor { get; set; }
        public int diagonalmenor { get; set; }
        public double getlado()=> Math.Sqrt(Math.Pow((diagonalmayor / 2), 2) + Math.Pow((diagonalmenor / 2), 2));


        public double getperimetro() => 4*getlado();
        public double getarea() => diagonalmayor * diagonalmenor / 2;
        public contorno contornodelrombo { get; set; }
}
}
