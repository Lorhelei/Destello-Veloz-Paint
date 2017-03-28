using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lineas_de_Bresenhaimsd
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DibujarLinea();  
        }

        private void DibujarLinea()
        {
            int xi, yi, xf, yf;
            xi = yi = 0;
            xf = 0;
            yf = 0;
            int s1, s2, intercambio, x, y;
            float ei, ax, ay, temp;


            Graphics graphicsObj = CreateGraphics();
            Pen pluma = new Pen(Color.Red, 1);
            x = xi;
            y = yi;
            ax = Math.Abs(xf - xi);
            ay = Math.Abs(yf - yi);
            s1 = signo(xf - xi);
            s2 = signo(yf - yi);

            if (ay > ax)
            {
                temp = ax;
                ax = ay;
                ay = temp;
                intercambio = 1;
            }
            else
            {
                intercambio = 0;
            }

            ei = 2 * ay - ax;

            for (int m = 1; m < ax; m++)
            {
                int puntox, puntoy;
                puntox = 100 + x;
                puntoy = 150 - y;
                graphicsObj.DrawRectangle(pluma, puntox, puntoy, 1, 1);
                if (ei >= 0)
                {
                    if (intercambio == 1)
                    {
                        x = x + s1;
                    }
                    else
                    {
                        y = y + s2;
                    }

                    ei = ei - (s2 * ax);
                }

                if (intercambio == 1)
                {
                    y = y + s2;
                }
                else
                {
                    x = x + s1;
                }

                ei = ei + 2 * ay;
            }
        }

        int signo(int num)
        {
            int resultado = 0;
            if (num < 0)
            {
                resultado = -1;
            }

            if (num > 0)
            {
                resultado = 1;
            }

            if (num == 0)
                return resultado;

            return resultado;
        }
    }
}
